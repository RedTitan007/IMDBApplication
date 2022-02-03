using Catalog.API.Repositories;
using IMDB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace IMDB.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class IMDBController : Controller
    {
        private readonly IIMDBRepository _imdbrepo;
        public IMDBController(IIMDBRepository imdbrepo)
        {
            _imdbrepo=imdbrepo;

        }
        [HttpGet]
        public IEnumerable GetMovieDetails()
        {
            return _imdbrepo.GetMovieDetails();
        }
        [HttpPost]
        public HttpResponseObject AddEditMovieDetails(AddMovieDetails addMovieDetails)
        {
            return _imdbrepo.AddEditMovieDetails(addMovieDetails);
        }


    }
}
