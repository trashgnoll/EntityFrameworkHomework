using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkHomework.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author()
        {
            Name = string.Empty;
        }
    }
}
