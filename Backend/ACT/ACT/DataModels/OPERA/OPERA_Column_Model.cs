using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class OPERA_Column_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public string ColumnName { get; set; }

        [Required]
        public string Type { get; set; }
        
        [Required]
        public int StartPOS { get; set; }
        
        [Required]
        public int EndPOS { get; set; }

        public virtual OPERA_Configuration_Model OPERA_Configuration { get; set; }
    }
}
