using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESCOM.Models.entidade
{
    public class recibo_comissao_detalhe_tb : IDisposable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public recibo_comissao_detalhe_tb()
        {
        }

        [Key]
        public int recibo_comissao_detalhe_id { get; set; }

        public int recibo_comissao_id { get; set; }

        public int corretor_id { get; set; }

        public DateTime data_pagamento { get; set; }

        public decimal valor_pagamento { get; set; }

        public decimal percentual_comissao { get; set; }

        public int status_pagamento { get; set; }

        public virtual recibo_comissao_tb recibo_comissao_tb { get; set; }

        public void Dispose() { }
    }
}