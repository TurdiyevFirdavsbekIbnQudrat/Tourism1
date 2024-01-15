using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toursim.Domain.Entities
{
    [Table("Tolov", Schema = "dbo")]
    public class Tolov
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("tolovQiymati")]
        public double tolovQiymati { get; set; }
        [Column("foydalanuvchiId")]
        public int foydalanuvchiId { get; set; }
        //[ForeignKey("foydalanuvchiId")]
        //public Foydalanuvchi foydalanuvchi { get; set; }
    }
}
