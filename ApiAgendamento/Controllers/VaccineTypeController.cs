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
    public class VaccineTypeController : ControllerBase
    {
        private readonly ILogger<VaccineTypeController> _logger;
        private readonly IVaccineTypeRepository _iVaccineTypeRepository;


        public VaccineTypeController(ILogger<VaccineTypeController> logger, IVaccineTypeRepository IVaccineTypeRepository)
        {
            _logger = logger;
            _iVaccineTypeRepository = IVaccineTypeRepository;
        }

        [HttpPost("SaveVaccineType")]
        public VaccineType SaveVaccineType([Body] VaccineType vaccineType)
        {
            var resultVaccineType = _iVaccineTypeRepository.InsertVaccineType(vaccineType);
            return resultVaccineType;
        }

        [HttpGet("GetAllVaccineType")]
        public IEnumerable<VaccineType> GetAllVaccineType()
        {
            return _iVaccineTypeRepository.SelectAllVaccineType();
        }
    }
}