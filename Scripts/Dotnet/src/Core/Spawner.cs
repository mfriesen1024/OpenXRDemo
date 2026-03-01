using Godot;

namespace CloneSaber.Scripts.Dotnet.Core;

public partial class Spawner:Node3D
{
    [Export] PackedScene[] objects;
    [Export] byte objectIndex;
    [Export] Vector3 pos;

    public override void _Ready()
    {
        var bla = Position;
        bla.Z = -8;
        Position =bla;
        GD.Print("Spawner init.");
    }

    void Spawn()
    {
        GD.Print($"Spawning {objectIndex}");
        var node = objects[objectIndex].Instantiate() as Node3D;
        AddChild(node);
        node.Position = pos;
    }
}