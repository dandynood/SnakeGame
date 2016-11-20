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
		Wall w;
		int delay = 400;
		int time = 400;
		public int CheckItselfCounter;

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

		public GameState CurrentState1 {
			get {
				return currentState;
			}
		}

		public Snake S {
			get {
				return s;
			}

		}

		public Level Level {
			get {
				return level;
			}
		}

		public Fruit F {
			get {
				return f;
			}

		}

		public void Initialized()
		{
			f = new Fruit ();
			level = new Level ();
			s = new Snake ();
			w = new Wall ();
			currentState = GameState.Level0;
			F.GenerateRan ();



			S.Head.X = 5;
			S.Head.Y = 5;


			S.Direction = DirectionEnum.Right;
		}

		public void PlayGame()
		{
			if (currentState == GameState.Level0) {

				F.Draw ();
				Level.Drawlevel3 ();


				S.Draw ();

				System.Timers.Timer timer = new System.Timers.Timer (delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => S.MoveForward ();
				timer.Start ();

				HandleUserInput ();


			

				

				delay += time;

			} else if (currentState == GameState.GameOver) {

				SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

			}
		}



		public void HandleUserInput ()
		{
			if (SwinGame.KeyDown (KeyCode.vk_a) && (S.Direction == DirectionEnum.Up || S.Direction == DirectionEnum.Down)) {
				S.Direction = DirectionEnum.Left;
			} else if (SwinGame.KeyDown (KeyCode.vk_d) && (S.Direction == DirectionEnum.Up || S.Direction == DirectionEnum.Down)) {
				S.Direction = DirectionEnum.Right;
			} else if (SwinGame.KeyDown (KeyCode.vk_w) && (S.Direction == DirectionEnum.Right || S.Direction == DirectionEnum.Left)) {
				S.Direction = DirectionEnum.Up;
			} else if (SwinGame.KeyDown (KeyCode.vk_s) && (S.Direction == DirectionEnum.Right || S.Direction == DirectionEnum.Left)) {
				S.Direction = DirectionEnum.Down;
			}

		}

		public void SnakeCheckSides ()
		{

			if (s.Head.Y < 0 || s.Head.Y > 23 || s.Head.X > 31 || s.Head.X < 0) {
				CurrentState = GameState.GameOver ;
			}

		}

	

	}
}