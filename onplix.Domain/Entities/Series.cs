using System;
using System.Collections.Generic;
using System.Text;

namespace onplix.Domain.Entities
{
	public class Series
	{
		public Guid Id { get; set; }
		public Guid TitleId { get; set; }
		public Title Title { get; set; }
		// Foreign references
		public ICollection<Season> Seasons { get; set; }
	}
}
