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

				SnakeCheckWallLevel3();


			
				SnakeCheckItself ();
				

				delay += time;

			} else if (currentState == GameState.GameOver) {

				SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

			}
		}

		public void SnakeCheckWallLevel1()
		{
			// Check for Wall 1

			if (s.Head.X == w.Wall1x && s.Head.Y >= w.Wall1y && s.Head.Y <= w.Wall1y + w.wallLenght - 1) {

				currentState = GameState.GameOver;

			}

			// Check for Wall 2

			if (s.Head.X == w.Wall2x && s.Head.Y >= w.Wall2y && s.Head.Y <= w.Wall2y + w.wallLenght - 1) {

				currentState = GameState.GameOver;

			}

		}


		public void SnakeCheckWallLevel2()
		{
			// Check for Wall 3

			if (s.Head.Y == w.wall3_y && s.Head.X >= w.wall3_x && s.Head.X <= w.wall3_x + w.wall3_width1 - 1) {

				currentState = GameState.GameOver;

			}else if (s.Head.X == w.wall3_x && s.Head.Y >= w.wall3_y && s.Head.Y <= w.wall3_y + w.wall3_lenght2 - 1) {

				currentState = GameState.GameOver;
			}

			// Check for Wall 4

			if (s.Head.Y == w.wall4_y && s.Head.X >= w.wall4_x && s.Head.X <= w.wall4_x + w.wall4_width1 - 1) {

				currentState = GameState.GameOver;

			} else if (s.Head.X == w.wall4_w && s.Head.Y >= w.wall4_y && s.Head.Y <= w.wall4_y + w.wall4_lenght2 - 1) {

				currentState = GameState.GameOver;
			}

			// Check for Wall 5

			if (s.Head.Y == w.wall5_w && s.Head.X >= w.wall5_x && s.Head.X <= w.wall5_x + w.wall5_width1 - 1) {

				currentState = GameState.GameOver;

			} else if (s.Head.X == w.wall5_x && s.Head.Y >= w.wall5_y && s.Head.Y <= w.wall5_y + w.wall5_lenght2 - 1) {

				currentState = GameState.GameOver;
			}


			if (s.Head.Y == w.wall6_w && s.Head.X >= w.wall6_x && s.Head.X <= w.wall6_x + w.wall6_width1 - 1) {

				currentState = GameState.GameOver;

			} else if (s.Head.X == w.wall4_w && s.Head.Y >= w.wall6_y && s.Head.Y <= w.wall6_y + w.wall6_lenght2 - 1) {

				currentState = GameState.GameOver;
			}



			

		}

		public void SnakeCheckWallLevel3 ()
		{
			SnakeCheckWallLevel1 ();
			SnakeCheckWallLevel2 ();
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

		public void SnakeCheckItself ()
		{

			for (int i = 1; i < s.SnakeParts.Count; i++) {

				if (s.SnakeParts[0].X == s.SnakeParts [i].X && s.SnakeParts[0].Y == s.SnakeParts [i].Y ) {

					CurrentState = GameState.GameOver;
				}

			}

		}
	

	}
}