﻿using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GESCOM
{
    public partial class seguradora_tb
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public seguradora_tb()
        {
            cotacao_tb = new HashSet<cotacao_tb>();
        }
        [Key]
        public int seguradora_id { get; set; }

        public int pessoa_id { get; set; }

        public virtual pessoa_tb pessoa_tb { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cotacao_tb> cotacao_tb { get; set; }

        
    }
}