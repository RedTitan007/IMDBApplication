using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Entities
{
	[Table("Producer")]
	public class Producer
	{
		public Producer()
		{
			this.Movie = new HashSet<Movie>();
		}
		public int ProducerID { get; set; }
		public string ProducerName { get; set; }
		public string ProducerBio { get; set; }
		public DateTime ProducerDOB { get; set; }
		public bool isActive { get; set; }
		public string ProducerCompany { get; set; }
		[Required]
		public int GenderID { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedTS { get; set; }
		public virtual ICollection<Movie> Movie { get; set; }
		[ForeignKey("GenderID")]
		public virtual Gender Gender { get; set; }
	}
	}
