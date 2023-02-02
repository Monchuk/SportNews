using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportNewsBackend.Sport.DataAccess.Models
{
    public class Article
    {
        [Key]
        public Guid Id { get; set; }
        public int Order { get; set; }// test from migration 
        public int Number { get; set; }// test from migration
        public string Name { get; set; } = string.Empty;

        public ICollection<Coment> Coments { get; set; } = null!;
    }
}
