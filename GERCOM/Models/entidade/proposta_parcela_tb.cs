namespace GESCOM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class proposta_parcela_tb : IDisposable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public proposta_parcela_tb()
        {
            //recibo_comissao_tb = new HashSet<recibo_comissao_tb>();
        }

        [Key]
        public int proposta_parcela_id { get; set; }

        public int proposta_id { get; set; }

        public int numero_parcela { get; set; }

        public DateTime data_vencimento { get; set; }

        public decimal premio_liquido { get; set; }

        public virtual proposta_tb proposta_tb { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<recibo_comissao_tb> recibo_comissao_tb { get; set; }

        public void Dispose() { }
    }
}
