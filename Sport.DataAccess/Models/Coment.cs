using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNewsBackend.Sport.DataAccess.Models
{
    public class Coment
    {
        [Key]
        public Guid Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string? Tag { get; set; }
        public Article Article { get; set; } = null!;
    }
}
