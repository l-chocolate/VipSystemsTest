using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VipSystemsTest.Model.Entities
{
    [Table("vip_movcli")]
    internal class Movimento
    {
        [Column("Idmov")]
        public int Id { get; set; }
        [Column("Id_cliente")]
        public int IdDoCliente { get; set; }
        [ForeignKey("Id_cliente")]
        public virtual required Cliente Cliente { get; set; }
        public string? Local { get; set; }
        [Column("Dthrent")]
        public DateTime DataEHoraDeEntrada { get; set; }
        [Column("Dthrsai")]
        public DateTime DataEHoraDeSaida { get; set; }
        [Column("Idstatus")]
        public double IdDeStatus { get; set; }
        [Column("Motbloqueio")]
        public double MotivoDoBloqueio { get; set; }
        [Column("Obsacesso")]
        public string? ObservacaoDeAcesso { get; set; }
    }
}
