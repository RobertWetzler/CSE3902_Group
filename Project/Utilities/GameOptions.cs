﻿using System;

namespace Project.Utilities
{
    public static class GameOptions
    {

        public static bool IsHarderVersion { get; set; } = false;
        private static String normal = "Content/XML/Map_Building.xml";
        private static String hard = "Content/XML/Hard_Map.xml";

        public static string XML => IsHarderVersion ? hard : normal;

        public static bool IsShaderOn { get; set; } = true;

    }
}
