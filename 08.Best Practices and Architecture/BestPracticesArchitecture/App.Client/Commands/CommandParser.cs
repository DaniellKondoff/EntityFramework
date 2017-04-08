using System;
using System.Collections.Generic;

namespace App.Client.Commands
{
   public  class CommandParser
    {
        private Dictionary<string, Command> commands;
        public CommandParser()
        {
            
            this.Initialize();
        }

        public Command Parse(string commandAsString,MyData data)
        {
            if (this.commands.ContainsKey(commandAsString))
            {
                return this.commands[commandAsString].Create(data);
            }
            else
            {
                return new NotFoundCommand(null);
            }
        }

        private void Initialize()
        {
            this.commands = new Dictionary<string, Command>
            {
                {"increment",new IncraseNumberCommand(null) },
                 {"print",new PrintStringCommand(null) },
                  {"report",new PrintNumber(null) }
            };
        }
    }
}
