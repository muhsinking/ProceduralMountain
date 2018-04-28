using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace KoboldMountain
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Vector2 windowDimensions = new Vector2(1400,800);
		ProceduralMountain mountain;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = (int)windowDimensions.X;  // set this value to the desired width of your window
			graphics.PreferredBackBufferHeight = (int)windowDimensions.Y;   // set this value to the desired height of your window
			graphics.ApplyChanges();
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);
			mountain = new ProceduralMountain(this.Content, GraphicsDevice, windowDimensions, 20);
		}

		protected override void Update(GameTime gameTime)
		{
			float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			Camera.HandleInput(elapsedTime);
			mountain.Update(elapsedTime);
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
			spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, null);
			mountain.Draw(spriteBatch);
			spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
