using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Entities
{
	[Table("Gender")]
	public class Gender
	{
		public int GenderID { get; set; }
		public string GenderName { get; set; }
		public bool isActive { get; set; }
		public string CreatedBy { get; set; }
		public DateTime CreatedTS { get; set; }
	}
}
