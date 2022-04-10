using System;

GameOfLife.Core.GameOfLife obj = new GameOfLife.Core.GameOfLife();
int rows = 25;
int columns = 25;
int[,] gen0 = new int[rows, columns];

Console.WriteLine("**********Game Of Life **********");

Console.WriteLine("Which generation's population are you interested to see?");
int targetGeneration = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Please enter the number of live cells:");
int liveCellCount = Convert.ToInt32(Console.ReadLine());

while(liveCellCount > 0)
{
    Console.WriteLine("Please enter the row index of live cell (1-based index): ");
    int i = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Please enter the column index of live cell (1-based index): ");
    int j = Convert.ToInt32(Console.ReadLine());

    gen0[i - 1, j - 1] = 1;
    liveCellCount--;
}

obj.InitializeGrid(rows, columns, gen0);
var output = obj.GetNthGeneration(targetGeneration);

Console.WriteLine("Generation 0 :");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write(gen0[i, j] + " ");
    }
    Console.Write("\n");
}

Console.WriteLine($"Generation {targetGeneration} :");
for (int i = 0; i < rows; i++)
{
    for(int j =0; j < columns; j++)
    {
        Console.Write(output[i, j] + " ");
    }
    Console.Write("\n");
}
