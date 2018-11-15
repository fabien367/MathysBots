namespace Mathys.Api.DB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TemplateTable")]
    public partial class TemplateTable
    {
        public int ID { get; set; }

        [Required]
        public string Classification { get; set; }

        public int OrderSolution { get; set; }

        [Required]
        public string Problem { get; set; }

        [Required]
        public string Solution { get; set; }
    }
}
