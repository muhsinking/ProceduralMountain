using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace KoboldMountain
{
	public class SpriteClass
	{
		public Texture2D texture { get; set; }
		public float X { get; set; }
		public float Y { get; set; }
		public float dX { get; set; }
		public float dY { get; set; }
		public float dA { get; set; }
		public float angle { get; set; }
		public float scale { get; set; }

		public SpriteClass(ContentManager content, string textureName)
		{
			X = 0;
			Y = 0;
			dX = 0;
			dY = 0;
			angle = 0f;
			scale = 1f;

			texture = content.Load<Texture2D>(textureName);
		}

		public SpriteClass(float X, float Y, float scale)
		{
			this.X = X;
			this.Y = Y;
			this.dX = 0;
			this.dY = 0;
			this.angle = 0;
			this.scale = scale;
		}

		public SpriteClass(ContentManager content, string textureName, float X, float Y, float scale)
		{
			this.X = X;
			this.Y = Y;
			this.dX = 0;
			this.dY = 0;
			this.angle = 0;
			this.scale = scale;

			texture = content.Load<Texture2D>(textureName);
		}

		public SpriteClass(ContentManager content, string textureName, float scale)
		{
			this.X = 0;
			this.Y = 0;
			this.dX = 0;
			this.dY = 0;
			this.angle = 0;
			this.scale = scale;
			texture = content.Load<Texture2D>(textureName);
		}

		public SpriteClass(ContentManager content, string textureName, float X, float Y, float scale, float angle)
		{
			this.X = X;
			this.Y = Y;
			this.dX = 0;
			this.dY = 0;
			this.angle = angle;
			this.scale = scale;

			texture = content.Load<Texture2D>(textureName);
		}

		public void Update(float elapsedTime)
		{
			X += dX * elapsedTime;
			Y += dY * elapsedTime;
			angle += dA * elapsedTime;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Vector2 spritePosition = new Vector2(X + Camera.X, Y + Camera.Y);
			spriteBatch.Draw(texture, spritePosition, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), new Vector2(Camera.zoom * scale, Camera.zoom * scale), SpriteEffects.None, 0f);
		}

		public void DrawFlippedHorizontal(SpriteBatch spriteBatch)
		{
			Vector2 spritePosition = new Vector2(X + Camera.X, Y + Camera.Y);
			spriteBatch.Draw(texture, spritePosition, null, Color.White, angle, new Vector2(texture.Width / 2, texture.Height / 2), new Vector2(Camera.zoom * scale, Camera.zoom * scale), SpriteEffects.None, 0f);
		}

		public void DrawHighlighted(SpriteBatch spriteBatch)
		{
			Vector2 spritePosition = new Vector2(X + Camera.X, Y + Camera.Y);
			spriteBatch.Draw(texture, spritePosition, null, Color.DeepSkyBlue, angle, new Vector2(texture.Width / 2, texture.Height / 2), new Vector2(scale, scale), SpriteEffects.None, 0f);
		}
	}
}
