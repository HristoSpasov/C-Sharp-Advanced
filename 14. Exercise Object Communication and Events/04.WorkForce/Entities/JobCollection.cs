using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _04.WorkForce.EventArgs;

namespace _04.WorkForce.Entities
{
    public class JobCollection
    {
        private readonly IList<Job> jobs;

        public JobCollection()
        {
            this.jobs = new List<Job>();
        }

        public void AddJob(Job newJob)
        {
            this.jobs.Add(newJob);

            newJob.JobFinished += this.OnJobDone;
        }

        public void OnJobDone(object sourse, JobEventArgs args)
        {
            Console.WriteLine($"Job {args.Name} done!");

            this.MarkJobAsDone(args.Name);
        }

        public string JobsStatus()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var job in this.jobs)
            {
                sb.AppendLine(job.ToString());
            }

            return sb.ToString().Trim();
        }

        public void JobsUpdate()
        {
            foreach (var job in this.jobs)
            {
                job.Update();
            }

            this.RemoveAllJobsWhichAreDone();
        }

        private void RemoveAllJobsWhichAreDone()
        {
            for (int i = 0; i < this.jobs.Count; i++)
            {
                if (this.jobs[i].IsDone)
                {
                    this.jobs.RemoveAt(i);
                    i = -1;
                }
            }
        }

        private void MarkJobAsDone(string jobName)
        {
            Job toRemove = this.jobs.First(n => n.Name == jobName);
            toRemove.JobFinished -= this.OnJobDone;
            toRemove.IsDone = true;
        }
    }
}