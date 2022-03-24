﻿using System;
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
            if (amount > nectar) { amount = nectar; } 

            nectar -= amount;
            honey += amount * NECTAR_CONVERSION_RATIO;
        }

        public static bool ConsumeHoney(float amount) //confusion here
        {
            if (amount >= honey) 
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
