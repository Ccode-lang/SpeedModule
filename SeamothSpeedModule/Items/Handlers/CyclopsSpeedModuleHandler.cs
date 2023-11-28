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
            this.OnClearUpgrades = () =>
            {
                SubControl control = cyclops.GetComponent<SubControl>();
                control.accelScale = 1f;
            };
            this.OnUpgradeCounted = () =>
            {
                SubControl control = cyclops.GetComponent<SubControl>();
                control.accelScale = 2f;
            };
        }
    }
}
