namespace RentCar.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Cliente")]
    public partial class Cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cliente()
        {
            Inspeccion = new HashSet<Inspeccion>();
            Renta = new HashSet<Renta>();
        }

        public int Id { get; set; }

        [StringLength(250)]
        public string Nombre { get; set; }

        [StringLength(13)]
        public string Cedula { get; set; }

        [MaxLength(20)]
        public byte[] NoTarjeta { get; set; }

        [Column(TypeName = "money")]
        public decimal? LimiteCredito { get; set; }

        public bool? TipoPersona { get; set; }

        public bool? Estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Inspeccion> Inspeccion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Renta> Renta { get; set; }
    }
}
