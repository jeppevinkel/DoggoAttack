using Smod2;
using Smod2.Attributes;
using System;
using System.Threading.Tasks;

namespace doggoAttack
{
    [PluginDetails(
        author = "Jopo",
        name = "DoggoAttack",
        description = "Doggo attack event",
        id = "jopo.gamemode.doggoattack",
        version = "2.6",
        SmodMajor = 3,
        SmodMinor = 0,
        SmodRevision = 0
        )]
    public class DoggoAttack : Plugin
    {
        static IConfigFile Config => ConfigManager.Manager.Config;

        public bool isActive = false;
        public bool roundStarted = false;
        public bool first = false;

        public override void OnDisable()
        {
            this.Info(this.Details.name + " was disabled ):");
        }

        public override void OnEnable()
        {
            this.Info(this.Details.name + " has loaded :)");
        }
        
        public override void Register()
        {
            // Register Events
            this.AddEventHandlers(new EventHandler(this));

            // Register Commands
            this.AddCommand("da_start", new StartCmd(this));
            this.AddCommand("da_stop", new StopCmd(this));
            this.AddCommand("da_test", new TestFunc(this));

            // Register configs
            AddConfig(new Smod2.Config.ConfigSetting("da_gamemodemanager", true, Smod2.Config.SettingType.BOOL, true, "Set whether the server is using gamemode manager"));

            if (ConfigManager.Manager.Config.GetBoolValue("da_gamemodemanager", true))
            {
                Info("Server using gamemode manager");
                GamemodeManager.GamemodeManager.RegisterMode(this);
            }
            else
            {
                Info("Server not using gamemode manager");
            }
        }
    }
}
