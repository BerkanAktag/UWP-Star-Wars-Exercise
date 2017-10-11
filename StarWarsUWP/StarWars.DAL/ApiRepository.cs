using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using StarWars.Domain;

namespace StarWars.DAL
{
    public class ApiRepository : IRepository
    {
        private readonly HttpClient _httpClient;

        public ApiRepository()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://swapi.co"),
            };    
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public Movie GetMobieByUrl(string url)
        {
            var movie = new Movie();

            HttpResponseMessage response =
                _httpClient.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
                movie = response.Content.ReadAsAsync<Movie>().Result;
            
            return movie;
        }

        public IList<Movie> GetAllMovies()
        {
            var url = "api/films";
            var allMovies = new List<Movie>();

            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
                allMovies = response.Content.ReadAsAsync<ResultsPage<Movie>>().Result.Results;

            return allMovies;
        }

        
    }
        internal class ResultsPage<T>
        {
            public int Count { get; set; }
            public String Next { get; set; }
            public string Previous { get; set; }
            public List<T> Results { get; set; }
        }
}
