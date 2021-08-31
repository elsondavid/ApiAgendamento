using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SchedulingController : ControllerBase
    {
        private readonly ILogger<SchedulingController> _logger;
        private readonly ISchedulingRepository _iSchedulingRepository;
        public SchedulingController(ILogger<SchedulingController> logger, ISchedulingRepository iSchedulingRepository)
        {
            _logger = logger;
            _iSchedulingRepository = iSchedulingRepository;
        }

        [HttpPost("SaveScheduling")]
        public Scheduling SaveScheduling(Scheduling scheduling)
        {
            var resultScheduling = new Scheduling();
            resultScheduling = _iSchedulingRepository.InsertScheduling(scheduling);
            return resultScheduling;
        }
    }
}
