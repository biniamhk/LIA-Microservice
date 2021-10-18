using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class TeamMessageHub : MessageHub
    {
        private List<TeamMember> members = new List<TeamMember>();
        public override void RegisterSingle(TeamMember member)
        {
            member.InitializeMessageHub(this);
            this.members.Add(member);
        }

        public override void Send(string from, string message)
        {
            this.members.ForEach(m => m.Recieve(from, message));
        }

        public void RegisterMultiple(params TeamMember[] teamMembers)
        {
            foreach (var member in teamMembers)
            {
                this.RegisterSingle(member);
            }
        }

    }
}
