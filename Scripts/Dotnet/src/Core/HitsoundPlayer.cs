using Godot;

namespace CloneSaber.Scripts.Dotnet.Core;

public partial class HitsoundPlayer:AudioStreamPlayer3D
{
    public override void _Ready()
    {
        Finished += QueueFree;
    }
}