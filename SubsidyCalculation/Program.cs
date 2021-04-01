using System;

namespace SubsidyCalculation
{
    class Program
    {
        static void Main(string[] args)
        {
            SubsidyCalc subsidyCalc = new SubsidyCalc();
            subsidyCalc.OnNotify += displayMessage;
            subsidyCalc.OnException += displayException;
            Charge charge = subsidyCalc.CalculateSubsidy(new Volume()
            {
                Value = 10,
                HouseId = 10,
                Month = new DateTime(2021, 2, 1, 18, 30, 25),
                ServiceId = 10
            }, new Tariff()
            {
                Value = 10,
                HouseId = 10,
                PeriodBegin = new DateTime(2021, 1, 1, 18, 30, 25),
                PeriodEnd = new DateTime(2021, 4, 1, 18, 30, 25),
                ServiceId = 10
            });
            Console.WriteLine(charge.Value);

        }
        static void displayMessage(object sender, string message)
        {
            Console.WriteLine(message);
        }

        static void displayException(object sender, Tuple<string, Exception> tuple)
        {
            Console.WriteLine(tuple.Item2.Message);
        }
    }
}