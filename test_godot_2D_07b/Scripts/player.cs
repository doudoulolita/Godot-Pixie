using Godot;
using System;

public partial class player : CharacterBody2D
{
	// variable pour l'argent
	public int coins = 0;
	
	// variables pour le son
	AudioStream coinSound;
	AudioStream jumpSound;
	AudioStream thunderSound;
	AudioStreamPlayer2D audioPlayer;
	
	// Constantes
	public const float SPEED = 300.0f;	
	// variable pour l'animation du sprite
	private AnimatedSprite2D AnimatedSprite;	
	// Récupération de la gravité depuis les options
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	// Constante pour la vélocité du saut
	public const float JumpVelocity = -600.0f;
	
	public void playCoinSound()
	{
		audioPlayer.Stream = coinSound;
		audioPlayer.Play();
	}
	
		public void playThunderSound()
	{
		audioPlayer.Stream = thunderSound;
		audioPlayer.Play();
	}
	
	public override void _Ready()
	{
		audioPlayer = GetNode<AudioStreamPlayer2D>("AudioStreamPlayer2D");
		coinSound = GD.Load("res://Sounds/gold_sack.wav") as AudioStream;
		jumpSound = GD.Load("res://Sounds/jumpland.wav") as AudioStream;
		thunderSound = GD.Load("res://Sounds/rock_breaking.wav") as AudioStream;
		
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite");
	}
		
	// Fonction qui tourne en boucle
	public override void _PhysicsProcess(double delta)
	{
		// Velocité du personnage
		Vector2 velocity = Velocity;
		
		// Pour stocker le vecteur de direction
		Vector2 direction = Input.GetVector(
			"ui_left", "ui_right", "ui_up", "ui_down"
		);
		
		// Pour appliquer la gravité quand on ne touche pas le sol
		if(!IsOnFloor())
		{
			velocity.Y += gravity * (float)delta;
			AnimatedSprite.Play("jump");
		}
		
		// gestion de la touche Echap < retour au menu
		if (Input.IsActionJustPressed("ui_cancel"))	
		{
			GetTree().ChangeSceneToFile("res://Scenes/menu.tscn");
		}
		
		// Gestion du saut si on appuie sur Espace
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			audioPlayer.Stream = jumpSound;
			audioPlayer.Play();
		}
		
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * SPEED;
			AnimatedSprite.Play("walk");
			if (direction.X >0) {
				AnimatedSprite.FlipH = false;
			}
			else {
				// pour retourner le sprite vers la gauche
				AnimatedSprite.FlipH = true;
			}
		}
		else
		{
			// pour arreter le mouvement
			velocity.X = 0;
			AnimatedSprite.Play("idle");
		}
		
		// On applique le mouvement
		Velocity = velocity;
		MoveAndSlide();
	}
}
