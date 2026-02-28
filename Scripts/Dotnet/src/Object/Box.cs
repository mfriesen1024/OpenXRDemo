using CloneSaber.Scripts.Dotnet.Core;
using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public partial class Box:NoteObject
{
    [Export] byte saberId;
    
    public override void Slash(byte saberId)
    {
        bool isPositive = saberId == this.saberId;
        EventSystem.InvokeScoreMod(Position, isPositive);
    }

    public override void Bonk()
    {
        EventSystem.InvokeScoreMod(Position,false);
    }
}