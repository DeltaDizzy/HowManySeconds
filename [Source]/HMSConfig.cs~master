using UnityEngine;

namespace HowManySeconds
{
    [KSPAddon(KSPAddon.Startup.MainMenu, true)]
    public class HMSConfig : MonoBehaviour
    {
        ConfigNode hmsnode;
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
             hmsnode = GameDatabase.Instance.GetConfigs("TooManySeconds")[0].config;
        }
    }
}
