namespace onplix.Domain.Entities
{
	public class Subscription
	{
		public Guid Id { get; set; }
		public Guid AccountId { get; set; }
		public Guid PlanId { get; set; }
		public DateTime CurrentPeriodStart { get; set; }
		public DateTime CurrentPeriodEnd { get; set; }
		public DateTime? CancelAt { get; set; }
		public decimal TotalPrice { get; set; }
		public Guid PaymentId { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		// Foreign references
		public Account Account { get; set; }
		public Plan Plan { get; set; }
	}
}
