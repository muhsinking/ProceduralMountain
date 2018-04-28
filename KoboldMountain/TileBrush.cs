using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace KoboldMountain
{
	public class TileBrush
	{
		SpriteClass empty;
		SpriteClass full;
		SpriteClass flat;
		SpriteClass fourtyFive;
		SpriteClass twentyTwoLower;
		SpriteClass twentyTwoUpper;
		SpriteClass sixtySevenLower;
		SpriteClass sixtySevenUpper;
		SpriteClass ninety;
		ContentManager content;

		/*
		* Ideally, I should read these files directly from the folder into a table. 
		* But I'm on an airplane and bored so let's do it the dumb way!
		*/
		public TileBrush(ContentManager content)
		{
			full = new SpriteClass(content, "mountain-tiles/dirt-full");
			flat = new SpriteClass(content, "mountain-tiles/flat");
			fourtyFive = new SpriteClass(content, "mountain-tiles/fourtyfive");
			twentyTwoLower = new SpriteClass(content, "mountain-tiles/22-lower"); // not sure if numbers work here? had some issues in the past
			twentyTwoUpper = new SpriteClass(content, "mountain-tiles/22-upper");
			sixtySevenLower = new SpriteClass(content, "mountain-tiles/67-lower");
			sixtySevenUpper = new SpriteClass(content, "mountain-tiles/67-upper");
			ninety = new SpriteClass(content, "mountain-tiles/90");
		}

		public void Draw(SpriteBatch spriteBatch, MountainTile tile)
		{
			if (tile.type == TileTypes.EMPTY) return;
			SpriteClass spriteToDraw = full;
			switch (tile.type)
			{
				case TileTypes.FULL:
					spriteToDraw = full;
					break;
				case TileTypes.FLAT:
					spriteToDraw = flat;
					break;
				case TileTypes.FOURTYFIVE:
					spriteToDraw = fourtyFive;
					break;
				case TileTypes.TWENTYTWOLOWER:
					spriteToDraw = twentyTwoLower;
					break;
				case TileTypes.TWENTYTWOUPPER:
					spriteToDraw = twentyTwoUpper;
					break;
				case TileTypes.SIXTYSEVENLOWER:
					spriteToDraw = sixtySevenLower;
					break;
				case TileTypes.SIXTYSEVENUPPER:
					spriteToDraw = sixtySevenUpper;
					break;
				case TileTypes.NINETY:
					spriteToDraw = ninety;
					break;
			}

			spriteToDraw.X = tile.X;
			spriteToDraw.Y = tile.Y;
			spriteToDraw.Draw(spriteBatch); //spriteToDraw may not have been initialized?
		}
	}
}
