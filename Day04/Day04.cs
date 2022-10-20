namespace AoCDay04;
public class Day04
{
    public int ExecuteFirstTask()
    {
        var boards = GetAllBoards(ReadInput());
        var numbers = GetAllNumbers(ReadInput());
        foreach(var number in numbers)
        {
            boards = CrossOccurences(boards, number);
            if(CheckAllBoardsForWinner(boards, out var winningBoard))
            {
                return CalculateRemainingSum(winningBoard) * Convert.ToInt32(number);
            }
        }
        return 0;
    }

    public int ExecuteSecondTask()
    {
        var boards = GetAllBoards(ReadInput());
        var numbers = GetAllNumbers(ReadInput());
        foreach(var number in numbers)
        {
            boards = CrossOccurences(boards, number);
            if(IsOnlyLooserBoardRemaining(boards, out boards))
            {
                return CalculateRemainingSum(boards.Single()) * Convert.ToInt32(number);
            }
        }
        return 0;
    }

    public int CalculateRemainingSum(string[,] board)
    {
        int sum = 0;
        for(int r = 0; r < 5; r++)
        {
            for(int c = 0; c < 5; c++)
            {
                if(board[r,c] == "X")
                {
                    continue;
                }
                sum += Convert.ToInt32(board[r,c]);
            }
        }
        return sum;
    }

    public bool CheckAllBoardsForWinner(List<string[,]> boards, out string[,] winningBoard)
    {
        winningBoard = new string[5,5];
        foreach(var board in boards)
        {
            if(IsWinningBoard(board))
            {
                winningBoard = board;
                return true;
            }
        }
        return false;
    }

    public bool IsOnlyLooserBoardRemaining(List<string[,]> boards, out List<string[,]> remainingBoards)
    {
        remainingBoards = new List<string[,]>(boards);
        foreach(var board in boards)
        {
            if(!IsWinningBoard(board))
            {
                continue;
            }
            else
            {
                if(boards.Count > 1)
                {
                    remainingBoards.Remove(board);
                }
                else
                {
                    return true;
                }

            }
        }
        return false;
    }

    public bool IsWinningBoard(string[,] board)
    {
        return CheckRowCondition(board) || CheckColumnCondition(board);
    }

    public bool CheckRowCondition(string[,] board)
    {
        for(int r = 0; r < 5; r++)
        {
            if(board[r,0] == "X" && board[r,1] == "X" && board[r,2] == "X" && board[r,3] == "X" && board[r,4] == "X")
            {
                return true;
            }
        }
        return false;
    }

    public bool CheckColumnCondition(string[,] board)
    {
        for(int c = 0; c < 5; c++)
        {
            if(board[0,c] == "X" && board[1,c] == "X" && board[2,c] == "X" && board[3,c] == "X" && board[4,c] == "X")
            {
                return true;
            }
        }
        return false;
    }

    public List<string> ReadInput()
    {
        var input = File.ReadAllLines(Path.Combine("..", "Day04", "Data","input.txt")).ToList();
        return input;
    }

    public List<string> GetAllNumbers(List<string> input)
    {
        return input[0].Split(',').ToList();
    }

    public List<string[,]> CrossOccurences(List<string[,]> boards, string toCross)
    {
        List<string[,]> replacedBoards = new List<string[,]>();
        foreach(var board in boards)
        {
            string[,] replacedBoard = new string[5,5];
            for(int r = 0; r < 5; r++)
            {
                for(int c = 0; c < 5; c++)
                {
                    if(board[r,c] == toCross)
                    {
                        replacedBoard[r,c] = "X";
                    }
                    else{
                        replacedBoard[r,c] = board[r,c];
                    }
                }
            }
            replacedBoards.Add(replacedBoard);
        }
        return replacedBoards;
    }

    public List<string[,]> GetAllBoards(List<string> input)
    {
        List<string[,]> boards = new List<string[,]>();
        string[,] board = new string[5,5];
        int boardrow = 0;
        for(int i = 2; i < input.Count; i++)
        {
            var line = input[i];
            if(line!="")
            {
                var numbers = line.Split(' ').ToList();
                int index = 0;
                foreach(var number in numbers)
                {
                    if(number == "")
                    {
                        continue;
                    }
                    board[boardrow, index] = number; 
                    index++;
                }
                boardrow++;  
            }
            else
            {
                boards.Add(board);
                board = new string[5,5];
                boardrow = 0;
            }
        }
        boards.Add(board);

        return boards;
    }
}
