using Godot;
using System;

public partial class Mimi : CharacterBody2D
{
    // Movement values
    [Export] public float Speed = 200f;
    [Export] public float JumpForce = -400f;
    [Export] public float Gravity = 900f;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Apply gravity
        if (!IsOnFloor())
        {
            velocity.Y += Gravity * (float)delta;
        }

        // Left and Right movement
        float direction = 0;

        if (Input.IsActionPressed("right"))
            direction += 1;
        if (Input.IsActionPressed("left"))
            direction -= 1;

        velocity.X = direction * Speed;

        // Jump
        if (Input.IsActionJustPressed("space") && IsOnFloor())
        {
            velocity.Y = JumpForce;
        }

        Velocity = velocity;
        MoveAndSlide();
    }
}
