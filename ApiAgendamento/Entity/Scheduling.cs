using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Entity
{
    public class Scheduling
    {
        public int IdPaciente { get; set; }
        public int IdVacina { get; set; }
        public DateTime Data { get; set; }
    }
}
