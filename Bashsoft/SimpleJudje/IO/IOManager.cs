namespace SimpleJudje.IO
{
    using System;
    using System.IO;
    using SimpleJudje.Contracts;
    using SimpleJudje.Exceptions;
    using DirectoryInfo = SimpleJudje.DirectoryInfo;

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

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath == "..")
            {
                try
                {
                    string currentPath = SessionData.CurrentPath;
                    int indexOfLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexOfLastSlash);

                    SessionData.CurrentPath = newPath;
                }
                catch (ArgumentOutOfRangeException)
                {
                    throw new ArgumentOutOfRangeException("indexOfLastSlash", ExceptionMessages.UnableToGoHigherInPartitionHierarchy);
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
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

            SessionData.CurrentPath = absolutePath;
        }

        private string GetCurrentDirectoryPath()
        {
            return SessionData.CurrentPath;
        }
    }
}