namespace StatsenkoAA
{
	public sealed class Wall : Environment, ISelectObj
	{
		public string GetMessage()
		{
			return Name;
		}
	}
}