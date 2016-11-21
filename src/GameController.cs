using System;
using System.Collections.Generic;
using System.Linq;
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
<<<<<<< HEAD
		private int delay = 80;
		private int time = 80;
		private int resetsetting = 80;
		private int delaytitle = 80;
		private int timetitle = 80;
		int counter=0;
		float vol = 0.4F;
		int level1limit = 25;
		int level2limit = 35;
		int level3limit = 40;
		int level0limit = 50;

 		const int Counter_Left= 375;
		const int Counter_Top=0;
		System.Timers.Timer timer2 = new System.Timers.Timer();
		System.Timers.Timer timer = new System.Timers.Timer();
=======
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
>>>>>>> origin

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
<<<<<<< HEAD
			SwinGame.LoadMusic ("megalovania snake.mp3");
			SwinGame.LoadMusic ("Eternal Shrine Maiden.mp3");
			SwinGame.LoadMusic ("Maple Dream.mp3");
			SwinGame.LoadMusic ("game over.mp3");
			SwinGame.LoadMusic ("Lotus Land.mp3");
			SwinGame.LoadMusic ("Selene Light.mp3");

			timer.Interval = delay;
			timer2.Interval = delaytitle;

			timer.AutoReset = false;
			timer.Elapsed += (sender, e) => s.MoveForward ();

			timer2.AutoReset = false;
			timer2.Elapsed += (sender, e) => menu.MoveTitle ();
