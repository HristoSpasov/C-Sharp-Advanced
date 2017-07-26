using SimpleJudje.Contracts;
using SimpleJudje.Exceptions;
using System;

namespace SimpleJudje.IO
{
    public abstract class Command : IExecutable
    {
        private string input;
        private string[] data;
        private readonly IContentComparer judge;
        private readonly IDatabase repository;
        private readonly IDirectoryManager inputOutputManager;

        protected Command(string input, string[] data, IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManagar)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManagar;
        }

        protected string Input
        {
            get { return this.input; }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get { return this.data; }

            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected IDatabase Repository => this.repository;

        protected IContentComparer Judge => this.judge;

        protected IDirectoryManager InputOutputManager => this.inputOutputManager;

        public abstract void Execute();
    }
}