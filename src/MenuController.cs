using System;
using SwinGameSDK;

namespace MyGame
{
	public class MenuController
	{
		private const int TileWidth = 25;
		private const int TileHeight = 25;
		private int i;
		private int y;
		private int mute=0;
		public int music=1;
		private Snake s = new Snake();
		private Snake n = new Snake();
		private Snake a = new Snake();
		private Snake a1 = new Snake();
		private Snake k = new Snake();
		private Snake k1 = new Snake();
		private Snake k2 = new Snake();
		private Snake e = new Snake();
		private Snake e1 = new Snake();

		public MenuController ()
		{
			s.Head.X = 3;
			n.Head.X = 9;
			a.Head.X = 15;
			k.Head.X = 19;
			e.Head.X = 28;

			a1.Head.X = 14;
			k1.Head.X = 19;
			k2.Head.X = 19;
			e1.Head.X = 24;

			s.Direction = DirectionEnum.Right;
			n.Direction = DirectionEnum.Up;
			a.Direction = DirectionEnum.Up;
			k.Direction = DirectionEnum.Up;
			e.Direction = DirectionEnum.Left;

			a1.Direction = DirectionEnum.Right;
			k1.Direction = DirectionEnum.Right;
			k2.Direction = DirectionEnum.Right;
			e1.Direction = DirectionEnum.Right;

			s.Head.Y = 5;
			n.Head.Y = 6;
			a.Head.Y = 6;
			k.Head.Y = 6;
			e.Head.Y = 5;

			k1.Head.Y = 3;
			k2.Head.Y = 3;
			a1.Head.Y = 3;
			e1.Head.Y = 3;
		}

		public int OptionSelected
		{
			get{ return i; }
			set{ i = value; }
		}

		public int SettingSelected
		{
			get{ return y; }
			set{ y = value; }
		}

		public int Mute
		{
			get{ return mute; }
		}

		public void DrawButton()
		{

			if (i == 1)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 240 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
			else if (i == 2)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 365 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
			else if (i == 3)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 490 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
			else if (i == 16)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 302 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
			else if (i == 7)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 425 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}

			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 240, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 302, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 365, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 425, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle(Color.Cyan, 13 * TileWidth, 478, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 530, 5*TileWidth, TileHeight+5);

			SwinGame.DrawBitmap ("Playtext.png", 14*TileWidth+10, 10*TileHeight-10);
			SwinGame.DrawBitmap ("tutorialtext.png", 13*TileWidth+5, 302);
			SwinGame.DrawBitmap ("Settingstext.png", 345, 15*TileHeight-10);
			SwinGame.DrawBitmap ("Music.png", 14 * TileWidth + 5, 425);
			SwinGame.DrawBitmap ("Credits.png", 350, 480);
			SwinGame.DrawBitmap ("Quittext.png", 360, 21*TileHeight+5);

			if (y == 1)
			{
				SwinGame.DrawText ("Easy", Color.Red, 14 * TileWidth + 20, 11 * TileHeight);
			}
			else if (y == 2)
			{
				SwinGame.DrawText ("Medium", Color.Red, 14 * TileWidth + 10, 11 * TileHeight);
			}
			else if (y == 3)
			{
				SwinGame.DrawText ("Hard", Color.Red, 14 * TileWidth + 20, 11 * TileHeight);
			}
			//SwinGame.DrawText ("Settings", Color.Red, 360, 15 * TileHeight);
			//SwinGame.DrawText ("Quit", Color.Red, 375, 20 * TileHeight);

		}

