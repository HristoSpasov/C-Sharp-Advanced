using SimpleJudje.Contracts;
using SimpleJudje.IO;
using SimpleJudje.Judje;
using SimpleJudje.Repository;

namespace SimpleJudje
{
    public class BashSoft
    {
        public static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentRepository(new RepositorySorter(), new RepositoryFilter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}