=======
>>>>>>> origin

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
<<<<<<< HEAD

			s.Direction = d;
		}

		public void PlayGame()
		{
			
			//Viewing the menu where the title, buttons are drawn.
			if (currentState == GameState.ViewingMenu)
			{
				SwinGame.DrawBitmap ("menubackground.png", 0, 0);
				SwinGame.DrawBitmap ("copyright.png", 0, 22 * 25);
				SwinGame.DrawText ("James, Ernest, Jacky, Reuben, Sem 2 2016 SWE20001", Color.Red, 2*25, 23 * 25);
				menu.DrawButton ();
				menu.DrawTitle ();

				timer2.Start ();

				menu.HandleUserInputMenu ();
	

				if (menu.OptionSelected == 1)
				{
					timer2.Stop ();
					delay = time;
					s.Head.X = 4;
					s.Head.Y = 5;
					s.Direction = DirectionEnum.Right;
					currentState = GameState.AnnouceGame;
					previouState = GameState.Level1;
					SwinGame.FadeMusicOut (2500);
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
					time = 100;
					delay = 100;
					resetsetting = 100;
					timer.Interval = delay;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 5)
				{
					menu.SettingSelected = 2;
					time = 80;
					delay = 80;
					resetsetting = 70;
					timer.Interval = delay;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 6)
				{
					menu.SettingSelected = 3;
					time = 50;
					delay = 50;
					resetsetting = 50;
					timer.Interval = delay;
					menu.DrawSettings ();
					menu.ResetTitle ();
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 7)
				{
					menu.DrawSettingMusic();
				}

				else if (menu.OptionSelected == 15)
				{
					currentState = GameState.ViewingCredits;
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 16)
				{
					SwinGame.DrawBitmap("GameInstruction.png", 460, 245);
				}
				delaytitle += timetitle;
								
			}
			else if (currentState == GameState.Pause)
			{
				if (previouState == GameState.Level1)
				{
					SwinGame.ClearScreen (Color.LightGreen);
					level.Drawlevel1 ();
				}
				else if (previouState == GameState.Level2)
				{
					SwinGame.ClearScreen (Color.PeachPuff);
					level.Drawlevel2 ();
				}
				else if (previouState == GameState.Level3)
				{
					SwinGame.ClearScreen (Color.Gold);
					level.Drawlevel3 ();
				}

				if (previouState == GameState.Level0)
				{
					SwinGame.ClearScreen (Color.Black);
					f.Draw ();
					s.DrawInvert ();
					menu.DrawPauseButtonsInvert ();
					menu.DrawTitleInvert ();
					SwinGame.DrawBitmap ("pausetext.png", 10 * 25, 2 * 25);
					menu.HandleUserInputPauseMenu ();
				
				}
				else
				{
					f.Draw ();
					s.Draw ();
					menu.DrawPauseButtons ();
					menu.DrawTitle ();
					SwinGame.DrawBitmap ("pausetext.png", 10 * 25, 2 * 25);
					menu.HandleUserInputPauseMenu ();
				
				}

				if (menu.OptionSelected == 3)
				{
					currentState = GameState.QuitProgram;
				}
				else if (menu.OptionSelected == 8)
				{
					currentState = previouState;
					menu.OptionSelected = 0;
				}
				else if (menu.OptionSelected == 9)
				{
					SwinGame.StopMusic ();
					SwinGame.SetMusicVolume (1F);
					SwinGame.PlayMusic ("Lotus Land.mp3");
					currentState = GameState.ViewingMenu;
					menu.ResetTitle ();
					s.ResetSnake ();
					counter = 0;
					delay = time;
					delaytitle = timetitle;
				}

			}
			else if (currentState == GameState.Level1)
			{
				SwinGame.ClearScreen (Color.LightGreen);
				level.Drawlevel1 ();
				s.Draw ();
				f.Draw ();
				DrawCounter ();
				timer.Start ();

				HandleUserInput ();
				delay += time;

				SnakeCheckWallLevel1 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				SnakeCheckItself ();
				GameStateControl ();

			}
			else if (currentState == GameState.Level2)
			{
				SwinGame.ClearScreen (Color.PeachPuff);
				level.Drawlevel2 ();
				s.Draw ();
				f.Draw ();
				DrawCounter ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWallLevel2 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				SnakeCheckItself ();
				GameStateControl ();
			}
			else if (currentState == GameState.Level3)
			{
				SwinGame.ClearScreen (Color.Gold);
				level.Drawlevel3 ();
				s.Draw ();
				f.Draw ();
				DrawCounter ();
				timer.Start ();

				HandleUserInput ();

				delay += time;
				SnakeCheckWallLevel3 ();
				SnakeCheckFruit ();
				SnakeCheckSides ();
				SnakeCheckItself ();
				GameStateControl ();
			}
			else if (currentState == GameState.Level0)
			{
				SwinGame.ClearScreen (Color.Black);
				if (counter >= 10 && counter < 20 && currentState == GameState.Level0)
				{
					level.DrawInvertLevel1 ();
					SnakeCheckWallLevel1 ();
				}
				else if (counter >= 20 && counter < 30 && currentState == GameState.Level0)
				{
					level.DrawInvertLevel2 ();
					SnakeCheckWallLevel2 ();
				}
				else if (counter >= 30 && counter < 40 && currentState == GameState.Level0)
				{
					level.DrawInvertLevel3 ();
					SnakeCheckWallLevel3 ();
				}

				s.DrawInvert ();
				f.Draw ();
				DrawCounter ();
				timer.Start ();
				HandleUserInput ();
				delay += time;
				SnakeCheckFruit ();
				SnakeCheckSides ();
				SnakeCheckItself ();
				GameStateControl ();
			}
			else if (currentState == GameState.GameOver)
			{
				if (previouState == GameState.Level1)
				{
					SwinGame.ClearScreen (Color.LightGreen);
					level.Drawlevel1 ();
					s.Draw ();
					s.DrawGameOverEyes ();
					f.Draw ();
					SwinGame.DrawBitmap ("gameover.gif", 150, 200);
					SwinGame.DrawText ("Press any key to go back to the main menu", Color.Blue, 250, 380);
				}
				else if (previouState == GameState.Level2)
				{
					SwinGame.ClearScreen (Color.PeachPuff);
					level.Drawlevel2 ();
					s.Draw ();
					s.DrawGameOverEyes ();
					f.Draw ();
					SwinGame.DrawBitmap ("gameover.gif", 150, 200);
					SwinGame.DrawText ("Press any key to go back to the main menu", Color.Blue, 250, 380);
				}
				else if (previouState == GameState.Level3)
				{
					SwinGame.ClearScreen (Color.Gold);
					level.Drawlevel3 ();
					s.Draw ();
					s.DrawGameOverEyes ();
					f.Draw ();
					SwinGame.DrawBitmap ("gameover.gif", 150, 200);
					SwinGame.DrawText ("Press any key to go back to the main menu", Color.Blue, 250, 380);
				}
				else if (previouState == GameState.Level0)
				{
					SwinGame.ClearScreen (Color.Black);
					for (int i = -1; i < 33; i++)
					{
						for (int y = -1; y < 41; y++)
						{
							SwinGame.DrawText (("YOU DIED"), Color.Red, i * 70, y * 15);
						}

					}
				}
				counter = 0;
				delay = resetsetting;
				time = resetsetting;
				delaytitle = timetitle;
				HandleUserGameOverInput ();
			}
			else if (currentState == GameState.AnnouceGame)
			{
				int i = 0;

				if (previouState == GameState.Level1)
				{
					level.Drawlevel1 ();
					f.GenerateRanLevel1 (s, w);
				}
				else if (previouState == GameState.Level2)
				{
					level.Drawlevel2 ();
					f.GenerateRanLevel2 (s, w);
				}
				else if (previouState == GameState.Level3)
				{
					level.Drawlevel3 ();
					f.GenerateRanLevel3 (s, w);
				}
				else if (previouState == GameState.Level0)
				{
					SwinGame.ClearScreen (Color.Black);
				}

				if (previouState != GameState.Level0)
				{
					while (i != 7)
					{
						DrawAnnouceGameText (i);
						SwinGame.Delay (500);
						i++;
						SwinGame.RefreshScreen (60);
					}

					if (previouState == GameState.Level1)
					{
						SwinGame.SetMusicVolume (0.7F);
						SwinGame.PlayMusic ("Selene Light.mp3");
					}
					else if (previouState == GameState.Level2)
					{
						SwinGame.SetMusicVolume (0.7F);
						SwinGame.PlayMusic ("Eternal Shrine Maiden.mp3");
					}
					else if (previouState == GameState.Level3)
					{
						SwinGame.SetMusicVolume (0.8F);
						SwinGame.PlayMusic ("Alice Maestra.mp3");
					}
				}
				else if (previouState == GameState.Level0)
				{
					while (i != 10)
					{
						DrawAnnouceGameText (i);
						i++;
						SwinGame.RefreshScreen (60);
					}
					SwinGame.Delay (1000);
					SwinGame.SetMusicVolume (0.8F);
					SwinGame.PlayMusic ("megalovania snake.mp3");
				}
				currentState = previouState;

			}
			else if (currentState == GameState.ViewingCredits)
			{
				SwinGame.DrawBitmap("snakecredit.png", 0, 0);
				SwinGame.RefreshScreen (60);
				SwinGame.Delay (3000);
				SwinGame.ProcessEvents ();
				currentState = GameState.ViewingMenu;
			}

=======

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
>>>>>>> origin
		}
			

