using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
   public class Current : Account
    {
        double MinOpAmt = 5000;
        double ODA = 3000;
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
            if (Balance +ODA > Amt)
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

