using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toursim.Domain.Enums;

namespace Toursim.Domain.Entities
{
    [Table("Foydalanuvchi",Schema ="dbo")]
    public class Foydalanuvchi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id {  get; set; }
        [Column("ism")]
        public string ism { get; set; }
        [Column("familiya")]
        public string familiya { get; set; }
        [Column("email")]
        public string email { get; set; }
        [Column("parol")]
        public string parol {  get; set; }
        [Column("role")]
        public Role role { get; set; }
        [Column("telNomer")]
        public string telNomer {  get; set; }
        [Column("condition")]
        public Condition condition { get; set; }

     //   public ICollection<Fikr> fikrlar { get; set; }
    //    public ICollection<Tolov> tolovlar { get; set; }
        public ICollection<FoydalanuvchiVaShahar> foydalanuvchiVaShaharlar { get; set; }
    }
}
