namespace ObserverDP
{
    public interface IObserver
    {
        public void Follow(ISubject subject);
        public void Unfollow(ISubject subject);
        public void GetNotified(string name, string status);
        public string GetName();
    }
    public interface ISubject
    {
        public void UpdateStatus(string status);
        public List<IObserver> GetList();
    }
    public class Subject : ISubject
    {
        private List<IObserver> followerList;
        private string name;
        private string? status;
        public Subject(string name)
        {
            this.name = name;
            this.followerList = new List<IObserver>();
        }
        public string GetName()
        {
            return this.name;
        }
        public List<IObserver> GetList()
        {
            return this.followerList;
        }
        public void UpdateStatus(string status)
        {
            this.status = status;
            foreach(var follower in followerList)
            {
                follower.GetNotified(this.name, status);
            }
        }
    }
    public class Observer : IObserver
    {
        private List<ISubject> followingList;
        private string name;
        public Observer(string name)
        {
            this.name = name;
            this.followingList = new List<ISubject>();
        }
        public void Follow(ISubject subject)
        {
            this.followingList.Add(subject);
            subject.GetList().Add(this);
        }
        public void Unfollow(ISubject subject)
        {
            this.followingList.Remove(subject);
            subject.GetList().Remove(this);
        }
        public void GetNotified(string name, string status)
        {
            System.Console.WriteLine($"------ {this.name}'s board ------------");
            System.Console.WriteLine($"{name} updated its own story");
            System.Console.WriteLine($"--> {status}");
        }
        public string GetName()
        {
            return this.name;
        }
        public List<ISubject> GetList()
        {
            return this.followingList;
        }
    }
    public class TwitterProfile
    {
        private string name;
        private ISubject subject;
        private IObserver observer;
        public TwitterProfile(string name)
        {
            this.name = name;
            this.subject = new Subject(name);
            this.observer = new Observer(name);
        }
        public string GetName()
        {
            return this.name;
        }
        public void Follow(TwitterProfile twitterProfile)
        {
            this.observer.Follow(twitterProfile.subject);
        }
        public void Unfollow(TwitterProfile twitterProfile)
        {
            this.observer.Unfollow(twitterProfile.subject);
        }
        public void UpdateStatus(string status)
        {
            this.subject.UpdateStatus(status);
        }
    }
}