<<<<<<< HEAD
		public void DrawAnnouceGameText(int i)
		{
			if (previouState != GameState.Level0)
			{
				if (i == 0)
				{
					SwinGame.DrawBitmap ("level.png", 1 * 25, 2 * 25);
				}
				else if (i == 1)
				{
					if (previouState == GameState.Level1)
					{
						SwinGame.DrawBitmap ("level1.png", 17 * 25, 2 * 25);
					}
					else if (previouState == GameState.Level2)
					{
						SwinGame.DrawBitmap ("level2.png", 17 * 25, 2 * 25);
					}
					else if (previouState == GameState.Level3)
					{
						SwinGame.DrawBitmap ("level3.png", 17 * 25, 2 * 25);
					}
				}
				else if (i == 2)
				{
					SwinGame.DrawBitmap ("one.png", 6 * 25, 15 * 25);
				}
				else if (i == 3)
				{
					SwinGame.DrawBitmap ("two.png", 14 * 25, 15 * 25);
				}
				else if (i == 4)
				{
					SwinGame.DrawBitmap ("three.png", 22 * 25, 15 * 25);
				}
				else if (i == 5)
				{
					SwinGame.DrawBitmap ("go.png", 12 * 25, 8 * 25);
				}
			}
			else if (previouState == GameState.Level0)
			{
				if (i == 0)
				{
					SwinGame.DrawBitmap ("finallevel.gif", 1 * 25, 2 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 1)
				{
					SwinGame.DrawBitmap ("level0.gif", 22 * 25, 2 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 2)
				{
					SwinGame.Delay (1000);
					SwinGame.DrawBitmap ("finallevel0.png", 7* 25, 7 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 3)
				{
					SwinGame.DrawBitmap ("finallevelslash.png", 12 * 25, 7 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 4)
				{
					SwinGame.DrawBitmap ("finallevel50.png", 17 * 25, 7 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 5)
				{
					SwinGame.DrawBitmap ("finallevel1.png", 6 * 25, 15 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 6)
				{
					SwinGame.DrawBitmap ("finallevel2.png", 14 * 25, 15 * 25);
					SwinGame.Delay (500);
				}
				else if (i == 7)
				{
				  SwinGame.DrawBitmap ("finallevel3.png", 22 * 25, 15 * 25);
				  SwinGame.Delay (500);
				}
			}
		}
			

		public void SnakeCheckWallLevel1()
		{
			// Check for Wall 1

			if (s.Head.X == w.Wall1x && s.Head.Y >= w.Wall1y && s.Head.Y <= w.Wall1y + w.wallLenght - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);
			}

			// Check for Wall 2

			if (s.Head.X == w.Wall2x && s.Head.Y >= w.Wall2y && s.Head.Y <= w.Wall2y + w.wallLenght - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;				
				SwinGame.Delay (2000);

			}
		
=======
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
>>>>>>> origin
		}


		public void SnakeCheckWallLevel2()
		{
			// Check for Wall 3
<<<<<<< HEAD
			if (s.Head.Y == w.wall3_y && s.Head.X >= w.wall3_x && s.Head.X <= w.wall3_x + w.wall3_width1 - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);

			}else if (s.Head.X == w.wall3_x && s.Head.Y >= w.wall3_y && s.Head.Y <= w.wall3_y + w.wall3_lenght2 - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);
=======

			if (s.Head.Y == w.wall3_y && s.Head.X >= w.wall3_x && s.Head.X <= w.wall3_x + w.wall3_width1 - 1) {

				currentState = GameState.GameOver;

			}else if (s.Head.X == w.wall3_x && s.Head.Y >= w.wall3_y && s.Head.Y <= w.wall3_y + w.wall3_lenght2 - 1) {

				currentState = GameState.GameOver;
>>>>>>> origin
			}

			// Check for Wall 4

			if (s.Head.Y == w.wall4_y && s.Head.X >= w.wall4_x && s.Head.X <= w.wall4_x + w.wall4_width1 - 1) {
<<<<<<< HEAD

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);

			} else if (s.Head.X == w.wall4_w && s.Head.Y >= w.wall4_y && s.Head.Y <= w.wall4_y + w.wall4_lenght2 - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);
=======

				currentState = GameState.GameOver;

			} else if (s.Head.X == w.wall4_w && s.Head.Y >= w.wall4_y && s.Head.Y <= w.wall4_y + w.wall4_lenght2 - 1) {

				currentState = GameState.GameOver;
>>>>>>> origin
			}

			// Check for Wall 5

			if (s.Head.Y == w.wall5_w && s.Head.X >= w.wall5_x && s.Head.X <= w.wall5_x + w.wall5_width1 - 1) {

<<<<<<< HEAD
				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);

			} else if (s.Head.X == w.wall5_x && s.Head.Y >= w.wall5_y && s.Head.Y <= w.wall5_y + w.wall5_lenght2 - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);
=======
				currentState = GameState.GameOver;

			} else if (s.Head.X == w.wall5_x && s.Head.Y >= w.wall5_y && s.Head.Y <= w.wall5_y + w.wall5_lenght2 - 1) {

				currentState = GameState.GameOver;
>>>>>>> origin
			}


			if (s.Head.Y == w.wall6_w && s.Head.X >= w.wall6_x && s.Head.X <= w.wall6_x + w.wall6_width1 - 1) {

<<<<<<< HEAD
				SwinGame.PlaySoundEffect ("crash.wav",vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);

			} else if (s.Head.X == w.wall4_w && s.Head.Y >= w.wall6_y && s.Head.Y <= w.wall6_y + w.wall6_lenght2 - 1) {

				SwinGame.PlaySoundEffect ("crash.wav", vol);
				currentState = GameState.GameOver;
				SwinGame.Delay (2000);
			}
				
		}

		public void SnakeCheckWallLevel3 ()
		{
			SnakeCheckWallLevel1 ();
			SnakeCheckWallLevel2 ();
		}

