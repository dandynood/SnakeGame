using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
	public class Wall
	{
		//Tile's area
		//private const TileWidth = 25;
		//private const TileHeight= 25;

		//strait wall
		private float wall1_x = 350;
		private float wall1_y = 200;
		private float wall2_x = 450;
		private float wall2_y = 200;
		private int wall1_width = 20;
		private int wall1_lenght= 150;

		//Corner Wall
		private int wall3_x=25;
		private int wall3_y=10;
		private int wall3_width1=150;
		private int wall3_width2=20;
		private int wall3_lenght1=20;
		private int wall3_lenght2=150;

		private int wall4_x= 620;
		private int wall4_y=10;
		private int wall4_w=750;
		private int wall4_width1=150;
		private int wall4_width2=20;
		private int wall4_lenght1=20;
		private int wall4_lenght2=150;

		private int wall5_x=25;
		private int wall5_y=440;
		private int wall5_w=575;
		private int wall5_width1=150;
		private int wall5_width2=20;
		private int wall5_lenght1=20;
		private int wall5_lenght2=150;

		private int wall6_x=620;
		private int wall6_y=440;
		private int wall6_w=575;
		private int wall6_width1=150;
		private int wall6_width2=20;
		private int wall6_lenght1=20;
		private int wall6_lenght2=150;

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
			SwinGame.FillRectangle (Color.Grey, wall1_x, wall1_y, wall1_width, wall1_lenght);

		}


		//draw wall 2
		public void DrawWall2()
		{
			SwinGame.FillRectangle (Color.Grey, wall2_x, wall2_y, wall1_width, wall1_lenght);
		}


		//draw wall 3
		public void DrawWall3()
		{
			SwinGame.FillRectangle (Color.Grey, wall3_x, wall3_y, wall3_width2, wall3_lenght2);
			SwinGame.FillRectangle (Color.Grey, wall3_x, wall3_y, wall3_width1, wall3_lenght1);
		}


		//draw wall 4
		public void DrawWall4()
		{
			SwinGame.FillRectangle (Color.Grey, wall4_x, wall4_y, wall4_width1, wall4_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall4_w, wall4_y, wall4_width2, wall4_lenght2);
		}
		//draw wall 5
		public void DrawWall5()
		{
			SwinGame.FillRectangle (Color.Grey, wall5_x, wall5_w, wall5_width1, wall5_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall5_x, wall5_y, wall5_width2, wall5_lenght2);
		}
		//draw wall 6
		public void DrawWall6()
		{
			SwinGame.FillRectangle (Color.Grey, wall6_x, wall6_w, wall6_width1, wall6_lenght1);
			SwinGame.FillRectangle (Color.Grey, wall4_w, wall6_y, wall6_width2, wall6_lenght2);
		}

	}
}

