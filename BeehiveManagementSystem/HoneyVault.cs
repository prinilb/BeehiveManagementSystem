using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManagementSystem
{
    static class HoneyVault
    {
        private static float honey = 25f;
        private static float nectar = 100f;
        public const float NECTAR_CONVERSION_RATIO = .19f;
        public const float LOW_LEVEL_WARNING = 10f;

        public static void ConvertNectarToHoney(float amount) //confusion here
        {
            if (amount < nectar) { amount = nectar; } 

            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount) //confusion here
        {
            if (amount > honey) 
            {
                honey -= amount;
                return true; 
            }

            return false;
        }
    }
}
