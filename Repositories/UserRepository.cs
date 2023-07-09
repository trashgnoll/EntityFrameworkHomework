using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkHomework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Identity.Client;

namespace EntityFrameworkHomework.Repositories
{
    public static class UserRepository
    {
        /// <summary>Returns a user by id or null</summary>
        public static User? GetUserById( AppContext db, int userId )
        {
            return db.Users.Where(user => user.Id == userId).FirstOrDefault();
        }
        /// <summary>Returns all users</summary>
        public static User[] GetAllUsers( AppContext db )
        {
            return db.Users.ToArray();
        }
        /// <summary>Add user to database</summary>
        /// <returns><b>True</b> if added, otherwise False</returns>
        public static bool AddUser( AppContext db, User user )
        {
            EntityEntry result = db.Users.Add( user );
            db.SaveChanges();
            return result is not null;
        }
        /// <summary>Remove user from database</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool RemoveUser( AppContext db, User user )
        {
            EntityEntry result = db.Users.Remove( user );
            db.SaveChanges();
            return result is not null;
        }
        /// <summary>Remove user from database by id</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool RemoveUser( AppContext db, int userId )
        {
            User user = new()
            {
                Id = userId
            };
            // changes will be saved below
            return RemoveUser(db, user);
        }
        /// <summary>Update user name by id</summary>
        /// <returns><b>True</b> if removed, otherwise False</returns>
        public static bool ChangeUserName( AppContext db, int userId, string newName )
        {
            int updated = db.Users
                            .Where(u => u.Id == userId)
                            .ExecuteUpdate(c => c.SetProperty(u => u.Name, newName));
            db.SaveChanges();
            return updated > 0;
        }
        ///<summary>Получать булевый флаг о том, есть ли определенная книга на руках у пользователя.</summary>
        public static bool HasBook( AppContext db, User user, int bookId )
        {
            return user.Books.Any(book => book.Id == bookId);
        }
        public static bool HasBook(AppContext db, User user, string bookName)
        {
            return user.Books.Any(book => book.Name.ToUpper() == bookName.ToUpper());
        }
        ///<summary>Получать количество книг на руках у пользователя.</summary>
        public static int BooksCount(AppContext db, User user)
        {
            return user.Books.Count;
        }
    }
}
