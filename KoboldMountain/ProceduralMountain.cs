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
			InitializeTiles();
			GenerateSlope();
			// GenerateCaverns();
			// GenerateFeatures();
		}

		// Generates an x and y position for each tile, and initializes them as empty
		void InitializeTiles()
		{
			float startingXPos = (windowDimensions.X / 2) - (altitude * 64 * Camera.zoom / 2);
			float startingYPos = (int)windowDimensions.Y - 100;

			// i is across, j is up
			for (int i = 0; i<altitude; i++)
			{
				for (int j = 0; j<altitude; j++)
				{
					float xPos = startingXPos + (i * 64);
					float yPos = startingYPos - (j * 64); // 100 is arbitraty
					mountainTiles[i, j] = new MountainTile(TileTypes.EMPTY, xPos, yPos, false);
				}
			}
		}

		/*
		 * Generates the slope (surface) of the mountain. 
		 * Start at the leftmost point, tracking the surface as it ascends to the maximum altitude.
		 * As each slope tile is added, all tiles below it are populated with full dirt tiles.
		 * At maximum altitude, tiles are horizontally flipped (using the flipped property of MountainTile.
		 */
		void GenerateSlope()
		{
			int currentAltitude = 0;
			int currentX = 0;
			while(currentAltitude < altitude-1 && currentX < altitude-1){ // must be altitude -1 so that double tile fills don't extend past array
				// roll 1d5
				// TODO make this actually random
				int zeroToFour = 2;

				// TODO rewrite this junk so it only does one tile per loop (but remembers when it needs to complete a sequence)
				switch (zeroToFour){
					case 0: // one flat slope. Y does not change, obvs
						mountainTiles[currentX, currentAltitude].type = TileTypes.FLAT;
						currentX++;
						break;
					case 1: // two 22 degree slopes
						mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOLOWER;
						mountainTiles[currentX+1, currentAltitude+1].type = TileTypes.TWENTYTWOUPPER;
						currentX += 2;
						currentAltitude += 2;
						break;
					case 2: // one 45 degree slope
						mountainTiles[currentX, currentAltitude].type = TileTypes.FOURTYFIVE;
						currentX++;
						currentAltitude++;
						break;
					case 3: // two 67 degree slopes
						mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENLOWER;
						mountainTiles[currentX+1, currentAltitude+1].type = TileTypes.SIXTYSEVENUPPER;
						currentX += 2;
						currentAltitude += 2;
						break;
					case 4: // one 90 degree slope. X does not change!
						mountainTiles[currentX, currentAltitude].type = TileTypes.NINETY;
						currentX++;
						currentAltitude++;
						break;

					// After generating the slope tile, populate all tiles below with full dirt tiles)
					// for(int i = currentAltitude; i >= 0; i--){

					// }
				}
			}

			while(currentAltitude > 1 && currentX < altitude-1){ // must be altitude -1 so that double tile fills don't extend past array
				// roll 1d5
				// TODO make this actually random
				int zeroToFour = 2;

				// REMEMBER you gotta do upper slopes first on the way down!
				switch (zeroToFour){
					case 0: // one flat slope. Y does not change, obvs
						mountainTiles[currentX, currentAltitude].type = TileTypes.FLAT;
						currentX++;
						break;
					case 1: // two 22 degree slopes
						mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOUPPER;
						mountainTiles[currentX+1, currentAltitude-1].type = TileTypes.TWENTYTWOLOWER;
						mountainTiles[currentX, currentAltitude].flipped = true;
						mountainTiles[currentX+1, currentAltitude-1].flipped = true;
						currentX += 2;
						currentAltitude -= 2;
						break;
					case 2: // one 45 degree slope
						mountainTiles[currentX, currentAltitude].type = TileTypes.FOURTYFIVE;
						mountainTiles[currentX, currentAltitude].flipped = true;
						currentX++;
						currentAltitude--;
						break;
					case 3: // two 67 degree slopes
						mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENUPPER;
						mountainTiles[currentX+1, currentAltitude-1].type = TileTypes.SIXTYSEVENLOWER;
						mountainTiles[currentX, currentAltitude].flipped = true;
						mountainTiles[currentX+1, currentAltitude-1].flipped = true;
						currentX += 2;
						currentAltitude -= 2;
						break;
					case 4: // one 90 degree slope. X does not change!
						mountainTiles[currentX, currentAltitude].type = TileTypes.NINETY;
						mountainTiles[currentX, currentAltitude].flipped = true;
						currentX++;
						currentAltitude--;
						break;

					// After generating the slope tile, populate all tiles below with full dirt tiles)
					// for(int i = currentAltitude; i >= 0; i--){

					// }
				}
			}

			// Creates a flat plane
			// for (int i = 0; i<altitude; i++)
			// {
			// 	for (int j = 0; j<altitude; j++)
			// 	{
			// 		if (j == 0){
			// 			mountainTiles[i, j].type = TileTypes.FLAT;
			// 		}
			// 	}
			// }
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