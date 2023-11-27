using MoreCyclopsUpgrades.API.Upgrades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedModule.Items.Handlers
{
    internal class CyclopsSpeedModuleHandler : UpgradeHandler
    {
        public CyclopsSpeedModuleHandler(TechType speedModule, SubRoot cyclops) : base(speedModule, cyclops)
        {
            this.OnClearUpgrades = () => { };
            this.OnUpgradeCounted = () => { };
        }
    }
}
