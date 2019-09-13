using System;
using UnityEngine;

namespace HowManySeconds
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class HMSConfig : MonoBehaviour
    {
        private static ConfigNode hmsnode;
        private static Double _duration;
        private static Texture2D _iconTex;
        private static Boolean _debug;

        public static Double Duration
        {
            get
            {
                return _duration;
            }
        }
        public static Boolean Debug
        {
            get
            {
                return _debug;
            }
        }
        public static Texture2D Icon
        {
            get
            {
                return _iconTex;
            }
        }

        void Start()
        {
            hmsnode = GameDatabase.Instance.GetConfigs("HowManySeconds")[0].config;
            _duration = Double.Parse(hmsnode.GetValue("msgDuration"));
            _iconTex = GameDatabase.Instance.GetTexture(hmsnode.GetValue("iconTexture"), false);
            _debug = Boolean.Parse(hmsnode.GetValue("debug"));
            Debug.Log(hmsnode.ToString());
        }
    }
}
