using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture ()]
	public class TestSnakeClass
	{

		[Test ()]
		public void SnakeMoveForward ()
		{
			Snake s = new Snake ();
			s.Head.Y = 5;
			s.Head.X = 5;
			s.Direction = DirectionEnum.Right;
			s.MoveForward ();

			Assert.IsTrue(s.Head.X == 6);

			s.Direction = DirectionEnum.Down;
			s.MoveForward ();

			Assert.IsTrue (s.Head.Y == 6);

			s.Direction = DirectionEnum.Left;
			s.MoveForward ();

			Assert.IsTrue (s.Head.X == 5);

			s.Direction = DirectionEnum.Up;
			s.MoveForward ();

			Assert.IsTrue (s.Head.Y == 5);
		}

		[Test ()]
		public void SnakeIncreaseLength()
		{
			Snake s = new Snake ();
			Assert.IsTrue (s.Lenght == 0);
			s.IncreaseLenght ();
			Assert.IsTrue (s.Lenght == 1);

			Assert.IsTrue (s.SnakeParts.Count == 2);
		}
	}
}

