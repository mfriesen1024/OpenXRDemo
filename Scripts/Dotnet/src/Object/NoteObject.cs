using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public abstract partial class NoteObject:Node3D
{
    double timeAlive;
    public abstract void Slash(byte saberId);

    public abstract void Bonk();

    public override void _PhysicsProcess(double delta)
    {
        timeAlive += delta;

        if (timeAlive > 1) return;
        var tPos = Position;
        tPos.Z = -(GetParent() as Node3D).Position.Z;

        Position = Position.Lerp(tPos,(float)(timeAlive * 1 / 0.6));
    }
}