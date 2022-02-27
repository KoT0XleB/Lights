using System;
using System.Collections.Generic;
using Qurre;
using Qurre.API;
using Qurre.Events;
using Qurre.API.Events;
using Qurre.API.Objects;
using UnityEngine;
using Mirror;
using MEC;

using Version = System.Version;
using Player = Qurre.API.Player;

namespace Lights
{
    public class Lights : Plugin
    {
        public override string Developer => "KoT0XleB#4663";
        public override string Name => "Lights";
        public override Version Version => new Version(1, 0, 0);
        public override int Priority => int.MinValue;
        public override void Enable() => RegisterEvents();
        public override void Disable() => UnregisterEvents();
        public static Config CustomConfig { get; set; }

        public static GameObject LightsObject;
        public static List<GameObject> gameObjects = new List<GameObject>();

        public void RegisterEvents()
        {
            CustomConfig = new Config();
            CustomConfigs.Add(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Round.Start += OnRoundStarted;
            Qurre.Events.Round.End += OnRoundEnded;
        }
        public void UnregisterEvents()
        {
            CustomConfigs.Remove(CustomConfig);
            if (!CustomConfig.IsEnable) return;

            Qurre.Events.Round.Start -= OnRoundStarted;
            Qurre.Events.Round.End -= OnRoundEnded;
        }
        public void OnRoundStarted()
        {
            foreach(var list in CustomConfig.MakingLights)
            {
                Color needColor;
                switch (list.Color)
                {
                    case "yellow":
                        needColor = Color.yellow;
                        break;
                    case "white":
                        needColor = Color.white;
                        break;
                    case "black":
                        needColor = Color.black;
                        break;
                    case "gray":
                        needColor = Color.gray;
                        break;
                    case "red":
                        needColor = Color.red;
                        break;
                    case "green":
                        needColor = Color.green;
                        break;
                    case "cyan":
                        needColor = Color.cyan;
                        break;
                    default:
                        needColor = Color.gray;
                        break;
                }
                CreateLight(list.Room, needColor, list.Position, list.Intensive, list.Range);
            }
        }
        public void CreateLight(RoomType room, Color color, Vector3 localposition, float Intensive, float Range)
        {
            var Light = new Qurre.API.Controllers.Light(localposition, color, Intensive, Range);
            LightsObject = Light.Base.gameObject;
            NetworkServer.UnSpawn(LightsObject);
            LightsObject.transform.parent = room.GetRoom().Transform;
            LightsObject.transform.localPosition = localposition;
            NetworkServer.Spawn(LightsObject);
            gameObjects.Add(LightsObject);
        }
        public void OnRoundEnded(RoundEndEvent ev)
        {
            foreach (GameObject gameObject in gameObjects)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}
