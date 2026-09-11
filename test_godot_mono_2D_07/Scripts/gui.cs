using Godot;
using System;

public partial class gui : CanvasLayer
{
	Label label;
	Label label2;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		label = GetNode("Label") as Label;
		label.Text = "0";
		
		label2 = GetNode("Label2") as Label;
		label2.Text = "Score = ";
	}

	public void ChangeVal(int val)
	{
		label.Text = val.ToString();
	}
	
		public void ChangeText(string text)
	{
		label.Text = text;
	}
	
			public void ChangeText2(string text)
	{
		label2.Text = text;
	}
}
