using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeCalculator
{
    class Program
    {
        static decimal itemCost, amountGiven, change, numQuarters, numDimes, numNickels, numPennies;
        //coinInfo array represents $20, $10, $5, $1, quarters, dimes, nickels, pennies
        //first set of brackets hold the amount of that dollar or coin type
        //second set of brackets hold the dollar or coin value

        static decimal[,] coinInfo =
            { {0, 0, 0, 0, 0, 0, 0, 0 },
            {20.0M, 10.0M, 5.0M, 1.0M, .25M, .10M, .05M, .01M} };

//integer value assignment for each set of brackets

        static int coinInfoIndexNum = 0, coinInfoIndexVal = 1;

static string[] coinTypeLabels = { "Dollars ($20): ", "Dollars ($10): ", "Dollars ($5): ", "Dollars ($1): ", "Quarters: ", "Dimes: ", "Nickels: ", "Pennies: " };

static void Main(string[] args)
{
    try
            { 
        getInputAmounts();

    calcCoinAmounts();

    displayResults();
    }
    catch (Exception e)
    {
        Console.WriteLine("An error occured");
        Console.WriteLine(e.Message);
    }
    Console.ReadLine();
}
static void getInputAmounts ()
{
    itemCost = inputMoney("How much does the item cost? $");

    while(true)
    {
        amountGiven = inputMoney("How much has the customer given you? $");
        if (amountGiven >= itemCost)
            {
            return;
        }
        else
        {
            Console.WriteLine("The amount given by the customer must be greater" + "than or equal to the cost (${0})", itemCost);
        }
    }

}
static void calcCoinAmounts()
{
    change = amountGiven - itemCost;

    decimal changeLeft = change;

    for (int i = 0; i < coinInfo.GetLength(1); i++)
    {
        coinInfo[coinInfoIndexNum, i] = Decimal.Floor(changeLeft / coinInfo[coinInfoIndexVal, i]);

        changeLeft = changeLeft % coinInfo[coinInfoIndexVal, i];
    }

}
static void calcCoin(decimal coinVal, out decimal numCoins, ref decimal changeAmount)
{
    numCoins = Decimal.Floor(changeAmount / coinVal);

    changeAmount = changeAmount % coinVal;
}
static void displayResults()
{
    Console.WriteLine("----------------------------------------------------------------");
    Console.WriteLine("The customer's change is: ${0}, given as:", change);

    for (int i = 0; i < coinTypeLabels.Length; i++)
    {
        Console.WriteLine(coinTypeLabels[i] + coinInfo[coinInfoIndexNum, i]);
    }
}
static decimal inputMoney (string message)
{
    while (true)
    {
        decimal inputAmount = inputPosDecNum(message);

        if (inputAmount == Math.Round(inputAmount, 2))
        {
            return inputAmount;
        }
        else
        {
            Console.WriteLine("Please enter a number with no more than 2 decimal places");

        }
    

    }

}
static decimal inputPosDecNum(string message)
{
    decimal resultNum = 0;
    while (true)
    {
        Console.Write(message);
        string input = Console.ReadLine();

        if (Decimal.TryParse(input, out resultNum))
        {
            if (resultNum > 0)
            {
                return resultNum;
            }
            else
            {
                Console.WriteLine("Please enter a positive number");
            }
        }
        else
        {
            Console.WriteLine("That number is too large");
        }
    }
}
}
}


