namespace Size
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("File");
            comboBox1.Items.Add("Folder");
            comboBox1.Text = "File";
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            if (comboBox1.SelectedItem == "File")
            {
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }

            if (comboBox1.SelectedItem == "Folder")
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }
        }
    }
}
