namespace LillyVKR
{
    partial class PatientsViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatientsViewForm));
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvIllness = new System.Windows.Forms.DataGridView();
            this.dgvSymptoms = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIllness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymptoms)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(237, 69);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(462, 74);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvIllness
            // 
            this.dgvIllness.AllowUserToAddRows = false;
            this.dgvIllness.AllowUserToDeleteRows = false;
            this.dgvIllness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIllness.Location = new System.Drawing.Point(32, 148);
            this.dgvIllness.Name = "dgvIllness";
            this.dgvIllness.ReadOnly = true;
            this.dgvIllness.Size = new System.Drawing.Size(311, 203);
            this.dgvIllness.TabIndex = 2;
            // 
            // dgvSymptoms
            // 
            this.dgvSymptoms.AllowUserToAddRows = false;
            this.dgvSymptoms.AllowUserToDeleteRows = false;
            this.dgvSymptoms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSymptoms.Location = new System.Drawing.Point(437, 148);
            this.dgvSymptoms.Name = "dgvSymptoms";
            this.dgvSymptoms.ReadOnly = true;
            this.dgvSymptoms.Size = new System.Drawing.Size(327, 213);
            this.dgvSymptoms.TabIndex = 3;
            // 
            // PatientsViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 450);
            this.Controls.Add(this.dgvSymptoms);
            this.Controls.Add(this.dgvIllness);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatientsViewForm";
            this.Text = "PatientsViewForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIllness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSymptoms)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dgvIllness;
        private System.Windows.Forms.DataGridView dgvSymptoms;
    }
}