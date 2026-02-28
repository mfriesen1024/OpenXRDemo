using CloneSaber.Scripts.Dotnet.Core;
using CloneSaber.Scripts.Dotnet.Object;
using Godot;

namespace CloneSaber.Scripts.Dotnet.UI;

public partial class ScoreDisplay:Label
{
    int score;
    public override void _Ready()
    {
        EventSystem.ScoreUpdated += ScoreUpdated;
    }

    void ScoreUpdated(Vector3 pos, bool isPositive)
    {
        score += isPositive ? 1 : -1;
        Text = $"Score: {score}";
    }
}