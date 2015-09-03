using System;

namespace CommandParser.Commands
{
    class PrintCommand: BaseCommand
    {
        public PrintCommand()
            : base("print")
        {
        }

        public override bool Execute()
        {
            var message = string.Join(CommandConstants.DefaultCommandSeparator.ToString(), Args);

            Console.WriteLine(message);

            return true;
        }
    }
}
