using Godot;
using System;

public partial class menu : CanvasLayer
{
	// clic sur le bouton Jouer
	private void _on_button_1_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/level_1.tscn");
	}
	//  clic sur le bouton Quitter
	private void _on_button_2_pressed()
	{
		GetTree().Quit();
	}	

}






