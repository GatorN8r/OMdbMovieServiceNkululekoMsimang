﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMDbConsoleApp.Model
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public List<Rating> Ratings { get; set; }
        public string Metascore { get; set; }
        public string imdbRating { get; set; }
        public string imdbVotes { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string DVD { get; set; }
        public string BoxOffice { get; set; }
        public string Production { get; set; }
        public string Website { get; set; }
        public string Response { get; set; }

        public override string ToString()
        {
                return $@"Title: {Title}
                Year: {Year}
                Rated: {Rated}
                Released: {Released}
                Runtime: {Runtime}
                Genre: {Genre}
                Director: {Director}
                Writer: {Writer}
                Actors: {Actors}
                Plot: {Plot}
                Language: {Language}
                Country: {Country}
                Awards: {Awards}
                Poster: {Poster}
                Metascore: {Metascore}
                imdbRating: {imdbRating}
                imdbVotes: {imdbVotes}
                imdbID: {imdbID}
                Type: {Type}
                DVD: {DVD}
                BoxOffice: {BoxOffice}
                Production: {Production}
                Website: {Website}
                Response: {Response}";
        }
    }
}
