using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Wall
	{
		//Tile's area
		public const int TileWidth  = 25;
		private const int TileHeight = 25;

		//strait wall
		public static float wall1_x = 14;
		private float wall1_y = 8;
		private float wall2_x = 18;
		private float wall2_y = 8;
		private int wall1_width = 1;
		private int wall1_lenght= 6;

		//Corner Wall
		private int wall3_x=1;
		private int wall3_y=0;
		private int wall3_width1=6;
		private int wall3_width2=1;
		private int wall3_lenght1=1;
		private int wall3_lenght2=6;

		private int wall4_x=25;
		private int wall4_y=0;
		private int wall4_w=30;
		private int wall4_width1=6;
		private int wall4_width2=1;
		private int wall4_lenght1=1;
		private int wall4_lenght2=6;

		private int wall5_x=1;
		private int wall5_y=18;
		private int wall5_w=23;
		private int wall5_width1=6;
		private int wall5_width2=1;
		private int wall5_lenght1=1;
		private int wall5_lenght2=6;

		private int wall6_x=25;
		private int wall6_y=18;
		private int wall6_w=23;
		private int wall6_width1=6;
		private int wall6_width2=1;
		private int wall6_lenght1=1;
		private int wall6_lenght2=6;

		public Wall(){
		}

		//GET SET ALL THE VALUES

		public float Wall1x{
			get{return wall1_x;}
			set{wall1_x = value;}
		}

		public float Wall1y{
			get{return wall1_y;}
			set{wall1_y = value; }
		}

		public float Wall2x{
			get{return wall2_x;}
			set{wall2_x = value;}
		}

		public float Wall2y{
			get{return wall2_y;}
			set{wall2_y = value;}
		}

		public int wallLenght{
			get{return wall1_lenght;}
			set{ wall1_lenght= value;}
		}

		public int wallWidth{
			get{return wall1_width;}
			set{wall1_width = value;}
		}

		//draw wall 1
		public void DrawWall1()
		{
			SwinGame.FillRectangle (Color.Grey, wall1_x*TileWidth, wall1_y*TileHeight, TileWidth*wall1_width, TileHeight*wall1_lenght);

		}


		//draw wall 2
		public void DrawWall2()
		{
			SwinGame.FillRectangle (Color.Grey, wall2_x*TileWidth, wall2_y*TileHeight, TileWidth*wall1_width, TileHeight*wall1_lenght);
		}


		//draw wall 3
		public void DrawWall3()
		{
			SwinGame.FillRectangle (Color.Grey, wall3_x*TileWidth, wall3_y*TileWidth, wall3_width2*TileWidth, TileHeight*wall3_lenght2);
			SwinGame.FillRectangle (Color.Grey, wall3_x*TileWidth, wall3_y*TileWidth, wall3_width1*TileWidth, TileHeight*wall3_lenght1);
		}


		//draw wall 4
		public void DrawWall4()
		{
			SwinGame.FillRectangle (Color.Grey, wall4_x*TileWidth, wall4_y*TileHeight, wall4_width1*TileWidth, TileHeight*wall4_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall4_w*TileWidth, wall4_y*TileHeight, wall4_width2*TileWidth, TileHeight*wall4_lenght2);
		}
		//draw wall 5
		public void DrawWall5()
		{
			SwinGame.FillRectangle (Color.Grey, wall5_x*TileWidth, TileHeight*wall5_w, wall5_width1*TileWidth, TileHeight*wall5_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall5_x*TileWidth, TileHeight*wall5_y, wall5_width2*TileWidth, TileHeight*wall5_lenght2);
		}
		//draw wall 6
		public void DrawWall6()
		{
			SwinGame.FillRectangle (Color.Grey, wall6_x*TileWidth, TileHeight*wall6_w, wall6_width1*TileWidth, TileHeight*wall6_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall4_w*TileWidth, TileHeight*wall6_y, wall6_width2*TileWidth, TileHeight*wall6_lenght2);
		}

	}
}