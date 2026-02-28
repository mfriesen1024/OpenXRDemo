using Godot;

namespace CloneSaber.Scripts.Dotnet.Core;

public static class EventSystem
{
    public delegate void ScoreUpdateEvent(Vector3 pos, bool isPositive);

    public static event ScoreUpdateEvent ScoreUpdated;
    
    public static void InvokeScoreMod(Vector3 position, bool isPositive)
    {
        ScoreUpdated?.Invoke(position, isPositive);
    }
}