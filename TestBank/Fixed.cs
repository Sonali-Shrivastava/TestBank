using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public class Fixed : Account 
    {

        int term = 3;
        DateTime opdate;
        DateTime matdate;
        public override int OpenAccount(string Name, double Amt)
        {
                Balance = Amt;
                AcHolderName = Name;
                ctr++;
                Acno = ctr;
            opdate = DateTime.Now;
            matdate = opdate.AddYears(term);
                return Acno;
            
        }
        public override bool WithDraw(double Amt)
        {
            if (DateTime.Compare(DateTime.Now ,matdate)>0  )
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

