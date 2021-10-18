using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public abstract class TeamMember
    {

        private MessageHub messageHub;

        public TeamMember(string name)
        {
            this.name = name;
        }

        public readonly string name;

        internal void InitializeMessageHub(MessageHub hub)
        {
            this.messageHub = hub;
        }

        public void Send(string message)
        {
            this.messageHub.Send(this.name, message);
        }

        public virtual void Recieve(string from, string message)
        {
            Console.WriteLine($"From {from} : '{message}");
        }

    }
}
