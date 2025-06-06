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
            label3 = new Label();
            button1 = new Button();
            commandOutputTextBox = new TextBox();
            label4 = new Label();
            Add_Source = new Button();
            Change_Output_Path = new Button();
            comboResolution = new ComboBox();
            txtCustomWidth = new TextBox();
            locker = new Button();
            txtCustomHeight = new TextBox();
            dataGridView1 = new DataGridView();
            Go = new Button();
            Start_Conversion = new DataGridViewTextBoxColumn();
            Info = new DataGridViewTextBoxColumn();
            Preset_Info = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
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
            // Add_Source
            // 
            Add_Source.Location = new Point(102, 45);
            Add_Source.Name = "Add_Source";
            Add_Source.Size = new Size(90, 23);
            Add_Source.TabIndex = 9;
            Add_Source.Text = "Add Source(s)";
            Add_Source.UseVisualStyleBackColor = true;
            Add_Source.Click += btnBrowseInput_Click;
            // 
            // Change_Output_Path
            // 
            Change_Output_Path.Location = new Point(412, 45);
            Change_Output_Path.Name = "Change_Output_Path";
            Change_Output_Path.Size = new Size(139, 23);
            Change_Output_Path.TabIndex = 10;
            Change_Output_Path.Text = "Change_Output_Path";
            Change_Output_Path.UseVisualStyleBackColor = true;
            Change_Output_Path.Click += button2_Click;
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
            locker.Size = new Size(22, 23);
            locker.TabIndex = 13;
            locker.Text = "🔒";
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Start_Conversion, Info, Preset_Info, Column1, Column2, Column3, Column4 });
            dataGridView1.Location = new Point(12, 303);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 10;
            dataGridView1.Size = new Size(776, 135);
            dataGridView1.TabIndex = 15;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Go
            // 
            Go.Location = new Point(686, 223);
            Go.Name = "Go";
            Go.Size = new Size(75, 23);
            Go.TabIndex = 16;
            Go.Text = "Go";
            Go.UseVisualStyleBackColor = true;
            Go.Click += button2_Click_1;
            // 
            // Start_Conversion
            // 
            Start_Conversion.FillWeight = 40F;
            Start_Conversion.Frozen = true;
            Start_Conversion.HeaderText = "";
            Start_Conversion.Name = "Start_Conversion";
            Start_Conversion.ReadOnly = true;
            Start_Conversion.Width = 30;
            // 
            // Info
            // 
            Info.FillWeight = 40F;
            Info.Frozen = true;
            Info.HeaderText = "";
            Info.Name = "Info";
            Info.ReadOnly = true;
            Info.Width = 30;
            // 
            // Preset_Info
            // 
            Preset_Info.FillWeight = 40F;
            Preset_Info.Frozen = true;
            Preset_Info.HeaderText = "";
            Preset_Info.Name = "Preset_Info";
            Preset_Info.ReadOnly = true;
            Preset_Info.Width = 30;
            // 
            // Column1
            // 
            Column1.FillWeight = 40F;
            Column1.Frozen = true;
            Column1.HeaderText = "Source File\n\n";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Width = 150;
            // 
            // Column2
            // 
            Column2.FillWeight = 40F;
            Column2.Frozen = true;
            Column2.HeaderText = "Preset";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 40F;
            Column3.Frozen = true;
            Column3.HeaderText = "Output Folder\n\n";
            Column3.Name = "Column3";
            Column3.ReadOnly = true;
            Column3.Width = 150;
            // 
            // Column4
            // 
            Column4.FillWeight = 40F;
            Column4.Frozen = true;
            Column4.HeaderText = "Output Filename (w/o extension)";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            Column4.Width = 250;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Go);
            Controls.Add(dataGridView1);
            Controls.Add(txtCustomHeight);
            Controls.Add(locker);
            Controls.Add(txtCustomWidth);
            Controls.Add(comboResolution);
            Controls.Add(Change_Output_Path);
            Controls.Add(Add_Source);
            Controls.Add(label4);
            Controls.Add(commandOutputTextBox);
            Controls.Add(button1);
            Controls.Add(label3);
            Name = "MainForm";
            Text = "Form1";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        


        #endregion
        private Label label3;
        private Button button1;
        private TextBox commandOutputTextBox;
        private Label label4;
        private Button Add_Source;
        private Button Change_Output_Path;
        private ComboBox comboResolution;
        private TextBox txtCustomWidth;
        private Button locker;
        private TextBox txtCustomHeight;
        private DataGridView dataGridView1;
        private Button Go;
        private DataGridViewTextBoxColumn Start_Conversion;
        private DataGridViewTextBoxColumn Info;
        private DataGridViewTextBoxColumn Preset_Info;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
    }
}
