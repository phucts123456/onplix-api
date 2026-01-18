namespace onplix.Domain.Entities
{
	public class Operator
	{
		
		public Guid Id { get; set; }
		public string Email { get; set; } // login identifier 
		public string PasswordHash { get; set; } // securely stored hash 
		public string DisplayName { get; set; } 
		public string Role { get; set; } // e.g. "superadmin", "editor", "moderator" 
		public bool IsActive { get; set; } // active/inactive flag 
		public DateTime CreatedAt { get; set; } 
		public DateTime UpdatedAt { get; set; }
	}
}
