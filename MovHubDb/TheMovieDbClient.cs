﻿using MovHubDb.Model;
using Newtonsoft.Json;
using System;
using System.Net;

namespace MovHubDb
{
    public class TheMovieDbClient
    {
        
        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/search/movie?api_key=bdfb152cef1990377f7fd876d8cf05bb&query=war%20games
        /// </summary>
        public MovieSearchItem[] Search(string title, int page)
        {
            return new MovieSearchItem[0];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508?api_key=bdfb152cef1990377f7fd876d8cf05bb
        /// </summary>
        public Movie MovieDetails(int id) {
            return new Movie();
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/movie/508/credits?api_key=bdfb152cef1990377f7fd876d8cf05bb
        /// </summary>
        public CreditsItem[] MovieCredits(int id) {
            return new CreditsItem[0];
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489?api_key=bdfb152cef1990377f7fd876d8cf05bb
        /// </summary>
        public Person PersonDetais(int actorId)
        {
            return new Person();
        }

        /// <summary>
        /// e.g.: https://api.themoviedb.org/3/person/3489/movie_credits?api_key=bdfb152cef1990377f7fd876d8cf05bb
        /// </summary>
        public MovieSearchItem[] PersonMovies(int actorId) {
            return new MovieSearchItem[0];
        }
        
    }
}
