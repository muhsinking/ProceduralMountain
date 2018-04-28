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
		int altitude; // mountain altitude should not be synonymous grid size, you dork
		Vector2 windowDimensions;
		MountainTile[,] mountainTiles;
		TileBrush tileBrush;

		/*
			Thoughts:
			Perhaps the mountain should have two levels: surface and cavern. 
			You could toggle between the surface view and the cross section. 
			This would also mean that you can create entrances to the mountain from more than just the sides.
			It would also give more space for activities like woodcutting, and give more area to show the external features of the mountain.
			Consider implementing this after you've got the basic mountain silhoutte figured out.
		*/

		public ProceduralMountain(ContentManager content, GraphicsDevice graphicsDevice, Vector2 windowDimensions, int altitude)
		{
			this.content = content;
			this.graphicsDevice = graphicsDevice;
			this.windowDimensions = windowDimensions;
			this.altitude = altitude;
			this tileBrush = new TileBrush(content);
			this mountainTiles = new MountainTile[altitude,altitude];

			GenerateMountain();
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
			float startingYPos = windowDimensions.Y - 100;

			// i is across, j is up
			for (int i = 0; i<altitude; i++)
			{
				for (int j = 0; j<altitude; j++)
				{
					float xPos = startingXPos + (i * 64);
					float yPos = startingYPos - (j * 64);
					mountainTiles[i, j] = new MountainTile(TileTypes.EMPTY, xPos, yPos);
				}
			}
		}

		/*
		 * Generates the slope (surface) of the mountain. 
		 * Start at the leftmost point, tracking the surface as it ascends to the maximum altitude.
		 * Before a slope tile is added, all squares below it are populated with full dirt tiles.
		 * After the peak, tiles are horizontally flipped (using the flipped property of MountainTile.
		 */
		void GenerateSlope()
		{
			int currentAltitude = 0;
			int currentX = 0;
			int sequenceNumber = -1; // -1 if not in sequence
			int zeroToFour;

			// generate upward slope (pre-peak)
			// TODO: tbh you could definitely combine this into one loop with the downward slope
			while(currentAltitude < altitude && currentX < altitude){

				// fill in all squares below the current with full dirt tiles
				for(int i = currentAltitude-1; i >= 0; i--){
					mountainTiles[currentX, i].type = TileTypes.FULL;
				}

				zeroToFour = ? (sequenceNumber >= 0) sequenceNumber : 2; // make random lol

				switch (zeroToFour){
					case 0: // flat slope. Y does not change, obvs
						mountainTiles[currentX, currentAltitude].type = TileTypes.FLAT;
						currentX++;
						break;
					case 1: // 22 degree slope sequence
						if (sequenceNumber < 0){
							mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOLOWER;
							sequenceNumber = 1;
						}
						else{
							mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOUPPER;
							sequenceNumber = -1;
							currentAltitude ++; // altitude only changes after sequence is complete
						}
						currentX ++;
						break;
					case 2: // 45 degree slope
						mountainTiles[currentX, currentAltitude].type = TileTypes.FOURTYFIVE;
						currentX++;
						currentAltitude++;
						break;
					case 3: // 67 degree slope sequence
						if (sequenceNumber < 0){
							mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENLOWER;
							sequenceNumber = 3;
						}
						else{
							mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENUPPER;
							sequenceNumber = -1;
							currentX ++; // X only changes after sequence is complete
						}
						currentAltitude ++;
						break;
					case 4: // 90 degree slope. X does not change!
						mountainTiles[currentX, currentAltitude].type = TileTypes.NINETY;
						currentAltitude++;
						break;
				}
			}

			// generate downward slope (post-peak)
			// TODO: combine with previous loop you dingus
			while(currentAltitude > 0 && currentX < altitude){

				// fill in all squares below the current with full dirt tiles
				for(int i = currentAltitude-1; i >= 0; i--){
					mountainTiles[currentX, i].type = TileTypes.FULL;
				}

				zeroToFour = ? (sequenceNumber >= 0) sequenceNumber : 2; // make it random instead of just 2

				// REMEMBER you gotta do upper slopes first on the way down!
				switch (zeroToFour){
					case 0: // flat slope. Y does not change, obvs
						mountainTiles[currentX, currentAltitude].type = TileTypes.FLAT;
						currentX++;
						break;
					case 1: // 22 degree slope sequence
						if (sequenceNumber < 0){
							mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOUPPER;
							sequenceNumber = 1;
						}
						else{
							mountainTiles[currentX, currentAltitude].type = TileTypes.TWENTYTWOLOWER;
							sequenceNumber = -1;
							currentAltitude --; // altitude only changes after sequence is complete
						}
						currentX ++;
						mountainTiles[currentX, currentAltitude].flipped = true;
						break;
					case 2: // 45 degree slope
						mountainTiles[currentX, currentAltitude].type = TileTypes.FOURTYFIVE;
						currentX++;
						currentAltitude--;
						mountainTiles[currentX, currentAltitude].flipped = true;
						break;
					case 3: // 67 degree slope sequence
						if (sequenceNumber < 0){
							mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENLOWER;
							sequenceNumber = 3;
						}
						else{
							mountainTiles[currentX, currentAltitude].type = TileTypes.SIXTYSEVENUPPER;
							sequenceNumber = -1;
							currentX ++; // X only changes after sequence is complete
						}
						currentAltitude --;
						mountainTiles[currentX, currentAltitude].flipped = true;
						break;
					case 4: // 90 degree slope. X does not change!
						mountainTiles[currentX, currentAltitude].type = TileTypes.NINETY;
						currentAltitude --;
						mountainTiles[currentX, currentAltitude].flipped = true;
						break;
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