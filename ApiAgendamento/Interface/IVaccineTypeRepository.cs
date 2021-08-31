using ApiAgendamento.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Interface
{
   public interface IVaccineTypeRepository
    {
        VaccineType InsertVaccineType(VaccineType vaccineType);
        IEnumerable<VaccineType> SelectAllVaccineType();
    }
}
