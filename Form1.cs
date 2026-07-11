namespace TestProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void userControl11_OnCalculationSelected(int obj)
        {
            if (obj >= 50)
            {
                MessageBox.Show("Congrats You Passed");
            }
        }

        private void userControl11_onSelectedName(string obj)
        {
            if (obj == "Yousuf")
            {
                MessageBox.Show("Welcome ALi");
            }
            else
            {
                MessageBox.Show("Fuck You");
            }
        }
    }
}
