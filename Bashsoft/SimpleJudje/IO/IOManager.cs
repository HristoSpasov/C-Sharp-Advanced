using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System;
using System.IO;

namespace SimpleJudje.IO
{
    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            DirectoryInfo.TraverseDirectory(depth);
        }

        public void CreateDirectoryInCurrentFolder(string folderName)
        {
            string path = this.GetCurrentDirectoryPath() + "\\" + folderName;

            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                // throw new ArgumentException(ExceptionMessages.ForbiddenSymbolsContainedInName);
                throw new InvalidFileNameException();
            }
        }

        private string GetCurrentDirectoryPath()
        {
            return SessionData.currentPath;
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.currentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);

                    SessionData.currentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("indexOfLastSlash", ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.currentPath;
                currentPath += "\\" + relativePath;
                this.ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                // throw new DirectoryNotFoundException(ExceptionMessages.InvalidPath);
                throw new InvalidPathException();
            }

            SessionData.currentPath = absolutePath;
        }
    }
}