﻿namespace _11.Inferno_Infinity.Core.Command
{
    public abstract class Command
    {
        private readonly string[] tokens;
        private readonly Db database;

        protected Command(Db database, string[] tokens)
        {
            this.tokens = tokens;
            this.database = database;
        }

        protected string[] Tokens => this.tokens;

        protected Db Database => this.database;

        public abstract void Ecexute();
    }
}