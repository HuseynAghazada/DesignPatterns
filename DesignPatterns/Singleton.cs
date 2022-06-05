namespace SingletonDP
{
    public class Singleton
    {
        private static Singleton? instance;
        private static readonly object _lock = new object();
        private Singleton()
        {}
        public static Singleton GetInstance()
        {
            if (instance == null)
            {
                lock(_lock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
        public string? Value { get; set; }
    }
}