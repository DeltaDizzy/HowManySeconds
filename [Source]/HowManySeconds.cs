using System;
using KSP.UI.Screens;
using UnityEngine;

namespace HowManySeconds
{
    [KSPAddon(KSPAddon.Startup.FlightAndKSC, false)]
    public class HowManySeconds : MonoBehaviour
    {
        private double seconds = 0;
        private double msgDuration = TMSConfig.Duration;
        private Texture2D tex;
        private ApplicationLauncherButton btn = new ApplicationLauncherButton();
        private Boolean showTime = false;
        private Boolean button = false; // prevent duplicate buttons

        void Start()
        {
            if(ApplicationLauncher.Ready && !button)
            {
                btn = ApplicationLauncher.Instance.AddModApplication(
                    onTrue: StartTime,
                    onFalse: StopTime,
                    onHover: null,
                    onHoverOut: null,
                    onEnable: null,
                    onDisable: Destroy,
                    visibleInScenes: ApplicationLauncher.AppScenes.SPACECENTER | ApplicationLauncher.AppScenes.FLIGHT,
                    texture: tex
                    );
                button = true;
            }
        }

        private void Destroy()
        {
            ApplicationLauncher.Instance.RemoveModApplication(btn);
            button = false;
        }

        void Update()
        {
            if (showTime == true)
            {
                ScreenMessages.PostScreenMessage(String.Format("[TMS] ", GetSeconds().ToString()), (float)msgDuration);
            }
        }

        private double GetSeconds()
        {
            seconds = Planetarium.GetUniversalTime();
            return seconds;
        }

        private void StopTime()
        {
            showTime = false;
        }

        private void StartTime()
        {
            showTime = true;
        }

    }
}
