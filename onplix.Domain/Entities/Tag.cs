using System;
using System.Collections.Generic;
using System.Text;

namespace onplix.Domain.Entities
{
	public class Tag
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		// Foreign references
		public ICollection<TitleTag> TitleTags { get; set; }
	}
}
