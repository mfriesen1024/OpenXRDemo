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

        if (timeAlive > 1.5) return;
        var tPos = Position;
        var node3D = GetParent() as Node3D;
        tPos.Z = -node3D.Position.Z;

        var newPos = Position.Lerp(tPos,(float)(timeAlive * (1 / 1.5)));
        
        Position = newPos;
    }
}