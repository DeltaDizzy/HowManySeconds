using UnityEngine;

namespace HowManySeconds
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class TMSConfig : MonoBehaviour
    {
        ConfigNode tmsnode;
        private static double _duration;

        public static double Duration
        {
            get
            {
                return _duration;
            }
            set
            {
                _duration = value;
            }
        }

        void Start()
        {
             tmsnode = GameDatabase.Instance.GetConfigs("TooManySeconds")[0].config;
        }
    }
}
