using _10.Create_Custom_Class_Attribute.Core;
using _10.Create_Custom_Class_Attribute.Core.Command;
using System.Linq;

namespace _10.Create_Custom_Class_Attribute.Factories
{
    public static class CommandFactory
    {
        public static Command GetCommand(Db database, string[] args)
        {
            switch (args[0])
            {
                case "Create":
                    return new CreateCommand(database, args.Skip(1).ToArray());

                case "Add":
                    return new AddCommand(database, args.Skip(1).ToArray());

                case "Remove":
                    return new RemoveCommand(database, args.Skip(1).ToArray());

                case "Print":
                    return new PrintCommand(database, args.Skip(1).ToArray());

                case "Author":
                    return new AuthorCommand(database, args);

                case "Revision":
                    return new RevisionCommand(database, args);

                case "Description":
                    return new DescriptionCommand(database, args);

                case "Reviewers":
                    return new ReviewersCommand(database, args);

                default:
                    return null;
            }
        }
    }
}