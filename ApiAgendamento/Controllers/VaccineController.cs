using ApiAgendamento.Entity;
using ApiAgendamento.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace ApiAgendamento.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VaccineController : ControllerBase
    {
        private readonly ILogger<VaccineController> _logger;
        private readonly IVaccineRepository _iVaccineRepository;

        public VaccineController(ILogger<VaccineController> logger, IVaccineRepository IVaccineRepository)
        {
            _logger = logger;
            _iVaccineRepository = IVaccineRepository;
        }

        [HttpPost("SaveVaccine")]
        public Vaccine SaveVaccine(Vaccine vaccine)

        {
            var resultVaccine = _iVaccineRepository.InsertVaccine(vaccine);
            return resultVaccine;
        }

        [HttpGet("GetAllVaccine")]
        public IEnumerable<Vaccine> GetAllVaccine()
        { 
            var resultAllVaccine = (List<Vaccine>)_iVaccineRepository.SelectAllVaccine();
            return resultAllVaccine;
        }
    }
}
