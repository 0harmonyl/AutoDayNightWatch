using BepInEx;
using System;
using UnityEngine;
using Utilla;

namespace NightDayWatch
{
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.6.9")]
    [BepInPlugin(PluginInfo.GUID, PluginInfo.Name, PluginInfo.Version)]
    public class Plugin : BaseUnityPlugin
    {
        void Awake()
        {
            Events.GameInitialized += GameInitialized;
        }

        void GameInitialized(object sender, EventArgs e)
        {
            OnEnable();
        }

        void OnEnable()
        {
            /* Mod set up in here as code in the OnEnable void runs at the start and when the mod is enabled */

            HarmonyPatches.ApplyHarmonyPatches();

            Setup();
        }

        void OnDisable()
        {
            /* Undoing mod set up in here as this is called when CI disables a mod */

            HarmonyPatches.RemoveHarmonyPatches();

            UndoSetup();
        }

        void Setup()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/LMAFN.LEFT.").SetActive(true);
        }

        void UndoSetup()
        {
            GameObject.Find("Player Objects/Local VRRig/Local Gorilla Player/rig/body/shoulder.L/upper_arm.L/forearm.L/hand.L/LMAFN.LEFT.").SetActive(false);
        }
    }
}
