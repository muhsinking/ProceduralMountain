namespace KoboldMountain
{
	public class MountainTile
	{
		public int type { get; set;}
		public float X { get; set;}
		public float Y { get; set;}
		public bool flipped { get; set;}

		public MountainTile(int type, float X, float Y, bool flipped)
		{
			this.type = type;
			this.X = X;
			this.Y = Y;
			this.flipped = flipped;
		}
	}
}