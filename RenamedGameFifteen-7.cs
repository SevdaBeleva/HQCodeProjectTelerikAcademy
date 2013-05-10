using System;

namespace GameFifteen
{
    class Game15
    {
        static int[,] board = new int[4, 4] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 0 } };
        static int rows = 3, cols = 3;
        static bool isNeighbour = true;
        static int moves;
        static string[] Top5Players = new string[5];
        static int topPlayersMoves = 0;

        static bool CheckNeighbours(int i, int j)
        {
            if ((i == rows - 1 || i == rows + 1) && j == cols)
            {
                return true;
            }
            if ((i == rows) && (j == cols - 1 || j == cols + 1))
            {
                return true;
            }
            return false;
        }

        static void MoveNumber(int number)
        {
            int k = rows, l = cols;
            bool start = true;
            for (int i = 0; i < 4; i++)
            {
                if (start)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (board[i, j] == number)
                        {
                            k = i; l = j;
                            start = false;
                            break;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            isNeighbour = CheckNeighbours(k, l);

            if (!isNeighbour)
            {
                Console.WriteLine("Illegal move!");
            }
            else
            {
                int temp = board[k, l];
                board[k, l] = board[rows, cols];
                board[rows, cols] = temp;
                rows = k;
                cols = l;
                moves++;
                Console.WriteLine(" -------------");

                for (int i = 0; i < 4; i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < 4; j++)
                    {
                        if (board[i, j] >= 10)
                            Console.Write("{0} ", board[i, j]);
                        else if (board[i, j] == 0)
                            Console.Write("   ");
                        else
                            Console.Write(" {0} ", board[i, j]);
                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine(" -------------");
            }
        }

        static bool CheckBoardRange()
        {
            if (board[3, 3] == 0)
            {
                int cells = 1;
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (cells <= 15)
                        {
                            if (board[i, j] == cells)
                            {
                                cells++;
                            }
                            else
                            {
                                return false;
                            }
                        }
                        else
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        static void StartNewGame()
        {
            moves = 0;
            Random random = new Random();
            for (int i = 0; i < 1000; i++)
            {
                int emptyCell = random.Next(3);
                if (emptyCell == 0)
                {
                    int currentRow = rows - 1;
                    int currentCol = cols;
                    if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                    {
                        int temp = board[rows, cols];
                        board[rows, cols] = board[currentRow, currentCol];
                        board[currentRow, currentCol] = temp;
                        rows = currentRow;
                        cols = currentCol;
                    }
                    else
                    {
                        emptyCell++;
                        i--;
                    }
                }
                if (emptyCell == 1)
                {
                    int currentRow = rows;
                    int currentCol = cols + 1;
                    if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                    {
                        int temp = board[rows, cols];
                        board[rows, cols] = board[currentRow, currentCol];
                        board[currentRow, currentCol] = temp;
                        rows = currentRow;
                        cols = currentCol;
                    }
                    else
                    {
                        emptyCell++;
                        i--;
                    }
                }
                if (emptyCell == 2)
                {
                    int currentRow = rows + 1;
                    int currentCol = cols;
                    if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                    {
                        int temp = board[rows, cols];
                        board[rows, cols] = board[currentRow, currentCol];
                        board[currentRow, currentCol] = temp;
                        rows = currentRow;
                        cols = currentCol;
                    }
                    else
                    {
                        emptyCell++;
                        i--;
                    }
                }
                if (emptyCell == 3)
                {
                    int currentRow = rows;
                    int currentCol = cols - 1;
                    if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                    {
                        int temp = board[rows, cols];
                        board[rows, cols] = board[currentRow, currentCol];
                        board[currentRow, currentCol] = temp;
                        rows = currentRow;
                        cols = currentCol;
                    }
                    else
                    {
                        i--;
                    }
                }
            }
            Console.WriteLine(" -------------");
            for (int i = 0; i < 4; i++)
            {
                Console.Write("| ");
                for (int j = 0; j < 4; j++)
                {
                    if (board[i, j] >= 10)
                        Console.Write("{0} ", board[i, j]);
                    else if (board[i, j] == 0)
                        Console.Write("   ");
                    else
                        Console.Write(" {0} ", board[i, j]);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(" -------------");
        }

        static void Move(int i, string result)
        {
            if (i == 0)
            {
                Top5Players[i] = result;
            }
            for (int j = 0; j < i; j++)
            {
                Top5Players[j] = Top5Players[j + 1];
            }
            Top5Players[i] = result;
        }

        static void Main(string[] args)
        {
            while (isNeighbour)
            {
                moves = 0;
                Random random = new Random();
                for (int i = 0; i < 1000; i++)
                {
                    int emptyCell = random.Next(3);
                    if (emptyCell == 0)
                    {
                        int currentRow = rows - 1;
                        int currentCol = cols;
                        if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                        {
                            int temp = board[rows, cols];
                            board[rows, cols] = board[currentRow, currentCol];
                            board[currentRow, currentCol] = temp;
                            rows = currentRow;
                            cols = currentCol;
                        }
                        else
                        {
                            emptyCell++;
                            i--;
                        }
                    }
                    if (emptyCell == 1)
                    {
                        int currentRow = rows;
                        int currentCol = cols + 1;
                        if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                        {
                            int temp = board[rows, cols];
                            board[rows, cols] = board[currentRow, currentCol];
                            board[currentRow, currentCol] = temp;
                            rows = currentRow;
                            cols = currentCol;
                        }
                        else
                        {
                            emptyCell++;
                            i--;
                        }
                    }
                    if (emptyCell == 2)
                    {
                        int currentRow = rows + 1;
                        int currentCol = cols;
                        if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                        {
                            int temp = board[rows, cols];
                            board[rows, cols] = board[currentRow, currentCol];
                            board[currentRow, currentCol] = temp;
                            rows = currentRow;
                            cols = currentCol;
                        }
                        else
                        {
                            emptyCell++;
                            i--;
                        }
                    }
                    if (emptyCell == 3)
                    {
                        int currentRow = rows;
                        int currentCol = cols - 1;
                        if (currentRow >= 0 && currentRow <= 3 && currentCol >= 0 && currentCol <= 3)
                        {
                            int temp = board[rows, cols];
                            board[rows, cols] = board[currentRow, currentCol];
                            board[currentRow, currentCol] = temp;
                            rows = currentRow;
                            cols = currentCol;
                        }
                        else
                        {
                            i--;
                        }
                    }
                }
                Console.WriteLine("Welcome to the game “15”. Please try to arrange the numbers sequentially. Use 'top' to view the top scoreboard, 'restart' to start a new game and 'exit' to quit the game.\n");
                Console.WriteLine(" -------------");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write("| ");
                    for (int j = 0; j < 4; j++)
                    {
                        if (board[i, j] >= 10)
                            Console.Write("{0} ", board[i, j]);
                        else if (board[i, j] == 0)
                            Console.Write("   ");
                        else
                            Console.Write(" {0} ", board[i, j]);
                    }
                    Console.WriteLine("|");
                }
                Console.WriteLine(" -------------");

                bool inBoardRange = CheckBoardRange();
                while (!inBoardRange)
                {
                    Console.Write("Enter a number to move: ");
                    string input = Console.ReadLine();
                    int number;
                    bool isNumber = int.TryParse(input, out number);
                    if (isNumber)
                    {
                        if (number >= 1 && number <= 15)
                        {
                            MoveNumber(number);
                        }
                        else
                        {
                            Console.WriteLine("Illegal move!");
                        }
                    }
                    else
                    {
                        if (input == "exit")
                        {
                            Console.WriteLine("Good bye!");
                            isNeighbour = false;
                            break;
                        }
                        else
                        {
                            if (input == "restart")
                            {
                                StartNewGame();
                            }
                            else
                            {
                                if (input == "top")
                                {
                                    Console.WriteLine("\nScoreboard:");
                                    if (topPlayersMoves != 0)
                                    {
                                        for (int i = 5 - topPlayersMoves; i < 5; i++)
                                        {
                                            Console.WriteLine("{0}", Top5Players[i]);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("-");
                                    }
                                    Console.WriteLine();
                                }
                                else
                                {
                                    Console.WriteLine("Illegal command!");
                                }
                            }
                        }
                    }
                inBoardRange = CheckBoardRange();
                }
                if (inBoardRange)
                {
                    Console.WriteLine("Congratulations! You won the game in {0} moves.", moves);
                    Console.Write("Please enter your name for the top scoreboard: ");
                    string playerName = Console.ReadLine();
                    string playerInfo = moves + " moves by " + playerName;

                    if (topPlayersMoves < 5)
                    {
                        Top5Players[topPlayersMoves] = playerInfo;
                        topPlayersMoves++;
                        Array.Sort(Top5Players);
                    }
                    else
                    {
                        for (int i = 4; i >= 0; i++)
                        {
                            if (Top5Players[i].CompareTo(playerInfo) <= 0)
                            {
                                Move(i, playerInfo);
                            }
                        }
                    }

                    Console.WriteLine("\nScoreboard:");
                    if (topPlayersMoves != 0)
                    {
                        for (int i = 5 - topPlayersMoves; i < 5; i++)
                        {
                            Console.WriteLine("{0}", Top5Players[i]);
                        }
                    }
                    else
                    {
                        Console.WriteLine("-");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
