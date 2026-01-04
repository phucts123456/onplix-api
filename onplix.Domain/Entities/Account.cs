namespace onplix.Domain.Entities
{
	public class Account
	{
		public Guid Id { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string DisplayName { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public bool IsActive { get; set; }
		public string AvatarUrl { get; set; }
		public string MaturityRating { get; set; } 

		// Foreign preferences
		public ICollection<Subscription> Subscriptions { get; set; }
		public ICollection<WatchHistory> WatchHistories { get; set; }
	}
}
