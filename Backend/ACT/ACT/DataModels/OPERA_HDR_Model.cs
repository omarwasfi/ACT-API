﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ACT.DataModels
{
    public class OPERA_HDR_Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string SunAttribute { get; set; }

        [Required]
        public bool IsConst { get; set; }

        public string ValueType { get; set; }

        public int? IntValue { get; set; }

        public short? ShortValue { get; set; }

        public DateTime? DateTimeValue { get; set; }

        public string StringValue { get; set; }

        public decimal? DecimalValue { get; set; }

        public string MapWithHRMS { get; set; }
    }
}
