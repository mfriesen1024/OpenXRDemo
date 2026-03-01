using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public abstract partial class NoteObject:Node3D
{
    [Export] double approachRate = 0.6;
    Vector3 startPos;
    
    double timeAlive;
    public abstract void Slash(byte saberId);

    public abstract void Bonk();

    public override void _Ready()
    {
        startPos = Position;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        timeAlive += delta;

        if (timeAlive > approachRate)
        {
            QueueFree();
            return;
        }
        var tPos = Position;
        var node3D = GetParent() as Node3D;
        tPos.Z = -node3D.Position.Z - 2; // add 2m of space between us and where things should vanish.

        var newPos = startPos.Lerp(tPos,(float)(timeAlive * (1 / approachRate)));
        
        Position = newPos;
    }
}