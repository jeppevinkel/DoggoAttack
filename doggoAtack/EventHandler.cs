using Smod2;
using Smod2.Attributes;
using Smod2.EventHandlers;
using Smod2.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doggoAttack
{
    class EventHandler : IEventHandlerWaitingForPlayers, IEventHandlerPlayerDie
    {
        static IConfigFile Config => ConfigManager.Manager.Config;
        private static readonly System.Random getrandom = new System.Random();
        private DoggoAttack plugin;

        public EventHandler(DoggoAttack plugin)
        {
            this.plugin = plugin;
        }

        public void OnWaitingForPlayers(WaitingForPlayersEvent ev)
        {

        }

        public void OnPlayerDie(PlayerDeathEvent ev)
        {
            if (!plugin.isActive)
            {
                return;
            }
            if ((byte)ev.Player.TeamRole.Role == 1 && ((byte)ev.Killer.TeamRole.Role == 16 | (byte)ev.Killer.TeamRole.Role == 17))
            {
                ev.SpawnRagdoll = false;
                ev.Player.ChangeRole(Smod2.API.Role.SCP_939_89, true, false, false, true);
            }
        }
    }
}
