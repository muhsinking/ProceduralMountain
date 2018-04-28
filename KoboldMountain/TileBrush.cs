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
		SpriteClass sixtySeverUpper;
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
		}

		public void Draw(SpriteBatch spriteBatch, MountainTile tile)
		{
			SpriteClass spriteToDraw;
		
			// TODO switch to a switch lol
			// To flip tiles horizontall, ideally I should create a spritesheet of the two versions, and choose which version based on tile.flipped 
			// It's probably possible to flip the tiles horizontally,
			// but according to the internet it's less overhead to just bake in the flipped version
			if (tile.type == TileTypes.FULL)
				spriteToDraw = full;
			else if (tile.type == TileTypes.FLAT) 
				spriteToDraw = flat;
			else if (tile.type == TileTypes.FOURTYFIVE) 
				spriteToDraw = fourtyfive;
			else if (tile.type == TileTypes.TWENTYTWOLOWER) 
				spriteToDraw = twentyTwoLower;
			else if (tile.type == TileTypes.TWENTYTWOUPPER)
				spriteToDraw = twentyTwoUpper;
			else if (tile.type == TileTypes.SIXTYSEVENLOWER)
				spriteToDraw = sixtySevenLower;
			else if (tile.type == TileTypes.SIXTYSEVENUPPER)
				spriteToDraw = sixtySevenUpper;

			spriteToDraw.X = tile.X;
			spriteToDraw.Y = tile.Y;
			spriteToDraw.Draw(spriteBatch); //spriteToDraw may not have been initialized?
		}
	}
}
