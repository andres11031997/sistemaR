using System;

namespace RewardSystem
{
    public class Customer
    {
        private int points = 0;

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

        public void ShowPoints()
        {
            Console.WriteLine($"Total points: {points}");
        }

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

            Console.WriteLine("Enter purchase amount:");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            customer.RegisterPurchase(amount);

            customer.ShowPoints();

            Console.WriteLine("Enter points to redeem:");
            int redeem = Convert.ToInt32(Console.ReadLine());
            customer.RedeemPoints(redeem);

            customer.ShowPoints();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
