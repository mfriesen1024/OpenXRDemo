// Copyright © 2026 ScottishDwarfStudios under licence from mFriesen1024 (mfriesen1024@gmail.com)

using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

internal partial class GameManager:Node
{
    public static GameManager Instance { get; set; }
    
    [Export] PackedScene WorldScene;
    [Export] public double ApproachRate = 0.9;

    public override void _Ready()
    {
        Instance = this;
    }
}