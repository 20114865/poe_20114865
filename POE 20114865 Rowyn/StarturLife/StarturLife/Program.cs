using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarturLife
{
    class Program
    {
        delegate void Del(string str);
        static void Main(string[] args)
        {
            //Declare variables
            float grossIncome = 0;
            float taxDeducted = 0;
            float groceries = 0;
            float waterAndLights = 0;
            float travelCosts = 0;
            float cellPhone = 0;
            float otherexpen = 0;
            float monthlyRental = 0;
            float propertyPrice = 0;
            float totalDeposit = 0;
            float interestRate = 0;
            int monthrepay = 0;
            int typeAcc = 0;
            float eMI = 0;
            //generic collection to store the expenses
            Dictionary<string, float> expenselist = new Dictionary<string, float>();
            //User enter Gross monthly income
            Console.WriteLine("Gross monthly income: ");
            float.TryParse(Console.ReadLine(), out grossIncome);
            //User enter Estimated monthly tax deducted
            Console.WriteLine("Estimated monthly tax deducted: ");
            float.TryParse(Console.ReadLine(), out taxDeducted);
            expenselist.Add("Estimated monthly tax deducted  R", taxDeducted);
            //Estimate following categories
            Console.WriteLine("___________________________________________________________________");
            Console.WriteLine("Estimated monthly expenditures in each of the following categories");
            Console.WriteLine("___________________________________________________________________");
           //User enter estimated Groceries and save in expenselist
            Console.WriteLine("Groceries");
            float.TryParse(Console.ReadLine(), out groceries);
            expenselist.Add("Groceries  R", groceries);
            //User enter estimated Water snd lights then save in expenselist
            Console.WriteLine("Water and lights");
            float.TryParse(Console.ReadLine(), out waterAndLights);
            expenselist.Add("Water and lights  R", waterAndLights);
            //User enter estimated travel costs then save in expenselist
            Console.WriteLine("Travel costs (including petrol)");
            float.TryParse(Console.ReadLine(), out travelCosts);
            expenselist.Add("Travel costs (including petrol)  R", travelCosts);
            //User enter telephone number then save in expenselist
            Console.WriteLine("Cell phone and telephone");
            float.TryParse(Console.ReadLine(), out cellPhone);
            expenselist.Add("Cell phone and telephone  ", cellPhone);
            //User enter estimated other expenses then save in expenselist
            Console.WriteLine("Other expenses  ");
            float.TryParse(Console.ReadLine(), out otherexpen);
            expenselist.Add("Other expenses  R", otherexpen);
            //ask user to choose option
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("For Renting accommodation select 1 or select 2 for buying a property");
            Console.WriteLine("_________________________________________________");
            //User must chooese 1 (Renting accommodation)or 2 (Buying a property)
            Console.WriteLine("1. Renting accommodation");
            Console.WriteLine("2. Buying a property");
            typeAcc = Convert.ToInt32(Console.ReadLine());
            // If rent
            if (typeAcc == 1)
            {
                //user enter monthly rental
                Console.WriteLine("Monthly rental amount");
                float.TryParse(Console.ReadLine(), out monthlyRental);
                expenselist.Add("Monthly rental amount  R", monthlyRental);
            }
            //if lone
            else if (typeAcc == 2)

            {
                //user enter purchase price of property
                Console.WriteLine("Purchase price of property: ");
                float.TryParse(Console.ReadLine(), out propertyPrice);
                //user enter Total deposit
                Console.WriteLine("Total deposit: ");
                float.TryParse(Console.ReadLine(), out totalDeposit);
                //User enter interest rate
                Console.WriteLine("Interest rate (percentage): ");
                float.TryParse(Console.ReadLine(), out interestRate);
                //user enter number of months to repay
                Console.WriteLine("Number of months to repay (between 240 and 360): ");
                monthrepay = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Monthly home loan repayment for buying a property: ");
                eMI = propertyPrice - totalDeposit;
                //if emi greater then gross income
                if (eMI > grossIncome / 3)
                {
                    Console.WriteLine("Approval of the home loan is unlikely");
                }
                expenselist.Add("Home Loan EMI", eMI);
            }
            //available money
            float availableMoney = 0;
            if (typeAcc == 1)
            {
                availableMoney = grossIncome - (taxDeducted + groceries + waterAndLights + travelCosts + cellPhone + otherexpen + monthlyRental);

            }
            else if (typeAcc == 2)
            {
                availableMoney = grossIncome - (taxDeducted + groceries + waterAndLights + travelCosts + cellPhone + otherexpen + eMI);
            }
            Console.WriteLine("Available monthly money after all the specified deductions have been made:{0}", availableMoney);
            float emiveh = BuyVehicle();
            if (emiveh > 0)
            {
                expenselist.Add("Vehicle EMI", emiveh);
            }
            float totalExpense = 0;
            
            if (typeAcc == 1)
            {
                totalExpense = taxDeducted + groceries + waterAndLights + travelCosts + cellPhone + monthlyRental + otherexpen + emiveh;
            }
            else if (typeAcc == 2)
            {
                totalExpense = taxDeducted + groceries + waterAndLights + travelCosts + cellPhone + otherexpen + eMI + emiveh;
            }
            if (totalExpense > (grossIncome * 3 / 4))
            {

                Del del3 = delegate (string name)
                { Console.WriteLine("Total expenses are greater than 75 percent of gross income"); };
            }
            //Display the expenses to the user in descending order by value
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Expenses to the user in descending order by value");
            Console.WriteLine("_________________________________________________");
            foreach (KeyValuePair<string, float> expin in expenselist.OrderBy(key => key.Value))
            {
                Console.WriteLine(expin.Key + expin.Value);
            }
            Console.ReadLine();
        }
        //emi calculator 
        static float emi_calculator(float emi, float interestRate, float monthrepay)
        {
            

            interestRate = interestRate / (12 * 100); // one month interest
            monthrepay = monthrepay * 12; // one month period
            emi = (emi * interestRate * (float)Math.Pow(1 + interestRate, monthrepay))
            / (float)(Math.Pow(1 + interestRate, monthrepay) - 1);

            return (emi);
        }
        static float BuyVehicle()
        {
            //ask user to choose option
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("Want to buy a vehicle, select 1 or 2");
            Console.WriteLine("_________________________________________________");
            Console.WriteLine("1: Yes");
            Console.WriteLine("2: No");
            float emivechilce = 0;
            int selectvehicle = Convert.ToInt32(Console.ReadLine());
            //if buy vehicle
            if (selectvehicle == 1)
            {
                //user enter model make
                Console.WriteLine("Model and make:");
                string make = Console.ReadLine();
                //user enter purchase price
                Console.WriteLine("Purchase price: ");
                float purchasePrice = 0;
                float.TryParse(Console.ReadLine(), out purchasePrice);
                //user enter total deposit
                Console.WriteLine("Total deposit: ");
                float totalDeposit = 0;
                float.TryParse(Console.ReadLine(), out totalDeposit);
                //user enter interest rate
                Console.WriteLine("Interest rate (percentage): ");
                float interestRate = 0;
                float.TryParse(Console.ReadLine(), out interestRate);
                //User enter estimated insurance premium
                Console.WriteLine("Estimated insurance premium: ");
                float estInsPremium = 0;
                float.TryParse(Console.ReadLine(), out estInsPremium);
                emivechilce = emi_calculator(purchasePrice - totalDeposit + estInsPremium, interestRate, 5);
            }
            return emivechilce;
        }
    }
}



