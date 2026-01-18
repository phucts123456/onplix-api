namespace onplix.Domain.Entities
{
	public class Series
	{
		public Guid Id { get; set; }
		public Guid TitleId { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		// Foreign references
		public Title Title { get; set; }
		public ICollection<Season> Seasons { get; set; }
	}
}
