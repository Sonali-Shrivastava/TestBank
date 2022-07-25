using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBank;
using System.Collections;

namespace TestBankClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc=null;
            ArrayList arr = new ArrayList();
           
            int choice=0;
            string name;
            double amt;

            while (choice != 6)
            {
                Console.WriteLine("1. Open Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Close Account");
                Console.WriteLine("6. Exit");
                Console.WriteLine("Enter your choice :");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:

                        Console.WriteLine("1.Savings");
                        Console.WriteLine("2.Current");
                        Console.WriteLine("3.Fixed");
                        Console.WriteLine("Enter your choice :");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            acc = new Savings();

                        }
                        else if (choice == 2)
                        {
                            acc = new Current();
                        }
                        else
                        {
                            acc = new Fixed();
                        }
                        acc.BalanceChange += new Account.MyDelegate(EventHandlerFn);
                        arr.Add(acc);
                        Console.WriteLine("Enter your name :");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter initial Amount:");
                        amt = Convert.ToDouble(Console.ReadLine());
                        int i = acc.OpenAccount(name, amt);
                        Console.WriteLine("Account Created .. Account number = " + i);
                        break;
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    
                    case 2: 
                        Console.WriteLine("Enter your Account Number:");
                        int a = Convert.ToInt32(Console.ReadLine());
                        int flag = 0;
                        IEnumerator e;
                        e = arr.GetEnumerator();
                        while (e.MoveNext())
                        {
                           Account temp = (Account)e.Current;
                            if (temp.ACNO == a)
                            {
                                acc = temp;
                                flag = 1;
                                break;
                            }
                        }
                        if (flag == 0)
                        {
                            
                        }


                        Console.WriteLine("Enter Amount to Deposit:");
                        amt = Convert.ToDouble(Console.ReadLine());

                        bool result = acc.Deposit(amt);
                        if (result == true)
                            Console.WriteLine("Deposit successfull");
                        break;
                    case 3:
                        Console.WriteLine("Enter your Account Number:");
                         a = Convert.ToInt32(Console.ReadLine());

                       
                        e = arr.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == a)
                            {
                                acc = temp;
                                break;
                            }
                        }
                        Console.WriteLine("Enter Amount to Withdraw:");
                        amt = Convert.ToDouble(Console.ReadLine());

                        result = acc.WithDraw(amt);
                        if (result == true)
                            Console.WriteLine("Withdraw successfull");
                        else
                            Console.WriteLine("Withdraw Unsucessfull");
                        break;
                    case 4:
                        Console.WriteLine("Enter your Account Number:");
                         a = Convert.ToInt32(Console.ReadLine());

                       
                        e = arr.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == a)
                            {
                                acc = temp;
                                break;
                            }
                        }
                        Console.WriteLine("Your Balance is :" + acc.CHECKBALANCE );
                        break;
                    case 5:
                        Console.WriteLine("Enter your Account Number:");
                         a = Convert.ToInt32(Console.ReadLine());

                        
                        e = arr.GetEnumerator();
                        while (e.MoveNext())
                        {
                            Account temp = (Account)e.Current;
                            if (temp.ACNO == a)
                            {
                                acc = temp;
                                break;
                            }
                        }
                        
                        Console.WriteLine(acc.CloseAccount());
                        arr.Remove(acc);
                        acc = null;
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                }
            }

        }

        public static void EventHandlerFn(double d)
        {
            Console.WriteLine("Balance has changed ... updated balance is :" + d);
        }
    }
}
