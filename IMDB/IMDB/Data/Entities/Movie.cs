using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMDB.Entities
{
    [Table("Movie")]
    public class Movie
    {
        public Movie()
        {
            this.Moviemapping = new HashSet<Moviemapping>();
        }
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public DateTime MovieDOR { get; set; }
        public bool isActive { get; set; }
        public string MoviePoster { get; set; }
        [Required]
        public int ProducerID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }
        [ForeignKey("ProducerID")]
        public virtual Producer Producer { get; set; }
        public virtual ICollection<Moviemapping> Moviemapping { get; set; }

    }
}
