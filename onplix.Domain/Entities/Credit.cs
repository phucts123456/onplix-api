namespace onplix.Domain.Entities
{
	public class Credit
	{
		public Guid Id { get; set; }
		public Guid TitleId { get; set; }
		public Guid FilmMemberId { get; set; }
		public string Role { get; set; }
		public string CharacterName { get; set; }
		// Foreign references
		public Title Title { get; set; }
		public FilmMember FilmMember { get; set; }
	}
}
