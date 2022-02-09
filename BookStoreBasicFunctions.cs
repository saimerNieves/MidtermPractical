using MidtermPractical.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidtermPractical
{
    public class BookStoreBasicFunctions
    {


        public static List<Book> GetAllBooksByBookTitle(string bookTitle)
        {

            try
            {
                using (var database = new SE407_BookStoreContext())
                {

                    return database.Books

                        .Join(database.Authors,
                        m => m.AuthorId,
                        d => d.AuthorId,
                        (m, d) => new
                        {
                            BookId = m.BookId,
                            BookTitle = m.BookTitle,
                            GenreId = m.GenreId,
                            AuthorId = m.AuthorId,
                            YearOfRelease = m.YearOfRelease,

                            AuthorFirst = d.AuthorFirst,
                            AuthorLast = d.AuthorLast
                        }).Where(d => d.BookTitle == bookTitle)
                        .Select(m => new Book
                        {

                            BookId = m.BookId,
                            BookTitle = m.BookTitle,
                            YearOfRelease = m.YearOfRelease,
                            GenreId = m.GenreId,
                            AuthorId = m.AuthorId,

                        }).ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }



        public static List<Book> GetAllBooksByAuthorLastName(string authorLastName)
        {

            try
            {
                using (var database = new SE407_BookStoreContext())
                {

                    return database.Books

                        .Join(database.Authors,
                        m => m.AuthorId,
                        d => d.AuthorId,
                        (m, d) => new
                        {
                            BookId = m.BookId,
                            BookTitle = m.BookTitle,
                            GenreId = m.GenreId,
                            AuthorId = m.AuthorId,
                            YearOfRelease = m.YearOfRelease,
                            
                            AuthorFirst = d.AuthorFirst,
                            AuthorLast = d.AuthorLast
                        }).Where(d => d.AuthorLast == authorLastName)
                        .Select(m => new Book
                        {

                            BookId = m.BookId,
                            BookTitle = m.BookTitle,
                            YearOfRelease = m.YearOfRelease,
                            GenreId = m.GenreId,
                            AuthorId = m.AuthorId,

                        }).ToList();//Basic select
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return null;

            }
        }




        public static List<Book> GetAllBooks()
        {
            using (var db = new SE407_BookStoreContext())
            {
                return db.Books.ToList();
            }
        }
    }
}
