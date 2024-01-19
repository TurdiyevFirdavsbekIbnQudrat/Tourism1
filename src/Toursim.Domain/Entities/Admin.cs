using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Toursim.Domain.Entities
{
    [Table("Admin",Schema ="dbo")]
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }
        [Column("ism")]
        public string ism { get; set; }
        [Column("familiya")]
        public string familiya { get; set; }
        [Column("parol")]
        public string parol { get; set; }
        [Column("email")]
        public string email { get; set; }
    }
}
