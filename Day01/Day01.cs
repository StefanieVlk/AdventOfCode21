using System.IO;

namespace AoCDay01;
public class Day01
{
    public List<int> ReadInput()
    {
        var input = File.ReadAllLines(Path.Combine("..", "Day01", "Data","input.txt")).ToList();
        var inputAsInt = input.Select(x => Convert.ToInt32(x)).ToList();
        return inputAsInt;
    }
    public int ExecuteFirstTask()
    {
        var data = ReadInput();
        int numberOfIncreases = CountIncreases(data);
        return numberOfIncreases;
    }

    public int ExecuteSecondTask()
    {
        var data = ReadInput();
        var slidingWindowData = CreateSlidingWindowList(data);
        int numberOfIncreases = CountIncreases(slidingWindowData);
        return numberOfIncreases;
    }

    private int CountIncreases(List<int> input)
    {
        int numberOfIncreases = 0;
        for(int i = 1; i < input.Count; i++)
        {
            if(input[i] > input[i-1])
            {
                numberOfIncreases++;
            }
        }
        return numberOfIncreases;
    }

    private List<int> CreateSlidingWindowList(List<int> data)
    {
        List<int> result = new List<int>();
        for(int i = 2; i < data.Count; i++)
        {
            result.Add(data[i]+data[i-1]+data[i-2]);
        }
        return result;
    }
}
