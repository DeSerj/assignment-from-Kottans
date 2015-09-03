using System;

namespace CommandParser.Commands
{
    class KeyCommand: BaseCommand
    {
        public KeyCommand()
            : base("k")
        {
        }

        public override bool Execute()
        {
            Console.WriteLine("print keys...");

            return true;
        }
    }
}
