// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using CloneSaber.Scripts.Dotnet.Core;
using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

internal partial class GameManager:Node
{
    public static GameManager Instance { get; set; }
    
    [Export] PackedScene WorldScene, MusicPrefab, HitsoundPrefab;
    [Export] XRCamera3D Camera;
    [Export] public double ApproachRate = 0.9;

    double timeAlive;
    bool spawned = false;

    public override void _Ready()
    {
        Instance = this;

        EventSystem.ScoreUpdated += EventSystemOnScoreUpdated;

        var world = WorldScene.Instantiate() as Node3D;
        Camera.AddChild(world);
        world.Reparent(this);
    }

    void EventSystemOnScoreUpdated(Vector3 pos, bool isPositive)
    {
        if(!isPositive)  return;
        var hitsound = HitsoundPrefab.Instantiate() as Node3D;
        AddChild(hitsound);
        hitsound.GlobalPosition = pos;
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