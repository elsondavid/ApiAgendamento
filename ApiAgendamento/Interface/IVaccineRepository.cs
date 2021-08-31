using ApiAgendamento.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Interface
{
    public interface IVaccineRepository
    {
        Vaccine InsertVaccine(Vaccine vaccine);
        IEnumerable<Vaccine> SelectAllVaccine();
    }
}
