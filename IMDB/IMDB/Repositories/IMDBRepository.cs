using IMDB.Entities;
using IMDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class IMDBRepository : IIMDBRepository
    {
        private readonly IMDBDBContext _context;
        private readonly string _user;

        public IMDBRepository(IMDBDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _user = "admin";
        }
        public IEnumerable<MovieDetails> GetMovieDetails()
        {
            var movieDetails = new List<MovieDetails>();
            try
            {

                var movieActors = (from mov in _context.Movie.Where(a => a.isActive)
                                   join prod in _context.Producer.Where(a => a.isActive)
                                    on mov.ProducerID equals prod.ProducerID
                                   join actmov in _context.Moviemapping.Where(a => a.isActive)
                                      on mov.MovieID equals actmov.MovieID
                                   join act in _context.Actor.Where(a => a.isActive)
                                   on actmov.ActorID equals act.ActorID
                                   select new
                                   {
                                       MovieID = mov.MovieID,
                                       MovieName = mov.MovieName,
                                       MoviePoster = mov.MoviePoster,
                                       Moviereleasedate = mov.MovieDOR,
                                       Moviedescription = mov.MoviePlot,
                                       ActorID = act.ActorID,
                                       Actorname = act.Actorname,
                                       ProducerID = prod.ProducerID,
                                       ProducerName = prod.ProducerName
                                   }
                                 ).ToList();
                var Moviedata = movieActors.GroupBy(a => new { a.MovieID, a.MovieName }).Select(a => a.FirstOrDefault()).ToList();

                Moviedata.ForEach(a =>
                {
                    MovieDetails md = new MovieDetails();
                    IMDB.Models.Movie m = new IMDB.Models.Movie();
                    IMDB.Models.Producer p = new IMDB.Models.Producer();
                    List<IMDB.Models.Actor> Actordetails = new List<IMDB.Models.Actor>();

                    m.MovieName = a.MovieName;
                    m.MovieID = a.MovieID;
                    m.MovieDOR = a.Moviereleasedate;
                    m.MoviePoster = a.MoviePoster;
                    m.MoviePlot = a.Moviedescription;
                    Actordetails = movieActors.Where(b => b.MovieID == a.MovieID).Select(c => new IMDB.Models.Actor()
                    {
                        ActorID = c.ActorID,
                        Actorname = c.Actorname
                    }).ToList();

                    md.Movie = m;
                    md.Actors=Actordetails;
                    p.ProducerID = a.ProducerID;
                    p.ProducerName = a.ProducerName;
                    md.Producer = p;
                    movieDetails.Add(md);
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return movieDetails.ToList();
        }
        public HttpResponseObject AddEditMovieDetails(AddMovieDetails addMovieDetails)
        {
            HttpResponseObject hro = new HttpResponseObject();
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (addMovieDetails.MovieID > 0)
                    {
                        var MovieData = _context.Movie.FirstOrDefault(a => a.MovieID == addMovieDetails.MovieID && a.isActive);
                        if (MovieData != null)
                        {
                            MovieData.MovieName = addMovieDetails.MovieName;
                            MovieData.MoviePlot = addMovieDetails.MoviePlot;
                            MovieData.MoviePoster = addMovieDetails.MoviePoster;
                            MovieData.MovieDOR = addMovieDetails.MovieDOR;
                            MovieData.ProducerID = addMovieDetails.ProdId;
                            MovieData.isActive = true;

                            var AllmovieMapping = _context.Moviemapping.Where(a => a.MovieID == addMovieDetails.MovieID).ToList();//1,2

                            var movieMapping = AllmovieMapping.Where(a => a.isActive).ToList();

                            var Existingids = movieMapping.Select(a => a.ActorID).ToArray();

                            var commmonids = Existingids.Intersect(addMovieDetails.ActorIDs).ToList();

                            addMovieDetails.ActorIDs.ForEach(a =>//3,4
                            {
                                if (!movieMapping.Any(b => b.ActorID == a))
                                {
                                    if (AllmovieMapping.Any(b => b.ActorID == a))
                                    {
                                        AllmovieMapping.FirstOrDefault(b => b.ActorID == a).isActive = true;

                                    }
                                    else
                                    {
                                        Moviemapping mov = new Moviemapping();
                                        mov.ActorID = a;
                                        mov.MovieID = addMovieDetails.MovieID;
                                        mov.isActive = true;
                                        mov.CreatedBy = _user;
                                        mov.CreatedTS = DateTime.UtcNow;
                                        _context.Moviemapping.AddRangeAsync(mov);
                                    }
                                }
                            });
                            if (commmonids.Any())
                            {
                                movieMapping.Where(a => !commmonids.Contains(a.ActorID) && a.MovieID == addMovieDetails.MovieID && a.isActive)
                                    .ToList().ForEach(a => { a.isActive = false; });
                            }
                            _context.SaveChanges();
                            hro.IsSuccess = true;
                            hro.Message = "Data Updated Sucessfully";
                        }

                    }
                    else {
                        IMDB.Entities.Movie mov = new IMDB.Entities.Movie();
                        mov.MovieName = addMovieDetails.MovieName;
                        mov.MoviePlot = addMovieDetails.MoviePlot;
                        mov.MoviePoster = addMovieDetails.MoviePoster;
                        mov.MovieDOR = addMovieDetails.MovieDOR;
                        mov.ProducerID = addMovieDetails.ProdId;
                        mov.isActive = true;
                        mov.CreatedBy = _user;
                        mov.CreatedTS = DateTime.UtcNow;
                        _context.Movie.Add(mov);
                        _context.SaveChanges();

                        var addmapping = addMovieDetails.ActorIDs.Select(a => new Moviemapping()
                        {
                            ActorID = a,
                            MovieID = mov.MovieID,
                            isActive = true,
                            CreatedBy = _user,
                            CreatedTS = DateTime.UtcNow
                        }).ToList();
                        _context.Moviemapping.AddRangeAsync(addmapping);
                        _context.SaveChanges();
                        hro.IsSuccess = true;
                        hro.Message = "Data Added Sucessfully";
                    }
                    transaction.Commit();
                    return hro;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    hro.IsSuccess = false;
                    hro.Message = ex.Message+ex.InnerException + ex.StackTrace;
                    return hro;
                }
            }
        }
    }
}
