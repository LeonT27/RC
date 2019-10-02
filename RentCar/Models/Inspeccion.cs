namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Inspeccion")]
    public partial class Inspeccion
    {
        public int Id { get; set; }

        public int? IdVehiculo { get; set; }

        public int? IdCliente { get; set; }

        public bool? TieneRalladuras { get; set; }

        public int? CantidadCombustible { get; set; }

        public bool? TieneRespuesta { get; set; }

        public bool? TieneGato { get; set; }

        public bool? TieneRoturasCristal { get; set; }

        public bool? GomaDelanteraR { get; set; }

        public bool? GomaDelanteraL { get; set; }

        public bool? GomaTraseraR { get; set; }

        public bool? GomaTraseraL { get; set; }

        public bool? GomaRespuesta { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Fecha { get; set; }

        public int? EmpleadoInspeccion { get; set; }

        public int? Estado { get; set; }

        public virtual Cliente Cliente { get; set; }

        public virtual Empleado Empleado { get; set; }

        public virtual Vehiculo Vehiculo { get; set; }
    }
}
