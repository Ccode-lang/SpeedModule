using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedModule
{
    internal class Utils
    {
        public static void MultiplySpeed(Vehicle vehicleInstance, float amount)
        {
            vehicleInstance.forwardForce *= amount;
            vehicleInstance.backwardForce *= amount;
            vehicleInstance.sidewardForce *= amount;
            vehicleInstance.verticalForce *= amount;
        }
        public static void ResetVertical(Vehicle vehicleInstance)
        {
            vehicleInstance.verticalForce = 11f;
        }

        public static void SeamothSpeed(Vehicle vehicleInstance, int slotId)
        {
            MultiplySpeed(vehicleInstance, 2f);
        }
        
        public static void PrawnSpeed(Vehicle vehicleInstance, int slotId)
        {
            MultiplySpeed(vehicleInstance, 1.3f);
            ResetVertical(vehicleInstance);
        }

        public static void ResetSpeed(Vehicle vehicleInstance, int slotId)
        {
            vehicleInstance.forwardForce = 13f;
            vehicleInstance.backwardForce = 5f;
            vehicleInstance.sidewardForce = 11.5f;
            vehicleInstance.verticalForce = 11f;
        }
    }
}
