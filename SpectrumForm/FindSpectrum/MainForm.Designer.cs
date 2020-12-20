
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
            this.runButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rTextBox = new System.Windows.Forms.TextBox();
            this.orderTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.maxKTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.drawButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // runButton
            // 
            this.runButton.Location = new System.Drawing.Point(966, 532);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 23);
            this.runButton.TabIndex = 0;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.runButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1027, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "R";
            // 
            // rTextBox
            // 
            this.rTextBox.Location = new System.Drawing.Point(941, 41);
            this.rTextBox.Name = "rTextBox";
            this.rTextBox.Size = new System.Drawing.Size(100, 23);
            this.rTextBox.TabIndex = 2;
            this.rTextBox.Text = "4";
            this.rTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // orderTextBox
            // 
            this.orderTextBox.Location = new System.Drawing.Point(966, 503);
            this.orderTextBox.Name = "orderTextBox";
            this.orderTextBox.Size = new System.Drawing.Size(75, 23);
            this.orderTextBox.TabIndex = 4;
            this.orderTextBox.Text = "4";
            this.orderTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(997, 485);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "k order";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(941, 89);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 23);
            this.kTextBox.TabIndex = 6;
            this.kTextBox.Text = "4";
            this.kTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1027, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "k";
            // 
            // maxKTextBox
            // 
            this.maxKTextBox.Location = new System.Drawing.Point(941, 138);
            this.maxKTextBox.Name = "maxKTextBox";
            this.maxKTextBox.Size = new System.Drawing.Size(100, 23);
            this.maxKTextBox.TabIndex = 8;
            this.maxKTextBox.Text = "10";
            this.maxKTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(971, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "max k order";
            // 
            // drawButton
            // 
            this.drawButton.Location = new System.Drawing.Point(965, 562);
            this.drawButton.Name = "drawButton";
            this.drawButton.Size = new System.Drawing.Size(75, 23);
            this.drawButton.TabIndex = 9;
            this.drawButton.Text = "Draw";
            this.drawButton.UseVisualStyleBackColor = true;
            this.drawButton.Click += new System.EventHandler(this.drawButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 597);
            this.Controls.Add(this.drawButton);
            this.Controls.Add(this.maxKTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.kTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.orderTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.runButton);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox rTextBox;
        private System.Windows.Forms.TextBox orderTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox maxKTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button drawButton;
    }
}

