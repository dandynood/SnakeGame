using System;
using NUnit.Framework;
using SwinGameSDK;



namespace MyGame
{
	[TestFixture ()]
	public class GameControllerUnitTests
	{
		[Test ()]
		public void GameInitializedTest ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();


			// Check that the initial position of the snake is initialized
			Assert.IsTrue (GameControllerTest.S.Head.X.ToString() == "5");
			Assert.IsTrue (GameControllerTest.S.Head.Y.ToString() == "5");


			// Check that the initial GameState is Level 0
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.Level0);


			// Check that the direction of the snake is initialized to the right
			Assert.IsTrue (GameControllerTest.S.Direction == DirectionEnum.Right);


			// Check that a random number is generated for the position of the fruit
			Assert.IsTrue (GameControllerTest.F.X >= 0 && GameControllerTest.F.X < 32);
			Assert.IsTrue (GameControllerTest.F.Y >= 0 && GameControllerTest.F.Y < 24);

		}

		[Test ()]
		public void SnakeCheckSidesTest ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();

			GameControllerTest.S.Head.X = 12;
			GameControllerTest.S.Head.Y = 15;

			GameControllerTest.SnakeCheckSides ();

			// Game State should remain at Level 0 because snake is within Game Screen
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.Level0);
			// Set snake to be out of range
			GameControllerTest.S.Head.X = -5;
			GameControllerTest.S.Head.Y = 50;
			GameControllerTest.SnakeCheckSides ();
			// Game State should change to GameOver because snake has died
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);


		}


	}
}
