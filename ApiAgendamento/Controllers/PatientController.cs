using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiAgendamento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ILogger<PatientController> _logger;
        private readonly IPatientRepository _iPatientRepository;

        public PatientController(ILogger<PatientController> logger, IPatientRepository IPatientRepository)
        {
            _logger = logger;
            _iPatientRepository = IPatientRepository;
        }

        [HttpPost("SavePatient")]
        public bool SavePatient([Body] Patient patient)
        {
            var resultPatient = _iPatientRepository.InsertPatient(patient);
            return resultPatient;
        }

        [HttpGet("GetPatient")]
        public Patient GetPatient([Body] Patient paciente)
        {
            var result = _iPatientRepository.GetPatientByCpf(paciente.Cpf);
            return result;
        }

        [HttpPut("UpdatePatient")]
        public bool UpdatePatient([Body] Patient paciente)
        {
            var result = _iPatientRepository.UpatePatient(paciente);
            return result;
        }
    }
}
