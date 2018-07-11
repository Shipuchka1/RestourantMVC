namespace RestourantManagement.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Menu")]
    public partial class Menu
    {
        [Key]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int? ItemEatTypeId { get; set; }

        public string ItemDesc { get; set; }

        [Column(TypeName = "money")]
        public decimal? Cost { get; set; }

        public virtual EatType eatType { get; set; }
    }
}
