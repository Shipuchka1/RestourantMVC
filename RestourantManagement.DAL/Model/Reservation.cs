namespace RestourantManagement.DAL.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reservation")]
    public partial class Reservation
    {
        public int ReservationId { get; set; }

        [StringLength(250)]
        public string FullName { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeOfReservation { get; set; }

        public string Email { get; set; }

        public bool Status { get; set; }
    }
}
