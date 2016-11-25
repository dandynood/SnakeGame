﻿using System;
using SwinGameSDK;

namespace MyGame
{
	public class Fruit
	{
		//Declare the necessary variable and const
		private Color _color;
		private float _x;
		private float _y;
		private int _width;
		private int _height;
		private int i;

		private const int TileWidth = 25;
		private const int TileHeight = 25;

		public Fruit ()
		{
			_color = Color.Green;
		}


		public Color Color
		{
			get{return _color;}
			set{_color = value;}

		}

		public float X
		{
			get{return _x;}
			set{_x = value;}

		}

		public float  Y
		{
			get{return _y;}
			set{_y = value;}

		}

		public int width{
			get{ return _width; }
			set{ _width = value; }
		}

		public int height{
			get{ return _height; }
			set{ _height = value; }
		}

		public int I {
			get {
				return i;
			}

			set {
				i = value;
			}
		}

		//Methods of random generation the location of fruit
		public void GenerateRan()
		{
			Random rnd = new Random();
			_x = (rnd.Next (0, 31));
			_y = (rnd.Next (0, 23));
		     i = (rnd.Next (1, 7));
		}

		//Methods of Drawing the fruit
		public void Draw()
		{
			
			//SwinGame.FillRectangle (_color, _x*TileWidth, _y*TileHeight,TileHeight, TileWidth);

			if (i == 1) 
			{
				SwinGame.DrawBitmap ("apple.png", _x * TileWidth-7, _y * TileHeight-10);
			} 
			else if (i == 2) 
			{
				SwinGame.DrawBitmap ("cherry.png", _x * TileWidth-7, _y * TileHeight-10);
			} 
			else if (i == 3)
			{
				SwinGame.DrawBitmap ("mango.png", _x * TileWidth-7, _y * TileHeight-10);
			} 
			else if (i == 4)
			{
				SwinGame.DrawBitmap ("watermellon.png", _x * TileWidth-7, _y * TileHeight-10);
			} 
			else if (i == 5) 
			{
				SwinGame.DrawBitmap ("strawberry.png", _x * TileWidth-7, _y * TileHeight-10);
			}
			else if (i == 6) 
			{
				SwinGame.DrawBitmap ("orange.png", _x * TileWidth-7, _y * TileHeight-10);
			}
			else if (i == 7) 
			{
				SwinGame.DrawBitmap ("applegreen.png", _x * TileWidth-7, _y * TileHeight-10);
			}
			else if (i == 8) 
			{
				SwinGame.DrawBitmap ("peach.png", _x * TileWidth-7, _y * TileHeight-10);
			}
		}

		public void GenerateRanLevel1 ( Wall w)
		{
			do {

				GenerateRan ();

			} while (SnakeCheckFruitLevel1 ( w));

		}

		public void GenerateRanLevel2 ( Wall w)
		{
			do {

				GenerateRan ();

			} while (SnakeCheckFruitLevel2 ( w));

		}

		public void GenerateRanLevel3 ( Wall w)
		{
			do {

				GenerateRan ();

			} while (SnakeCheckFruitLevel3 ( w));

		}

		//Ernest: Added codes to fix fruits on wall bugs
		public bool SnakeCheckFruitLevel1 ( Wall w)
		{
			// Check for Wall 1

			if (_x == w.Wall1x && _y >= w.Wall1y && _y <= w.Wall1y + w.wallLenght - 1) {

				return true;

			}

			// Check for Wall 2

			if (_x == w.Wall2x && _y >= w.Wall2y && _y <= w.Wall2y + w.wallLenght - 1) {

				return true;


			}

			return false;

		}

		public bool SnakeCheckFruitLevel2 ( Wall w)
		{
			// Check for Wall 3

			if (_y == w.wall3_y && _x >= w.wall3_x && _x <= w.wall3_x + w.wall3_width1 - 1) {

				return true;

			} else if (_x == w.wall3_x && _y >= w.wall3_y && _y <= w.wall3_y + w.wall3_lenght2 - 1) {

				return true;
			}

			// Check for Wall 4

			if (_y == w.wall4_y && _x >= w.wall4_x && _x <= w.wall4_x + w.wall4_width1 - 1) {

				return true;

			} else if (_x == w.wall4_w && _y >= w.wall4_y && _y <= w.wall4_y + w.wall4_lenght2 - 1) {

				return true;
			}

			// Check for Wall 5

			if (_y == w.wall5_w && _x >= w.wall5_x && _x <= w.wall5_x + w.wall5_width1 - 1) {

				return true;

			} else if (_x == w.wall5_x && _y >= w.wall5_y && _y <= w.wall5_y + w.wall5_lenght2 - 1) {

				return true;
			}


			if (_y == w.wall6_w && _x >= w.wall6_x && _x <= w.wall6_x + w.wall6_width1 - 1) {

				return true;

			} else if (_x == w.wall4_w && _y >= w.wall6_y && _y <= w.wall6_y + w.wall6_lenght2 - 1) {

				return true;
			}

			return false;

		}

		public bool SnakeCheckFruitLevel3 (Wall w)
		{
			if (SnakeCheckFruitLevel1 ( w) || SnakeCheckFruitLevel2 ( w)) {
				return true;
			}

			return false;


		}




	}
}

