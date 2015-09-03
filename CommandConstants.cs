namespace CommandParser
{
    /// <summary>
    /// It contains command constants.
    /// </summary>
    static class CommandConstants
    {
        public static readonly char[] CommandPrefixes = {'/', '-'};

        public static readonly char[] CommandSeparators = { DefaultCommandSeparator };

        public const char DefaultCommandSeparator = ' ';
        
        public const string DefaultKeyValue = "<null>";
        
        public const string Exit = "exit";
    }
}
