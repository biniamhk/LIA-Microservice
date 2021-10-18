using AutoMapper;
using MementoService.DTOs;
using MementoService.Models;
using MementoService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.Controllers
{
    [ApiController]
    public class MementoController : ControllerBase
    {
        private readonly Originator _originator;
        private readonly IMapper _mapper;

        public MementoController(Originator originator, IMapper mapper)
        {
            _originator = originator;
            _mapper = mapper;
        }

        [HttpPost("save")]
        public ActionResult PostMemento(MementoCreateDTO memento)
        {
            var _memento = _mapper.Map<MementoModel>(memento);
            _originator.PruneMementos(_memento.UserID, _memento.Index);
            _originator.CreateMemento(_memento);
            return Ok();
        }


        [HttpGet("undo/{userID}/{index}")]
        public ActionResult<MementoReadDTO> Undo(string userID, int index)
        {
            var _memento = _originator.RestoreMemento(userID, index -= 1);
            if (_memento != null)
                return Ok(_mapper.Map<MementoReadDTO>(_memento));

            return NotFound();
        }

        [HttpGet("redo/{userID}/{index}")]
        public ActionResult<MementoReadDTO> Redo(string userID, int index)
        {
            var _memento = _originator.RestoreMemento(userID, index += 1);
            if (_memento != null)
                return Ok(_mapper.Map<MementoReadDTO>(_memento));

            return NotFound();
        }
    }
}

