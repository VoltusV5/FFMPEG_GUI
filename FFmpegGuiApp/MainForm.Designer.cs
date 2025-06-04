namespace FFmpegGuiApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            inputTextBox = new TextBox();
            outputTextBox = new TextBox();
            label2 = new Label();
            resolutionTextBox = new TextBox();
            label3 = new Label();
            button1 = new Button();
            commandOutputTextBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 49);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 0;
            label1.Text = "Input path:";
            label1.Click += label1_Click;
            // 
            // inputTextBox
            // 
            inputTextBox.Location = new Point(92, 46);
            inputTextBox.Name = "inputTextBox";
            inputTextBox.Size = new Size(100, 23);
            inputTextBox.TabIndex = 1;
            inputTextBox.TextChanged += textBox1_TextChanged;
            // 
            // outputTextBox
            // 
            outputTextBox.Location = new Point(92, 84);
            outputTextBox.Name = "outputTextBox";
            outputTextBox.Size = new Size(100, 23);
            outputTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 87);
            label2.Name = "label2";
            label2.Size = new Size(78, 15);
            label2.TabIndex = 2;
            label2.Text = "Output  path:";
            // 
            // resolutionTextBox
            // 
            resolutionTextBox.Location = new Point(92, 122);
            resolutionTextBox.Name = "resolutionTextBox";
            resolutionTextBox.Size = new Size(100, 23);
            resolutionTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(8, 125);
            label3.Name = "label3";
            label3.Size = new Size(66, 15);
            label3.TabIndex = 4;
            label3.Text = "Resolution:";
            // 
            // button1
            // 
            button1.Location = new Point(8, 166);
            button1.Name = "button1";
            button1.Size = new Size(137, 23);
            button1.TabIndex = 6;
            button1.Text = "Build command";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // commandOutputTextBox
            // 
            commandOutputTextBox.Location = new Point(8, 228);
            commandOutputTextBox.Multiline = true;
            commandOutputTextBox.Name = "commandOutputTextBox";
            commandOutputTextBox.Size = new Size(361, 23);
            commandOutputTextBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 201);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 8;
            label4.Text = "Command:";
            label4.Click += label4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(commandOutputTextBox);
            Controls.Add(button1);
            Controls.Add(resolutionTextBox);
            Controls.Add(label3);
            Controls.Add(outputTextBox);
            Controls.Add(label2);
            Controls.Add(inputTextBox);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox inputTextBox;
        private TextBox outputTextBox;
        private Label label2;
        private TextBox resolutionTextBox;
        private Label label3;
        private Button button1;
        private TextBox commandOutputTextBox;
        private Label label4;
    }
}
