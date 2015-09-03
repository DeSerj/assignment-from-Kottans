using System.Collections.Generic;

namespace CommandParser.Commands
{
    /// <summary>
    /// It defines base command.
    /// </summary>
    internal abstract class BaseCommand
    {
        public string Key { get; private set; }

        public List<string> Args { get; private set; }

        /// <summary>
        /// Execute command. Returns true to continue processing, false - to stop processing.
        /// </summary>
        /// <returns></returns>
        public abstract bool Execute();

        protected BaseCommand(string key)
        {
            Key = key;
            Args = new List<string>();
        }
    }
}
