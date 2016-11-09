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
			_x = (rnd.Next (0, 32));
			_y = (rnd.Next (0, 24));
		}

		//Methods of Drawing the fruit
		public void Draw()
		{
			SwinGame.FillRectangle (_color, _x*TileWidth, _y*TileHeight,TileHeight, TileWidth);
		}




	}
}

