
namespace FindSpectrum
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
            this.runStaticButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rTextBox = new System.Windows.Forms.TextBox();
            this.orderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxKTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.stepTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.drawEvolutionButton = new System.Windows.Forms.Button();
            this.tMaxTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.runEvolutionButton = new System.Windows.Forms.Button();
            this.tTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runStaticButton
            // 
            this.runStaticButton.Location = new System.Drawing.Point(976, 488);
            this.runStaticButton.Name = "runStaticButton";
            this.runStaticButton.Size = new System.Drawing.Size(75, 23);
            this.runStaticButton.TabIndex = 0;
            this.runStaticButton.Text = "Run Static";
            this.runStaticButton.UseVisualStyleBackColor = true;
            this.runStaticButton.Click += new System.EventHandler(this.runStaticButtonClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1126, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "R";
            // 
            // rTextBox
            // 
            this.rTextBox.Location = new System.Drawing.Point(1041, 42);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(100, 23);
            this.rTextBox.TabIndex = 2;
            this.rTextBox.Text = "4";
            this.rTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // orderTextBox
            // 
            this.orderTextBox.Location = new System.Drawing.Point(976, 459);
            this.orderTextBox.Name = "orderTextBox";
            this.orderTextBox.Size = new System.Drawing.Size(75, 23);
            this.orderTextBox.TabIndex = 4;
            this.orderTextBox.Text = "4";
            this.orderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1007, 441);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "k order";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(1041, 90);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 23);
            this.kTextBox.TabIndex = 6;
            this.kTextBox.Text = "4";
            this.kTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1126, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "k";
            // 
            // maxKTextBox
            // 
            this.maxKTextBox.Location = new System.Drawing.Point(1041, 139);
            this.maxKTextBox.Name = "maxKTextBox";
            this.maxKTextBox.Size = new System.Drawing.Size(100, 23);
            this.maxKTextBox.TabIndex = 8;
            this.maxKTextBox.Text = "10";
            this.maxKTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1071, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "max k order";
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(976, 518);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 9;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // stepTextBox
            // 
            this.stepTextBox.Location = new System.Drawing.Point(1041, 229);
            this.stepTextBox.Name = "stepTextBox";
            this.stepTextBox.Size = new System.Drawing.Size(100, 23);
            this.stepTextBox.TabIndex = 11;
            this.stepTextBox.Text = "0,01";
            this.stepTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1111, 211);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 10;
            this.label5.Text = "step";
            // 
            // drawEvolutionButton
            // 
            this.drawEvolutionButton.Location = new System.Drawing.Point(1066, 518);
            this.drawEvolutionButton.Name = "drawEvolutionButton";
            this.drawEvolutionButton.Size = new System.Drawing.Size(74, 23);
            this.drawEvolutionButton.TabIndex = 15;
            this.drawEvolutionButton.Text = "Draw";
            this.drawEvolutionButton.UseVisualStyleBackColor = true;
            this.drawEvolutionButton.Click += new System.EventHandler(this.drawEvolutionButton_Click);
            // 
            // tMaxTextBox
            // 
            this.tMaxTextBox.Location = new System.Drawing.Point(1041, 185);
            this.tMaxTextBox.Name = "tMaxTextBox";
            this.tMaxTextBox.Size = new System.Drawing.Size(100, 23);
            this.tMaxTextBox.TabIndex = 14;
            this.tMaxTextBox.Text = "10";
            this.tMaxTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1104, 167);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "t max";
            // 
            // runEvolutionButton
            // 
            this.runEvolutionButton.Location = new System.Drawing.Point(1066, 488);
            this.runEvolutionButton.Name = "runEvolutionButton";
            this.runEvolutionButton.Size = new System.Drawing.Size(75, 23);
            this.runEvolutionButton.TabIndex = 12;
            this.runEvolutionButton.Text = "Run";
            this.runEvolutionButton.UseVisualStyleBackColor = true;
            this.runEvolutionButton.Click += new System.EventHandler(this.runEvolutionButtonClick);
            // 
            // tTextBox
            // 
            this.tTextBox.Location = new System.Drawing.Point(1066, 459);
            this.tTextBox.Name = "tTextBox";
            this.tTextBox.Size = new System.Drawing.Size(74, 23);
            this.tTextBox.TabIndex = 17;
            this.tTextBox.Text = "4";
            this.tTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1128, 442);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "t";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(1066, 563);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 23);
            this.refreshButton.TabIndex = 18;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 597);
            this.Controls.Add(this.refreshButton);
            this.Controls.Add(this.tTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.drawEvolutionButton);
            this.Controls.Add(this.tMaxTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.runEvolutionButton);
            this.Controls.Add(this.stepTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.maxKTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runStaticButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button runStaticButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rTextBox;
        private System.Windows.Forms.TextBox orderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxKTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button drawButton;
        private System.Windows.Forms.TextBox stepTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button drawEvolutionButton;
        private System.Windows.Forms.TextBox tMaxTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button runEvolutionButton;
        private System.Windows.Forms.TextBox tTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button refreshButton;
    }
}

