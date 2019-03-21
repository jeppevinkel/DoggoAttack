using Smod2.API;
using Smod2.Commands;
using Smod2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doggoAttack
{
    class ConfigCmd : ICommandHandler
    {
        private readonly DoggoAttack plugin;

        static IConfigFile Config => ConfigManager.Manager.Config;

        public ConfigCmd(DoggoAttack plugin)
        {
            //Constructor passing plugin refrence to this class
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            // This prints when someone types HELP HELLO
            return "Starts the event";
        }

        public string GetUsage()
        {
            return "da_start";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            Player caller = sender as Player;
            plugin.isActive = true;

            return new string[] { "DoggoAttack", "Activated" };
        }
    }
}
