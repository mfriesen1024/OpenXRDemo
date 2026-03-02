using Godot;

namespace CloneSaber.Scripts.Dotnet.Core;

public partial class HitsoundPlayer:AudioStreamPlayer
{
    public override void _Ready()
    {
        EventSystem.ScoreUpdated += ScoreUpdated;
    }

    void ScoreUpdated(Vector3 pos, bool isPositive)
    {
        Playing = true;
    }
}