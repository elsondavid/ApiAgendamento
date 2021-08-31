using ApiAgendamento.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Interface
{
    public interface ISchedulingRepository
    {
        Scheduling InsertScheduling(Scheduling scheduling);
        Scheduling UpateScheduling(Scheduling scheduling);
    }
}
