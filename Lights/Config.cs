using Qurre.API.Addons;
using Qurre.API.Controllers;
using Qurre.API.Objects;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

namespace Lights
{
    public class Config : IConfig
    {
        [Description("Plugin Name")]
        public string Name { get; set; } = "Lights";
        [Description("Enable the plugin?")]
        public bool IsEnable { get; set; } = true;
        [Description("You can customize lights: room/color/pos etc?")]
        public List<MakeLight> MakingLights { get; set; } = new List<MakeLight>()
        {
            new MakeLight
            {
                Light_Name = "Tutorial Room",
                Room = RoomType.Surface,
                Color = "yellow",
                Position = new Vector3(53.5f, 20f, -44.2f),
                Intensive = 0.8f,
                Range = 10f
            },
            new MakeLight
            {
                Light_Name = "SCP-106 Room",
                Room = RoomType.Pocket,
                Color = "yellow",
                Position = new Vector3(0, 4, 0),
                Intensive = 1f,
                Range = 40f
            },
            new MakeLight
            {
                Light_Name = "Surface Nuke",
                Room = RoomType.Surface,
                Color = "yellow",
                Position = new Vector3(41, -9, -37),
                Intensive = 1.5f,
                Range = 10f
            },
            new MakeLight
            {
                Light_Name = "Chaos Spawn",
                Room = RoomType.Surface,
                Color = "yellow",
                Position = new Vector3(0, -5, -58),
                Intensive = 1f,
                Range = 20f
            },
            new MakeLight
            {
                Light_Name = "MTF Elevator",
                Room = RoomType.Surface,
                Color = "yellow",
                Position = new Vector3(87.7f, -3.5f, -48.5f),
                Intensive = 1f,
                Range = 10f
            },
            new MakeLight
            {
                Light_Name = "Alpha-Warhead",
                Room = RoomType.HczNuke,
                Color = "yellow",
                Position = new Vector3(-3.6f, 403.3f, 14.8f),
                Intensive = 1f,
                Range = 10f
            },
            new MakeLight
            {
                Light_Name = "SCP-096 Room",
                Room = RoomType.Hcz096,
                Color = "yellow",
                Position = new Vector3(0, 3, 0),
                Intensive = 1f,
                Range = 10f
            },
        };
    }
    public class MakeLight
    {
        public string Light_Name { get; set; }
        public RoomType Room { get; set; }
        public string Color { get; set; }
        public Vector3 Position { get; set; }
        public float Intensive { get; set; }
        public float Range { get; set; }
    }
}
