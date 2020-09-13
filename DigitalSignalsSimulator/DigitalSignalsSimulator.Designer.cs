namespace DigitalSignalsSimulator
{
    partial class DigitalSignalsSimulator
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
            this.labelA = new System.Windows.Forms.Label();
            this.labelF = new System.Windows.Forms.Label();
            this.labelFi = new System.Windows.Forms.Label();
            this.textBoxA = new System.Windows.Forms.TextBox();
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.textBoxFi = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.comboBoxWave = new System.Windows.Forms.ComboBox();
            this.labelWaveType = new System.Windows.Forms.Label();
            this.labelD = new System.Windows.Forms.Label();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.buttonAddPoly = new System.Windows.Forms.Button();
            this.buttonClearPoly = new System.Windows.Forms.Button();
            this.buttonModulateAmplitude = new System.Windows.Forms.Button();
            this.buttonModulateFrequency = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelA
            // 
            this.labelA.AutoSize = true;
            this.labelA.Location = new System.Drawing.Point(6, 5);
            this.labelA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelA.Name = "labelA";
            this.labelA.Size = new System.Drawing.Size(59, 17);
            this.labelA.TabIndex = 0;
            this.labelA.Text = "Enter A:";
            // 
            // labelF
            // 
            this.labelF.AutoSize = true;
            this.labelF.Location = new System.Drawing.Point(6, 33);
            this.labelF.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelF.Name = "labelF";
            this.labelF.Size = new System.Drawing.Size(54, 17);
            this.labelF.TabIndex = 1;
            this.labelF.Text = "Enter f:";
            // 
            // labelFi
            // 
            this.labelFi.AutoSize = true;
            this.labelFi.Location = new System.Drawing.Point(6, 62);
            this.labelFi.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFi.Name = "labelFi";
            this.labelFi.Size = new System.Drawing.Size(61, 17);
            this.labelFi.TabIndex = 2;
            this.labelFi.Text = "Enter Fi:";
            // 
            // textBoxA
            // 
            this.textBoxA.Location = new System.Drawing.Point(82, 3);
            this.textBoxA.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxA.Name = "textBoxA";
            this.textBoxA.Size = new System.Drawing.Size(72, 22);
            this.textBoxA.TabIndex = 3;
            this.textBoxA.Text = "25";
            // 
            // textBoxF
            // 
            this.textBoxF.Location = new System.Drawing.Point(82, 31);
            this.textBoxF.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(72, 22);
            this.textBoxF.TabIndex = 4;
            this.textBoxF.Text = "100";
            // 
            // textBoxFi
            // 
            this.textBoxFi.Location = new System.Drawing.Point(82, 61);
            this.textBoxFi.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFi.Name = "textBoxFi";
            this.textBoxFi.Size = new System.Drawing.Size(72, 22);
            this.textBoxFi.TabIndex = 5;
            this.textBoxFi.Text = "3";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(163, 180);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(2);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(94, 42);
            this.buttonCreate.TabIndex = 6;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // comboBoxWave
            // 
            this.comboBoxWave.FormattingEnabled = true;
            this.comboBoxWave.Items.AddRange(new object[] {
            "Sive Wave",
            "Pulse Wave",
            "Triangle Wave",
            "Sawtooth Wave",
            "Noise"});
            this.comboBoxWave.Location = new System.Drawing.Point(280, 3);
            this.comboBoxWave.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxWave.Name = "comboBoxWave";
            this.comboBoxWave.Size = new System.Drawing.Size(174, 24);
            this.comboBoxWave.TabIndex = 7;
            // 
            // labelWaveType
            // 
            this.labelWaveType.AutoSize = true;
            this.labelWaveType.Location = new System.Drawing.Point(160, 5);
            this.labelWaveType.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelWaveType.Name = "labelWaveType";
            this.labelWaveType.Size = new System.Drawing.Size(104, 17);
            this.labelWaveType.TabIndex = 8;
            this.labelWaveType.Text = "Type of WAVE:";
            // 
            // labelD
            // 
            this.labelD.AutoSize = true;
            this.labelD.Location = new System.Drawing.Point(6, 92);
            this.labelD.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelD.Name = "labelD";
            this.labelD.Size = new System.Drawing.Size(60, 17);
            this.labelD.TabIndex = 11;
            this.labelD.Text = "Enter D:";
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(82, 89);
            this.textBoxD.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.Size = new System.Drawing.Size(72, 22);
            this.textBoxD.TabIndex = 12;
            this.textBoxD.Text = "0,5";
            // 
            // buttonAddPoly
            // 
            this.buttonAddPoly.Location = new System.Drawing.Point(280, 61);
            this.buttonAddPoly.Name = "buttonAddPoly";
            this.buttonAddPoly.Size = new System.Drawing.Size(174, 33);
            this.buttonAddPoly.TabIndex = 13;
            this.buttonAddPoly.Text = "Add to polyharmonics";
            this.buttonAddPoly.UseVisualStyleBackColor = true;
            this.buttonAddPoly.Click += new System.EventHandler(this.buttonAddPoly_Click);
            // 
            // buttonClearPoly
            // 
            this.buttonClearPoly.Location = new System.Drawing.Point(280, 100);
            this.buttonClearPoly.Name = "buttonClearPoly";
            this.buttonClearPoly.Size = new System.Drawing.Size(174, 37);
            this.buttonClearPoly.TabIndex = 14;
            this.buttonClearPoly.Text = "Clear polyharmonics";
            this.buttonClearPoly.UseVisualStyleBackColor = true;
            this.buttonClearPoly.Click += new System.EventHandler(this.buttonClearPoly_Click);
            // 
            // buttonModulateAmplitude
            // 
            this.buttonModulateAmplitude.Location = new System.Drawing.Point(9, 116);
            this.buttonModulateAmplitude.Name = "buttonModulateAmplitude";
            this.buttonModulateAmplitude.Size = new System.Drawing.Size(149, 29);
            this.buttonModulateAmplitude.TabIndex = 15;
            this.buttonModulateAmplitude.Text = "Modulate Amplitude";
            this.buttonModulateAmplitude.UseVisualStyleBackColor = true;
            // 
            // buttonModulateFrequency
            // 
            this.buttonModulateFrequency.Location = new System.Drawing.Point(9, 151);
            this.buttonModulateFrequency.Name = "buttonModulateFrequency";
            this.buttonModulateFrequency.Size = new System.Drawing.Size(149, 29);
            this.buttonModulateFrequency.TabIndex = 16;
            this.buttonModulateFrequency.Text = "Modulate Frequency";
            this.buttonModulateFrequency.UseVisualStyleBackColor = true;
            // 
            // DigitalSignalsSimulator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 233);
            this.Controls.Add(this.buttonModulateFrequency);
            this.Controls.Add(this.buttonModulateAmplitude);
            this.Controls.Add(this.buttonClearPoly);
            this.Controls.Add(this.buttonAddPoly);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.labelD);
            this.Controls.Add(this.labelWaveType);
            this.Controls.Add(this.comboBoxWave);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxFi);
            this.Controls.Add(this.textBoxF);
            this.Controls.Add(this.textBoxA);
            this.Controls.Add(this.labelFi);
            this.Controls.Add(this.labelF);
            this.Controls.Add(this.labelA);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(480, 280);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(480, 280);
            this.Name = "DigitalSignalsSimulator";
            this.Text = "Digital Signals Simulator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelA;
        private System.Windows.Forms.Label labelF;
        private System.Windows.Forms.Label labelFi;
        private System.Windows.Forms.TextBox textBoxA;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.TextBox textBoxFi;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ComboBox comboBoxWave;
        private System.Windows.Forms.Label labelWaveType;
        private System.Windows.Forms.Label labelD;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.Button buttonAddPoly;
        private System.Windows.Forms.Button buttonClearPoly;
        private System.Windows.Forms.Button buttonModulateAmplitude;
        private System.Windows.Forms.Button buttonModulateFrequency;
    }
}

