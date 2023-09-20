using MSCLoader;
using System;
using UnityEngine;
using System.Linq;

namespace LightPlugin
{ 
    public static class Extensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
                return new T[] { item };
            Array.Resize(ref array, array.Length + 1);
            array[array.Length - 1] = item;

            return array;
        }
    }
    public class LightPlugin : Mod
    {
        public override string ID => "LightPlugin";
        public override string Name => "LightPlugin"; 
        public override string Author => "ELS122"; 
        public override string Version => "1.1"; 
        public override bool UseAssetsFolder => false;
        public static Light[] lightComponents;
        public static Settings toggleShadows = new Settings("shadowsOn", "Light Shadows Enabled", true, SwitchShadows);
        public static bool shadowsOn;
        public override void ModSettings()
        {
            Settings.AddCheckBox(this, toggleShadows);
        }
        public override void OnLoad()
        {
            lightComponents = Resources.FindObjectsOfTypeAll<Light>().Where(x => (x.shadows == LightShadows.None)).ToArray();
            SwitchShadows();
//(v1.1 code on top, v1.0 code below removed

            //lightComponents = null;

            //Transform lights = GameObject.Find("MAP/StreetLights").transform;
            //for (int i = 0; i < lights?.childCount; i++)
            //{
            //    Transform currentLight = lights.GetChild(i).GetChild(0).GetChild(lights.GetChild(i).GetChild(0).childCount - 1);
            //    for (int e = 0; e < currentLight?.childCount; e++)
            //        lightComponents = lightComponents.Append(currentLight.GetChild(e).gameObject.GetComponent<Light>());
            //}

            //Transform npcCars = GameObject.Find("NPC_CARS")?.transform;
            //AddShadowsCommonOther(npcCars?.GetChild(3)?.GetChild(7));
            //AddShadowsCommonOther(npcCars?.GetChild(4)?.GetChild(0)?.GetChild(14));
            //AddShadowsCommonOther(npcCars?.GetChild(4)?.GetChild(1)?.GetChild(14));

            //Transform bus = null;
            //if (npcCars?.GetChild(0)?.childCount > 0)
            //    bus = npcCars?.GetChild(0)?.GetChild(0);
            //if (npcCars?.GetChild(1)?.childCount > 0)
            //    bus = npcCars?.GetChild(1)?.GetChild(0);
            //if (npcCars?.GetChild(2)?.childCount > 0)
            //    bus = npcCars?.GetChild(2)?.GetChild(0);
            //AddShadowsCommon(bus?.GetChild(11));

            //Transform trafficCars = GameObject.Find("TRAFFIC")?.transform;
            //AddShadowsCommonOther(trafficCars?.GetChild(7)?.GetChild(0)?.GetChild(0)?.GetChild(8));

            //Transform highwayCars = trafficCars?.GetChild(6);
            //AddShadowsCommon(highwayCars?.GetChild(0)?.GetChild(6).GetChild(4));
            //AddShadowsCommon(highwayCars?.GetChild(1)?.GetChild(3).GetChild(0));
            //AddShadowsCommon(highwayCars?.GetChild(2)?.GetChild(8));
            //AddShadowsCommon(highwayCars?.GetChild(3)?.GetChild(9));
            //AddShadowsCommon(highwayCars?.GetChild(4)?.GetChild(8));
            //AddShadowsCommon(highwayCars?.GetChild(5)?.GetChild(7));
            //AddShadowsCommon(highwayCars?.GetChild(6)?.GetChild(7));
            //AddShadowsCommon(highwayCars?.GetChild(7)?.GetChild(7));
            //AddShadowsCommon(highwayCars?.GetChild(8)?.GetChild(7));
            //AddShadowsCommon(highwayCars?.GetChild(9)?.GetChild(6));

            //SwitchShadows();

            //void AddShadowsCommon(Transform light)
            //{
            //    lightComponents = lightComponents.Append(light.GetChild(0)?.GetChild(0)?.gameObject.GetComponent<Light>());
            //    lightComponents = lightComponents.Append(light.GetChild(0)?.GetChild(1)?.gameObject.GetComponent<Light>());
            //}
            //void AddShadowsCommonOther(Transform light)
            //{
            //    lightComponents = lightComponents.Append(light.GetChild(0)?.GetChild(2)?.gameObject.GetComponent<Light>());
            //    lightComponents = lightComponents.Append(light.GetChild(0)?.GetChild(3)?.gameObject.GetComponent<Light>());
            //}
        }
        public static void SwitchShadows()
        {
            shadowsOn = bool.Parse(toggleShadows.GetValue().ToString());

            foreach (Light light in lightComponents)
                light.shadows = shadowsOn ? LightShadows.Soft : LightShadows.None;
        }
    } 
}
