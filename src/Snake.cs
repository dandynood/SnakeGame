using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Snake
	{
		List<SnakePart> _snakeParts = new List<SnakePart> ();
		SnakePart _head = new SnakePart();

		private const int TileWidth = 15;
		private const int TileHeight = 15;

		private const int GridWidth = 15;
		private const int GridHeight = 15;

		private int _length;
		private DirectionEnum _direction;

		public Snake ()
		{
			_length = 0;
			_head.color = Color.Red;
			_snakeParts.Add (_head);
			_direction = DirectionEnum.Left;
		}

		public int Lenght
		{
			get { return _length; }
			set { _length = value; }
		}

		public List<SnakePart> SnakeParts
		{
			get { return _snakeParts; }
			set { _snakeParts = value; }
		}

		public DirectionEnum Direction
		{
			get { return _direction; }
			set { _direction = value; }
		}

		public void MoveForward(DirectionEnum d)
		{	
			if(d == DirectionEnum.Up)
			{
				_snakeParts.RemoveAt (_snakeParts.Count - 1);
				_snakeParts.Insert (0, _head);

			}
			else if(d == DirectionEnum.Down)
			{

			}
			else if(d == DirectionEnum.Right)
			{

			}
			else if(d == DirectionEnum.Left)
			{

			}
		}

		public void IncreaseLenght()
		{
			
		}
			
	}
}

