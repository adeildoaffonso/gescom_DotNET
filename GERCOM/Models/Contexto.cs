using GESCOM.Models.entidade;
using GESCOM.Models.mapeamento;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace GESCOM.Models
{
    public class Contexto : DbContext
    {
        public Contexto() : base("name=DC_GERCOM") {   }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("DBO".ToUpper());
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.Add(new PessoaMap());
        }
    }
}