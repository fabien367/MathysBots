namespace Mathys.Api.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Firm")]
    public partial class Firm
    {
        public int ID { get; set; }

        [Required]
        [StringLength(255)]
        public string FirmName { get; set; }

        [Required]
        public string ModelName { get; set; }

        [Required]
        public string TableName { get; set; }

        public bool IsDel { get; set; }

        public DateTime Created { get; set; }

        public DateTime Updated { get; set; }
    }
}
