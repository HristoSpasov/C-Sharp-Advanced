using _01HarestingFields.Commands;

namespace _01HarestingFields.Factories
{
    public static class CommandFactory
    {
        public static Command GetCommand(string command)
        {
            switch (command)
            {
                case "private":
                    return new PrivateCommand();

                case "protected":
                    return new ProtectedCommand();

                case "public":
                    return new PublicCommand();

                case "all":
                    return new AllCommand();

                default:
                    return null;
            }
        }
    }
}