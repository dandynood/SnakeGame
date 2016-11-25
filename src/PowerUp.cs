using System;
using SwinGameSDK;

namespace MyGame
{
	public class PowerUp
	{

		private Color _color;
		private float _x;
		private float _y;

		private int _width;
		private int _height;
		private int _PowerUpID;


		private const int TileWidth = 25;
		private const int TileHeight = 25;

		// PowerUp Counter
		public int PowerUpCounter = 0;


		public PowerUp ()
		{
			_color = Color.Blue;
		}


		public Color Color {
			get { return _color; }
			set { _color = value; }

		}

		public float X {
			get { return _x; }
			set { _x = value; }

		}

		public float Y {
			get { return _y; }
			set { _y = value; }

		}

		public int width {
			get { return _width; }
			set { _width = value; }
		}

		public int height {
			get { return _height; }
			set { _height = value; }
		}

		public int PowerUpID {
			get {
				return _PowerUpID;
			}

		}

		//Generate random location of power up
		public void GenerateRanPowerUp (GameState currentState)
		{
			Random Rand = new Random ();
			Random puID = new Random ();


			_x = (Rand.Next (0, 31));
			_y = (Rand.Next (0, 23));

			if (currentState == GameState.Level0) {


				_PowerUpID = 3;



			} else {

				_PowerUpID = (puID.Next (1, 6));

			}
		
		}

		public void GenerateRanPowerUpLevel1 ( Wall w , GameState currentState)
		{
			do {

				GenerateRanPowerUp (currentState);

			} while (SnakeCheckPowerUpLevel1 ( w));

		}

		public void GenerateRanPowerUpLevel2 ( Wall w ,GameState currentState)
		{
			do {

				GenerateRanPowerUp (currentState);

			} while (SnakeCheckPowerUpLevel2 ( w));

		}

		public void GenerateRanPowerUpLevel3 ( Wall w ,GameState currentState)
		{
			do {

				GenerateRanPowerUp (currentState);

			} while (SnakeCheckPowerUpLevel3 (w));

		}

		//Methods of Drawing the fruit
		public void Draw (GameState currentState)
		{
			if (PowerUpID == 1) {
				SwinGame.DrawBitmap ("lightning.png", _x * TileWidth - 7, _y * TileHeight - 10);
			} else if (PowerUpID == 2) {
				SwinGame.DrawBitmap ("turtle.png", _x * TileWidth - 7, _y * TileHeight - 10);
			} else if (PowerUpID == 3 && currentState != GameState.Level0) {
				SwinGame.DrawBitmap ("multiplyfruit.png", _x * TileWidth - 7, _y * TileHeight - 10);
			} else if (PowerUpID == 3 && currentState == GameState.Level0) {
					SwinGame.DrawBitmap ("multiplyfruit-inverted.jpg", _x * TileWidth - 7, _y * TileHeight - 10);
			} else if (PowerUpID == 4) {
				SwinGame.DrawBitmap ("scissors.png", _x * TileWidth - 7, _y * TileHeight - 10);
			} else if (PowerUpID == 5) {
				SwinGame.DrawBitmap ("question.png", _x * TileWidth - 7, _y * TileHeight - 10);
			}
		
		}


		public bool SnakeCheckPowerUpLevel1 ( Wall w)
		{
			// Check for Wall 1

			if (_x == w.Wall1x && _y >= w.Wall1y && _y <= w.Wall1y + w.wallLenght - 1) {

				return true;

			}

			// Check for Wall 2

			if (_x == w.Wall2x && _y >= w.Wall2y && _y <= w.Wall2y + w.wallLenght - 1) {

				return true;


			}

			return false;

		}

		public bool SnakeCheckPowerUpLevel2 ( Wall w)
		{
			// Check for Wall 3

			if (_y == w.wall3_y && _x >= w.wall3_x && _x <= w.wall3_x + w.wall3_width1 - 1) {

				return true;

			} else if (_x == w.wall3_x && _y >= w.wall3_y && _y <= w.wall3_y + w.wall3_lenght2 - 1) {

				return true;
			}

			// Check for Wall 4

			if (_y == w.wall4_y && _x >= w.wall4_x && _x <= w.wall4_x + w.wall4_width1 - 1) {

				return true;

			} else if (_x == w.wall4_w && _y >= w.wall4_y && _y <= w.wall4_y + w.wall4_lenght2 - 1) {

				return true;
			}

			// Check for Wall 5

			if (_y == w.wall5_w && _x >= w.wall5_x && _x <= w.wall5_x + w.wall5_width1 - 1) {

				return true;

			} else if (_x == w.wall5_x && _y >= w.wall5_y && _y <= w.wall5_y + w.wall5_lenght2 - 1) {

				return true;
			}


			if (_y == w.wall6_w && _x >= w.wall6_x && _x <= w.wall6_x + w.wall6_width1 - 1) {

				return true;

			} else if (_x == w.wall4_w && _y >= w.wall6_y && _y <= w.wall6_y + w.wall6_lenght2 - 1) {

				return true;
			}

			return false;

		}

		public bool SnakeCheckPowerUpLevel3 (Wall w)
		{
			if (SnakeCheckPowerUpLevel1 ( w) || SnakeCheckPowerUpLevel2 ( w)) {
				return true;
			}

			return false;


		}

	


	}
}
