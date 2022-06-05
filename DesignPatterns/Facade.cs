namespace FacadeDP
{
    public class BankAccountFacade
    {
        private Card card;
        private FundsCheck fundsCheck;
        private ActivationCheck activationCheck;
        public BankAccountFacade(string owner, long cardNumber, int cvv)
        {
            this.card = new Card(owner, cardNumber, cvv);
            this.fundsCheck = new FundsCheck(card);
            this.activationCheck = new ActivationCheck();
        }
        public void Withdraw(double money)
        {
            System.Console.WriteLine($"---- {this.GetOwner()}'s board ------------");
            System.Console.WriteLine("Trying To Withdraw...");
            if (activationCheck.IsActivated(this.card))
            {
                this.fundsCheck.DecreaseMoney(money);
            }
            else
            {
                System.Console.WriteLine("The Card is Deactivated!!!");
            }
        }
        public void IncreaseBalance(double money)
        {
            System.Console.WriteLine($"---- {this.GetOwner()}'s board ------------");
            System.Console.WriteLine("Trying To Withdraw...");
            if (activationCheck.IsActivated(this.card))
            {
                this.fundsCheck.IncreaseMoney(money);
            }
            else
            {
                System.Console.WriteLine("The Card is Deactivated!!!");
            }
        }
        public string GetOwner()
        {
            return this.card.GetOwner();
        }
        public void RequestToActivateCard()
        {
            ActivatedCards.GetActivatedCards().Add(this.card);
        }
    }
    public class Card
    {
        private string owner;
        private double currentCash = 0;
        private long cardNumber;
        private int cvv;
        public Card(string owner, long cardNumber, int cvv)
        {
            this.owner = owner;
            this.cardNumber = cardNumber;
            this.cvv = cvv;
        }
        public long GetCardNumber()
        {
            return this.cardNumber;
        }
        public double GetCurrentCash()
        {
            return this.currentCash;
        }
        public int GetCVV()
        {
            return this.cvv;
        }
        public void SetCurrentCash(double money)
        {
            this.currentCash = money;
        }
        public string GetOwner()
        {
            return this.owner;
        }
    }
    public class FundsCheck
    {
        private Card card;
        public FundsCheck(Card card)
        {
            this.card = card;
        }
        public bool HaveEnoughMoney(double money)
        {
            if (this.card.GetCurrentCash() >= money)
            {
                return true;
            }
            System.Console.WriteLine("You Don't Have Enough Money!!!");
            return false;
        }
        public void DecreaseMoney(double money)
        {
            if (this.HaveEnoughMoney(money))
            {
                System.Console.WriteLine("Your Balance is Decreased!!!");
                double temp = this.card.GetCurrentCash() - money;
                this.card.SetCurrentCash(temp);
                System.Console.WriteLine($"The Current Balance --> {this.card.GetCurrentCash()}");
            }
        }
        public void IncreaseMoney(double money)
        {
            System.Console.WriteLine("Your Balance is Increased!!!");
            double temp = this.card.GetCurrentCash() + money;
            this.card.SetCurrentCash(temp);
            System.Console.WriteLine($"The Current Balance --> {this.card.GetCurrentCash()}");
        }
    }
    public static class ActivatedCards
    {
        private static List<Card> activatedCardList = new List<Card>();
        public static List<Card> GetActivatedCards()
        {
            return activatedCardList;
        }
    }
    public class ActivationCheck
    {
        public bool IsActivated(Card card)
        {
            if (ActivatedCards.GetActivatedCards().Contains(card))
            {
                return true;
            }
            return false;
        }
    }
}