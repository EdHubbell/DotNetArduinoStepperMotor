namespace DotNetArduinoStepperMotor
{
    partial class Form1
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
            this.numUpDown = new System.Windows.Forms.NumericUpDown();
            this.btnRotateCW = new System.Windows.Forms.Button();
            this.btnRotateCCW = new System.Windows.Forms.Button();
            this.btnFindAttachedArduinos = new System.Windows.Forms.Button();
            this.cbArduinoAddress = new System.Windows.Forms.ComboBox();
            this.lblArduinoCOMPort = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // numUpDown
            // 
            this.numUpDown.Location = new System.Drawing.Point(135, 245);
            this.numUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.numUpDown.Name = "numUpDown";
            this.numUpDown.Size = new System.Drawing.Size(102, 20);
            this.numUpDown.TabIndex = 0;
            this.numUpDown.ValueChanged += new System.EventHandler(this.numUpDown_ValueChanged);
            // 
            // btnRotateCW
            // 
            this.btnRotateCW.Location = new System.Drawing.Point(431, 83);
            this.btnRotateCW.Name = "btnRotateCW";
            this.btnRotateCW.Size = new System.Drawing.Size(75, 23);
            this.btnRotateCW.TabIndex = 1;
            this.btnRotateCW.Text = "Rotate CW";
            this.btnRotateCW.UseVisualStyleBackColor = true;
            this.btnRotateCW.Click += new System.EventHandler(this.btnRotateCW_Click);
            // 
            // btnRotateCCW
            // 
            this.btnRotateCCW.Location = new System.Drawing.Point(431, 112);
            this.btnRotateCCW.Name = "btnRotateCCW";
            this.btnRotateCCW.Size = new System.Drawing.Size(75, 23);
            this.btnRotateCCW.TabIndex = 2;
            this.btnRotateCCW.Text = "Rotate CCW";
            this.btnRotateCCW.UseVisualStyleBackColor = true;
            this.btnRotateCCW.Click += new System.EventHandler(this.btnRotateCCW_Click);
            // 
            // btnFindAttachedArduinos
            // 
            this.btnFindAttachedArduinos.Location = new System.Drawing.Point(12, 13);
            this.btnFindAttachedArduinos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFindAttachedArduinos.Name = "btnFindAttachedArduinos";
            this.btnFindAttachedArduinos.Size = new System.Drawing.Size(244, 40);
            this.btnFindAttachedArduinos.TabIndex = 23;
            this.btnFindAttachedArduinos.Text = "Find Attached Arduinos";
            this.btnFindAttachedArduinos.UseVisualStyleBackColor = true;
            this.btnFindAttachedArduinos.Click += new System.EventHandler(this.btnFindAttachedArduinos_Click);
            // 
            // cbArduinoAddress
            // 
            this.cbArduinoAddress.FormattingEnabled = true;
            this.cbArduinoAddress.Location = new System.Drawing.Point(15, 103);
            this.cbArduinoAddress.Name = "cbArduinoAddress";
            this.cbArduinoAddress.Size = new System.Drawing.Size(244, 21);
            this.cbArduinoAddress.TabIndex = 22;
            this.cbArduinoAddress.SelectedIndexChanged += new System.EventHandler(this.cbArduinoAddress_SelectedIndexChanged);
            // 
            // lblArduinoCOMPort
            // 
            this.lblArduinoCOMPort.AutoSize = true;
            this.lblArduinoCOMPort.Location = new System.Drawing.Point(12, 83);
            this.lblArduinoCOMPort.Name = "lblArduinoCOMPort";
            this.lblArduinoCOMPort.Size = new System.Drawing.Size(95, 13);
            this.lblArduinoCOMPort.TabIndex = 21;
            this.lblArduinoCOMPort.Text = "Arduino COM Port:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnFindAttachedArduinos);
            this.Controls.Add(this.cbArduinoAddress);
            this.Controls.Add(this.lblArduinoCOMPort);
            this.Controls.Add(this.btnRotateCCW);
            this.Controls.Add(this.btnRotateCW);
            this.Controls.Add(this.numUpDown);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numUpDown;
        private System.Windows.Forms.Button btnRotateCW;
        private System.Windows.Forms.Button btnRotateCCW;
        private System.Windows.Forms.Button btnFindAttachedArduinos;
        private System.Windows.Forms.ComboBox cbArduinoAddress;
        private System.Windows.Forms.Label lblArduinoCOMPort;
    }
}

