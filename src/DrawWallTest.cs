using System;
using NUnit.Framework;

namespace MyGame
{
	[TestFixture()]
	public class DrawWallTest
	{
		[Test()]
		public void DrawTest()
		{
			//int wallloc_x= 350;


			Wall x = new Wall ();

			//x.DrawWallx ();

			Assert.IsTrue ( 350 == Wall.wall1_x* Wall.TileWidth);
		}
	}
}

