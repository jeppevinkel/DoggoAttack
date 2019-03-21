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
    class TestFunc : ICommandHandler
    {
        private DoggoAttack plugin;

        static IConfigFile Config => ConfigManager.Manager.Config;

        public TestFunc(DoggoAttack plugin)
        {
            //Constructor passing plugin refrence to this class
            this.plugin = plugin;
        }

        public string GetCommandDescription()
        {
            // This prints when someone types HELP HELLO
            return "Starts the doggo attack event";
        }

        public string GetUsage()
        {
            return "test";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
                foreach (var str in plugin.pluginManager.CommandManager.CallCommand(plugin.Server, "doors", new string[] { "close" }))
                {
                    if (str.Length != 0)
                        plugin.Info(str);
                }

            return new string[] { "Didn't crash!" };
        }
    }
}
