using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class OPERA_Configuration_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string  FilePath { get; set; }

        [Required]
        public int NumberOfLinesToBeIgnoredAtTheBeginning { get; set; } = 1 ;

        [Required]
        public int NumberOfLinesToBeIgnoredAtTheEnd { get; set; } = 1;
        /// <summary>
        /// Daily Based
        /// We care about Hour and Min
        /// </summary>
        [Required]
        public DateTime CycleTime { get; set; }

        [Required]
        public virtual List<OPERA_REPORT_Column_Model> Columns { get; set; }
    }
}
