using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toursim.Domain.Entities
{
    [Table("Fikr",Schema ="dbo")]
    public class Fikr
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("foydalanuvchiFikr")]
        public string foydalanuvchiFikr { get; set; }
        [Column("foydalanuvchiId")]
        public int foydalanunchiId { get; set; }
        //[ForeignKey("foydalanuvchiId")]
        //public Foydalanuvchi Foydalanuvchi {  get; set; }
    }
}
