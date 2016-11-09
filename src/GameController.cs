using System;
using SwinGameSDK;

namespace MyGame
{
	public class GameController
	{
		public GameController ()
		{


		}


		public void MoveForward (Snake s)
		{
			int index = s.SnakeParts.Count - 1;

			if (s.Direction == DirectionEnum.Up) {
				s.SnakeParts.RemoveAt (index);
				s.SnakeParts.Insert (0, new SnakePart (s.Head.X, s.Head.Y - 1));
				s.Head.Y--;
			} else if (s.Direction == DirectionEnum.Down) {
				s.SnakeParts.RemoveAt (index);
				s.SnakeParts.Insert (0, new SnakePart (s.Head.X, s.Head.Y + 1));
				s.Head.Y++;
			} else if (s.Direction == DirectionEnum.Right) {
				s.SnakeParts.RemoveAt (index);
				s.SnakeParts.Insert (0, new SnakePart (s.Head.X + 1, s.Head.Y));
				s.Head.X++;
			} else if (s.Direction == DirectionEnum.Left) {
				s.SnakeParts.RemoveAt (index);
				s.SnakeParts.Insert (0, new SnakePart (s.Head.X - 1, s.Head.Y));
				s.Head.X--;
			}


		}

		public void HandleUserInput (Snake s)
		{
			if (SwinGame.KeyDown (KeyCode.vk_a) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down)) {
				s.Direction = DirectionEnum.Left;
			} else if (SwinGame.KeyDown (KeyCode.vk_d) && (s.Direction == DirectionEnum.Up || s.Direction == DirectionEnum.Down)) {
				s.Direction = DirectionEnum.Right;
			} else if (SwinGame.KeyDown (KeyCode.vk_w) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left)) {
				s.Direction = DirectionEnum.Up;
			} else if (SwinGame.KeyDown (KeyCode.vk_s) && (s.Direction == DirectionEnum.Right || s.Direction == DirectionEnum.Left)) {
				s.Direction = DirectionEnum.Down;
			}

		}

		public void SnakeCheckSides (Snake s)
		{


			if (s.Head.Y < 0 || s.Head.Y > 23 || s.Head.X > 31 || s.Head.X < 0) {
				SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

			}

		}



		/*	public void SnakeCheckWalls(Snake s)
			{ 
				if (s.Direction == DirectionEnum.Up) {

					if (s.Head.Y < 0) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

					}

				} else if (s.Direction == DirectionEnum.Down) {

					if (s.Head.Y > 24) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

					}

				} else if (s.Direction == DirectionEnum.Right) {

					if (s.Head.X > 32) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

					}

				} else if (s.Direction == DirectionEnum.Left) {

					if (s.Head.X < 0) {
						SwinGame.DrawText ("GAME OVER!", Color.Blue, 365, 280);

					}
				}
			}*/
	}
}
