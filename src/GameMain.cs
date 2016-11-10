using System;
using SwinGameSDK;
using System.Windows.Forms;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
           // SwinGame.ShowSwinGameSplashScreen();

			GameController control = new GameController ();

			control.Initialized ();

            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                SwinGame.DrawFramerate(0,0);


				control.PlayGame ();


				// Has to go after ClearScreen and NOT before refreshscreen
                //Draw onto the screen
				SwinGame.RefreshScreen(60);




            }
        }
    }
}