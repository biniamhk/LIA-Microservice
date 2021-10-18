using MementoService.DTOs;
using MementoService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.Services
{
    public class Originator
    {
        private readonly Memento _memento;

        public Originator(Memento memento)
        {
            _memento = memento;
        }

        public void CreateMemento(MementoModel memento) => 
            _memento.Create(memento);

        public MementoModel RestoreMemento(string userID, int index) => 
            _memento.Get(userID, index);

        public void PruneMementos(string userID, int index) => 
            _memento.RemoveThisAndAfter(userID, index);
    }
}
