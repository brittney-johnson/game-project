using System.Collections;
using System.Collections.Generic;
using System;
/*takes in a string of user input, breaks it down into separate words*/
namespace StarterGame
{
    public class Parser
    {
        private CommandWords _commands;

        public Parser() : this(new CommandWords()){}

        // Designated Constructor
        public Parser(CommandWords newCommands)
        {
            _commands = newCommands;
        }

        public Command ParseCommand(string commandString)
        {
            Command command = null;
            string[] words = commandString.Split(' ');
            if (words.Length > 0)
            {
                command = _commands.Get(words[0]);
                if (command != null)
                {
                    if (words.Length > 1)
                    {
                        command.SecondWord = words[1];
                    }
                    else
                    {
                        command.SecondWord = null;
                    }
                    if (words.Length > 2)
                    {
                        command.ThirdWord = words[2];
                    }
                    else
                    {
                        command.ThirdWord = null;
                    }

                    if (words.Length > 3)
                    {
                        command.FourthWord = words[3];
                    }
                    else
                    {
                        command.FourthWord = null;
                    }
                }
                else
                {
                    // This is debug line of code, should remove for regular execution
                    Console.WriteLine(">>>Did not find the command " + words[0]);
                }
            }
            else
            {
                // This is a debug line of code
                Console.WriteLine("No words parsed!");
            }
            return command;
        }

        public string Description()
        {
            return _commands.Description();
        }
    }
}