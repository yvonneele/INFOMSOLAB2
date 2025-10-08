public class Character
{
    public int X { get; private set; } = 0; // Starts at (0,0)
    public int Y { get; private set; } = 0;
    public Direction Facing { get; private set; } = Direction.East;

    public void Move(int steps) {
        switch (Facing)
        {
            case Direction.North: Y += steps; break;
            case Direction.East: X += steps; break;
            case Direction.South: Y -= steps; break;
            case Direction.West: X -= steps; break;
        }
    }

    public void turnLeft() {
        Facing = (Direction)(((int)Facing + 3) % 4);
    }

    public void turnRight() {
        Facing = (Direction)(((int)Facing + 1) % 4);
    }
}