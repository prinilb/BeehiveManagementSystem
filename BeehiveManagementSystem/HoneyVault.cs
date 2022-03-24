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

        public static void ConvertNectarToHoney(float amount)
        {
            float nectarToConvert = amount; // need to set this as it's own variable because need to change the value on Line 17
            if (nectarToConvert > nectar) { nectarToConvert = nectar; }

            nectar -= nectarToConvert;
            honey += nectarToConvert * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount)
        {
            if (honey >= amount)
            {
                honey -= amount;
                return true;
            }

            return false;
        }

        public static void CollectNectar(float amount)
        {
            if (amount > 0f) { nectar += amount; }
        }

        public static string StatusReport
        {
            get
            {
                string status = $"{honey: 0.0} units of honey\n" + $"{nectar: 0.0} units of nectar\n";

                string warnings = "";
                if (honey < LOW_LEVEL_WARNING) warnings += "LOW HONEY - ADD A HONEY MANUFACTURER";
                if (nectar < LOW_LEVEL_WARNING) warnings += "LOW NECTAR - ADD A NECTAR COLLECTOR";

                return status + warnings;
            }
        }
    }
}
