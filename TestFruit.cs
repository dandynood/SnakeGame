using System;
using SwinGameSDK;
using NUnit.Framework;


namespace MyGame
{
	[TestFixture()]
	public class TestFruit
	{
		[Test()]
		public void TestFruitProperty ()
		{
			Fruit f = new Fruit ();

			//Declare location of fruit
			f.X = 100;
			f.Y = 100;

			//Test the fruit location
			Assert.AreEqual (100, f.X);
			Assert.AreEqual (100, f.Y);

			//Declare Size of food
			f.width = 50;
			f.height = 50;

			//Test the fruit size
			Assert.AreEqual (50, f.width);
			Assert.AreEqual (50, f.height);
		}

		[Test()]
		public void TestFruitLocation ()
		{
			Fruit f = new Fruit ();
			//Initialise the location of fruit
			f.X = 100;
			f.Y = 100;

			//Test if it is at the selected location
			Assert.AreEqual (100, f.X);
			Assert.AreEqual (100, f.Y);

			//Random generate the location of fruit
			Random rnd = new Random();
			f.X=(rnd.Next(0,800));
			f.Y = (rnd.Next (0,600));

			//Test if the fruit is no more at the first initialised location
			Assert.IsFalse (f.X== 100);
			Assert.IsFalse (f.Y == 100);
		}
	}
}

