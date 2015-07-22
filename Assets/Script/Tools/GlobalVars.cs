﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

namespace MVVM
{
    public class GlobalVars
    {
        public const string PREF_USER_ID = "USER_ID";
        public const string PREF_USER_PASSWORD = "USER_RPASSWORD";
        public const string PREF_USER_ITEM = "USER_ITEM";

        public const int DEFAULT_SCREEN_WIDTH = 1080;

        public static string IPAddress = "104.224.165.21";
        //public const string IPAddress = "192.168.45.17";
        public const int IPPort = 8081;
    }
}