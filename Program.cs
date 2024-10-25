namespace Comission
{
    class Transaction
    {
        public String Name {  get; set; }
        public int Sales {  get; set; }
        public double Commission { get; set;}
        public double CommissionDue {  get; set; }
        public double Tax {  get; set; }
        public double AfterTaxCommission { get; set; }
    }
    internal class Program
    {
        //creating a list to save transactions in 
        static List<Transaction> history = new List<Transaction>();
        static void Main(string[] args)
        {
            double flatTaxRate = 0.15;
            

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("--------------------------");
                Console.WriteLine("BSCL COMMISSION CALCULATOR");
                Console.WriteLine("--------------------------");

                Console.Write("Name: ");
                string name = Console.ReadLine();

                Console.Write("Sales Made: $");
                int sales = Convert.ToInt32(Console.ReadLine());
                while (sales < 0)
                {
                    Console.WriteLine("Invalid sales amount, Try again");
                    Console.Write("Sales Made: $");
                    sales = Convert.ToInt32(Console.ReadLine());
                }
                //double commission =
                //      sales > 0 && sales <= 10000 ? 0
                //    : sales > 10000 && sales <= 15000 ? 0.5
                //    : sales > 15001 && sales <= 20000 ? 0.75
                //    : 1;
                //Console.WriteLine("Commission Percentage%: " + commission);

                double commission = 0;
                if (sales > 0 && sales <= 10000)
                {
                    Console.WriteLine("No commission");
                }
                else if (sales > 10000 && sales <= 15000)
                {
                    commission = 0.5;
                }
                else if (sales > 15000 && sales <= 20000)
                {
                    commission = 0.75;
                }
                else
                {
                    commission = 1;
                }
                Console.WriteLine("Commission allocated for your sales ${0} is {1}  ", sales, commission);
                double commissionDue = sales * commission;

                Console.WriteLine("Commission Due: $" + commissionDue);


                double taxAmount = flatTaxRate * commissionDue;
                double afterTaxCommission = commissionDue - taxAmount;

                Console.WriteLine("Tax rate at 15%: " + taxAmount);
                Console.WriteLine("Commission after tax: $" + afterTaxCommission);

                //adding a new transaction
                history.Add(new Transaction
                {
                    Name = name,
                    Sales = sales,
                    Commission = commission,
                    CommissionDue = commissionDue,
                    Tax = taxAmount,
                    AfterTaxCommission = afterTaxCommission

                });
                

                Console.WriteLine("Would you like to view transaction history? (yes/no)");
                string viewHistory = Console.ReadLine().ToLower();

                Console.WriteLine("Do you want to export to a text file");
                if(Console.ReadLine().ToLower() == "yes")
                {
                    ExportToTextFile();
                    Console.WriteLine("File Exported successfully");
                }

                if (viewHistory == "yes")
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("------Transaction History-----");
                    Console.ResetColor();

                    foreach (var transaction in history)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine($"Name: {transaction.Name} \n" +
                            $"Sales: {transaction.Sales}\n" +
                            $"Commission: {transaction.Commission} \n" +
                            $"Commission Due: {transaction.CommissionDue} \n" +
                            $"Tax: {transaction.Tax} \n" +
                            $"After Tax Amount: {transaction.AfterTaxCommission}\n");
                        Console.ResetColor();
                    }
                }

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("Would you like to calculate another commssion(yes/no)");
                string repeat = Console.ReadLine().ToLower();
                Console.ResetColor();

                if (repeat != "yes")
                {
                    Console.WriteLine("Thanks for using our calculator:)");
                    break;
                }

                Console.ResetColor();
            }

        }
        static void ExportToTextFile()
        {
            string filePath = "C:\\Users\\USER\\source\\repos\\Comission\\Comission\\elton.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                
                writer.WriteLine("------Transaction History-----");
               
                foreach (var transaction in history)
                {
                    writer.WriteLine($"Name: {transaction.Name} \n" +
                        $"Sales: {transaction.Sales}\n" +
                        $"Commission: {transaction.Commission} \n" +
                        $"Commission Due: {transaction.CommissionDue} \n" +
                        $"Tax: {transaction.Tax} \n" +
                        $"After Tax Amount: {transaction.AfterTaxCommission}\n");
                }
                Console.ResetColor();
            };
        }
    }
}
