using Godot;
using System;

public partial class thunder : Sprite2D
{
	public player p;
	public gui GUIScript;
	
	private void _on_area_2d_body_entered(Node2D body)
	{
		if (body is player)
		{
			(body as player).playThunderSound(); // jouer le son		
			GUIScript = GetParent().GetNode("Player/Camera2D/GUI") as gui;
			(body as player).coins --; // baisser le score
			GD.Print((body as player).coins); // écrire le score dans l'interfacethunder
			GUIScript.ChangeVal((body as player).coins);
			
		} 
	}
}
