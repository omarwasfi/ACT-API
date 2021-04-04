using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class HRMS_Configuration_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        /// <summary>
        /// The Connections string of the HRMS Database
        /// </summary>
        [Required]
        public string ConnectionsString { get; set; }
        
        /// <summary>
        /// Monthly based
        /// We care about day , Hour and Min
        /// </summary>
        [Required]
        public DateTime CycleTime { get; set; }

        [Required]
        public virtual List<HRMS_REPORT_Column_Model> Columns { get; set; }


    }
}
