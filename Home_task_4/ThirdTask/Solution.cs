using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{

    public class ApartmentInfo
    {
        public int ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string OwnerSurname { get; set; }
        public int QuarterNumber { get; set; }
        public int StartMeterReading { get; set; }
        public int EndMeterReading { get; set; }
        public DateTime WithdrawalOfIndicatorsDate_1 { get; set; }
        public DateTime WithdrawalOfIndicatorsDate_2 { get; set; }
        public DateTime WithdrawalOfIndicatorsDate_3 { get; set; }

        public static void PrintReport()
        {
            var withdrawals = WithdrawalOfIndicators.GetWithdrawalsList();
            var apartments = Apartment.GetApartmentsList();

            Console.WriteLine("Зняття показників лічильників за кварталами:");

            var groupedWithdrawals = withdrawals.GroupBy(w => w.QuarterNumber);
            foreach (var group in groupedWithdrawals)
            {
                Console.WriteLine("Квартал {0}", group.Key);
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine("|Номер\t\t|Адреса\t\t\tПрізвище власника\t|");
                Console.WriteLine("----------------------------------------------------------------");

                foreach (var withdrawal in group)
                {
                    var apartment = apartments.FirstOrDefault(a => a.ApartmentNumber == withdrawal.apartmentId);
                    Console.WriteLine("|{0,-14}\t|{1,-14}\t|{2,-18} |", apartment.ApartmentNumber, apartment.Address, apartment.OwnerSurname);
                }

                Console.WriteLine("----------------------------------------------------------------");

                Console.WriteLine("|Показники лічильників\t\t\tЗняття показників\t|");
                Console.WriteLine("|\t\t\t\t| 1 місяць | 2 місяць | 3 місяць|");
                Console.WriteLine("----------------------------------------------------------------");

                foreach (var withdrawal in group)
                {
                    var apartment = apartments.FirstOrDefault(a => a.ApartmentNumber == withdrawal.apartmentId);
                    Console.WriteLine("| {0,-22} | {1,-9} | {2,-9} | {3,-9} |",
                        $"{withdrawal.StartMeterReading} - {withdrawal.EndMeterReading}",
                        withdrawal.WithdrawalOfIndicatorsDate_1.ToString("dd MMM"),
                        withdrawal.WithdrawalOfIndicatorsDate_2.ToString("dd MMM"),
                        withdrawal.WithdrawalOfIndicatorsDate_3.ToString("dd MMM"));
                }

                Console.WriteLine("----------------------------------------------------------------\n");
            }
        }
        public static void PrintApartmentInfo(int apartmentNumber)
        {
            var withdrawals = WithdrawalOfIndicators.GetWithdrawalsList();
            var apartments = Apartment.GetApartmentsList();

            Console.WriteLine("Информация о квартире №{0} за все кварталы:", apartmentNumber);

            var groupedWithdrawals = withdrawals.Where(w => apartments.FirstOrDefault(a => a.ApartmentNumber == apartmentNumber)?.ApartmentNumber == w.apartmentId).GroupBy(w => w.QuarterNumber);
            foreach (var group in groupedWithdrawals)
            {
                Console.WriteLine("Квартал {0}", group.Key);
                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine("| Показники лічильників | Зняття показників       |");
                Console.WriteLine("|                        | 1 місяць | 2 місяць | 3 місяць |");
                Console.WriteLine("--------------------------------------------------------");

                var withdrawal = group.FirstOrDefault();
                if (withdrawal != null)
                {
                    Console.WriteLine("| {0,-22} | {1,-9} \t| {2,-9} \t| {3,-9} \t|",
                        $"{withdrawal.StartMeterReading} - {withdrawal.EndMeterReading}",
                        withdrawal.WithdrawalOfIndicatorsDate_1.ToString("dd MMMM"),
                        withdrawal.WithdrawalOfIndicatorsDate_2.ToString("dd MMMM"),
                        withdrawal.WithdrawalOfIndicatorsDate_3.ToString("dd MMMM"));
                }
                else
                {
                    Console.WriteLine("|                        |           |           |           |");
                }

                Console.WriteLine("--------------------------------------------------------\n");
            }
        }
        public static void PrintOwnerWithMaxDebt()
        {
            var withdrawals = WithdrawalOfIndicators.GetWithdrawalsList();
            var apartments = Apartment.GetApartmentsList();

            var ownerDebts = new Dictionary<string, decimal>();

            foreach (var apartment in apartments)
            {
                var withdrawalsForApartment = withdrawals.Where(w => w.apartmentId == apartment.ApartmentNumber).ToList();

                // calculate total debt for the apartment
                decimal totalDebt = 0;
                foreach (var withdrawal in withdrawalsForApartment)
                {
                    totalDebt += (withdrawal.EndMeterReading - withdrawal.StartMeterReading) * 1.44m;
                }

                // add debt to the owner's debt
                if (ownerDebts.ContainsKey(apartment.OwnerSurname))
                {
                    ownerDebts[apartment.OwnerSurname] += totalDebt;
                }
                else
                {
                    ownerDebts.Add(apartment.OwnerSurname, totalDebt);
                }
            }

            // find owner with max debt
            var maxDebtOwner = ownerDebts.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;
            var maxDebt = ownerDebts[maxDebtOwner];

            Console.WriteLine("Власник з найбільшою заборгованістю:");
            Console.WriteLine("Прізвище: {0}\t\tЗаборгованість: {1} грн", maxDebtOwner, maxDebt);
        }
        public static void FindApartmentWithoutElectricityUsage()
        {
            var withdrawals = WithdrawalOfIndicators.GetWithdrawalsList();
            var apartments = Apartment.GetApartmentsList();

            var unusedApartments = apartments.Where(apartment =>
            {
                // Find withdrawals for the apartment
                var apartmentWithdrawals = withdrawals.Where(w => w.apartmentId == apartment.ApartmentNumber).ToList();

                // Check if any withdrawal has a zero meter reading
                return apartmentWithdrawals.Any(w => w.StartMeterReading - w.EndMeterReading == 0);
            });

            if (unusedApartments.Any())
            {
                Console.WriteLine("Квартира, де не користувались електроенергією:");

                foreach (var apartment in unusedApartments)
                {
                    Console.WriteLine("Адреса: {0}", apartment.Address);
                    Console.WriteLine("Власник: {0}", apartment.OwnerSurname);
                }
            }
            else
            {
                Console.WriteLine("Немає квартир без використання електроенергії");
            }
        }
        public static void PrintExpensesPerQuarter()
        {
            var withdrawals = WithdrawalOfIndicators.GetWithdrawalsList();
            var apartments = Apartment.GetApartmentsList();
            const decimal pricePerKw = 1.44m;

            Console.WriteLine("Розрахунок витрат на електроенергію за квартал:");

            var groupedWithdrawals = withdrawals.GroupBy(w => w.QuarterNumber);
            foreach (var group in groupedWithdrawals)
            {
                Console.WriteLine("Квартал {0}", group.Key);
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine("| Номер квартири | Власник               | Витрати           |");
                Console.WriteLine("-------------------------------------------------------------");

                foreach (var withdrawal in group)
                {
                    var apartment = apartments.FirstOrDefault(a => a.ApartmentNumber == withdrawal.apartmentId);

                    var startMeter = withdrawal.StartMeterReading;
                    var endMeter = withdrawal.EndMeterReading;
                    var kwUsed = endMeter - startMeter;
                    var expenses = kwUsed * pricePerKw;

                    Console.WriteLine("| {0,-14} | {1,-21} | {2,-13:F2} грн |", apartment.ApartmentNumber, apartment.OwnerSurname, expenses);
                }

                Console.WriteLine("-------------------------------------------------------------\n");
            }
        }


    }


    public class Apartment
    {
        public int ApartmentNumber { get; set; }
        public string Address { get; set; }
        public string OwnerSurname { get; set; }

        public static List<Apartment> GetApartmentsList()
        {
            string json = File.ReadAllText("apartmentData.json");
            return JsonConvert.DeserializeObject<List<Apartment>>(json);
        }

        public static Apartment GetApartmentByNumber(int id)
        {
            var source = GetApartmentsList();
            return source.FirstOrDefault(f => f.ApartmentNumber == id);
        }
    }
    //класс, який описує зняття показників лічильника
    public class WithdrawalOfIndicators
    {
        public int apartmentId { get; set; }
        //номер кварталу
        public int QuarterNumber { get; set; }
        //показ лічильника на початок кварталу
        public int StartMeterReading { get; set; }
        //показ лічильника на кінець кварталу
        public int EndMeterReading { get; set; }

        //дата зняття показників із лічильника в першому місяці кварталу
        public DateTime WithdrawalOfIndicatorsDate_1 { get; set; }
        //дата зняття показників із лічильника в другому місяці кварталу
        public DateTime WithdrawalOfIndicatorsDate_2 { get; set; }
        //дата зняття показників із лічильника в першому третьому кварталу
        public DateTime WithdrawalOfIndicatorsDate_3 { get; set; }

        public static List<WithdrawalOfIndicators> GetWithdrawalsList()
        {
            string json = File.ReadAllText("withdrawalOfIndicators.json");
            return JsonConvert.DeserializeObject<List<WithdrawalOfIndicators>>(json);
        }
    }
    public static class Solution
    {
        public static void Demo()
        {
            while (true)
            {
                Console.WriteLine("Оберіть опцію:\n\n" +
                    "1). Зняття показників лічильників за кварталами\n" +
                    "2). Информация о квартире за все кварталы\n" +
                    "3). Власник із найбільшим боргом\n" +
                    "4). Квартира, де електроенергія не використовувалась\n" +
                    "5). Витрати всіх користувачів за всі квартали");

                var i = int.Parse(Console.ReadLine());

                if (i == 1)
                {
                    ApartmentInfo.PrintReport();
                }
                else if (i == 2)
                {
                    Console.WriteLine("Введіть номер квартири:");
                    try
                    {
                        int n = int.Parse(Console.ReadLine());
                        ApartmentInfo.PrintApartmentInfo(n);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                else if (i == 3)
                {
                    ApartmentInfo.PrintOwnerWithMaxDebt();
                }
                else if (i == 4)
                {
                    ApartmentInfo.FindApartmentWithoutElectricityUsage();
                }
                else if (i == 5)
                {
                    ApartmentInfo.PrintExpensesPerQuarter();
                }
                else {
                    Console.WriteLine("Ви завершили роботу програми!");
                    break;
                }
            }
        }
    }
}