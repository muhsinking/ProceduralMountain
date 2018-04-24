using System;
using Microsoft.Xna.Framework.Input;

namespace KoboldMountain
{
	public static class Camera
	{
		public static float X = 0;
		public static float Y = 0;
		public static float speed = 300;
		public static float zoom = 1;
		public static float zoomSpeed = .5f;

		//public Camera()
		//{
		//	x = 0;
		//	y = 0;
		//}

		// TODO make this non framerate dependent
		public static void HandleInput(float elapsedTime)
		{
			KeyboardState state = Keyboard.GetState();
			if (state.IsKeyDown(Keys.Up))
			{
				Y += speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Down))
			{
				Y -= speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Left))
			{
				X += speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.Right))
			{
				X -= speed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.J))
			{
				zoom += zoomSpeed * elapsedTime;
			}
			if (state.IsKeyDown(Keys.K))
			{
				zoom -= zoomSpeed * elapsedTime;
			}
		}
	}
}