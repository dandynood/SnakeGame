using System;
using SwinGameSDK;

namespace MyGame
{
    public class GameMain
    {
        public static void Main()
        {

            //Open the game window
            SwinGame.OpenGraphicsWindow("GameMain", 800, 600);
            SwinGame.ShowSwinGameSplashScreen();
            
            //Run the game loop
            while(false == SwinGame.WindowCloseRequested())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents();
                
                //Clear the screen and draw the framerate
                SwinGame.ClearScreen(Color.White);

				//DrawWalls levels
				Level LVL=new Level();

				//Draw Level 1
				//LVL.Drawlevel1();

				//Draw Level 2
				//LVL.Drawlevel2();

				//LVL.Drawlevel3
				//LVL.Drawlevel3();

                SwinGame.DrawFramerate(0,0);

				// Has to go after ClearScreen and NOT before refreshscreen


                //Draw onto the screen
                SwinGame.RefreshScreen(60);




            }
        }
    }
}