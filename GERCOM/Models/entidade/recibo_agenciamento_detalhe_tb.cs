using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public class recibo_agenciamento_detalhe_tb : IDisposable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recibo_agenciamento_detalhe_tb()
        {
        }

        [Key]
        public int recibo_agenciamento_detalhe_id { get; set; }

        public int recibo_comissao_id { get; set; }

        public int agenciador_id { get; set; }

        public DateTime data_pagamento { get; set; }

        public decimal valor_pagamento { get; set; }

        public decimal percentual_comissao { get; set; }

        public int status_pagamento { get; set; }

        public virtual agenciador_tb agenciador_tb { get; set; }

        public void Dispose() { }
    }
}