using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameMain
	{
		public static void Main()
		{
			//Declare local variable of fruit and assign new fruit
			Fruit Sfruit = new Fruit ();

			//Open the game window
			SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen();

			Sfruit.GenerateRan();

			//Run the game loop
			while(false == SwinGame.WindowCloseRequested())
			{
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen(Color.White);

				SwinGame.DrawFramerate(0,0);

				// Has to go after ClearScreen and NOT before refreshscreen

				//Call fruit to draw itself
				//Sfruit.GenerateRan();
				SwinGame.Delay (800);
				Sfruit.Draw ();

				//Draw onto the screen
				SwinGame.RefreshScreen(60);




			}
		}
	}
}