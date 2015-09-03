using System;

namespace CommandParser.Commands
{
    class HelpCommand : BaseCommand
    {
        public HelpCommand(string key) : base(key)
        {
        }

        public override bool Execute()
        {
            Console.WriteLine("Bla-bla-bla - this is a help...");

            return false;
        }
    }
}
