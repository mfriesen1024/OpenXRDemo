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
    bool spawnedWorld;
    bool spawnedMusic;

    public override void _Ready()
    {
        Instance = this;

        EventSystem.ScoreUpdated += EventSystemOnScoreUpdated;
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
        WorldSpawner(delta);
        if(!spawnedWorld) return;
        MusicSpawner(delta);
    }

    void WorldSpawner(double delta)
    {
        if (spawnedWorld) return;
        if(timeAlive < 1) return;
        spawnedWorld = true;
        
        var world = WorldScene.Instantiate() as Node3D;
        AddChild(world);
        
        world.GlobalPosition = Camera.GlobalPosition;
        world.GlobalBasis = Camera.GlobalBasis;
        
        timeAlive = 0;
    }

    void MusicSpawner(double delta)
    {
        if (timeAlive < ApproachRate) return;
        if (spawnedMusic) return;
        spawnedMusic = true;
        AddChild(MusicPrefab.Instantiate());
    }
}