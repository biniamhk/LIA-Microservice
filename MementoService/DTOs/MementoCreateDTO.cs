using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MementoService.DTOs
{
    public class MementoCreateDTO
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        public int Index { get; set; }

        [Required]
        public string State { get; set; }

        public MementoCreateDTO(string userID, int index, string state)
        {
            UserID = userID;
            Index = index;
            State = state;
        }
    }
}
