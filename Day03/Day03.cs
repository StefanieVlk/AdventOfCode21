namespace AoCDay03;
public class Day03
{
    public int ExecuteFirstTask()
    {
        var data = ReadInput();
        var gamma = 0;
        var epsilon = 0;
        for(int i = 0; i < data[0].Length; i++)
        {
            gamma += GetMajorityForIndex(data, i) * (int) Math.Pow(2, data[0].Length-i-1);
            epsilon += GetMinorityForIndex(data, i) * (int) Math.Pow(2, data[0].Length-i-1);
        }
        return gamma * epsilon;
    }

    public int ExecuteSecondTask()
    {
        return 0;
    }

    public List<string> ReadInput()
    {
        var input = File.ReadAllLines(Path.Combine("..", "Day03", "Data","input.txt")).ToList();
        return input;
    }

    private int GetMajorityForIndex(List<string> data, int index)
    {
        int count0 = 0;
        int count1 = 0;
        foreach(var item in data)
        {
            if(item[index] == '0')
            {
                count0++;
            }
            else if(item[index] == '1')
            {
                count1++;
            }
        }
        int result = count0 > count1 ? 0 : 1;
        return result;
    }

     private int GetMinorityForIndex(List<string> data, int index)
    {
        int count0 = 0;
        int count1 = 0;
        foreach(var item in data)
        {
            if(item[index] == '0')
            {
                count0++;
            }
            else if(item[index] == '1')
            {
                count1++;
            }
        }
        int result = count0 > count1 ? 1 : 0;
        return result;
    }
}
