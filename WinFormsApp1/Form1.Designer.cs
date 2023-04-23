namespace WinFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            entry = new TextBox();
            title = new TextBox();
            synch = new Button();
            save = new Button();
            label1 = new Label();
            one = new Button();
            two = new Button();
            three = new Button();
            four = new Button();
            five = new Button();
            load = new Button();
            comboBox1 = new ComboBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // entry
            // 
            entry.BackColor = Color.FromArgb(251, 244, 215);
            entry.BorderStyle = BorderStyle.FixedSingle;
            entry.Location = new Point(24, 91);
            entry.Multiline = true;
            entry.Name = "entry";
            entry.Size = new Size(865, 545);
            entry.TabIndex = 0;
            entry.TextChanged += entry_TextChanged;
            // 
            // title
            // 
            title.BackColor = Color.FromArgb(251, 244, 215);
            title.BorderStyle = BorderStyle.FixedSingle;
            title.Location = new Point(24, 23);
            title.Multiline = true;
            title.Name = "title";
            title.Size = new Size(865, 48);
            title.TabIndex = 1;
            title.TextChanged += title_TextChanged;
            // 
            // synch
            // 
            synch.Location = new Point(1069, 12);
            synch.Name = "synch";
            synch.Size = new Size(94, 29);
            synch.TabIndex = 3;
            synch.Text = "Synch";
            synch.UseVisualStyleBackColor = true;
            synch.Click += synch_Click;
            // 
            // save
            // 
            save.Location = new Point(1069, 47);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 4;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(988, 364);
            label1.Name = "label1";
            label1.Size = new Size(114, 20);
            label1.TabIndex = 7;
            label1.Text = "Get the weather";
            label1.Click += label1_Click;
            // 
            // one
            // 
            one.BackColor = Color.Brown;
            one.Image = (Image)resources.GetObject("one.Image");
            one.Location = new Point(136, 647);
            one.Name = "one";
            one.Size = new Size(56, 49);
            one.TabIndex = 8;
            one.UseVisualStyleBackColor = false;
            one.Click += one_Click;
            // 
            // two
            // 
            two.BackColor = Color.FromArgb(192, 64, 0);
            two.BackgroundImage = (Image)resources.GetObject("two.BackgroundImage");
            two.BackgroundImageLayout = ImageLayout.Center;
            two.Location = new Point(293, 647);
            two.Name = "two";
            two.Size = new Size(55, 49);
            two.TabIndex = 9;
            two.UseVisualStyleBackColor = false;
            two.Click += two_Click;
            // 
            // three
            // 
            three.BackColor = Color.FromArgb(255, 128, 0);
            three.BackgroundImage = (Image)resources.GetObject("three.BackgroundImage");
            three.BackgroundImageLayout = ImageLayout.Center;
            three.Location = new Point(449, 647);
            three.Name = "three";
            three.Size = new Size(52, 49);
            three.TabIndex = 10;
            three.UseVisualStyleBackColor = false;
            three.Click += button3_Click;
            // 
            // four
            // 
            four.BackColor = Color.LawnGreen;
            four.BackgroundImage = (Image)resources.GetObject("four.BackgroundImage");
            four.BackgroundImageLayout = ImageLayout.Center;
            four.Location = new Point(585, 647);
            four.Name = "four";
            four.Size = new Size(51, 49);
            four.TabIndex = 11;
            four.UseVisualStyleBackColor = false;
            four.Click += four_Click;
            // 
            // five
            // 
            five.BackColor = Color.FromArgb(0, 192, 0);
            five.BackgroundImage = (Image)resources.GetObject("five.BackgroundImage");
            five.BackgroundImageLayout = ImageLayout.Center;
            five.Location = new Point(744, 647);
            five.Name = "five";
            five.Size = new Size(54, 49);
            five.TabIndex = 12;
            five.UseVisualStyleBackColor = false;
            five.Click += five_Click;
            // 
            // load
            // 
            load.Location = new Point(1069, 82);
            load.Name = "load";
            load.Size = new Size(94, 29);
            load.TabIndex = 13;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(970, 387);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 14;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Center;
            pictureBox1.Location = new Point(950, 186);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(183, 175);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(206, 214, 177);
            ClientSize = new Size(1180, 703);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox1);
            Controls.Add(load);
            Controls.Add(five);
            Controls.Add(four);
            Controls.Add(three);
            Controls.Add(two);
            Controls.Add(one);
            Controls.Add(label1);
            Controls.Add(save);
            Controls.Add(synch);
            Controls.Add(title);
            Controls.Add(entry);
            Name = "Form1";
            Text = "UltimateNote";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox entry;
        private TextBox title;
        private Button synch;
        private Button save;
        private Label label1;
        private Button one;
        private Button two;
        private Button three;
        private Button four;
        private Button five;
        private Button load;
        private ComboBox comboBox1;
        private PictureBox pictureBox1;
    }
}