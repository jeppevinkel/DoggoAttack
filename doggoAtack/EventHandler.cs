﻿using Smod2;
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
            if (!plugin.isActive) return;

            if ((byte)ev.Player.TeamRole.Role == 1 && ev.Damage >= ev.Player.GetHealth() && ((byte)ev.Attacker.TeamRole.Role == 16 | (byte)ev.Attacker.TeamRole.Role == 17))
            {
                ev.Damage = 0f;
                ev.Player.ChangeRole(Role.SCP_939_53, true, false, false, true);
            }
        }

        public void OnRoundStart(RoundStartEvent ev)
        {
            plugin.roundStarted = true;
            if (!plugin.isActive) return;

            //Task.Delay(1000).ContinueWith(t => bar());

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

            //Task.Delay(500).ContinueWith(t => closeDoors());

            plugin.Server.Map.Broadcast(10, "Doggo Attack: This is an event where the mission of Class D is to escape the facility by any means necessary. One escaped Class D is a victory to Class D", false);
            plugin.Server.Map.Broadcast(10, "There will spawn one scp 939-53, and any Class D killed by it will become scp 939-89, and aid it in killing Class D.", false);
        }

        public void OnTeamRespawn(TeamRespawnEvent ev)
        {
            if (!plugin.isActive) return;

            ev.PlayerList = null;
        }

        public void OnRoundEnd(RoundEndEvent ev)
        {
            plugin.roundStarted = false;
            if (!plugin.isActive) return;
            plugin.isActive = true;
        }

        public void closeDoors()
        {
            foreach (var str in plugin.pluginManager.CommandManager.CallCommand(plugin.Server, "doors", new string[] { "close" }))
            {
                if (str.Length != 0)
                    plugin.Info(str);
            }
        }
    }
}
