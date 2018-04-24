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

		public TileBrush(ContentManager content)
		{
			flat = new SpriteClass(content, "mountain-tiles/flat");
			fourtyFive = new SpriteClass(content, "mountain-tiles/fourtyfive");
		}

		public void Draw(SpriteBatch spriteBatch, MountainTile tile)
		{
			if (tile.type == TileTypes.FLAT)
			{
				flat.X = tile.X;
				flat.Y = tile.Y;
				flat.Draw(spriteBatch);
			}

			if (tile.type == TileTypes.FOURTYFIVE)
			{
				fourtyFive.X = tile.X;
				fourtyFive.Y = tile.Y;
				fourtyFive.Draw(spriteBatch);
			}
		}
	}
}
