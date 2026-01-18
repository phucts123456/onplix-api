namespace onplix.Domain.Entities
{
	public class Review
	{
		public Guid Id { get; set; }
		public Guid TitleId { get; set; }
		public string Body { get; set; }
		public int Score { get; set; }
		public Title Title { get; set; }
	}
}
