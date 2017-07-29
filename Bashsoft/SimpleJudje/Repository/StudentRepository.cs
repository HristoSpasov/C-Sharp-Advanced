using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using SimpleJudje.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using SimpleJudje.DataStructures;

namespace SimpleJudje.Repository
{
    public class StudentRepository : IDatabase
    {
        private bool isDataInitialized;
        private readonly RepositoryFilter filter;
        private readonly RepositorySorter sorter;
        private Dictionary<string, ICourse> courses;
        private Dictionary<string, IStudent> students;

        public StudentRepository(RepositorySorter sorter, RepositoryFilter filter)
        {
            this.filter = filter;
            this.sorter = sorter;
        }

        public void LoadData(string fileName)
        {
            if (this.isDataInitialized)
            {
                // OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitialisedException);
                // return;
                throw new InvalidDataException(ExceptionMessages.DataAlreadyInitialisedException);
            }

            this.students = new Dictionary<string, IStudent>();
            this.courses = new Dictionary<string, ICourse>();
            this.isDataInitialized = true;
            this.ReadData(fileName);
        }

        public void UnloadData()
        {
            if (!this.isDataInitialized)
            {
                // OutputWriter.DisplayException(ExceptionMessages.DataNotInitialisedException);
                // return;
                throw new InvalidDataException(ExceptionMessages.DataNotInitialisedException);
            }

            this.students = null;
            this.courses = null;
            this.isDataInitialized = false;
        }

        public void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (this.CourseExists(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(p => p.Key, p => p.Value.MarksByCourseName[courseName]);

                this.filter.FilterAndTake(marks, givenFilter, studentsToTake.Value);
            }
        }

        public void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (this.CourseExists(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = this.courses[courseName].StudentsByName.Count;
                }

                Dictionary<string, double> marks = this.courses[courseName].StudentsByName
                    .ToDictionary(p => p.Key, p => p.Value.MarksByCourseName[courseName]);

                this.sorter.OrderAndTake(marks, comparison, studentsToTake.Value);
            }
        }

        private void ReadData(string fileName)
        {
            string path = SessionData.currentPath + "\\" + fileName;

            if (File.Exists(path))
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");

                // File exists
                string pattern = @"([A-Z][a-zA-Z#\++]*_[A-Z][a-z]{2}_\d{4})\s+([A-Za-z]+\d{2}_\d{2,4})\s([\s0-9]+)";
                Regex regex = new Regex(pattern);
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(allInputLines[line]) && regex.IsMatch(allInputLines[line]))
                        {
                            Match currMatch = regex.Match(allInputLines[line]);
                            string courseName = currMatch.Groups[1].Value;
                            string userName = currMatch.Groups[2].Value;
                            string scoresStr = currMatch.Groups[3].Value;

                            int[] scores = scoresStr.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                                .Select(int.Parse).ToArray();

                            if (scores.Any(x => x > 100 || x < 0))
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidScore);
                            }

                            if (scores.Length > Course.NumberOfTasksOnExam)
                            {
                                OutputWriter.DisplayException(ExceptionMessages.InvalidNumberOfScores);
                                continue;
                            }

                            if (!this.students.ContainsKey(userName))
                            {
                                this.students.Add(userName, new Student(userName));
                            }

                            if (!this.courses.ContainsKey(courseName))
                            {
                                this.courses.Add(courseName, new Course(courseName));
                            }

                            ICourse course = this.courses[courseName];
                            IStudent student = this.students[userName];

                            student.EnrollInCourse(course);
                            student.SetMarksInCourse(courseName, scores);

                            course.EnrollStudent(student);
                        }
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(e.Message + $" at line: {line + 1}!");
                    }
                }

                OutputWriter.WriteMessageOnNewLine("Data read!");
            }
            else
            {
                try
                {
                    throw new InvalidPathException();
                }
                catch (InvalidPathException ex)
                {
                    OutputWriter.WriteMessage(ex.Message);
                }
                //OutputWriter.WriteMessage(ExceptionMessages.InvalidPath);
            }
        }

        public void GetAllStudentsFromCourse(string courseName)
        {
            if (this.CourseExists(courseName))
            {
                foreach (var studentMarksEntry in this.courses[courseName].StudentsByName)
                {
                    this.GetStudentScoresFromCourse(courseName, studentMarksEntry.Key);
                }
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine($"Course {courseName} does not exist!");
            }
        }

        public ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse> cmp)
        {
            SimpleSortedList<ICourse> sordedCourses = new SimpleSortedList<ICourse>(cmp);
            sordedCourses.AdAll(this.courses.Values);

            return sordedCourses;
        }

        public ISimpleOrderedBag<IStudent> GetAllStudentsSorted(IComparer<IStudent> cmp)
        {
            SimpleSortedList<IStudent> sortedStudents = new SimpleSortedList<IStudent>(cmp);
            sortedStudents.AdAll(this.students.Values);

            return sortedStudents;
        }

        private bool CourseExists(string courseName)
        {
            if (this.courses.ContainsKey(courseName))
            {
                return true;
            }

            return false;
        }

        public void GetStudentScoresFromCourse(string courseName, string userName)
        {
            if (this.UserNameExists(userName, courseName))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, double>(userName, this.courses[courseName].StudentsByName[userName].MarksByCourseName[courseName]));
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine($"Course '{courseName}' or user '{userName}' does not exist in database!");
            }
        }

        private bool UserNameExists(string userName, string courseName)
        {
            if (this.CourseExists(courseName))
            {
                if (this.courses[courseName].StudentsByName.ContainsKey(userName))
                {
                    // User exists
                    return true;
                }

                return false;
            }

            return false;
        }
    }
}