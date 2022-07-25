using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class Savings : Account 
    {
        double MinOpAmt = 1000;
        double MinBal = 1000;
        public override int OpenAccount(string Name, double Amt)
        {
            if (Amt > MinOpAmt)
            {
                Balance = Amt;
                AcHolderName = Name;
                ctr++;
                Acno = ctr;
                return Acno;
            }
            else
                return 0;
        }
        public override bool WithDraw(double Amt)
        {
            if (Balance - Amt > MinBal)
            {
                Balance -= Amt;
                RaiseEvent(); 
                return true;
            }
            else
                return false;
        }
    }
}
