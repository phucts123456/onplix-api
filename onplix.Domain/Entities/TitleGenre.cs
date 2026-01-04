namespace onplix.Domain.Entities
{
	public class TitleGenre
	{
		public Guid TitleId { get; set; }
		public Guid GenreId { get; set; }

		// Foreign references
		public Title Title { get; set; }
		public Genre Genre { get; set; }
	}
}
