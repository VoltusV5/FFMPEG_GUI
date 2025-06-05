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
            txtInputPath = new TextBox();
            txtOutputPath = new TextBox();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            commandOutputTextBox = new TextBox();
            label4 = new Label();
            btnBrowseInput = new Button();
            btnSelectFolder = new Button();
            comboResolution = new ComboBox();
            txtCustomWidth = new TextBox();
            locker = new Button();
            txtCustomHeight = new TextBox();
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // txtInputPath
            // 
            txtInputPath.AllowDrop = true;
            txtInputPath.Location = new Point(92, 46);
            txtInputPath.Name = "txtInputPath";
            txtInputPath.Size = new Size(100, 23);
            txtInputPath.TabIndex = 1;
            txtInputPath.TextChanged += textBox1_TextChanged;
            // 
            // txtOutputPath
            // 
            txtOutputPath.AllowDrop = true;
            txtOutputPath.Location = new Point(92, 84);
            txtOutputPath.Name = "txtOutputPath";
            txtOutputPath.Size = new Size(100, 23);
            txtOutputPath.TabIndex = 3;
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
            // btnBrowseInput
            // 
            btnBrowseInput.Location = new Point(198, 46);
            btnBrowseInput.Name = "btnBrowseInput";
            btnBrowseInput.Size = new Size(90, 23);
            btnBrowseInput.TabIndex = 9;
            btnBrowseInput.Text = "BrowseInput";
            btnBrowseInput.UseVisualStyleBackColor = true;
            btnBrowseInput.Click += btnBrowseInput_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(198, 84);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(90, 23);
            btnSelectFolder.TabIndex = 10;
            btnSelectFolder.Text = "SelectFolder";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += button2_Click;
            // 
            // comboResolution
            // 
            comboResolution.FormattingEnabled = true;
            comboResolution.Items.AddRange(new object[] { "4K (4096x2160)", "UHD (3840x2160)", "Quad HD (2560x1440)", "Full HD (1920x1080)", "HD (1280x720)", "SD NTSC Wide (854x480)", "SD NTSC (720x480)", "Custom" });
            comboResolution.Location = new Point(92, 122);
            comboResolution.Name = "comboResolution";
            comboResolution.Size = new Size(100, 23);
            comboResolution.TabIndex = 11;
            comboResolution.SelectedIndexChanged += comboResolution_SelectedIndexChanged;
            // 
            // txtCustomWidth
            // 
            txtCustomWidth.Location = new Point(198, 122);
            txtCustomWidth.Name = "txtCustomWidth";
            txtCustomWidth.Size = new Size(90, 23);
            txtCustomWidth.TabIndex = 12;
            // 
            // locker
            // 
            locker.Location = new Point(294, 122);
            locker.Name = "locker";
            locker.Size = new Size(22, 20);
            locker.TabIndex = 13;
            locker.Text = "button2";
            locker.UseVisualStyleBackColor = true;
            // 
            // txtCustomHeight
            // 
            txtCustomHeight.Location = new Point(322, 122);
            txtCustomHeight.Name = "txtCustomHeight";
            txtCustomHeight.Size = new Size(90, 23);
            txtCustomHeight.TabIndex = 14;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(12, 273);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 165);
            dataGridView1.TabIndex = 15;
            // 
            // Column1
            // 
            Column1.Frozen = true;
            Column1.HeaderText = "Source File\n\n";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 200;
            // 
            // Column2
            // 
            Column2.Frozen = true;
            Column2.HeaderText = "Preset";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.Frozen = true;
            Column3.HeaderText = "Output Folder\n\n";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            // 
            // Column4
            // 
            Column4.Frozen = true;
            Column4.HeaderText = "Output Filename (w/o extension)";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(txtCustomHeight);
            Controls.Add(locker);
            Controls.Add(txtCustomWidth);
            Controls.Add(comboResolution);
            Controls.Add(btnSelectFolder);
            Controls.Add(btnBrowseInput);
            Controls.Add(label4);
            Controls.Add(commandOutputTextBox);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(txtOutputPath);
            Controls.Add(label2);
            Controls.Add(txtInputPath);
            Controls.Add(label1);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtInputPath;
        private TextBox txtOutputPath;
        private Label label2;
        private Label label3;
        private Button button1;
        private TextBox commandOutputTextBox;
        private Label label4;
        private Button btnBrowseInput;
        private Button btnSelectFolder;
        private ComboBox comboResolution;
        private TextBox txtCustomWidth;
        private Button locker;
        private TextBox txtCustomHeight;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}
