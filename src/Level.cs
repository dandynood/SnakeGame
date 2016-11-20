using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Level
	{
		public Level ()
		{

		}
		//Draw level 1 map
		public void Drawlevel1()
		{
			Wall DWall = new Wall();

			DWall.DrawWall1 ();
			DWall.DrawWall2 ();
		}

		//Draw Level 2 map
		public void Drawlevel2(){
			Wall DWall = new Wall();

			DWall.DrawWall3 ();
			DWall.DrawWall4 ();
			DWall.DrawWall5 ();
			DWall.DrawWall6 ();
		}

		//Draw Level 3 map
		public void Drawlevel3()
		{
			Wall DWall = new Wall();

			DWall.DrawWall1 ();
			DWall.DrawWall2 ();
			DWall.DrawWall3 ();
			DWall.DrawWall4 ();
			DWall.DrawWall5 ();
			DWall.DrawWall6 ();

		}

		public void DrawInvertLevel1()
		{
			Wall DWall = new Wall ();
			DWall.InvertedWallLevel1 ();
		}

		public void DrawInvertLevel2()
		{
			Wall DWall = new Wall ();
			DWall.InvertedWallLevel2 ();
		}

		public void DrawInvertLevel3()
		{
			Wall DWall = new Wall ();
			DWall.InvertedWallLevel1 ();
			DWall.InvertedWallLevel2 ();
		}

		public bool isAt(float X, float Y)
		{
			return false;
		}
			
	}
}

