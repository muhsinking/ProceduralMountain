using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace KoboldMountain
{
	class ProceduralMountain
	{
		ContentManager content;
		GraphicsDevice graphicsDevice;
		int altitude;
		Vector2 windowDimensions;
		MountainTile[,] mountainTiles;
		TileBrush tileBrush;

		public ProceduralMountain(ContentManager content, GraphicsDevice graphicsDevice, Vector2 windowDimensions, int altitude)
		{
			this.content = content;
			this.graphicsDevice = graphicsDevice;
			this.windowDimensions = windowDimensions;
			this.altitude = altitude;

			tileBrush = new TileBrush(content);

			GenerateMountain();
			mountainTiles = new MountainTile[altitude,altitude];
		}

		void GenerateMountain()
		{
			GenerateSlope();
			// GenerateCaverns();
			// GenerateFeatures();
		}

		/*
		 * Generates the slope (surface) of the mountain. 
		 * Start at the leftmost point, tracking the surface as it ascends to the maximum altitude.
		 * As each slope tile is added, all tiles below it are populated with full dirt tiles.
		 * At maximum altitude, tiles are horizontally flipped (using the flipped property of MountainTile.
		 */
		void GenerateSlope()
		{
			float startingXPos = (windowDimensions.X / 2) - (altitude * 64 * Camera.zoom / 2);

			// i is across, j is up
			for (int i = 0; i<altitude; i++)
			{
				for (int j = 0; j<altitude; j++)
				{
					float xPos = startingXPos + (i * 64);
					float yPos = (int)windowDimensions.Y - 100 - (j * 64); // 100 is arbitraty

					if (j == 0)
					{
						mountainTiles[i, j] = new MountainTile(TileTypes.FLAT, xPos, yPos, false);
					}
					else
					{
						mountainTiles[i, j] = new MountainTile(TileTypes.EMPTY, xPos, yPos, false);
					}
				}
			}
		}

		public void Update(float elapsedTime)
		{
			for (int i = 0; i < altitude; i++)
			{
				for (int j = 0; j < altitude; j++)
				{
					// Update mountainTiles
				}
			}
		}

		public void Draw(SpriteBatch spritebatch)
		{
			for (int i = 0; i < altitude; i++)
			{
				for (int j = 0; j < altitude; j++){
					tileBrush.Draw(spritebatch,mountainTiles[i, j]);
				}
			}
		}


	}
}