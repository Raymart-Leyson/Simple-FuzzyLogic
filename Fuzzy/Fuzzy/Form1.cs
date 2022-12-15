namespace Fuzzy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Convert.ToInt32(textBox1.Text);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            textBox1.Text = trackBar1.Value.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuzzyLogic f = new FuzzyLogic();
            float[] result = f.Defuzzify(trackBar1.Value);
            string temp;
            if (result[0] != 0)
            {
                temp = "cold";
                pictureBox1.BackColor = Color.Blue;
            }
            else if (result[1] != 0)
            {
                temp = "warm";
                pictureBox1.BackColor = Color.Orange;
            }
            else
            {
                temp = "hot";
                pictureBox1.BackColor = Color.Red;
            }
            label2.Text = temp;
            richTextBox1.Text = "Temperature is " + trackBar1.Value + " and it is " + temp + 
                ".\nCrisp Output is " + result[3] + ".";
        }
    }
}