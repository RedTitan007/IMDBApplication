using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Entities
{
	[Table("Actor")]
	public class Actor
	{
        public Actor()
        {
			this.Moviemapping = new HashSet<Moviemapping>();
		}
        public int ActorID { get; set; }
		public string Actorname { get; set; }
		public bool isActive { get; set; }
		public string ActorBio { get; set; }
		public DateTime ActorDOB { get; set; }
		[Required]
		public int GenderID { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedTS { get; set; }
		[ForeignKey("GenderID")]
		public virtual Gender Gender { get; set; }
		public virtual ICollection<Moviemapping> Moviemapping { get; set; }

	}
}
