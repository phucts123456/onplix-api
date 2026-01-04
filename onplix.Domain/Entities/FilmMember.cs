namespace onplix.Domain.Entities
{
	public class FilmMember
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Bio { get; set; }
		public string AvatarUrl { get; set; }
		// Foreign references
		public ICollection<Credit> Credits { get; set; }
	}
}
