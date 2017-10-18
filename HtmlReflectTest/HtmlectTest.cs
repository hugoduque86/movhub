using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovHubDb;
using HtmlReflect;
using MovHubDb.Model;

namespace HtmlReflectTest
{
    [TestClass]
    public class HtmlectTest
    {
        [TestMethod]
        public void ToHtmlArrayTest()
        {
            Htmlect html = new Htmlect();
            string r =html.ToHtml(a.Search("Deadpool",1));
            Console.WriteLine(r);
        }

        [TestMethod]
        public void ToHtmlTest()
        {
            Htmlect html = new Htmlect();
            string r = html.ToHtml(a.MovieDetails(58));
        }

        [TestMethod]
        public void TestSearch()
        {
            
            MovieSearchItem[] B =a.Search("Deadpool", 1);
            foreach (var item in B)
            {
                Console.WriteLine(item.Id);
            }
        }
        TheMovieDbClient a = new TheMovieDbClient();
        [TestMethod]
        public void MovieDetails()
        {
            
            a.MovieDetails(508);
        }
        [TestMethod]
        public void MovieCredits()
        {
            a.MovieCredits(1018);
        }
        [TestMethod]
        public void PersonCredits()
        {
            a.PersonDetais(85);

        }
        [TestMethod]
        public void PersonMovies()
        {
            a.PersonMovies(85);
        }

        [TestMethod]
        public void TestIfCacheWorking()
        {
            Assert.AreEqual(a.PersonDetais(85), a.PersonDetais(85));
        }
    }
}
