using EntityFrameworkHomework.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Identity.Client;
using System.Formats.Asn1;

namespace EntityFrameworkHomework.Repositories
{
    public static class BookRepository
    {
        /// <summary>Returns a book by id or null</summary>
        public static Book? GetBookById(AppContext db, int bookId)
        {
            return db.Books.Where(book => book.Id == bookId).FirstOrDefault();
        }
        /// <summary>Returns all books</summary>
        public static Book[] GetAllBooks(AppContext db)
        {
            return db.Books.ToArray();
        }
        /// <summary>Add book to database</summary>
        /// <returns><b>True</b> if added, otherwise False</returns>
        public static bool AddBook(AppContext db, Book book)
        {
            EntityEntry result = db.Books.Add(book);
            db.SaveChanges();
            return result is not null;
        }
        /// <summary>Remove book from database</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool RemoveBook(AppContext db, Book book)
        {
            EntityEntry result = db.Books.Remove(book);
            db.SaveChanges();
            return result is not null;
        }
        /// <summary>Remove book from database by id</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool RemoveBook(AppContext db, int bookId)
        {
            Book book = new()
            {
                Id = bookId
            };
            // changes will be saved below
            return RemoveBook(db, book);
        }
        /// <summary>Update book publish year by id</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool ChangeBookPublishYear(AppContext db, int bookId, int newPublishYear)
        {
            int updated = db.Books
                            .Where(u => u.Id == bookId)
                            .ExecuteUpdate(c => c.SetProperty(b => b.PublishYear, newPublishYear));
            db.SaveChanges();
            return updated > 0;
        }

        /// <summary>Получать список книг определенного жанра</summary>
        public static Book[] GetBooksByGenre(AppContext db, int genreId)
        {
            return db.Books.Where(book => book.GenreId == genreId).ToArray();
        }
        /// <summary>вышедших между определенными годами.</summary>
        public static Book[] GetBooksPublishedBetween(AppContext db, int fromYear, int toYear)
        {
            return db.Books.Where(book => ( book.PublishYear >= fromYear ) &&
                                          ( book.PublishYear <= toYear) ).ToArray();
        }
        /// <summary>Получать булевый флаг о том, есть ли книга определенного автора и с определенным названием в библиотеке</summary>
        public static bool IsBookOfAuthorAndName(AppContext db, string authorName, string bookName)
        {
            return db.Books.Any(book => ( book.Author.Name.ToUpper() == authorName.ToUpper() ) &&
                                        ( book.Name.ToUpper() == bookName.ToUpper() ));
        }
        /// <summary>Получение списка всех книг, отсортированного в алфавитном порядке по названию.</summary>
        public static Book[] GetAllBooksSortAbc(AppContext db)
        {
            return db.Books.OrderBy(book => book.Name).ToArray();
        }
        /// <summary>Получение списка всех книг, отсортированного в порядке убывания года их выхода.</summary>
        public static Book[] GetAllBooksSortYearDesc(AppContext db)
        {
            return db.Books.OrderByDescending(book => book.PublishYear).ToArray();
        }
        /// <summary>Получение последней вышедшей книги.</summary>
        public static Book? GetLastPublishedBook(AppContext db)
        {
            return GetAllBooksSortYearDesc(db).FirstOrDefault();
        }
        /// <summary>Получать количество книг определенного автора в библиотеке.</summary>
        public static int GetAuthorBooksCount(AppContext db, int authorId )
        {
            return db.Books.Count(book => book.AuthorId == authorId);
        }
        /// <summary>Получать количество книг определенного автора в библиотеке.</summary>
        public static int GetAuthorBooksCount(AppContext db, string authorName)
        {
            return db.Books.Count(book => book.Author.Name.ToUpper() == authorName.ToUpper());
        }
        /// <summary>Получать количество книг определенного жанра в библиотеке.</summary>
        public static int GetGenreBooksCount(AppContext db, int genreId)
        {
            return db.Books.Count(book => book.AuthorId == genreId);
        }
        /// <summary>Получать количество книг определенного жанра в библиотеке.</summary>
        public static int GetGenreBooksCount(AppContext db, string genreName)
        {
            return db.Books.Count(book => book.Genre.Name.ToUpper() == genreName.ToUpper() );
        }
    }
}
