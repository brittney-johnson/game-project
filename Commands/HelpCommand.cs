using System.Collections;
using System.Collections.Generic;

namespace StarterGame
{
    public class HelpCommand : Command
    {
        private CommandWords _words;

        public HelpCommand() : this(new CommandWords()){}

        // Designated Constructor
        public HelpCommand(CommandWords commands) : base()
        {
            _words = commands;
            this.Name = "help";
        }

        override
            public bool Execute(Player player)
        {
            player.OutputMessage("\nYou are trying to escape the tower, \n\nYour available commands are " + _words.Description());
            return false;
        }
    }
}