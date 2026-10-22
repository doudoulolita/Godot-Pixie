using Godot;
using System;

public partial class objet : Sprite2D
{
	
	public player p;
	public gui GUIScript;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		p = GetParent().GetNode<player>("Player");
		GUIScript = GetParent().GetNode("Player/Camera2D/GUI") as gui;
	}
	
	private void _on_area_2d_body_entered(Node2D body)
	{
		if (body is player)
		{
			GUIScript = GetParent().GetNode("Player/Camera2D/GUI") as gui;
			(body as player).playCoinSound(); // jouer le son
			(body as player).coins ++; // augmenter le score
			GD.Print((body as player).coins); // écrire le score dans l'interfacethunder
			GUIScript.ChangeVal((body as player).coins);
			QueueFree();
			
			if ((body as player).coins >=6)
			{
				GD.Print("Bravo !");
				GUIScript.ChangeText2("Bravo !");
				GUIScript.ChangeVal((body as player).coins);
			}
		}		
	}

}
