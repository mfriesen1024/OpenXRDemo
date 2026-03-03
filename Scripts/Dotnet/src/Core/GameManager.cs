// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using CloneSaber.Scripts.Dotnet.Core;
using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

internal partial class GameManager:Node
{
    public static GameManager Instance { get; set; }
    
    [Export] PackedScene WorldScene, MusicPrefab;
    [Export] XRCamera3D Camera;
    [Export] public double ApproachRate = 0.9;

    double timeAlive;
    bool spawned = false;

    public override void _Ready()
    {
        Instance = this;

        var world = WorldScene.Instantiate() as Node3D;
        world.Ready += OnWorldInit;
        AddChild(world);

        void OnWorldInit()
        {
            world.GlobalBasis = Camera.GlobalBasis;
            world.GlobalPosition = Camera.GlobalPosition;
        }
    }

    public override void _PhysicsProcess(double delta)
    {
        timeAlive += delta;
        if (timeAlive < ApproachRate) return;
        if (spawned) return;
        spawned = true;
        AddChild(MusicPrefab.Instantiate());
    }
}