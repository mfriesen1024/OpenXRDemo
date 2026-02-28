using CloneSaber.Scripts.Dotnet.Core;

namespace CloneSaber.Scripts.Dotnet.Object;

public partial class Bomb:NoteObject
{
    public override void Slash(byte saberId)
    {
        EventSystem.InvokeScoreMod(Position, false);
    }

    public override void Bonk()
    {
        
    }
}