namespace _04.Recharge.Entities
{
    using _04.Recharge.Contracts;

    public class Robot : IWorker, IRechargeable
    {
        private string id;
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity)
        {
            this.id = id;
            this.capacity = capacity;
        }

        public string Id
        {
            get { return this.id; }
            private set { this.id = value; }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set { this.capacity = value; }
        }

        public int CurrentPower
        {
            get { return this.currentPower; }
            private set { this.currentPower = value; }
        }

        public void Work(int hours)
        {
            if (hours > this.currentPower)
            {
                hours = this.CurrentPower;
            }

            this.currentPower -= hours;
        }

        public void Recharge()
        {
            this.CurrentPower = this.Capacity;
        }
    }
}