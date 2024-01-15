using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toursim.Domain.Entities
{
    [Table("FoydalanuvchiVaShahar",Schema ="dbo")]
    public class FoydalanuvchiVaShahar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("shaharId")]
        public int shaharId {  get; set; }
        [ForeignKey("shaharId")]
        public Shahar shahar { get; set; }
        [Column("foydalanuvchiId")]
        public int foydalanuvchiId { get; set; }
        [ForeignKey("foydalanuvchiId")]
        public Foydalanuvchi foydalanuvchi { get; set; }

    }
}
