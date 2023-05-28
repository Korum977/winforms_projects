namespace PR8
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Scroll_red = new System.Windows.Forms.HScrollBar();
            this.Scroll_green = new System.Windows.Forms.HScrollBar();
            this.Scroll_blue = new System.Windows.Forms.HScrollBar();
            this.numeric_red = new System.Windows.Forms.NumericUpDown();
            this.numeric_green = new System.Windows.Forms.NumericUpDown();
            this.numeric_blue = new System.Windows.Forms.NumericUpDown();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_red)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_green)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_blue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 173);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(129, 173);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(374, 173);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Other colors";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Green";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Blue";
            // 
            // Scroll_red
            // 
            this.Scroll_red.Location = new System.Drawing.Point(69, 35);
            this.Scroll_red.Name = "Scroll_red";
            this.Scroll_red.Size = new System.Drawing.Size(200, 13);
            this.Scroll_red.TabIndex = 6;
            this.Scroll_red.Scroll += new System.Windows.Forms.ScrollEventHandler(this.Scroll_red_Scroll);
            this.Scroll_red.ValueChanged += new System.EventHandler(this.Scroll_red_ValueChanged);
            // 
            // Scroll_green
            // 
            this.Scroll_green.Location = new System.Drawing.Point(69, 68);
            this.Scroll_green.Name = "Scroll_green";
            this.Scroll_green.Size = new System.Drawing.Size(200, 13);
            this.Scroll_green.TabIndex = 6;
            this.Scroll_green.ValueChanged += new System.EventHandler(this.Scroll_green_ValueChanged);
            // 
            // Scroll_blue
            // 
            this.Scroll_blue.Location = new System.Drawing.Point(69, 98);
            this.Scroll_blue.Name = "Scroll_blue";
            this.Scroll_blue.Size = new System.Drawing.Size(200, 13);
            this.Scroll_blue.TabIndex = 6;
            this.Scroll_blue.ValueChanged += new System.EventHandler(this.Scroll_blue_ValueChanged);
            // 
            // numeric_red
            // 
            this.numeric_red.Location = new System.Drawing.Point(294, 39);
            this.numeric_red.Name = "numeric_red";
            this.numeric_red.Size = new System.Drawing.Size(61, 20);
            this.numeric_red.TabIndex = 7;
            this.numeric_red.ValueChanged += new System.EventHandler(this.numeric_red_ValueChanged);
            // 
            // numeric_green
            // 
            this.numeric_green.Location = new System.Drawing.Point(294, 68);
            this.numeric_green.Name = "numeric_green";
            this.numeric_green.Size = new System.Drawing.Size(61, 20);
            this.numeric_green.TabIndex = 8;
            this.numeric_green.ValueChanged += new System.EventHandler(this.numeric_green_ValueChanged);
            // 
            // numeric_blue
            // 
            this.numeric_blue.Location = new System.Drawing.Point(294, 96);
            this.numeric_blue.Name = "numeric_blue";
            this.numeric_blue.Size = new System.Drawing.Size(61, 20);
            this.numeric_blue.TabIndex = 8;
            this.numeric_blue.ValueChanged += new System.EventHandler(this.numeric_blue_ValueChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(374, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 77);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 208);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.numeric_blue);
            this.Controls.Add(this.numeric_green);
            this.Controls.Add(this.numeric_red);
            this.Controls.Add(this.Scroll_blue);
            this.Controls.Add(this.Scroll_green);
            this.Controls.Add(this.Scroll_red);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Colors";
            ((System.ComponentModel.ISupportInitialize)(this.numeric_red)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_green)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_blue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.HScrollBar Scroll_red;
        private System.Windows.Forms.HScrollBar Scroll_green;
        private System.Windows.Forms.HScrollBar Scroll_blue;
        private System.Windows.Forms.NumericUpDown numeric_red;
        private System.Windows.Forms.NumericUpDown numeric_green;
        private System.Windows.Forms.NumericUpDown numeric_blue;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}