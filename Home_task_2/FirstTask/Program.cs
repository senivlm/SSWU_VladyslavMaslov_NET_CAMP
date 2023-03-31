using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task.Model;

namespace task
{
    internal class Program
    {
        static void AddNewWaterTower(Shell shell)
        {
            //
            Console.WriteLine("enter pump power");
            int power = int.Parse(Console.ReadLine());
            Console.WriteLine("enter pump flow rate");
            int flowRate = int.Parse(Console.ReadLine());
            Console.WriteLine("enter water tower max volume");
            int maxVolume = int.Parse(Console.ReadLine());

            shell.waterTowerList.Add(new WaterTower(maxVolume, new Pump(power, flowRate)));
            Console.WriteLine("You have successfully added a new water tower!");
        }
        static void AddNewUser(Shell shell)
        {
            Console.WriteLine("Enter username");
            string usrName = Console.ReadLine();
            Console.WriteLine("Enter password");
            string pwd = Console.ReadLine();

            //Console.WriteLine("Enter the number of the water tower you want to assign the user to");
            //int num = int.Parse(Console.ReadLine());
            //shell.waterTowerList[num].Users.Add(new User)
            shell.users.Add(new User(usrName, pwd));
            Console.WriteLine("Successfully");
        }
        static void Main(string[] args)
        {
            Shell shell = new Shell();

            while (true)
            {
                try
                {
                    Console.WriteLine("Make your choice:\n" +
                        "0. Stop this program\n" +
                        "1. Add new water tower\n" +
                        "2. Add new user\n" +
                        "3. Go to user 'cabinet'\n" +
                        "4. Next step");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 0)
                    {
                        break;
                    }
                    else if (input == 1)
                    {
                        //Console.WriteLine("")
                        AddNewWaterTower(shell);
                    }
                    else if(input == 2)
                    {
                        AddNewUser(shell);
                    }
                    else if( input == 3)
                    {
                        //bool isLoged = false;
                        Console.WriteLine( "Enter username" );
                        string usr = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        string pwd = Console.ReadLine();

                        var user = shell.users.FirstOrDefault(f => f.userName == usr && f.password == pwd);

                        if (user == null)
                            Console.WriteLine(  "password or username is wrong");
                        else
                        {
                            Console.WriteLine("Make your choise:\n" +
                                "0. nothing\n" +
                                "1. draw water\n");
                            var inp = int.Parse(Console.ReadLine());

                            if (inp == 1)
                            {
                                int i = 0;
                                string allTowers = "Select your tower:\n";
                                foreach(var tower in shell.waterTowerList)
                                {
                                    allTowers += $"{i} {tower}\n";
                                }
                                Console.WriteLine(allTowers);
                                int choise = int.Parse(Console.ReadLine());

                                Console.WriteLine("How much water you need?");
                                int volume = int.Parse(Console.ReadLine());
                                int drained = shell.waterTowerList[choise].Drain(volume, user);
                                user.waterUsed += drained;

                                Console.WriteLine($"You drain {drained} liters");
                            }
                        }
                    }
                    else if(input == 4)
                    {
                        shell.GoNextStep();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.WriteLine("You are break this program");
            Console.ReadLine();
        }
    }
}