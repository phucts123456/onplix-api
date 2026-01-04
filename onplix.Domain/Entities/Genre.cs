namespace onplix.Domain.Entities
{
	public class Genre
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		// Foreign references
		public ICollection<TitleGenre> TitleGenres { get; set; }
	}
}
