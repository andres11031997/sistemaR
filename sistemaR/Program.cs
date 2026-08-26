using System;

namespace RewardSystem
{
    public class Customer
    {
        private int points;

        public Customer()
        {
            points = 0;
        }

        // Register a purchase and calculate points
        public void RegisterPurchase(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Error: Purchase amount must be greater than zero.");
                return;
            }

            int earnedPoints = (int)(amount / 1000);
            points += earnedPoints;
            Console.WriteLine($"Purchase registered. Earned {earnedPoints} points.");
        }

        // Show total points
        public void ShowPoints()
        {
            Console.WriteLine($"Total points: {points}");
        }

        // Redeem points
        public void RedeemPoints(int pointsToRedeem)
        {
            if (pointsToRedeem <= 0)
            {
                Console.WriteLine("Error: Points to redeem must be greater than zero.");
                return;
            }

            if (pointsToRedeem > points)
            {
                Console.WriteLine("Error: Not enough points to redeem.");
                return;
            }

            decimal discount = pointsToRedeem * 100;
            points -= pointsToRedeem;
            Console.WriteLine($"Redeemed {pointsToRedeem} points. Discount applied: ${discount}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer();

            customer.RegisterPurchase(5000); // Example purchase
            customer.ShowPoints();

            customer.RedeemPoints(3); // Example redemption
            customer.ShowPoints();
        }
    }
}
