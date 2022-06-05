namespace AdapterDP
{
    public interface IHomeAppliances
    {
        public int Charge();
    }

    public class Fridge : IHomeAppliances
    {
        private int volt;
        public Fridge()
        {
            this.volt = 250;
        }
        public int Charge()
        {
            System.Console.WriteLine("The fridge is charging!!!");
            return this.volt;
        }
    }

    public class Television : IHomeAppliances
    {
        private int volt;
        public Television()
        {
            this.volt = 350;
        }
        public int Charge()
        {
            System.Console.WriteLine("The television is charging!!!");
            return this.volt;
        }
    }

    public class Outlet
    {
        public void GiveElectric(IHomeAppliances homeAppliances)
        {
            int volt = homeAppliances.Charge();
            System.Console.WriteLine($"The outlet gives {volt} volt!!!");
            System.Console.WriteLine();
            System.Console.WriteLine();
        }
    }

    public class PhoneAdapter : IHomeAppliances
    {
        private Phone phone;
        public PhoneAdapter(Phone phone)
        {
            this.phone = phone;
        }
        public int Charge()
        {
            return this.phone.GetVolt();
        }
    }
    public interface Phone
    {
        public int GetVolt();
    }

    public class Samsung : Phone
    {
        private int volt;
        public Samsung()
        {
            this.volt = 5;
        }
        public int GetVolt()
        {
            System.Console.WriteLine("The samsung is charging!!!");
            return this.volt;
        }
    }
}