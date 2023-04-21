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
            entry = new TextBox();
            title = new TextBox();
            synch = new Button();
            save = new Button();
            test = new Button();
            label1 = new Label();
            one = new Button();
            two = new Button();
            three = new Button();
            four = new Button();
            five = new Button();
            load = new Button();
            SuspendLayout();
            // 
            // entry
            // 
            entry.BackColor = Color.FromArgb(251, 244, 215);
            entry.BorderStyle = BorderStyle.FixedSingle;
            entry.Location = new Point(24, 91);
            entry.Multiline = true;
            entry.Name = "entry";
            entry.Size = new Size(547, 595);
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
            title.Size = new Size(547, 48);
            title.TabIndex = 1;
            title.TextChanged += title_TextChanged;
            // 
            // synch
            // 
            synch.Location = new Point(1094, 12);
            synch.Name = "synch";
            synch.Size = new Size(94, 29);
            synch.TabIndex = 3;
            synch.Text = "Synch";
            synch.UseVisualStyleBackColor = true;
            synch.Click += synch_Click;
            // 
            // save
            // 
            save.Location = new Point(1094, 47);
            save.Name = "save";
            save.Size = new Size(94, 29);
            save.TabIndex = 4;
            save.Text = "Save";
            save.UseVisualStyleBackColor = true;
            save.Click += save_Click;
            // 
            // test
            // 
            test.Location = new Point(1049, 189);
            test.Name = "test";
            test.Size = new Size(94, 29);
            test.TabIndex = 6;
            test.Text = "button1";
            test.UseVisualStyleBackColor = true;
            test.Click += test_ClickAsync;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(956, 189);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 7;
            label1.Text = "label1";
            label1.Click += label1_Click;
            // 
            // one
            // 
            one.Location = new Point(602, 657);
            one.Name = "one";
            one.Size = new Size(94, 29);
            one.TabIndex = 8;
            one.Text = "button1";
            one.UseVisualStyleBackColor = true;
            one.Click += one_Click;
            // 
            // two
            // 
            two.Location = new Point(719, 657);
            two.Name = "two";
            two.Size = new Size(94, 29);
            two.TabIndex = 9;
            two.Text = "button2";
            two.UseVisualStyleBackColor = true;
            two.Click += two_Click;
            // 
            // three
            // 
            three.Location = new Point(847, 657);
            three.Name = "three";
            three.Size = new Size(94, 29);
            three.TabIndex = 10;
            three.Text = "button3";
            three.UseVisualStyleBackColor = true;
            three.Click += button3_Click;
            // 
            // four
            // 
            four.Location = new Point(970, 657);
            four.Name = "four";
            four.Size = new Size(94, 29);
            four.TabIndex = 11;
            four.Text = "button4";
            four.UseVisualStyleBackColor = true;
            four.Click += four_Click;
            // 
            // five
            // 
            five.Location = new Point(1084, 657);
            five.Name = "five";
            five.Size = new Size(94, 29);
            five.TabIndex = 12;
            five.Text = "button5";
            five.UseVisualStyleBackColor = true;
            five.Click += five_Click;
            // 
            // load
            // 
            load.Location = new Point(1094, 82);
            load.Name = "load";
            load.Size = new Size(94, 29);
            load.TabIndex = 13;
            load.Text = "Load";
            load.UseVisualStyleBackColor = true;
            load.Click += load_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(206, 214, 177);
            ClientSize = new Size(1200, 698);
            Controls.Add(load);
            Controls.Add(five);
            Controls.Add(four);
            Controls.Add(three);
            Controls.Add(two);
            Controls.Add(one);
            Controls.Add(label1);
            Controls.Add(test);
            Controls.Add(save);
            Controls.Add(synch);
            Controls.Add(title);
            Controls.Add(entry);
            Name = "Form1";
            Text = "UltimateNote";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox entry;
        private TextBox title;
        private Button synch;
        private Button save;
        private Button test;
        private Label label1;
        private Button one;
        private Button two;
        private Button three;
        private Button four;
        private Button five;
        private Button load;
    }
}