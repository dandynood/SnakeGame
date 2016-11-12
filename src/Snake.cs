using System;
using System.Collections.Generic;
using SwinGameSDK;

namespace MyGame
{
	public class Snake
	{
		List<SnakePart> _snakeParts = new List<SnakePart> ();
		SnakePart _head = new SnakePart();

		private const int TileWidth = 25;
		private const int TileHeight = 25;


		private int _lengthcount;
		private DirectionEnum _direction;

		public Snake ()
		{
			_lengthcount = 0;
			_head.color = Color.Red;
			_head.X = 20;
			_head.Y = 10;
			_snakeParts.Add (_head);
			_direction = DirectionEnum.Left;
		}

		public int Lenght
		{
			get { return _lengthcount; }
			set { _lengthcount = value; }
		}

		public List<SnakePart> SnakeParts
		{
			get { return _snakeParts; }
			set { _snakeParts = value; }
		}

		public SnakePart Head
		{
			get{ return _head; }
		}

		public DirectionEnum Direction
		{
			get { return _direction; }
			set { _direction = value; }
		}

		public void MoveForward()
		{	
			
			if (_direction == DirectionEnum.Up)
			{

				_head.Y--;
			}
			else if (_direction == DirectionEnum.Down)
			{

				_head.Y++;
			}
			else if (_direction == DirectionEnum.Right)
			{

				_head.X++;
			}
			else if (_direction == DirectionEnum.Left)
			{

				_head.X--;
			}

		}

		public void Draw()
		{
			SwinGame.FillRectangle (_head.color, _head.X * TileWidth, _head.Y * TileHeight, TileWidth, TileHeight);
			for (int i = 1; i < _snakeParts.Count; i++)
			{
				SwinGame.FillRectangle (_snakeParts [i].color, _snakeParts [i].X * TileWidth, _snakeParts [i].Y * TileHeight, TileWidth, TileHeight);
			}
		}

		public void IncreaseLenght()
		{
			int index = _snakeParts.Count - 1;
			_snakeParts.Add( new SnakePart(_snakeParts[index].X, _snakeParts[index].Y));
			_lengthcount++;
		}

		/*public void HandleSnakeInput()
		{
			if (SwinGame.KeyDown (KeyCode.vk_a) && (_direction == DirectionEnum.Up || _direction == DirectionEnum.Down))
			{
				_direction = DirectionEnum.Left;
			}
			else if (SwinGame.KeyDown (KeyCode.vk_d) && (_direction == DirectionEnum.Up || _direction == DirectionEnum.Down))
			{
				_direction = DirectionEnum.Right;
			}
			else if (SwinGame.KeyDown (KeyCode.vk_w) && (_direction == DirectionEnum.Right || _direction == DirectionEnum.Left))
			{
				_direction = DirectionEnum.Up;
			}
			else if (SwinGame.KeyDown (KeyCode.vk_s) && (_direction == DirectionEnum.Right || _direction == DirectionEnum.Left))
			{
				_direction = DirectionEnum.Down;
			}
				
		}*/
			
	}
}

