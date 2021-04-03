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
        public virtual List<SUN_HDR_Column_Model> HDR_Columns { get; set; }

        [Required]
        public virtual List<SUN_DETAIL_Column_Model> DETAIL_Columns { get; set; }



    }
}
