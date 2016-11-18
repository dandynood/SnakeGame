using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class TestSnake
	{
		[Test ()]
		public void TestSnakeLeft ()
		{
			Snake s = new Snake ();
			s.Head.X = 8;
			s.Head.Y = 5;
			int i = 0;

			while (i != 3)
			{
				if (s.Head.X != 10)
				{	
					s.Direction = DirectionEnum.Right;
					s.IncreaseLenght ();
					s.MoveForward ();
					i++;
				}
			}


			Assert.AreEqual(s.Head.X, 10 );
		}
	}
}

