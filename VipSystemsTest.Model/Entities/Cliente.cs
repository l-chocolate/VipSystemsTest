using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VipSystemsTest.Model.Entities
{
    [Table("vip_clientes")]
    public class Cliente
    {
        [Column("Id_cliente")]
        public int Id { get; set; }
        public required string Nome { get; set; }
        [Column("Dtnasc")]
        public DateTime DataDeNascimento { get; set; }
        public required string Senha { get; set; }
        [Column("Mae")]
        public required string NomeDaMae { get; set; }
        public byte[]? Foto { get; set; }
        [Column("DiasAcesso")]
        public required string DiasDeAcesso { get; set; }
        public required string CPF { get; set; }
        [Column("HrIniAcesso")]
        public required string HoraInicialDePermissaoDeAcesso { get; set; }
        [Column("HrFimAcesso")]
        public required string HoraFinalDePermissaoDeAcesso { get; set; }
        [Column("Livre_int")]
        public int? NumeroLivre { get; set; }
        [Column("Livre_text")]
        public string? TextoLivre { get; set; }
    }
}
