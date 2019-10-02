namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Empleado")]
    public partial class Empleado
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Empleado()
        {
            Inspeccion = new HashSet<Inspeccion>();
            Renta = new HashSet<Renta>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(13)]
        public string Cedula { get; set; }

        [StringLength(250)]
        public string TandaLabor { get; set; }

        public int? PorcientoComision { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaIngreso { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspeccion> Inspeccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta> Renta { get; set; }
    }
}
