using System;
using System.Collections.Generic;
using System.Linq;
using CommandParser.Commands;

namespace CommandParser
{
    /// <summary>
    /// Entry point class.
    /// </summary>
    class Program
    {
        private static IList<BaseCommand> Commands { get; set; }

        static void Main(string[] args)
        {
            RegisterCommands();
            
            string input = null;
            
            do
            {
                if (!string.IsNullOrEmpty(input))
                    args = input.Split(CommandConstants.CommandSeparators, StringSplitOptions.RemoveEmptyEntries);

                ParseArgs(args);

                Console.WriteLine();
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("Please enter new command or 'exit' to finish application.");

                input = Console.ReadLine();
            }
            while (!CommandConstants.Exit.Equals(input, StringComparison.OrdinalIgnoreCase));
        }

        private static void RegisterCommands()
        {
            Commands = new List<BaseCommand>(new BaseCommand[]
            {
                new HelpCommand("help"),
                new HelpCommand("?"),
                new KeyCommand(),
                new PingCommand(),
                new PrintCommand()
            });
        }

        /// <summary>
        /// Parse entered arguments.
        /// </summary>
        /// <param name="args"></param>
        private static void ParseArgs(IEnumerable<string> args)
        {
            BaseCommand currentCommand = null;

            foreach (var arg in args)
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    if (CommandConstants.CommandPrefixes.Contains(arg[0]))
                    {
                        if (currentCommand != null)
                        {
                            var isContinue = currentCommand.Execute();
                            currentCommand = null;
                            if (!isContinue)
                                break;
                        }
                        
                        var commandKey = arg.TrimStart(CommandConstants.CommandPrefixes);

                        currentCommand = Commands.FirstOrDefault(
                                c => string.Equals(c.Key, commandKey, StringComparison.OrdinalIgnoreCase));

                        if (currentCommand == null)
                        {
                            PrintInvalidCommand(commandKey);
                            break;
                        }
                    }
                    else
                    {
                        if (currentCommand != null)
                            currentCommand.Args.Add(arg);
                        else
                        {
                            PrintInvalidCommand(arg);
                            break;
                        }
                    }
                }
            }

            if (currentCommand != null)
                currentCommand.Execute();
        }

        private static void PrintInvalidCommand(string command)
        {
            Console.WriteLine("Command <{0}> is not supported, use CommandParser.exe /? to see set of allowed commands", command);
        }
    }
}