=======
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

>>>>>>> origin
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
			//Count = string.Format ("{0}", counter);
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

<<<<<<< HEAD

			//Created for the sprint work 
			if (s.Head.X == f.X && s.Head.Y == f.Y)
			{
				s.IncreaseLenght ();
				if (currentState == GameState.Level1)
				{
					f.GenerateRanLevel1 (s, w);
				}
				else if (currentState == GameState.Level2)
				{
					f.GenerateRanLevel2 (s, w);
				}
				else if (currentState == GameState.Level3)
				{
					f.GenerateRanLevel3 (s, w);
				}
				else if (currentState == GameState.Level0)
				{
					f.GenerateRanLevel3 (s, w);
				}

				Counter ();
				SwinGame.PlaySoundEffect ("bump.aiff", 0.6F);

				if (counter == 10 && currentState == GameState.Level0)
				{
					for (int i = 0; i < 6; i++)
					{
						delay = 45;
						time = 45;
						timer.Interval = delay;
						s.IncreaseLenght ();
					}
				}
					
				if (counter == 20 && currentState == GameState.Level0)
				{
					for (int i = 0; i < 7; i++)
					{
						s.IncreaseLenght ();
						delay = 40;
						time = 40;
						timer.Interval = delay;

					}
				}

				if (counter == 30 && currentState == GameState.Level0)
				{
					for (int i = 0; i < 8; i++)
					{
						s.IncreaseLenght ();
						delay = 35;
						time = 35;
						timer.Interval = delay;
					}
				}

				if (counter == 40 && currentState == GameState.Level0)
				{
					for (int i = 0; i < 9; i++)
					{
						s.IncreaseLenght ();
						delay = 30;
						time = 30;
						timer.Interval = delay;
					}
				}

			}
		}

		//edit by Reuben
		public void Counter()
		{

			counter++;		
			//Count = string.Format ("{0}", counter);
		}

		public void GameStateControl()
		{
			if (counter == level1limit && currentState == GameState.Level1)
			{
				SwinGame.FadeMusicOut (2500);
				SwinGame.Delay (2000);
				counter = 0;
				s.ResetSnake ();
				s.Head.X = 10;
				s.Head.Y = 10;
				delay = resetsetting;
				time = resetsetting;
				f.GenerateRanLevel2 (s, w);
				currentState = GameState.AnnouceGame;
				previouState = GameState.Level2;

			}
			else if (counter == level2limit && currentState == GameState.Level2)
			{
				SwinGame.FadeMusicOut (2500);
				SwinGame.Delay (2000);
				counter = 0;
				s.ResetSnake ();
				s.Head.X = 8;
				s.Head.Y = 10;
				delay = resetsetting;
				time = resetsetting;
				f.GenerateRanLevel3 (s, w);
				currentState = GameState.AnnouceGame;
				previouState = GameState.Level3;
			
			}
			else if (counter == level3limit && currentState == GameState.Level3)
			{
				SwinGame.FadeMusicOut (2500);
				SwinGame.Delay (2000);
				counter = 0;
				s.ResetSnake ();
				s.Head.X = 15;
				s.Head.Y = 11;
				delay = 50;
				time = 50;
				f.GenerateRanLevel3 (s, w);
				timer.Interval = delay;
				currentState = GameState.AnnouceGame;
				previouState = GameState.Level0;
				SwinGame.ClearScreen (Color.Black);
				s.Draw ();
				SwinGame.Delay (3000);
			}
			else if (counter == level0limit && currentState == GameState.Level0)
			{
				SwinGame.StopMusic ();
				SwinGame.Delay (2000);
				int i = 0;
				SwinGame.SetMusicVolume (0.7F);
				SwinGame.PlayMusic ("Maple Dream.mp3");
				menu.ResetTitle ();
				while (i < 15)
				{
					SwinGame.ClearScreen (Color.White);
					s.DrawWin ();
					SwinGame.Delay (500);
					SwinGame.RefreshScreen (60);
					i++;
				}
				s.ResetSnake ();
				delay = resetsetting;
				time = resetsetting;
				timer.Interval = resetsetting;
				currentState = GameState.ViewingCredits;
				previouState = GameState.ViewingMenu;
			}
			else if (previouState == GameState.Level0 && currentState == GameState.GameOver)
			{
				SwinGame.SetMusicVolume (1F);
				SwinGame.PlayMusic ("horrordrone.mp3");
			}
			else if (previouState != GameState.Level0 && currentState == GameState.GameOver)
			{
				SwinGame.SetMusicVolume (1F);
				SwinGame.PlayMusic ("game over.mp3", 0);
			}
		}

