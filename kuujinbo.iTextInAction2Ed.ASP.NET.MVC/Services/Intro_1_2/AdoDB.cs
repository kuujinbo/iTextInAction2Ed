/*
 * ###########################################################################
 * SQLite is fast, low overhead, and so easy to use...
 * ###########################################################################
 * System.Data.SQLite:
 * https://system.data.sqlite.org/index.html/doc/trunk/www/index.wiki
 * ###########################################################################
 * System.Data.SQLite is the ADO.NET provider for the SQLite database engine:
 * http://www.sqlite.org/
 * ###########################################################################
*/
using System;
using System.Data.Common;
using System.Web.Configuration;

namespace kuujinbo.iTextInAction2Ed.ASP.NET.MVC.Services.Intro_1_2
{
    public class AdoDB
    {
        // ===========================================================================
        public static readonly string CS;
        public static readonly DbProviderFactory Provider;
        static AdoDB()
        {
            CS = WebConfigurationManager.ConnectionStrings["iTextEx"]
                 .ConnectionString;
            Provider = DbProviderFactories.GetFactory("System.Data.SQLite");
        }
        // ---------------------------------------------------------------------------
        /** SQL statement to get all the movies of the festival. */
        public const String MOVIES =
    @"SELECT m.id, m.title, m.original_title, m.imdb, m.year, m.duration, 
e.year, c.name, c.keyword, c.color 
FROM film_movietitle m, festival_entry e, festival_category c 
  WHERE m.id = e.film_id AND e.category_id = c.id 
ORDER BY m.title";
        // ---------------------------------------------------------------------------
        /** SQL statement to get the directors of a specific movie. */
        public const String DIRECTORS =
    @"SELECT d.name, d.given_name 
FROM film_director d, film_movie_director md 
  WHERE md.film_id = @film_id AND md.director_id = d.id";
        // ---------------------------------------------------------------------------  
        /** SQL statement to get the movies of a specific director. */
        public const String MOVIEDIRECTORS =
    @"SELECT m.id, m.title, m.original_title, m.imdb, m.year, m.duration 
FROM film_movietitle m, film_movie_director md 
  WHERE md.director_id = @director_id AND md.film_id = m.id
ORDER BY m.title";
        // ---------------------------------------------------------------------------
        /** SQL statement to get the countries of a specific movie. */
        public const String COUNTRIES =
    @"SELECT c.country 
FROM film_country c, film_movie_country mc 
  WHERE mc.film_id = @film_id AND mc.country_id = c.id";
        // ---------------------------------------------------------------------------  
        /** SQL statement to get the movies from a specific country. */
        public const String MOVIECOUNTRIES =
    @"SELECT m.id, m.title, m.original_title, m.imdb, m.year, m.duration
FROM film_movietitle m, film_movie_country mc 
  WHERE mc.country_id = @country_id AND mc.film_id = m.id 
ORDER BY m.title";
        // ---------------------------------------------------------------------------
        /** SQL statement to get all the days of the festival. */
        public const String DAYS =
            "SELECT DISTINCT day FROM festival_screening ORDER BY day";
        // ---------------------------------------------------------------------------        
        /** SQL statament to get all the locations at the festival */
        public const String LOCATIONS =
            "SELECT DISTINCT location FROM festival_screening ORDER by location";
        // ---------------------------------------------------------------------------        
        /** SQL statement to get screenings. */
        public const String SCREENINGS =
    @"SELECT m.title, m.original_title, m.imdb, m.year, m.duration,
s.day, s.time, s.location, s.press, 
e.year, c.name, c.keyword, c.color, m.id 
FROM festival_screening s, film_movietitle m, 
festival_entry e, festival_category c 
WHERE day = @day AND s.film_id = m.id 
AND m.id = e.film_id AND e.category_id = c.id";
        // ---------------------------------------------------------------------------
        /** SQL statement to get screenings. */
        public const String MOVIESCREENINGS =
    @"SELECT s.day, s.time, s.location, s.press 
FROM festival_screening s 
WHERE s.film_id = @film_id";
        // ---------------------------------------------------------------------------
        /** SQL statement to get screenings. */
        public const String PRESS =
    @"SELECT m.title, m.original_title, m.imdb, m.year, m.duration,
s.day, s.time, s.location, s.press,
e.year, c.name, c.keyword, c.color, m.id 
FROM festival_screening s, film_movietitle m, 
festival_entry e, festival_category c 
WHERE s.press=1 AND s.film_id = m.id 
AND m.id = e.film_id AND e.category_id = c.id 
ORDER BY day, time ASC";
        // ===========================================================================  
    }
}