using System;
using SwinGameSDK;

namespace MyGame
{
	public class SnakePart
	{
		private int _x;
		private int _y;
		private Color _color;

		public SnakePart ()
		{
			_x = 0;
			_y = 0;
			_color = Color.Black;
		}

		public int X
		{
			get{ return _x; }
			set{ _x = value; }
		}

		public int y
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

