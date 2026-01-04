namespace onplix.Domain.Entities
{
	public class MediaAsset
	{
		public Guid Id { get; set; }
		/// <summary>Content type (it can be title or episode)</summary>
		public string ContentRefType { get; set; }
		/// <summary>Content id (it can be title id or episode it)</summary>
		public Guid ContentRefId { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}
