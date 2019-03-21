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
    class StartCmd : ICommandHandler
    {
        private DoggoAttack plugin;

        static IConfigFile Config => ConfigManager.Manager.Config;

        private static Random getRandom = new System.Random();

        public StartCmd(DoggoAttack plugin)
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
            return "da_start";
        }

        public string[] OnCall(ICommandSender sender, string[] args)
        {
            if (plugin.isActive) return new string[] { "DoggoAttack is already active!" };

            plugin.isActive = true;

            if (!plugin.roundStarted) return new string[] { "DoggoAttack Activated" };

            List<Player> players = plugin.Server.GetPlayers();
            if (players.Count <= 0) return new string[] { "No players online" };

            int rnd = getRandom.Next(0, players.Count);

            Player scpPlayer = players[rnd];
            players.RemoveAt(rnd);

            scpPlayer.ChangeRole(Role.SCP_939_89);

            foreach (Player p in players)
            {
                p.ChangeRole(Role.CLASSD);
                p.GiveItem(ItemType.SCIENTIST_KEYCARD);
            }

            plugin.Server.Map.Broadcast(10, "Doggo Attack: This is an event where the mission of Class D is to escape the facility by any means necessary. One escaped Class D is a victory to Class D", false);
            plugin.Server.Map.Broadcast(10, "There will spawn one scp 939-89, and any Class D killed by it will become scp 939-53, and aid it in killing Class D.", false);

            return new string[] { "DoggoAttack Activated" };
        }
    }
}
