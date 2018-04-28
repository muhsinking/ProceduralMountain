namespace KoboldMountain
{

// For now let's say each tile represents 10 feet. That makes everest ~2000 tiles tall. Yikes!

	public class MountainTile
	{
		public int type { get; set;}
		public float X { get; set;}
		public float Y { get; set;}
		public bool flipped { get; set;}
		// This should ultimately contain some info about the "scenery" on the tile. Like snow, plants, etc.

		public MountainTile(int type, float X, float Y)
		{
			this.type = type;
			this.X = X;
			this.Y = Y;
			this.flipped = false;
		}
	}
}