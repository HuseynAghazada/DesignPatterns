namespace ProxyDP
{
    public interface IData
    {
        public string GetData();
    }
    public class UltraSecretData : IData
    {
        public string GetData()
        {
            return "Hehe, You Found Me";
        }
    }
    public class ProxyData : IData
    {
        private IData data;
        private string username;
        private string password;
        public ProxyData(IData data, string username, string password)
        {
            this.data = data;
            this.username = username;
            this.password = password;
        }
        public string GetData()
        {
            if (this.HaveAccess())
            {
                return this.data.GetData();
            }
            else
            {
                throw new NotImplementedException("Access is Denied!!!");
            }
        }
        public bool HaveAccess()
        {
            if (username.Equals("admin") && password.Equals("admin"))
            {
                return true;
            }
            return false;
        }
    }
    public class UserLogin
    {
        private string username;
        private string password;
        public UserLogin(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public string GetSuperSecretData(IData data)
        {
            return data.GetData();
        }
    }
}