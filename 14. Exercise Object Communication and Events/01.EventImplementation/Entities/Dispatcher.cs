namespace _01.EventImplementation.Entities
{
    public delegate void NameChangeEventHandler(object sourse, NameChangeEventArgs args);

    public class Dispatcher
    {
        public event NameChangeEventHandler NameChange;

        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.OnDispatcherNameChange(this.Name);
            }
        }

        protected virtual void OnDispatcherNameChange(string name)
        {
            if (NameChange != null)
            {
                NameChange(this, new NameChangeEventArgs(name));
            }
        }
    }
}