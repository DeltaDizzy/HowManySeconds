using System;
using KSP.UI.Screens;
using UnityEngine;
using UnityEngine.Profiling;

namespace HowManySeconds
{
    [KSPAddon(KSPAddon.Startup.FlightAndKSC, false)]
    public class HowManySeconds : MonoBehaviour
    {
        private double seconds = 0;
        private double msgDuration = HMSConfig.Duration;
        private Texture2D tex = HMSConfig.Icon;
        private Boolean debug = HMSConfig.Debug;
        private ApplicationLauncherButton btn = new ApplicationLauncherButton();
        private Boolean showTime = false;
        private Boolean button = false; // prevent duplicate buttons

        void Start()
        {
            Profiler.BeginSample("btn");
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
            Profiler.EndSample();
        }

        private void Destroy()
        {
            ApplicationLauncher.Instance.RemoveModApplication(btn);
            button = false;
        }

        void Update()
        {
            if (showTime && debug)
            {
                ScreenMessages.PostScreenMessage(String.Format("[HMS] ", GetSeconds().ToString()), (float)msgDuration);
            }
            else if (showTime && !debug)
            {
                Debug.Log(String.Format("[HMS] ", GetSeconds().ToString()));
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
