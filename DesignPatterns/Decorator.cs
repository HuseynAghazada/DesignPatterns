namespace DecoratorDP
{
    public interface IPizza
    {
        public string GetPizzaType();
    }
    public class EmptyPizza : IPizza
    {
        public string GetPizzaType()
        {
            return "This is a normal pizza";
        }
    }
    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza pizza;
        public PizzaDecorator(IPizza pizza)
        {
            this.pizza = pizza;
        }
        public abstract string GetPizzaType();
    }
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza)
        {}
        public override string GetPizzaType()
        {
            string temp = pizza.GetPizzaType();
            return temp + "\n    with extra cheese";
        }
    }
    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza)
        {}
        public override string GetPizzaType()
        {
            string temp = pizza.GetPizzaType();
            return temp + "\n    with extra tomato";
        }
    }
}