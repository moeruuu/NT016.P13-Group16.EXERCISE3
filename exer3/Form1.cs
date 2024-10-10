namespace exer3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            signup sup = new signup();
            sup.ShowDialog();
        }
    }
}
