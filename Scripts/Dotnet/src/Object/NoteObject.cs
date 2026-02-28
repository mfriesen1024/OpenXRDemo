using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public abstract partial class NoteObject:Node3D
{
    public abstract void Slash(byte saberId);

    public abstract void Bonk();
}