namespace onplix.Domain.Entities
{
	public class Episode
	{
		public Guid Id { get; set; }
		public Guid SeasonId { get; set; }
		public Guid TitleId { get; set; }
		public string EpisodeNumber { get; set; }
		public string Description { get; set; }
		public DateTime ReleasedDate { get; set; }
		public int EpisodeLengthSeconds { get; set; }
		// Foreign references
		public Season Season { get; set; }
		public Title Title { get; set; }
		public ICollection<MediaAsset> MediaAssets { get; set; }
	}
}
