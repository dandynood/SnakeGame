using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		private GameState currentState;
		private GameState previouState;
		private Snake s;
		private MenuController menu;
		private Level level;
		private Fruit f;
		Wall w;
		private int delay = 150;
		private int time = 150;
		private int delaytitle = 80;
		private int timetitle = 80;
		int counter=0;
		int level1limit = 10;
		int level2limit = 25;
		int level3limit = 35;
 		const int Counter_Left= 375;
		const int Counter_Top=0;

		public GameController ()
		{
			f = new Fruit ();
			level = new Level ();
			s = new Snake ();
			menu = new MenuController ();
			w = new Wall ();
			menu.SettingSelected = 2;
			currentState = GameState.ViewingMenu;
			f.GenerateRan ();

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

		public void Initialized(float x, float y, DirectionEnum d)
		{
			s.Head.X = x;
			s.Head.Y = y;

			s.Direction = d;
		}

		public void PlayGame()
		{
			//Viewing the menu where the title, buttons are drawn.
			if (currentState == GameState.ViewingMenu)
			{
				menu.DrawButton ();
				menu.DrawTitle ();

				System.Timers.Timer timer2 = new System.Timers.Timer(delaytitle);
				timer2.AutoReset = false;
				timer2.Elapsed += (sender, e) => menu.MoveTitle ();
				timer2.Start ();

				menu.HandleUserInputMenu ();
	

				if (menu.OptionSelected == 1)
				{
					timer2.Stop ();
					delay = time;
					SwinGame.Delay (400);
					s.Head.X = 4;
					s.Head.Y = 5;
					s.Direction = DirectionEnum.Right;
					currentState = GameState.Level1;
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 2)
				{
					menu.DrawSettings ();
				}
				else if (menu.OptionSelected == 3)
				{
					currentState = GameState.QuitProgram;
				}
				else if (menu.OptionSelected == 4)
				{
					menu.SettingSelected = 1;
					time = 400;
					delay = 400;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 5)
				{
					menu.SettingSelected = 2;
					time = 150;
					delay = 150;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}

				else if (menu.OptionSelected == 6)
				{
					menu.SettingSelected = 3;
					time = 50;
					delay = 50;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}

				else if (menu.OptionSelected == 7)
				{
					menu.DrawSettingMusic();
				}

				else if (menu.OptionSelected == 10)
				{
					menu.SettingSelected = 1;
					SwinGame.PlaySoundEffect ("SMusic1.wav");
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				//Title
				else if (menu.OptionSelected == 10)
				{
					menu.SettingSelected = 1;

					SwinGame.PlaySoundEffect ("SMusic2.wav");
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				//Level 1
				else if (menu.OptionSelected == 11)
				{
					menu.SettingSelected = 1;

					SwinGame.PlaySoundEffect ("SMusic2.wav");
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				//Level2
				else if (menu.OptionSelected == 12)
				{
					menu.SettingSelected = 1;

					SwinGame.PlaySoundEffect ("SMusic2.wav");
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				//Level3
				else if (menu.OptionSelected == 13)
				{
					menu.SettingSelected = 1;

					SwinGame.PlaySoundEffect ("SMusic2.wav");
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				//mute
				else if (menu.OptionSelected == 14)
				{
					menu.SettingSelected = 1;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				delaytitle += timetitle;
								
			}
	
			else if (currentState == GameState.Level1)
			{
				f.Draw ();
				level.Drawlevel1 ();
				s.Draw ();
				DrawCounter ();
				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWallLevel1 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				//SnakeCheckItself ();
				GameStateControl ();

			}
			else if (currentState == GameState.Level2)
			{
				f.Draw ();
				level.Drawlevel2 ();
				s.Draw ();
				DrawCounter ();
				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWallLevel2 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				//SnakeCheckFruit ();
				GameStateControl ();
			}
			else if (currentState == GameState.Level3)
			{
				f.Draw ();
				level.Drawlevel3 ();
				s.Draw ();
				DrawCounter ();
				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWallLevel3 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				//SnakeCheckItself ();
				GameStateControl ();
			}
			else if (currentState == GameState.GameOver)
			{
				s.Draw ();
				f.Draw ();
				if (previouState == GameState.Level1)
				{
					level.Drawlevel1 ();
				}
				else if (previouState == GameState.Level2)
				{
					level.Drawlevel2 ();
				}
				else if (previouState == GameState.Level3)
				{
					level.Drawlevel3 ();
				}
				SwinGame.DrawText ("YOU DIED!", Color.Blue, 365, 280);
				currentState = GameState.ViewingMenu;
				menu.ResetTitle ();
				s.ResetSnake ();
				counter = 0;
				delay = time;
				delaytitle = timetitle;
				SwinGame.Delay (1000);
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
			previouState = GameState.Level1;
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
				
			previouState = GameState.Level2;
		}

		public void SnakeCheckWallLevel3 ()
		{
			SnakeCheckWallLevel1 ();
			SnakeCheckWallLevel2 ();
			previouState = GameState.Level3;
		}

		/*public void SnakeCheckItself ()
		{

			for (int i = 1; i < s.SnakeParts.Count; i++) {

				if (s.Head.X == s.SnakeParts [i].X && s.Head.Y == s.SnakeParts [i].Y) {

					CurrentState = GameState.GameOver;
				}

			}

		}*/

		//Check the fruit and when it is eaten, snake will increase length and at the same time fruit relocation
		public void SnakeCheckFruit()
		{
			//Created for the sprint work 
			if (s.Head.X == f.X && s.Head.Y == f.Y)
			{
				s.IncreaseLenght ();
				f.GenerateRan ();
				Counter ();
			}
		}

		//edit by Reuben
		public void Counter()
		{

			counter++;		
		}

		public void GameStateControl()
		{
			if (counter == level1limit && currentState == GameState.Level1)
			{
				SwinGame.Delay (2000);
				counter = 0;
				s.ResetSnake ();
				s.Head.X = 10;
				s.Head.Y = 10;
				delay = time;
				currentState = GameState.Level2;

			}
			else if (counter == level2limit && currentState == GameState.Level2)
			{
				counter = 0;
				s.ResetSnake ();
				s.Head.X = 8;
				s.Head.Y = 10;
				delay = time;
				currentState = GameState.Level3;
				SwinGame.Delay (2000);
			}
			else if (counter == level3limit && currentState == GameState.Level3)
			{
				level.Drawlevel3();
			}
		}

		public void DrawCounter()
		{
			if (currentState == GameState.Level1)
			{
				SwinGame.DrawText ((counter+"/"+level1limit),Color.Blue,Counter_Left,Counter_Top);
			}
			else if (currentState ==GameState.Level2)
			{
				SwinGame.DrawText ((counter+"/"+level2limit),Color.Blue,Counter_Left,Counter_Top);
			}
			else if (currentState ==GameState.Level3)
			{
				SwinGame.DrawText ((counter+"/"+level3limit),Color.Blue,Counter_Left,Counter_Top);
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

		public void SnakeCheckSides ()
		{

			if (s.Head.Y < 0)
			{
				s.Head.Y = 23;
			}
			else if (s.Head.Y > 23)
			{
				s.Head.Y = 0;
			}
			else if (s.Head.X < 0)
			{
				s.Head.X = 31;
			}
			else if (s.Head.X > 31)
			{
				s.Head.X = 0;
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