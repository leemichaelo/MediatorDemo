using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediatorDemo.ChatApp
{
    public class TeamChatroom : Chatroom
    {
        private List<TeamMember> members = new List<TeamMember>();

        public override void Register(TeamMember member)
        {
            member.SetChatroom(this);
            members.Add(member);
        }

        public override void Send(string from, string message)
        {
            members.ForEach(m => m.Receive(from, message));
        }

        public void RegisterMembers(params TeamMember[] teamMembers)
        {
            foreach(var member in teamMembers)
            {
                Register(member);
            }
        }

        public override void SendTo<T>(string from, string message)
        {
            members.OfType<T>().ToList().ForEach(m => m.Receive(from, message));
        }
    }
}
