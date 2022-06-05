namespace ChainOfResponsibilityDP
{
    public class Currency
    {
        private int amount;
        public Currency(int amount)
        {
            this.amount = amount;
        }
        public int GetAmmount()
        {
            return this.amount;
        }
    }
    public interface IHandler
    {
        public IHandler SetNextHandler(IHandler handler);
        public void Handle(Currency currency);
    }
    public abstract class BaseHandler : IHandler
    {
        protected IHandler? handler;
        public IHandler SetNextHandler(IHandler handler)
        {
            this.handler = handler;
            return handler;
        }
        public abstract void Handle(Currency currency);
    }
    public class Check200 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 200)
            {
                int counter = temp / 200;
                System.Console.WriteLine($"{counter} 200-dollar bills\n");
                int rem = temp - 200 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check100 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 100)
            {
                int counter = temp / 100;
                System.Console.WriteLine($"{counter} 100-dollar bills\n");
                int rem = temp - 100 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check50 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 50)
            {
                int counter = temp / 50;
                System.Console.WriteLine($"{counter} 50-dollar bills\n");
                int rem = temp - 50 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check20 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 20)
            {
                int counter = temp / 20;
                System.Console.WriteLine($"{counter} 20-dollar bills\n");
                int rem = temp - 20 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check10 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 10)
            {
                int counter = temp / 10;
                System.Console.WriteLine($"{counter} 10-dollar bills\n");
                int rem = temp - 10 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check5 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 5)
            {
                int counter = temp / 5;
                System.Console.WriteLine($"{counter} 5-dollar bills\n");
                int rem = temp - 5 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class Check1 : BaseHandler
    {
        public override void Handle(Currency currency)
        {
            int temp = currency.GetAmmount();
            if (temp >= 1)
            {
                int counter = temp / 1;
                System.Console.WriteLine($"{counter} 1-dollar bills\n");
                int rem = temp - 1 * counter;
                if (rem != 0)
                {
                    this.handler?.Handle(new Currency(rem));
                }
            }
            else
            {
                this.handler?.Handle(currency);
            }
        }
    }
    public class ATMWithdraw
    {
        private IHandler handler;
        public ATMWithdraw(IHandler handler)
        {
            this.handler = handler;
        }
        public void Withdraw(Currency currency)
        {
            this.handler.Handle(currency);
        }
    }
}