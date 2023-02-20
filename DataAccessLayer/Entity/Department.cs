using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entity
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        public string name { get; set; }
        [StringLength(30)]
        public string code { get; set; }
    }
}
