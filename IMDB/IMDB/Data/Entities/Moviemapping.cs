using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Entities
{
	[Table("Moviemapping")]
	public class Moviemapping
	{
		[Required]
		public int MovieID { get; set; }
		[Required]
		public int ActorID { get; set; }
		public bool isActive { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedTS { get; set; }

		[ForeignKey("MovieID")]
		public virtual Movie Movie { get; set; }
		[ForeignKey("ActorID")]
		public virtual Actor Actor { get; set; }
	}
}
