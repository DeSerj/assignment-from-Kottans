using System;

namespace CommandParser.Commands
{
    class PingCommand: BaseCommand
    {
        public PingCommand()
            : base("ping")
        {
        }

        public override bool Execute()
        {
            Console.Beep();
            Console.WriteLine("Pinging...");

            return true;
        }
    }
}
