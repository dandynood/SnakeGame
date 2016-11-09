using System;
using SwinGameSDK;

namespace MyGame
{
	public class SnakePart
	{
		private float _x;
		private float _y;
		private Color _color;

		public SnakePart (float x, float y)
		{
			_x = x;
			_y = y;
			_color = Color.Black;
		}

		public SnakePart() : this (0, 0)
		{

		}

		public float X
		{
			get{ return _x; }
			set{ _x = value; }
		}

		public float Y
		{
			get{ return _y; }
			set{ _y = value; }
		}

		public Color color
		{
			get{ return _color; }
			set{ _color = value; }

		}
	}
}

