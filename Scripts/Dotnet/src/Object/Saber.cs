using Godot;

namespace CloneSaber.Scripts.Dotnet.Object;

public partial class Saber : Area3D
{
	[Export] byte saberID;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += OnTriggerEnter;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	
	void OnTriggerEnter(Area3D area)
	{
		if (area.GetParent() is NoteObject boxObject)
		{
			boxObject.Slash(saberID);
		}
	}
}