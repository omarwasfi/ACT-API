using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class HRMS_Column_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string ColumnName { get; set; }

        [Required]
        public string Type { get; set; }

        public HRMS_Configuration_Model HRMS_Configuration { get; set; }
    }
}
