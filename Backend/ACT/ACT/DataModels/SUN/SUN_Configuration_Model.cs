using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class SUN_Configuration_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string ConnectionsString { get; set; }

        [Required]
        public List<SUN_Column_Model> Columns { get; set; }




    }
}
