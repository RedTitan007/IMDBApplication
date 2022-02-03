using IMDB.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public interface IIMDBRepository
    {
        IEnumerable<MovieDetails> GetMovieDetails();

         HttpResponseObject AddEditMovieDetails(AddMovieDetails addMovieDetails);
        //Task<Product> GetProduct(string id);

        //Task<IEnumerable<Product>> GetProductByName(string name);

        //Task<IEnumerable<Product>> GetProductByCategory(string categoryName);

        //Task CreateProduct(Product product);
        //Task<bool> UpdateProduct(Product product);
        //Task<bool> DeleteProduct(string id);
    }
}
