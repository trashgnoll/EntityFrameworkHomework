using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkHomework.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<Book> Books{ get; set; } = new List<Book>();
        public User()
        {
            Name = string.Empty;
            Email = string.Empty;
            Role = string.Empty;
        }
    }
}
