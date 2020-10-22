using System;

namespace MediatorDemo.ChatApp
{
    public abstract class TeamMember
    {
        private Chatroom chatroom;

        public string Name { get; }

        public TeamMember(string name)
        {
            Name = name;
        }

        internal void SetChatroom(Chatroom chatroom)
        {
            this.chatroom = chatroom;
        }

        public void Send(string message)
        {
            this.chatroom.Send(Name, message);
        }

        public virtual void Receive(string from, string message)
        {
            Console.WriteLine($"from {from}: '{message}'");
        }

        public void SendTo<T>(string message) where T : TeamMember
        {
            chatroom.SendTo<T>(Name, message);
        }
    }
}