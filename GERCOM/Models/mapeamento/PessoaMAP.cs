using GESCOM.Models.entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GESCOM.Models.mapeamento
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            ToTable("pessoa_tb", "dbo");
            HasKey(c => c.PessoaID);
            Property(p => p.PessoaID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnName("pessoa_id")
                .IsRequired();

            Property(p => p.cpf_cnpj)
                .HasColumnName("cpf_cnpj")
                .IsRequired();

            Property(p => p.Nome)
                .HasColumnName("nome")
                .IsRequired();

            Property(p => p.Tipo_Pessoa)
                .HasColumnName("tipo_pessoa");
        }
    }
}