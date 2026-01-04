namespace onplix.Domain.Entities
{
	public class TitleTag
	{
		public Guid TitleId { get; set; }
		public Guid TagId { get; set; }
		// Foreign references
		public Title Title { get; set; }
		public Tag Tag { get; set; }
	}
}
