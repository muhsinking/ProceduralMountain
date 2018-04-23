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

			mountainTiles = new MountainTile[altitude,altitude];

			// center mountain on window
			float startingXPos = windowDimensions.X - (altitude * 64 / 2);

			// i is across, j is up
			for (int i = 0; i < altitude; i++)
			{
				for (int j = 0; j < altitude; j++)
				{
					float xPos = startingXPos + (i * 64);
					float yPos = (int)windowDimensions.Y - 100 - (j * 64); // 100 is arbitraty
					if (j == 0)
					{
						// 64 is tile width, 100 is arbitrary height
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