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
    class StopCmd : ICommandHandler
    {
        private DoggoAttack plugin;

        public StopCmd(DoggoAttack plugin)
        {
            //Constructor passing plugin refrence to this class
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            // This prints when someone types HELP HELLO
            return "Stops the doggo attack event";
        }

        public string GetUsage()
        {
            return "da_stop";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (!plugin.isActive) return new string[] { "DoggoAttack is not active!" };

            plugin.isActive = false;

            plugin.Server.Map.Broadcast(10, "DA event stopped!", false);
            return new string[] { "DoggoAttack Deactivated" };
        }
    }
}
