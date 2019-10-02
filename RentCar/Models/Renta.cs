namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Renta")]
    public partial class Renta
    {
        [Key]
        [StringLength(250)]
        public string NoRenta { get; set; }

        public int? IdEmpleado { get; set; }

        public int? IdVehiculo { get; set; }

        public int? IdCliente { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaRenta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaDevolucion { get; set; }

        [Column(TypeName = "money")]
        public decimal? MontoDia { get; set; }

        public int? CantidadDias { get; set; }

        public string Comentario { get; set; }

        public bool? Estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
