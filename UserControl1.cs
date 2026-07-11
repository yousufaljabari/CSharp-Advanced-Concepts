using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            if(Handler!=null)
            {
                Handler(name);
            }

        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            int Result = int.Parse(textBoxFirstNumber.Text) + int.Parse(textBoxSecondNumber.Text);
            labelResullt.Text = Result.ToString();
            string name = "Yousuf";
            if(OnCalculationSelected!=null)
            {
                CalculationComplete(Result);
            }
            if(onSelectedName!=null)
            {
                SelectName(name);
            }
        }

        // Simple Events With Parameters 

    }
}
