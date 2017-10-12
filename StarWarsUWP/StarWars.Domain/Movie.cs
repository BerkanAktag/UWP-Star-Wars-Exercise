using Newtonsoft.Json;
using StarWars.Domain.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StarWars.Domain
{
    public class Movie : INotifyPropertyChanged
    {
        private string _title { get; set; }
        private string _director { get; set; }
        private string _producer { get; set; }
        private DateTime _releasedate { get; set; }
        private double _rating { get; set; }

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }


        [JsonProperty(PropertyName = "episode_id")]
        public int EpisodeId { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        public string Director
        {
            get { return _director; }
            set
            {
                _director = value;
                OnPropertyChanged(nameof(Director));
            }
        }

        public string Producer
        {
            get { return _producer; }
            set
            {
                _producer = value;
                OnPropertyChanged(nameof(Producer));
            }
        }

        [JsonProperty(PropertyName = "release_date")]
        public DateTime ReleaseDate {
            get { return _releasedate; }
            set
            {
                _releasedate = value;
                OnPropertyChanged(nameof(ReleaseDate));
            }
            
        }

        public double Rating
        {
            get { return _rating; }
            set
            {
                if (value > 10)
                {
                    _rating = 10;
                }
                else if (value < 0)
                {
                    _rating = 0;
                }
                else
                {
                    _rating = value;
                }
                    
                OnPropertyChanged(nameof(Rating));

            }
        }


        [JsonIgnore]
        public virtual ICollection<Planet> Planets { get; set; }

        [JsonProperty(PropertyName = "planets")]
        public List<string> PlanetUris { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //Same as above
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
        }

        
    }
}
