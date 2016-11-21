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
<<<<<<< HEAD
			SwinGame.PlayMusic ("Lotus Land.mp3");
            //Run the game loop
			while (!(SwinGame.WindowCloseRequested() == true || control.CurrentState == GameState.QuitProgram))
=======

            //Run the game loop
			while (!(SwinGame.WindowCloseRequested() == true | control.CurrentState == GameState.QuitProgram))
>>>>>>> origin
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                //SwinGame.DrawFramerate(0,0);

				control.PlayGame ();

				// Has to go after ClearScreen and NOT before refreshscreen
                //Draw onto the screen
				SwinGame.RefreshScreen(60);

            }

			SwinGame.ReleaseAllMusic ();
        }
    }
}