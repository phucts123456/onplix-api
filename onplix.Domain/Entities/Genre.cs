namespace onplix.Domain.Entities
{
	public class Genre
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		// Foreign references
		public ICollection<TitleGenre> TitleGenres { get; set; }
	}
}
