using System;
using System.Collections.Generic;
using System.Text;

namespace onplix.Domain.Entities
{
	public class Season
	{
		public Guid Id { get; set; }
		public Guid SeriesId { get; set; }
		public string Name { get; set; }
		public string SeasonNumber { get; set; }
		public Series Series { get; set; }
		// Foreign references
		public ICollection<Episode> Episodes { get; set; }
	}
}
