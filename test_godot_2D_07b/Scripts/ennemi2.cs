using Godot;
using System;



public partial class ennemi2 : CharacterBody2D
{
	Vector2 velocity = new Vector2(150,0);
	private Sprite2D Sprite;	
	
	public override void _PhysicsProcess(double delta)
	{
		var collision = MoveAndCollide(velocity * (float)delta);

		if (collision != null)
		{
			velocity = velocity.Bounce(collision.GetNormal());
		}
	}
	private void _on_area_2d_body_entered(Node2D body)
	{
			GetTree().ReloadCurrentScene();		
	}
}
