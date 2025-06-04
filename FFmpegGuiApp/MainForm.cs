namespace FFmpegGuiApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var builder = new FFmpegWrapperLib.FFmpegCommandBuilder
            {
                InputPath = inputTextBox.Text,
                OutputPath = outputTextBox.Text,
                Resolution = resolutionTextBox.Text
            };

            string command = builder.BuildCommand();
            commandOutputTextBox.Text = command;
        }
    }
}
