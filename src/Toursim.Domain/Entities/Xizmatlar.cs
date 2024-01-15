using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toursim.Domain.Entities
{
    [Table("Xizmatlar", Schema = "dbo")]
    public class Xizmatlar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("nomi")]
        public string nomi { get; set; }
        [Column("narxi")]
        public int narxi { get; set; }
        [Column("rasm")]
        public string rasm { get; set; }
        [Column("boshlanishVaqti")]
        public string boshlanishVaqti { get; set; }
        [Column("tugashVaqti")]
        public string tugashVaqti { get; set; }
        [Column("haqida")]
        public string haqida { get; set; }
        [Column("kun")]
        public string kun {  get; set; }

        [Column("shaharId")]
        public int shaharId { get; set; }
        [ForeignKey("shaharId")]
        public Shahar shahar {  get; set; }

    }
}