=======
>>>>>>> origin
		public void DrawCounter()
		{
			if (currentState == GameState.Level1)
			{
<<<<<<< HEAD
				SwinGame.DrawText ((counter + "/" + level1limit), Color.Blue, Counter_Left, Counter_Top);
			}
			else if (currentState == GameState.Level2)
			{
				SwinGame.DrawText ((counter + "/" + level2limit), Color.Blue, Counter_Left, Counter_Top);
			}
			else if (currentState == GameState.Level3)
			{
				SwinGame.DrawText ((counter + "/" + level3limit), Color.Blue, Counter_Left, Counter_Top);
			}
			else if (currentState == GameState.Level0 && counter < 40)
			{
				for (int i = 0; i < 32; i++)
				{
					SwinGame.DrawText ((counter + "/" + level0limit), Color.Red, i * 40, Counter_Top + 2);
					SwinGame.DrawText ((counter + "/" + level0limit), Color.Red, i * 40, 23 * 25);
				}

				for (int i = 0; i < 23; i++)
				{
					SwinGame.DrawText ((counter + "/" + level0limit), Color.Red, 0, i * 25);
					SwinGame.DrawText ((counter + "/" + level0limit), Color.Red, 31 * 25-10, i * 25);
				}
			}
			else if (currentState == GameState.Level0 && counter >= 40)
			{
				for (int i = 0; i < 32; i++)
				{

					for (int y = 0; y < 25; y++)
					{
						SwinGame.DrawText ((counter + "/" + level0limit), Color.Red, i * 45, y *25);
					}

				}
=======
				SwinGame.DrawText ((counter+"/"+level1limit),Color.Blue,Counter_Left,Counter_Top);
			}
			else if (currentState ==GameState.Level2)
			{
				SwinGame.DrawText ((counter+"/"+level2limit),Color.Blue,Counter_Left,Counter_Top);
			}
			else if (currentState ==GameState.Level3)
			{
				SwinGame.DrawText ((counter+"/"+level3limit),Color.Blue,Counter_Left,Counter_Top);
>>>>>>> origin
			}
		}

		public void HandleUserInput ()
		{
			if ((SwinGame.KeyDown (KeyCode.vk_a) || SwinGame.KeyDown(KeyCode.vk_LEFT)) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down))
			{
				s.Direction = DirectionEnum.Left;
			}
			else if ((SwinGame.KeyDown (KeyCode.vk_d) || SwinGame.KeyDown(KeyCode.vk_RIGHT)) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down))
			{
				s.Direction = DirectionEnum.Right;
			}
			else if ((SwinGame.KeyDown (KeyCode.vk_w) || SwinGame.KeyDown(KeyCode.vk_UP)) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left))
			{
				s.Direction = DirectionEnum.Up;
			}
			else if ((SwinGame.KeyDown (KeyCode.vk_s) || SwinGame.KeyDown(KeyCode.vk_DOWN)) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left))
			{
				s.Direction = DirectionEnum.Down;
			}
			else if (SwinGame.KeyDown (KeyCode.vk_ESCAPE))
			{
				currentState = GameState.Pause;
			}

		}

<<<<<<< HEAD
		public void HandleUserGameOverInput()
=======
		public void SnakeCheckSides ()
>>>>>>> origin
		{
			if (SwinGame.AnyKeyPressed())
			{
				currentState = GameState.ViewingMenu;
				SwinGame.StopMusic ();
				SwinGame.PlayMusic ("Lotus Land.mp3");
				menu.ResetTitle ();
				s.ResetSnake ();
				f.GenerateRan ();
			}
		}

<<<<<<< HEAD
		public void SnakeCheckSides ()
		{

=======
>>>>>>> origin
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

		public void SnakeCheckItself()
		{
			for (int i = 1; i < s.SnakeParts.Count - 1; i++)
			{
				if (s.SnakeParts [i].X == s.Head.X && s.SnakeParts [i].Y == s.Head.Y)
				{
					SwinGame.Delay (500);
					currentState = GameState.GameOver;
					break;
				}
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