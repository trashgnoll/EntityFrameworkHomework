using EntityFrameworkHomework.Models;
using EntityFrameworkHomework.Repositories;

namespace EntityFrameworkHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var db = new AppContext())
            {
                var user1 = new User { Name = "Arthur", Role = "Admin" };
                var user2 = new User { Name = "Bob", Role = "Admin" };
                var user3 = new User { Name = "Clark", Role = "User" };
                var user4 = new User { Name = "Dan", Role = "User" };
                db.Users.AddRange(user1, user2, user3, user4);

                var Author1 = new Author { Name = "Author1" };
                var Author2 = new Author { Name = "Author2" };
                var Author3 = new Author { Name = "Author3" };
                db.Authors.AddRange(Author1, Author2, Author3);

                var Genre1 = new Genre { Name = "Sci-Fi" };
                var Genre2 = new Genre { Name = "Doc" };
                var Genre3 = new Genre { Name = "Manual" };
                db.Genres.AddRange(Genre1, Genre2, Genre3);

                db.SaveChanges();

                var book1 = new Book
                {
                    Name = "Book 1",
                    PublishYear = 1900,
                    Author = Author1, AuthorId = 1,
                    Genre = Genre1, GenreId = 1
                };

                var book2 = new Book
                {
                    Name = "Book 1",
                    PublishYear = 1900,
                    Author = Author2, AuthorId = 2,
                    Genre = Genre1, GenreId = 1
                };

                var book3 = new Book
                {
                    Name = "Book 1",
                    PublishYear = 1900,
                    Author = Author3, AuthorId = 3,
                    Genre = Genre3, GenreId = 3
                };
                var book4 = new Book
                {
                    Name = "Book 1",
                    PublishYear = 1900,
                    Author = Author1, AuthorId = 1,
                    Genre = Genre2, GenreId = 2
                };

                db.Books.AddRange(book1, book2, book3, book4);
                
                db.SaveChanges();
            }
        }
    }
}