using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		private GameState currentState;
		private Snake s;
		private MenuController menu;
		private Level level;
		private Fruit f;
		private int delay = 400;
		private int time = 400;


		public GameController ()
		{
			f = new Fruit ();
			level = new Level ();
			s = new Snake ();
			menu = new MenuController ();
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

				System.Timers.Timer timer2 = new System.Timers.Timer(delay);
				timer2.AutoReset = false;
				timer2.Elapsed += (sender, e) => menu.MoveTitle ();
				timer2.Start ();

				menu.HandleUserInputMenu ();
	

				if (menu.OptionSelected == 1)
				{
					timer2.Stop ();
					delay = time;
					SwinGame.Delay (400);
					currentState = GameState.Level1;
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

				delay += time;
									
			}
			else if (currentState == GameState.Level1)
			{
				f.Draw ();
				level.Drawlevel1 ();
				s.Draw ();

				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWall ();
				SnakeCheckFruit ();
			}
			else if (currentState == GameState.Level2)
			{
				f.Draw ();
				level.Drawlevel2 ();
				s.Draw ();

				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWall ();
				SnakeCheckFruit ();
			}
			else if (currentState == GameState.Level3)
			{
				f.Draw ();
				level.Drawlevel3 ();
				s.Draw ();

				System.Timers.Timer timer = new System.Timers.Timer(delay);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => s.MoveForward ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWall ();
				SnakeCheckFruit ();
			}

		}

		public void SnakeCheckWall()
		{

		}

		public void SnakeCheckFruit()
		{

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