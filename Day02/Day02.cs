namespace AoCDay02;
public class Day02
{
    public int ExecuteFirstTask()
    {
        var data = ReadInput();
        (int horizontalPosition, int depth) = PerformBasicMovement(data);
        return horizontalPosition * depth;
    }

    public int ExecuteSecondTask()
    {
        return 0;
    }

    public List<string> ReadInput()
    {
        var input = File.ReadAllLines(Path.Combine("..", "Day02", "Data","input.txt")).ToList();
        return input;
    }

    private (int, int) PerformBasicMovement(List<string> data)
    {
        int horizontalPosition = 0;
        int depth = 0;
        foreach(var item in data)
        {
            var direction = item.Split(' ')[0];
            var distance = Convert.ToInt32( item.Split(' ')[1]);
            switch(direction)
            {
                case "forward":
                    horizontalPosition += distance;
                    break;
                case "up":
                    depth -= distance;
                    break;
                case "down":
                    depth += distance;
                    break;
            }
        }

        return (horizontalPosition, depth);
    }
}
