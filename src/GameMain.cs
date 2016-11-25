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
			SwinGame.PlayMusic ("Lotus Land.mp3");
            //Run the game loop
			while (!(SwinGame.WindowCloseRequested() == true || control.CurrentState == GameState.QuitProgram))
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

                //SwinGame.DrawFramerate(0,0);
				if(SwinGame.KeyDown(KeyCode.vk_F4))
				{
					SwinGame.ToggleFullScreen ();	
				}
				control.PlayGame ();

				// Has to go after ClearScreen and NOT before refreshscreen
                //Draw onto the screen
				SwinGame.RefreshScreen(60);

            }

			SwinGame.ReleaseAllMusic ();
        }
    }
}