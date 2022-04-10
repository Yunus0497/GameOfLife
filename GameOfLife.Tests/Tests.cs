using NUnit.Framework;
using GameOfLife.Core;

namespace GameOfLife.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void NullPointerTest()
        {
            Core.GameOfLife obj = new Core.GameOfLife();
            Assert.IsNotNull(obj.Grid);
        }

        [Test]
        public void IsInitializeGridTest()
        {
            Core.GameOfLife obj = new Core.GameOfLife();
            int[,] grid = new int[,] { { 1, 0 }, { 0, 1 } };
            var isInitialized = obj.InitializeGrid(2, 2, grid);
            Assert.AreEqual(isInitialized, true);
            Assert.AreEqual(grid[0, 1], obj.Grid[0, 1]);
        }

        [Test]
        public void PreventMultipleInitializationTest()
        {
            Core.GameOfLife obj = new Core.GameOfLife();
            int[,] grid = new int[,] { { 1, 0 }, { 0, 1 } };
            obj.InitializeGrid(2, 2, grid);
            var isInitialized = obj.InitializeGrid(2, 2, grid);
            Assert.AreEqual(isInitialized, false);
        }


        [Test]
        public void Get0thGenerationTest()
        {
            Core.GameOfLife obj = new Core.GameOfLife();
            int[,] grid = new int[,] { { 1, 0 }, { 0, 1 } };
            obj.InitializeGrid(2, 2, grid);
            int[,] output = obj.GetNthGeneration(0);
            Assert.AreEqual(grid[0, 1], output[0, 1]);
            Assert.AreEqual(grid[1, 1], output[1, 1]);
        }

        [Test]
        public void GetNthGenerationTest()
        {
            Core.GameOfLife obj = new Core.GameOfLife();
            int[,] grid = new int[,] { { 0, 0, 0 }, { 1, 1, 1 }, { 0, 0, 0 } };
            obj.InitializeGrid(3, 3, grid);
            int[,] output = obj.GetNthGeneration(3);
            Assert.AreEqual(1 , output[0, 1]);
            Assert.AreEqual(1, output[1, 1]);
            Assert.AreEqual(1, output[2, 1]);
        }

    }
}