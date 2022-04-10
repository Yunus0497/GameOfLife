using System;

namespace GameOfLife.Core
{
    public class GameOfLife
    {
        private static int _Rows;
        private static int _Cols;
        public int[,] Grid { get; private set; }

        public GameOfLife()
        {
            _Rows = 0;
            _Cols = 0;
            Grid = new int[ _Rows, _Cols] ;
        }
        /// <summary>
        /// Initializes the grid with Generation 0 population
        /// </summary>
        /// <param name="rows">Number of rows in the grid</param>
        /// <param name="columns">Number of columns in the grid</param>
        /// <param name="initialGrid">Generation 0 population grid</param>
        /// <returns>Boolean value to indicate if the initialization was success</returns>
        public bool InitializeGrid(int rows, int columns, int[,] initialGrid)
        {
            if (_Rows == 0)
            {
                _Rows = rows;
                _Cols = columns;
                Grid = initialGrid;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Computes the grid population for the target generation
        /// </summary>
        /// <param name="targetGeneration">Target generation</param>
        /// <returns>The grid with the population of target generation</returns>
        public int[,] GetNthGeneration(int targetGeneration)
        {
            int[,] currentGen = new int[_Rows, _Cols];
            Array.Copy(this.Grid, 0, currentGen, 0, this.Grid.Length);
            int[,] GenN = new int[ _Rows, _Cols];
            GenN[0,1] = 25;
            int liveNeighbors = 0;
            if (targetGeneration == 0)
                return this.Grid;
            for (int k = 1; k <= targetGeneration; k++)
            {
                for (int i = 0; i < _Rows; i++)
                {
                    for (int j = 0; j < _Cols; j++)
                    {
                        liveNeighbors = countNeighbors(i, j, currentGen);

                        if (liveNeighbors < 2 || liveNeighbors > 3)
                            GenN[i, j] = 0;
                        else if (liveNeighbors == 3)
                            GenN[i, j] = 1;
                        else if (liveNeighbors == 2 || liveNeighbors == 3)
                            GenN[i, j] = currentGen[i, j];
                    }
                }
                Array.Copy(GenN,0,currentGen,0,GenN.Length);
                for (int i = 0; i < _Rows; i++)
                {
                    for (int j = 0; j < _Cols; j++)
                    {
                        Console.Write(GenN[i, j] + " ");
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
            return GenN;
        }

        /// <summary>
        /// Calculates the number of live neighbors for a given cell co-ordinates and current grid
        /// </summary>
        /// <param name="i">Row index of the cell</param>
        /// <param name="j">Column index of the cell</param>
        /// <param name="currentGen">Current grid population</param>
        /// <returns>Number of live neighbors surrounding the target cell</returns>
        private int countNeighbors(int i, int j, int[,] currentGen)
        {
            int liveNeighbors = 0;
            if (i < _Rows - 1)
            {
                liveNeighbors += currentGen[i + 1, j];
                if (j < _Cols - 1)
                    liveNeighbors += currentGen[i + 1, j + 1];
                if (j != 0)
                    liveNeighbors += currentGen[i + 1, j - 1];
            }

            if (i != 0)
            {
                liveNeighbors += currentGen[i - 1, j];
                if (j < _Cols - 1)
                    liveNeighbors += currentGen[i - 1, j + 1];
                if (j != 0)
                    liveNeighbors += currentGen[i - 1, j - 1];
            }
            if (j != 0)
                liveNeighbors += currentGen[i, j - 1];
            if (j < _Cols - 1)
                liveNeighbors += currentGen[i, j + 1];

            return liveNeighbors;
        }        
    }
}
