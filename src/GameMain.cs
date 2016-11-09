using SwinGameSDK;
using System.Threading.Tasks;



namespace MyGame
{
	public class GameMain
	{


		public static void Main ()
		{



			//Open the game window
			SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
			SwinGame.ShowSwinGameSplashScreen ();

			Snake snake = new Snake ();
			GameController gameController = new GameController ();
			//   System.Threading.Timer timer = null;
			int time = 250;

			snake.IncreaseLenght ();
			snake.IncreaseLenght ();
			snake.IncreaseLenght ();




			//Run the game loop
			while (false == SwinGame.WindowCloseRequested ()) {
				//Fetch the next batch of UI interaction
				SwinGame.ProcessEvents ();

				//Clear the screen and draw the framerate
				SwinGame.ClearScreen (Color.White);

				SwinGame.DrawFramerate (0, 0);

				// Has to go after ClearScreen and NOT before refreshscreen

				snake.Draw ();


				System.Timers.Timer timer = new System.Timers.Timer (time);
				timer.AutoReset = false;
				timer.Elapsed += (sender, e) => gameController.MoveForward (snake);
				timer.Start ();


				gameController.HandleUserInput (snake);

				gameController.SnakeCheckSides (snake);

				time += 250;


				//Draw onto the screen
				SwinGame.RefreshScreen (60);




			}
		}
	}
}