using System;
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




	}
}

