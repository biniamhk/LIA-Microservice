using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Administrator:TeamMember
    {
        public Administrator(string name) : base(name)
        {

        }

        public override void Recieve(string from, string message)
        {
            
            Console.Write($"{this.name} ({nameof(Administrator)}) has recieved ");
            base.Recieve(from, message);
        }
    }
}
