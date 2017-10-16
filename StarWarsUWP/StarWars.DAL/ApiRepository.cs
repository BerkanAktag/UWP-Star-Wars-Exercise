using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
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

        public Movie GetMovieByUrl(string url)
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
            var planet = new Planet();
            
            HttpResponseMessage response = _httpClient.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
                allMovies = response.Content.ReadAsAsync<ResultsPage<Movie>>().Result.Results;

            for (int i = 0; i < allMovies.Count; i++)
            {
                allMovies[i].Planets = new List<Planet>();
                for (int j = 0; j < allMovies[i].PlanetUris.Count; j++)
                {
                    string planetsUrl = "api/planets/" + allMovies[i].PlanetUris[j].Substring(allMovies[i].PlanetUris[j].Length - 2);
                    HttpResponseMessage responseMovie = _httpClient.GetAsync(planetsUrl).Result;

                    if (responseMovie.IsSuccessStatusCode)
                    {
                        planet = responseMovie.Content.ReadAsAsync<Planet>().Result;
                        allMovies[i].Planets.Add(planet);
                    }
                }
            }


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
