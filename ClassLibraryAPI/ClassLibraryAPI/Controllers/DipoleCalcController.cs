using ClassLibraryAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClassLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DipoleCalcController : ControllerBase
    {
        private readonly ICalcModel _calcModel;

        public DipoleCalcController(ICalcModel calcModel)
        {
            _calcModel = calcModel;
        }

        [HttpGet("add/{paramOne}/{paramTwo}")]
        public IActionResult GetAdd(double paramOne, double paramTwo)
        {
            return Ok(_calcModel.Add(paramOne, paramTwo));
        }

        [HttpGet("wavelength/{frequency}")]
        public IActionResult GetWavelength(double frequency)
        {
            return Ok(_calcModel.GetWavelength(frequency));
        }

        [HttpGet("frequency/{waveLength}")]
        public IActionResult GetFrequency(double waveLength)
        {
            return Ok(_calcModel.GetFrequency(waveLength));
        }

        [HttpGet("dipolearm/{waveLength}")]
        public IActionResult GetDipoleArmLength(double waveLength)
        {
            return Ok(_calcModel.GetDipoleArmLength(waveLength));
        }

        [HttpGet("dipole/{waveLength}")]
        public IActionResult GetDipoleLength(double waveLength)
        {
            return Ok(_calcModel.GetDipoleFullLength(waveLength));
        }

        [HttpGet("adjustmentfactor/{waveLength}/{diameterOfConductor}")]
        public IActionResult GetAdjustmentFactor(double waveLength, double diameterOfConductor)
        {
            return Ok(_calcModel.GetAdjustmentFactor(waveLength, diameterOfConductor));
        }

        [HttpGet("adjusteddiapole/{adjustmentFactor}/{frequency}")]
        public IActionResult GetAdjustedDipoleLength(double adjustmentFactor, double frequency)
        {
            return Ok(_calcModel.GetAdjustedDipoleFullLength(adjustmentFactor, frequency));
        }
    }
}
