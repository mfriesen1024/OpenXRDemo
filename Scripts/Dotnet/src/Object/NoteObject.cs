using CloneSaber.Scripts.Dotnet.Core;
using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public abstract partial class NoteObject:Node3D
{
    double ApproachRate => GameManager.Instance.ApproachRate; 
    Vector3 startPos;
    
    double timeAlive;
    public abstract void Slash(byte saberId);

    public abstract void Bonk();

    public override void _Ready()
    {
        startPos = Position;
        
        EventSystem.ScoreUpdated += DeleteOnHit;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        timeAlive += delta;

        if (timeAlive > ApproachRate)
        {
            QueueFree();
            return;
        }
        var tPos = Position;
        var node3D = GetParent() as Node3D;
        tPos.Z = -node3D.Position.Z - 0.25f; // add 2m of space between us and where things should vanish.

        var newPos = startPos.Lerp(tPos,(float)(timeAlive * (1 / ApproachRate)));
        
        Position = newPos;
    }
    
    void DeleteOnHit(Vector3 pos, bool isPositive)
    {
        EventSystem.ScoreUpdated -= DeleteOnHit;
        QueueFree();
    }
}