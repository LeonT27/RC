namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vehiculo")]
    public partial class Vehiculo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehiculo()
        {
            Inspeccion = new HashSet<Inspeccion>();
            Renta = new HashSet<Renta>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Descripcion { get; set; }

        [StringLength(250)]
        public string NoChasis { get; set; }

        [StringLength(250)]
        public string NoMotor { get; set; }

        [StringLength(50)]
        public string NoPlaca { get; set; }

        public int? IdTipoVehiculo { get; set; }

        public int? IdMarca { get; set; }

        public int? IdModelo { get; set; }

        public int? IdTipoCombustible { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspeccion> Inspeccion { get; set; }

        public virtual Marca Marca { get; set; }

        public virtual Modelo Modelo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta> Renta { get; set; }

        public virtual TipoCombustible TipoCombustible { get; set; }

        public virtual TipoVehiculo TipoVehiculo { get; set; }
    }
}
