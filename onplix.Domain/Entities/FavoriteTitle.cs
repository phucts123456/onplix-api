namespace onplix.Domain.Entities
{
	public class FavoriteTitle
	{
		public Guid AccountId { get; set; }
		public Guid TitleId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }

		// Foreign references
		public Title Title { get; set; }
		public Account Account { get; set; }
	}
}
