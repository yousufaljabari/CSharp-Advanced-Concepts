using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace TestProject
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        // Simple Events With Parameters 

        public event Action<int> OnCalculationSelected;
        public event Action<string> onSelectedName;

        protected virtual void CalculationComplete(int Result)
        {
            Action<int> handler = OnCalculationSelected;
            if (handler != null)
            {
                handler(Result);
            }

        }
        protected virtual void SelectName(string name)
        {
            Action<string> Handler = onSelectedName;
            if (Handler != null)
            {
                Handler(name);
            }

        }



        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int Result = int.Parse(textBoxFirstNumber.Text) + int.Parse(textBoxSecondNumber.Text);
            labelResullt.Text = Result.ToString();
            string name = "Yousuf";
            if (OnCalculationSelected != null)
            {
                CalculationComplete(Result);
            }
            if (onSelectedName != null)
            {
                SelectName(name);
            }

        }

        // Simple Events With Parameters 


        //Simple Event With Parameters Using Arguments
        public event EventHandler<CalculationCompleteEventArgs> OnCalculationComplete;

        public class CalculationCompleteEventArgs : EventArgs
        {
            public int Result { get; }
            public int val1 { get; }
            public int Val2 { get; }

            public CalculationCompleteEventArgs(int result, int val1, int val2)
            {
                this.Result = result;
                this.val1 = val1;
                this.Val2 = val2;
            }
        }


        public void RaiseOnCalculationComplete(int Result, int Val1, int Val2)
        {
            RaiseOnCalculationComplete(new CalculationCompleteEventArgs(Result, Val1, Val2));
        }

        protected virtual void RaiseOnCalculationComplete(CalculationCompleteEventArgs e)
        {
            OnCalculationComplete?.Invoke(this, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int val1 = int.Parse(textBoxFirstNumber.Text);
            int val2 = int.Parse(textBoxSecondNumber.Text);
            int Result = val1 + val2;

            if(OnCalculationComplete!=null)
            {
                RaiseOnCalculationComplete(Result, val1, val2);
            }



        }

        //Simple Event With Parameters Using Arguments



    }

}
