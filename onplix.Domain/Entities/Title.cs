namespace onplix.Domain.Entities
{
	public class Title
	{	
		public Guid Id { get; set; }
		/// <summary>Title type (it can be title/episode</summary>
		public string Type { get; set; }
		public string Name { get; set; }
		public string ReleasedYear { get; set; }
		public string MaturityRating { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; } 
		public string PreviewUrl { get; set; }
		
		// Foreign preferences
		public ICollection<Review> Reviews { get; set; } 
		public ICollection<TitleGenre> TitleGenres { get; set; } 
		public ICollection<TitleTag> TitleTags { get; set; } 
		public ICollection<Credit> Credits { get; set; } 
		public ICollection<Episode> Episodes { get; set; } 
		public Series Series { get; set; }
	}
}
