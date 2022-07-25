using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBank
{
    public abstract  class Account
    {

        public static int ctr;
        protected int Acno;
        protected string AcHolderName;
        protected double Balance;

        public delegate void MyDelegate(double d);
        public event MyDelegate BalanceChange;
        public abstract int OpenAccount(string Name, double Amt);

        public int ACNO
        {
            get
            {
                return Acno;
            }
        }
        public virtual bool Deposit(double Amt)
        {
            if (Amt > 0)
            {
                Balance += Amt;
                BalanceChange(Balance);
                return true;
            }
            else
                return false;
        }
        public abstract bool WithDraw(double Amt);
        public double CHECKBALANCE
        {
            get
            {
                return Balance;
            }
        }
        public string CloseAccount()
        {
            return "Account Closed";
        }
        protected void RaiseEvent()
        {
            BalanceChange(Balance);
        }
    }

}
