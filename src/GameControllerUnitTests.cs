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

		[Test ()]
		public void SnakeCheckWallLevel1Test ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();

			Wall w = new Wall ();

			// Put Snake somewhere within wall 1
			GameControllerTest.S.Head.X = w.Wall1x;
			GameControllerTest.S.Head.Y = w.Wall1y + 3;
			// Check Whether Snake is in Wall 1
			GameControllerTest.SnakeCheckWallLevel1 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);

			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 2
			GameControllerTest.S.Head.X = w.Wall2x;
			GameControllerTest.S.Head.Y = w.Wall2y + 4;
			// Check Whether Snake is in Wall 2
			GameControllerTest.SnakeCheckWallLevel1 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



		}

		[Test ()]
		public void SnakeCheckWallLevel2Test ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();

			Wall w = new Wall ();

			// Put Snake somewhere within wall 3
			GameControllerTest.S.Head.X = w.wall3_x + 3;
			GameControllerTest.S.Head.Y = w.wall3_y;
			// Check Whether Snake is in Wall 3
			GameControllerTest.SnakeCheckWallLevel2 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 4
			GameControllerTest.S.Head.X = w.wall4_x + 2;
			GameControllerTest.S.Head.Y = w.wall4_y;
			// Check Whether Snake is in Wall 4
			GameControllerTest.SnakeCheckWallLevel2 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 5
			GameControllerTest.S.Head.X = w.wall5_x + 4;
			GameControllerTest.S.Head.Y = w.wall5_w;
			// Check Whether Snake is in Wall 5
			GameControllerTest.SnakeCheckWallLevel2 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 6
			GameControllerTest.S.Head.X = w.wall4_w;
			GameControllerTest.S.Head.Y = w.wall6_y + 2;
			// Check Whether Snake is in Wall 6
			GameControllerTest.SnakeCheckWallLevel2 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);


		}

		[Test ()]
		public void SnakeCheckWallLevel3Test ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();

			Wall w = new Wall ();

			// Put Snake somewhere within wall 1
			GameControllerTest.S.Head.X = w.Wall1x;
			GameControllerTest.S.Head.Y = w.Wall1y + 3;
			// Check Whether Snake is in Wall 1
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);

			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 2
			GameControllerTest.S.Head.X = w.Wall2x;
			GameControllerTest.S.Head.Y = w.Wall2y + 4;
			// Check Whether Snake is in Wall 2
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);


			// Put Snake somewhere within wall 3
			GameControllerTest.S.Head.X = w.wall3_x + 3;
			GameControllerTest.S.Head.Y = w.wall3_y;
			// Check Whether Snake is in Wall 3
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 4
			GameControllerTest.S.Head.X = w.wall4_x + 2;
			GameControllerTest.S.Head.Y = w.wall4_y;
			// Check Whether Snake is in Wall 4
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 5
			GameControllerTest.S.Head.X = w.wall5_x + 4;
			GameControllerTest.S.Head.Y = w.wall5_w;
			// Check Whether Snake is in Wall 5
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the wall
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);



			// Set GameState back to level 0
			GameControllerTest.CurrentState = GameState.Level0;
			// Put Snake somewhere within wall 6
			GameControllerTest.S.Head.X = w.wall4_w;
			GameControllerTest.S.Head.Y = w.wall6_y + 2;
			// Check Whether Snake is in Wall 6
			GameControllerTest.SnakeCheckWallLevel3 ();
			// Game State should change to GameOver because snake has hit the walls
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);


		}

		[Test ()]
		public void SnakeCheckItselfTest ()
		{
			GameController GameControllerTest = new GameController ();

			GameControllerTest.Initialized ();

			// Increase the length of the snake in order to be tested.

			GameControllerTest.S.IncreaseLenght ();
			GameControllerTest.S.IncreaseLenght ();
			GameControllerTest.S.IncreaseLenght ();
			GameControllerTest.S.IncreaseLenght ();
			GameControllerTest.S.IncreaseLenght ();
			GameControllerTest.S.IncreaseLenght ();
			

			// Set the snake so that its head collide with it's body
			GameControllerTest.S.SnakeParts [0].X = 10;
			GameControllerTest.S.SnakeParts [0].Y = 10;

			GameControllerTest.S.SnakeParts [4].X = 10;
			GameControllerTest.S.SnakeParts [4].Y = 10;

			// Snake Check itself
			GameControllerTest.SnakeCheckItself ();

			// Check that the game has ended because the snake died
			Assert.IsTrue (GameControllerTest.CurrentState == GameState.GameOver);

		}
	
	}
}