		public void HandleUserInputMenu()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				i = Selected(SwinGame.PointAt(SwinGame.MouseX (), SwinGame.MouseY ()));
			}
		}

		public void HandleUserInputPauseMenu()
		{
			if (SwinGame.MouseClicked (MouseButton.LeftButton))
			{
				i = PauseSelected(SwinGame.PointAt(SwinGame.MouseX (), SwinGame.MouseY ()));
			}
		}

		public int PauseSelected(Point2D pt)
		{
			if (SwinGame.PointInRect (pt, 13 * TileWidth, 240, 5 * TileWidth, TileHeight + 5))
			{
				//resume
				return 8;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 364, 5 * TileWidth, TileHeight + 5))
			{
				//end gam
				return 9;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 490, 5 * TileWidth, TileHeight + 5))
			{
				//quit
				return 3;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 302, 5 * TileWidth, TileHeight + 5))
			{
				//mute
				if (mute == 0)
				{
					SwinGame.PauseMusic ();
					mute = 1;
				}
				//unmute
				else if(mute == 1)
				{
					SwinGame.ResumeMusic ();
					mute = 0;
				}
				return 0;
			}
			else
			{
				return 0;
			}
		}
	
		public int Selected(Point2D pt)
		{
			if (SwinGame.PointInRect (pt, 13 * TileWidth, 240, 5 * TileWidth, TileHeight+5))
			{
				//play
				return 1;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 365, 5 * TileWidth, TileHeight+5))
			{
				//settings
				return 2;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 530, 5 * TileWidth, TileHeight+5))
			{
				//quit
				return 3;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 365, 5 * TileWidth, TileHeight) && i == 2)
			{
				//easy
				y = 1;
				return 4;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 405, 5 * TileWidth, TileHeight) && i == 2)
			{
				//mediuum
				y = 2;
				return 5;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 450, 5 * TileWidth, TileHeight) && i == 2)
			{
				//medium
				y = 3;
				return 6;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 478, 5 * TileWidth, TileHeight + 5))
			{
				//Credits Author: Jacky
				return 15;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 302, 5 * TileWidth, TileHeight + 5))
			{
				//instructions
				return 16;
			}
			else if (SwinGame.PointInRect (pt, 13 * TileWidth, 425, 5 * TileWidth, TileHeight+5))
			{
				//Music
				return 7;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 355, 5 * TileWidth, TileHeight) && i == 7)
			{
				//title
				music = 1;
				SwinGame.SetMusicVolume (1F);
				SwinGame.PlayMusic ("Lotus Land.mp3");
				return 7;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 385, 5 * TileWidth, TileHeight) && i == 7)
			{
				//Level1
				music = 2;
				SwinGame.SetMusicVolume (0.8F);
				SwinGame.PlayMusic ("Selene Light.mp3");
				return 7;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 415, 5 * TileWidth, TileHeight) && i == 7)
			{
				//Level2
				music = 3;
				SwinGame.SetMusicVolume (0.8F);
				SwinGame.PlayMusic ("Eternal Shrine Maiden.mp3");
				return 7;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 445, 5 * TileWidth, TileHeight) && i == 7)
			{
				//Level3
				music = 4;
				SwinGame.SetMusicVolume (0.8F);
				SwinGame.PlayMusic ("Alice Maestra.mp3");
				return 7;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 475, 5 * TileWidth, TileHeight) && i == 7)
			{
				//Mute
				if (mute == 0)
				{
					SwinGame.PauseMusic ();
					mute = 1;
				}
				//unmute
				else if(mute == 1)
				{
					SwinGame.ResumeMusic ();
					mute = 0;
				}
				return 7;
			}
			if (SwinGame.PointInRect (pt, 20 * TileWidth, 240, 5 * TileWidth, TileHeight + 5)&& i == 1)
			{
				//level1
				return 20;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 280, 5 * TileWidth, TileHeight + 5)&& i == 1)
			{
				//level2
				return 21;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 320, 5 * TileWidth, TileHeight + 5)&& i == 1)
			{
				//level3
				return 22;
			}
			else if (SwinGame.PointInRect (pt, 20 * TileWidth, 360, 5 * TileWidth, TileHeight+5)&& i == 1)
			{
				//level0
				return 23;
			}
			else
			{
				return 0;
			}

		}

		public void DrawSettings()
		{
			if (y == 1)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 365 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}
			else if (y == 2)
			{
				SwinGame.FillRectangle (Color.Red, 20*TileWidth-4, 405-4, (5*TileWidth)+8, TileWidth+8);
			}
			else if (y == 3)
			{
				SwinGame.FillRectangle (Color.Red, 20*TileWidth-4, 450-4, (5*TileWidth)+8, TileWidth+8);
			}

			SwinGame.FillRectangle (Color.Orange, 20 * TileWidth, 365, 5*TileWidth, TileHeight);
			SwinGame.FillRectangle (Color.Orange, 20 * TileWidth, 405, 5*TileWidth, TileHeight);
			SwinGame.FillRectangle (Color.Orange, 20 * TileWidth, 450, 5*TileWidth, TileHeight);

			SwinGame.DrawBitmap ("Easytext.png", 540, 365);
			SwinGame.DrawBitmap ("Mediumtext.png", 522, 405);
			SwinGame.DrawBitmap ("Hardtext.png", 536, 450);

			//SwinGame.DrawText ("Easy", Color.Red, 550, 375);
			//SwinGame.DrawText ("Medium", Color.Red, 542, 405);
			//SwinGame.DrawText ("Hard", Color.Red, 550, 435);
		}


		public void DrawLevelSelect()
		{

			SwinGame.FillRectangle (Color.DarkBlue, 20 * TileWidth, 240, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.DarkBlue, 20 * TileWidth, 280, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.DarkBlue, 20 * TileWidth, 320, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Black, 20 * TileWidth, 360, 5*TileWidth, TileHeight+5);

			SwinGame.DrawBitmap ("Lvl1.png", 526, 240);
			SwinGame.DrawBitmap ("Lvl2.png", 526, 280);
			SwinGame.DrawBitmap ("Lvl3.png", 526, 320);
			SwinGame.DrawBitmap ("Lvl0.png", 526, 360);

		}

		public void DrawSettingMusic()
		{
			if (music == 1)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 355 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}
			else if (music == 2)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 385 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}
			else if (music == 3)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 415 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}
			else if (music == 4)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 445 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}

			if (mute == 1)
			{
				SwinGame.FillRectangle (Color.Red, 20 * TileWidth - 4, 475 - 4, (5 * TileWidth) + 8, TileWidth + 8);
			}

			//title
			SwinGame.FillRectangle (Color.Purple, 20 * TileWidth, 355, 5*TileWidth, TileHeight);
			//lvl1
			SwinGame.FillRectangle (Color.Purple, 20 * TileWidth, 385, 5*TileWidth, TileHeight);
			//lvl2
			SwinGame.FillRectangle (Color.Purple, 20 * TileWidth, 415, 5*TileWidth, TileHeight);
			//lvl3
			SwinGame.FillRectangle (Color.Purple, 20 * TileWidth, 445, 5*TileWidth, TileHeight);
			//mute
			SwinGame.FillRectangle (Color.Purple, 20 * TileWidth, 475, 5*TileWidth, TileHeight);

			SwinGame.DrawBitmap ("Title.png", 536, 355);
			SwinGame.DrawBitmap ("Lvl1.png", 525, 385);
			SwinGame.DrawBitmap ("Lvl2.png", 525, 415);
			SwinGame.DrawBitmap ("Lvl3.png", 525, 445);
			SwinGame.DrawBitmap ("Mute.png", 536, 475);
		}

		public void DrawTitle()
		{
			s.Draw ();
			n.Draw ();
			a.Draw ();
			k.Draw ();
			e.Draw ();
			e1.Draw ();

			a1.Draw ();
			k1.Draw ();
			k2.Draw ();
		}

		public void DrawTitleInvert()
		{
			s.DrawInvert ();
			n.DrawInvert ();
			a.DrawInvert ();
			k.DrawInvert ();
			e.DrawInvert ();
			e1.DrawInvert ();

			a1.DrawInvert ();
			k1.DrawInvert ();
			k2.DrawInvert ();
		}

		public void DrawPauseButtons()
		{
			if (mute == 1)
			{
				SwinGame.FillRectangle (Color.Blue, 13 * TileWidth - 2, 302 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 240, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 302, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 364, 5*TileWidth, TileHeight+5);
			SwinGame.FillRectangle (Color.Cyan, 13 * TileWidth, 490, 5*TileWidth, TileHeight+5);

			SwinGame.DrawBitmap ("Resume.png", 14*TileWidth, 10*TileHeight-10);
			SwinGame.DrawBitmap ("mute.png", 360, 12*TileHeight+5);
			SwinGame.DrawBitmap ("End game.png", 340, 15*TileHeight-10);
			SwinGame.DrawBitmap ("Quittext.png", 360, 20*TileHeight-10);

		}

		public void DrawPauseButtonsInvert()
		{
			if (mute == 1)
			{
				SwinGame.FillRectangle (Color.White, 13 * TileWidth - 2, 302 - 2, (5 * TileWidth) + 4, TileWidth + 9);
			}
				SwinGame.FillRectangle (Color.Red, 13 * TileWidth, 240, 5*TileWidth, TileHeight+5);
				SwinGame.FillRectangle (Color.Red, 13 * TileWidth, 302, 5*TileWidth, TileHeight+5);
				SwinGame.FillRectangle (Color.Red, 13 * TileWidth, 364, 5*TileWidth, TileHeight+5);
				SwinGame.FillRectangle (Color.Red, 13 * TileWidth, 490, 5*TileWidth, TileHeight+5);

				SwinGame.DrawBitmap ("Resume.png", 14*TileWidth, 10*TileHeight-10);
				SwinGame.DrawBitmap ("mute.png", 360, 12*TileHeight+5);
				SwinGame.DrawBitmap ("End game.png", 340, 15*TileHeight-10);
				SwinGame.DrawBitmap ("Quittext.png", 360, 20*TileHeight-10);
		}

		public void MoveTitle()
		{

			if (s.Head.X != 7 && s.Direction == DirectionEnum.Right)
			{
				s.IncreaseLenght ();
				s.MoveForward ();
			}
			else if (s.Head.X == 7 && s.Head.Y > 3)
			{
				s.Direction = DirectionEnum.Up;
				s.IncreaseLenght ();
				s.MoveForward ();
			}
			else if (s.Head.X != 4 && s.Head.Y == 3)
			{
				s.Direction = DirectionEnum.Left;
				s.IncreaseLenght ();
				s.MoveForward ();
			}
			else if (s.Head.X == 4 && s.Head.Y > 1)
			{
				s.Direction = DirectionEnum.Up;
				s.IncreaseLenght ();
				s.MoveForward ();
			}
			else if (s.Head.X != 7)
			{
				s.Direction = DirectionEnum.Right;
				s.IncreaseLenght ();
				s.MoveForward ();
			}

			if (n.Head.Y > 1 && n.Direction == DirectionEnum.Up)
			{
				n.IncreaseLenght ();
				n.MoveForward ();
			}
			else if (n.Head.Y == 1 && n.Head.X < 11)
			{
				n.Direction = DirectionEnum.Right;
				n.IncreaseLenght ();
				n.MoveForward ();
			}
			else if (n.Head.X == 11 && n.Head.Y < 5)
			{
				n.Direction = DirectionEnum.Down;
				n.IncreaseLenght ();
				n.MoveForward ();
			}
			else if (n.Head.X < 13 && n.Head.Y == 5)
			{
				n.Direction = DirectionEnum.Right;
				n.IncreaseLenght ();
				n.MoveForward ();
			}
			else if(n.Head.X == 13 && n.Head.Y > 1)
			{
				n.Direction = DirectionEnum.Up;
				n.IncreaseLenght ();
				n.MoveForward ();
			}

			if (a.Head.Y > 1 && a.Direction == DirectionEnum.Up)
			{
				a.IncreaseLenght ();
				a.MoveForward ();
			}
			else if (a.Head.X < 17 && a.Head.Y == 1)
			{
				a.Direction = DirectionEnum.Right;
				a.IncreaseLenght ();
				a.MoveForward ();
			}
			else if (a.Head.X == 17 && a.Head.Y < 5)
			{
				a.Direction = DirectionEnum.Down;
				a.IncreaseLenght ();
				a.MoveForward ();
			}

			if (a1.Head.X < 17)
			{
				a1.IncreaseLenght ();
				a1.MoveForward ();
			}

			if (k.Head.Y > 1 && k.Direction == DirectionEnum.Up)
			{
				k.IncreaseLenght ();
				k.MoveForward ();
			}

			if (k1.Head.X < 21 && k1.Direction == DirectionEnum.Right)
			{
				k1.IncreaseLenght ();
				k1.MoveForward ();
			}
			else if (k1.Head.X == 21 && k1.Head.Y != 1)
			{
				k1.Direction = DirectionEnum.Up;
				k1.IncreaseLenght ();
				k1.MoveForward ();
			}
			else if (k1.Head.Y == 1 && k1.Head.X != 22)
			{
				k1.Direction = DirectionEnum.Right;
				k1.IncreaseLenght ();
				k1.MoveForward ();
			}

			if (k2.Head.X < 22 && k2.Direction == DirectionEnum.Right)
			{
				k2.IncreaseLenght ();
				k2.MoveForward ();
			}
			else if (k2.Head.X == 22 && k2.Head.Y != 5)
			{
				k2.Direction = DirectionEnum.Down;
				k2.IncreaseLenght ();
				k2.MoveForward ();
			}

			if (e.Head.X > 24 && e.Direction == DirectionEnum.Left)
			{
				e.IncreaseLenght ();
				e.MoveForward ();
			}
			else if (e.Head.X == 24 && e.Head.Y != 1)
			{
				e.Direction = DirectionEnum.Up;
				e.IncreaseLenght ();
				e.MoveForward ();
			}
			else if (e.Head.Y == 1 && e.Head.X != 27)
			{
				e.Direction = DirectionEnum.Right;
				e.IncreaseLenght ();
				e.MoveForward ();
			}

			if (e1.Head.X < 27)
			{
				e1.IncreaseLenght ();
				e1.MoveForward ();
			}

		

		}
			

		public void ResetTitle()
		{
			s.SnakeParts.RemoveRange(0,s.SnakeParts.Count-1);
			n.SnakeParts.RemoveRange (0,n.SnakeParts.Count-1);
			a.SnakeParts.RemoveRange (0,a.SnakeParts.Count-1);
			k.SnakeParts.RemoveRange (0,k.SnakeParts.Count-1);
			e.SnakeParts.RemoveRange (0,e.SnakeParts.Count-1);
			a1.SnakeParts.RemoveRange (0,a1.SnakeParts.Count-1);
			k1.SnakeParts.RemoveRange (0,k1.SnakeParts.Count-1);
			k2.SnakeParts.RemoveRange (0,k2.SnakeParts.Count-1);
			e1.SnakeParts.RemoveRange (0,e1.SnakeParts.Count-1);

			s.Head.X = 3;
			n.Head.X = 9;
			a.Head.X = 15;
			k.Head.X = 19;
			e.Head.X = 28;

			a1.Head.X = 14;
			k1.Head.X = 19;
			k2.Head.X = 19;
			e1.Head.X = 24;

			s.Direction = DirectionEnum.Right;
			n.Direction = DirectionEnum.Up;
			a.Direction = DirectionEnum.Up;
			k.Direction = DirectionEnum.Up;
			e.Direction = DirectionEnum.Left;

			a1.Direction = DirectionEnum.Right;
			k1.Direction = DirectionEnum.Right;
			k2.Direction = DirectionEnum.Right;
			e1.Direction = DirectionEnum.Right;

			s.Head.Y = 5;
			n.Head.Y = 6;
			a.Head.Y = 6;
			k.Head.Y = 6;
			e.Head.Y = 5;

			k1.Head.Y = 3;
			k2.Head.Y = 3;
			a1.Head.Y = 3;
			e1.Head.Y = 3;
		}
	}
}