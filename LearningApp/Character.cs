public class Character
{
    private int x = 0; // Starts at (0,0)
    private int y = 0;
    public Direction Facing { get; private set; } = Direction.East;

    public void Move(int steps) {
        switch (Facing)
        {
            case Direction.North: y += steps; break;
            case Direction.East: x += steps; break;
            case Direction.South: y -= steps; break;
            case Direction.West: x -= steps; break;
        }
    }

    public void turnLeft() {
        Facing = (Direction)(((int)Facing + 3) % 4);
    }

    public void turnRight() {
        Facing = (Direction)(((int)Facing + 1) % 4);
    }
}