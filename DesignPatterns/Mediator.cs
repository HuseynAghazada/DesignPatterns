namespace MediatorDP
{
    public interface IChatroom
    {
        public void Register(IUser user);
        public void SendMessage(IUser from, IUser to, string message);
        public void Broadcast(IUser from, string message);
        public void Multicast(IUser from, List<IUser> list, string message)
        {
            
        }
    }
    public class Chatroom : IChatroom
    {
        public Chatroom()
        {
            this.userList = new List<IUser>();
        }
        private List<IUser> userList;
        public void Register(IUser user)
        {
            this.userList.Add(user);
        }
        public void SendMessage(IUser from, IUser to, string message)
        {
            if (userList.Contains(to))
            {
                to.ReceiveMessage(from, message);
            }
        }
        public void Broadcast(IUser from, string message)
        {
            foreach(var user in userList)
            {
                if (user != from)
                {
                    user.ReceiveMessage(from, message);
                }
            }
        }
        public void Multicast(IUser from, List<IUser> list, string message)
        {
            foreach(var user in list)
            {
                user.ReceiveMessage(from, message);
            }
        }
    }
    public interface IUser
    {
        public void RegisterToChatroom(IChatroom chatroom);
        public void SendMessage(IUser to, string message);
        public void Broadcast(string message);
        public void ReceiveMessage(IUser from, string message);
        public void Multicast(List<IUser> list, string message);
        public string GetName();
    }
    public class User : IUser
    {
        public User(string name)
        {
            this.name = name;
        }
        private string name;
        public string GetName()
        {
            return this.name;
        }
        public IChatroom? chatroom;
        public void RegisterToChatroom(IChatroom chatroom)
        {
            this.chatroom = chatroom;
            this.chatroom.Register(this);
        }
        public void SendMessage(IUser to, string message)
        {
            if (this.chatroom != null)
            {
                this.chatroom.SendMessage(this, to, message);
            }
            else
            {
                System.Console.WriteLine("The chatroom is null!!!");
            }
        }
        public void Broadcast(string message)
        {
            if (this.chatroom != null)
            {
                this.chatroom.Broadcast(this, message);
            }
            else
            {
                System.Console.WriteLine("The chatroom is null!!!");
            }
        }
        public void ReceiveMessage(IUser user, string message)
        {
            System.Console.WriteLine();
            System.Console.WriteLine($"{this.GetName()}'s board-----------");
            System.Console.WriteLine($"you received a message from {user.GetName()}:");
            System.Console.WriteLine($"---> {message}");
        }
        public void Multicast(List<IUser> list, string message)
        {
            if (this.chatroom != null)
            {
                this.chatroom.Multicast(this, list, message);
            }
            else
            {
                System.Console.WriteLine("The chatroom is null!!!");
            }
        }
    }
}