namespace onplix.Domain.Entities
{
	public class WatchHistory
	{
		public Guid Id { get; set; }
		public Guid AccountId { get; set; }
		/// <summary>Content type (it can be title or episode)</summary>
		public string ContentRefType { get; set; }
		/// <summary>Content id (it can be title id or episode it)</summary>
		public Guid ContentRefId { get; set; }
		public int ProgressSeconds { get; set; }
		public bool Completed { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		// Foreign references
		public Account Account { get; set; }
	}
}