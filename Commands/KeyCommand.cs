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

            for (var i = 0; i < Args.Count; i++)
            {
                var key = Args[i];

                var value = (++i < Args.Count) ? Args[i] : CommandConstants.DefaultKeyValue;

                WriteKeyInfo(key, value);

            }

            return true;

        }

        private static void WriteKeyInfo(string key, string value)
        {
            Console.WriteLine("-k {0} {1}", key, value);
        }
    }
}
