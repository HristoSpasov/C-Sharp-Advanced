using _08.Military_Elite.Interfaces;
using System;

namespace _08.Military_Elite.Entities
{
    public class Mission : IMission
    {
        private string missionState;

        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = state;
        }

        public string CodeName { get; private set; }

        public string State
        {
            get { return this.missionState; }
            private set
            {
                if (value != "inProgress" && value != "Finished")
                {
                    throw new ArgumentException("Invalid State;");
                }

                this.missionState = value;
            }
        }

        public void CompleteMission()
        {
            this.State = "Finished";
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}