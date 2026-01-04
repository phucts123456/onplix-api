namespace onplix.Domain.Entities
{
	public class Plan
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int MaxDevices { get; set; }
		public decimal Price { get; set; }
		public string Currency { get; set; }
		// Foreign references
		public ICollection<Subscription> Subscriptions { get; set; }
	}
}
