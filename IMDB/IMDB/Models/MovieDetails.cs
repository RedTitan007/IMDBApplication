using IMDB.Entities;
using System;
using System.Collections.Generic;

namespace IMDB.Models
{
    public class MovieDetails
    {
        //public int MovieID { get; set; }
        //public string MovieName { get; set; }
        //public DateTime MovieDOR { get; set; }
        public Movie Movie { get; set; }
        public List<Actor> Actors { get; set; }
		public Producer Producer { get; set; }
	}
    public class Movie
    {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public DateTime MovieDOR { get; set; }
        public bool isActive { get; set; }
        public string MoviePoster { get; set; }
        public int ProducerID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }


    }
    public class AddMovieDetails {
        public int MovieID { get; set; }
        public string MovieName { get; set; }
        public string MoviePlot { get; set; }
        public DateTime MovieDOR { get; set; }
        public bool isActive { get; set; }
        public string MoviePoster { get; set; }
        public int ProdId { get; set; }
        public List<int> ActorIDs { get; set; }

    }
    public class HttpResponseObject {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    
    }


    public class Actor
    {
        public int ActorID { get; set; }
        public string Actorname { get; set; }
        public bool isActive { get; set; }
        public string ActorBio { get; set; }
        public DateTime ActorDOB { get; set; }
        public int GenderID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }

    }
    public class Producer
    {
        public int ProducerID { get; set; }
        public string ProducerName { get; set; }
        public string ProducerBio { get; set; }
        public DateTime ProducerDOB { get; set; }
        public bool isActive { get; set; }
        public string ProducerCompany { get; set; }
        public int GenderID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedTS { get; set; }
        public virtual ICollection<Movie> Movie { get; set; }
    }
}
