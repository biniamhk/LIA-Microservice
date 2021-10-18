using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingsService.Services;
using SettingsService.Models;

namespace SettingsService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SettingsController : ControllerBase
    {

        private readonly SettingsServices _settingsService;

        public SettingsController(SettingsServices settingsServices)
        {
            _settingsService = settingsServices;
        }


        [HttpGet]
        public ActionResult<List<SettingsModel>> Get() =>
            _settingsService.Get();


        [HttpGet("{userId}")]
        public ActionResult<SettingsModel> GetByUserId(string userId)
        {
            var settings = _settingsService.GetbyUserID(userId);

            if (settings == null)
            {
                //return NotFound();
                // Ful kodning User registreringen borde skicka en post via rabbit o skapas den vägen

                settings = new SettingsModel();
                settings.UserId = userId;
                _settingsService.Create(settings);
                return settings;

            }
            return settings;
        }


        [HttpPut("{userId}")]
        public IActionResult UpdateByUserId(string userId, SettingsModel settingIn)
        {
            var settings = _settingsService.GetbyUserID(userId);

            if (settings == null)
            {
                return NotFound();
            }

            settingIn.Id = settings.Id;
            settingIn.UserId = settings.UserId;


            _settingsService.Update(settings.Id, settingIn);

            return NoContent();
        }


        [HttpGet("Restore/{userId}")]
        public ActionResult<SettingsModel>RestoreDefaultSettings(string userId)
        {
            var settings = _settingsService.GetbyUserID(userId);
            if (settings == null)
            {
                return NotFound();
            }

            _settingsService.Remove(settings.Id);

            settings = new SettingsModel();
            settings.UserId = userId;
            _settingsService.Create(settings);

            return settings;


        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var settings = _settingsService.Get(id);

            if (settings == null)
            {
                return NotFound();
            }

            _settingsService.Remove(settings.Id);

            return NoContent();
        }

    }
}
