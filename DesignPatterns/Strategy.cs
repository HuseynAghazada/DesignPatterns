namespace StrategyDB
{
    public class TravelContext
    {
        private ITravelStrategy travelStrategy;
        public TravelContext(ITravelStrategy travelStrategy)
        {
            this.travelStrategy = travelStrategy;
        }
        public void CalculateCost(double distance)
        {
            double cost = this.travelStrategy.Cost(distance);
            System.Console.WriteLine($"The Cost ---> {cost}$");
        }
    }
    public interface ITravelStrategy
    {
        public double Cost(double distance);
    }
    public class Car : ITravelStrategy
    {
        private double costPerKilometer;
        public Car()
        {
            this.costPerKilometer = 35;
        }
        public double Cost(double distance)
        {
            return this.costPerKilometer * distance;
        }
    }
    public class Bus : ITravelStrategy
    {
        private double costPerKilometer;
        public Bus()
        {
            this.costPerKilometer = 10;
        }
        public double Cost(double distance)
        {
            return this.costPerKilometer * distance;
        }
    }
    public class Plane : ITravelStrategy
    {
        private double costPerKilometer;
        public Plane()
        {
            this.costPerKilometer = 75;
        }
        public double Cost(double distance)
        {
            return this.costPerKilometer * distance;
        }
    }
}