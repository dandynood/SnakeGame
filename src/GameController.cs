using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		GameState currentState;
		Snake s;
		Level level;
		Fruit f;
		int delay = 250;
		int time = 250;

		public GameController ()
		{


		}


		public int Delay
		{
			get{ return delay; }
			set{ delay = value; }
		}

		public int Time
		{
			get{ return time; }
			set{ time = value; }
		}

		public GameState CurrentState 
		{
			get{ return currentState; }
			set{ currentState = value; }
		}

		public void Initialized()
		{
			f = new Fruit ();
			level = new Level ();
			s = new Snake ();
			currentState = GameState.Level0;
			f.GenerateRan ();

			s.Head.X = 5;
			s.Head.Y = 5;

			s.IncreaseLenght ();

			s.Direction = DirectionEnum.Right;
		}

		public void PlayGame()
		{
			f.Draw ();
			level.Drawlevel2 ();
			s.Draw ();

			System.Timers.Timer timer = new System.Timers.Timer (delay);
			timer.AutoReset = false;
			timer.Elapsed += (sender, e) => s.MoveForward ();
			timer.Start ();

			HandleUserInput ();

			SnakeCheckWall ();
			SnakeCheckFruit();

			delay += time;
		}

		public void SnakeCheckWall()
		{

		}

		//Check the fruit and when it is eaten, snake will increase length and at the same time fruit relocation
		public void SnakeCheckFruit()
		{
			//Created for the sprint work 
			if (s.Head.X == f.X && s.Head.Y == f.Y)
			{
				s.IncreaseLenght ();
				f.GenerateRan ();
			}
		}

		public void HandleUserInput ()
		{
			if (SwinGame.KeyDown (KeyCode.vk_a) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down)) {
				s.Direction = DirectionEnum.Left;
			} else if (SwinGame.KeyDown (KeyCode.vk_d) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down)) {
				s.Direction = DirectionEnum.Right;
			} else if (SwinGame.KeyDown (KeyCode.vk_w) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left)) {
				s.Direction = DirectionEnum.Up;
			} else if (SwinGame.KeyDown (KeyCode.vk_s) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left)) {
				s.Direction = DirectionEnum.Down;
			}

		}

		public void SnakeCheckSides (Snake s)
		{


			if (s.Head.Y < 0 || s.Head.Y > 23 || s.Head.X > 31 || s.Head.X < 0) {
				SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

			}

		}



		/*	public void SnakeCheckWalls(Snake s)
			{ 
				if (s.Direction == DirectionEnum.Up) {
					if (s.Head.Y < 0) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);
					}
				} else if (s.Direction == DirectionEnum.Down) {
					if (s.Head.Y > 24) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);
					}
				} else if (s.Direction == DirectionEnum.Right) {
					if (s.Head.X > 32) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);
					}
				} else if (s.Direction == DirectionEnum.Left) {
					if (s.Head.X < 0) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);
					}
				}
			}*/
	}
}