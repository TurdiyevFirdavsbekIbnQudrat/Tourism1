using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toursim.Domain.Entities
{
    [Table("Shahar",Schema ="dbo")]
    public class Shahar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("nomi")]
        public string nomi {  get; set; }
        [Column("rasm")]
        public string rasm { get; set; }
        public ICollection<Xizmatlar> xizmatlar { get; set;}
        public ICollection<FoydalanuvchiVaShahar> foydalanuvchiVaShaharlar { get; set;}

    }
}
