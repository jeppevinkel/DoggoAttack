using Smod2;
using Smod2.Attributes;
using Smod2.EventHandlers;
using Smod2.Events;
using Smod2.API;
using System;
using System.Collections.Generic;
using System.Linq;
using Smod2.EventSystem.Events;
using System.Threading.Tasks;

namespace doggoAttack
{
    class EventHandler : IEventHandlerPlayerHurt, IEventHandlerRoundStart, IEventHandlerTeamRespawn, IEventHandlerRoundEnd
    {
        static IConfigFile Config => ConfigManager.Manager.Config;
        private static Random getRandom = new System.Random();
        private DoggoAttack plugin;

        public EventHandler(DoggoAttack plugin)
        {
            this.plugin = plugin;
        }

        public void OnPlayerHurt(PlayerHurtEvent ev)
        {
            if (Config.GetBoolValue("da_gamemodemanager", true))
            {
                if (GamemodeManager.GamemodeManager.CurrentMode != plugin) return;
            }
            else
            {
                if (!plugin.isActive) return;
            }

            if (ev.Player.TeamRole.Role == Role.CLASSD && ev.Damage >= ev.Player.GetHealth() && (ev.Attacker.TeamRole.Role == Role.SCP_939_53 || ev.Attacker.TeamRole.Role == Role.SCP_939_89))
            {
                ev.Damage = 0f;
                ev.Player.ChangeRole(Role.SCP_939_53, true, false, false, true);
            }
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            plugin.roundStarted = true;
            if (Config.GetBoolValue("da_gamemodemanager", true))
            {
                if (GamemodeManager.GamemodeManager.CurrentMode != plugin) return;
            }
            else
            {
                if (!plugin.isActive) return;
            }

            List<Player> players = plugin.Server.GetPlayers();
            int rnd = getRandom.Next(0, players.Count);

            if (players.Count <= 0) return;
                
            Player scpPlayer = players[rnd];
            players.RemoveAt(rnd);

            scpPlayer.ChangeRole(Role.SCP_939_89);

            foreach (Player p in players)
            {
                p.ChangeRole(Smod2.API.Role.CLASSD);
                p.GiveItem(ItemType.SCIENTIST_KEYCARD);
            }

            plugin.Server.Map.Broadcast(10, "Doggo Attack: This is an event where the mission of Class D is to escape the facility by any means necessary. One escaped Class D is a victory to Class D", false);
            plugin.Server.Map.Broadcast(10, "There will spawn one scp 939-89, and any Class D killed by it will become scp 939-53, and aid it in killing Class D.", false);
        }

        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            if (Config.GetBoolValue("da_gamemodemanager", true))
            {
                if (GamemodeManager.GamemodeManager.CurrentMode != plugin) return;
            }
            else
            {
                if (!plugin.isActive) return;
            }

            ev.PlayerList = null;
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {
            plugin.roundStarted = false;
            if (Config.GetBoolValue("da_gamemodemanager", true))
            {
                if (GamemodeManager.GamemodeManager.CurrentMode != plugin) return;
            }
            else
            {
                if (!plugin.isActive) return;
            }
            plugin.isActive = false;
        }
    }
}
