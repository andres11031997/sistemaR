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

        public void ShowPointsValue()
        {
            decimal value = points * 100;
            Console.WriteLine($"Your points are worth: ${value}");
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
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n--- Reward System Menu ---");
                Console.WriteLine("1. Register a purchase");
                Console.WriteLine("2. Show total points");
                Console.WriteLine("3. Show points value in money");
                Console.WriteLine("4. Redeem points");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.Write("Enter purchase amount: ");
                            decimal amount = Convert.ToDecimal(Console.ReadLine());
                            customer.RegisterPurchase(amount);
                            break;

                        case "2":
                            customer.ShowPoints();
                            break;

                        case "3":
                            customer.ShowPointsValue();
                            break;

                        case "4":
                            Console.Write("Enter points to redeem: ");
                            int redeem = Convert.ToInt32(Console.ReadLine());
                            customer.RedeemPoints(redeem);
                            break;

                        case "5":
                            exit = true;
                            Console.WriteLine("Exiting program...");
                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Error: Invalid input. Please enter numbers only.");
                }
            }
        }
    }
}
