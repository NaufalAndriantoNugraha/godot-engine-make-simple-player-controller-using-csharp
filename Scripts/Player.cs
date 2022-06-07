using Godot;
using System;

public class Player : Area2D
{
    // Declare member variables here. Examples:
    
    [Export]
    public int Speed = 400;
    public Vector2 ScreenSize;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        ScreenSize = GetViewportRect().Size;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        var velocity = Vector2.Zero; // The player's movement vector.

        if (Input.IsActionPressed("move_right"))
        {
            velocity += Transform.x;
        }

        else if (Input.IsActionPressed("move_left"))
        {
            velocity -= Transform.x;
        }

        else if (Input.IsActionPressed("move_down"))
        {
            velocity += Transform.y;
        }

        else if (Input.IsActionPressed("move_up"))
        {
            velocity -= Transform.y;
        }

        if (velocity.Length() > 0)
        {
        velocity = velocity.Normalized() * Speed;
        }
        
        Position += velocity * delta;
    }
}
