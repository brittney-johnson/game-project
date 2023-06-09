using System.Collections;
using System.Collections.Generic;
using System;
/*
 * CommandWords is used to implement all the Commands of the game
 */
namespace StarterGame
{
    public class CommandWords
    {
        private Dictionary<string, Command> commands;
        //command classes added
        private static Command[] commandArray = { new GoCommand(), new QuitCommand(), new InspectCommand(), new PickUpCommand(), new DropCommand(), new InventoryCommand(), new ShowMapCommand(), new UseCommand(), new BackCommand(), new TalkToCommand(), new OpenCommand()};

        public CommandWords() : this(commandArray) {}

        // Designated Constructor
        public CommandWords(Command[] commandList)
        {
            commands = new Dictionary<string, Command>();
            foreach (Command command in commandList)
            {
                commands[command.Name] = command;
            }
            Command help = new HelpCommand(this);
            commands[help.Name] = help;
        }

        public Command Get(string word)
        {
            Command command = null;
            commands.TryGetValue(word, out command);
            return command;
        }

        public string Description()
        {
            string commandNames = "";
            Dictionary<string, Command>.KeyCollection keys = commands.Keys;
            foreach (string commandName in keys)
            {
                commandNames += " " + commandName;
            }
            return commandNames;
        }
    }
}