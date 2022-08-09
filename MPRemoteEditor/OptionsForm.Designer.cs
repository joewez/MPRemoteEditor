
namespace MPRemoteEditor
{
    partial class OptionsForm
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabComm = new System.Windows.Forms.TabPage();
            this.tabREPL = new System.Windows.Forms.TabPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRunPutty = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rdoPutty = new System.Windows.Forms.RadioButton();
            this.tabMiscellaneous = new System.Windows.Forms.TabPage();
            this.findfilePutty = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.tabOptions.SuspendLayout();
            this.tabREPL.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(113, 220);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Save";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(194, 220);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabComm);
            this.tabOptions.Controls.Add(this.tabREPL);
            this.tabOptions.Controls.Add(this.tabMiscellaneous);
            this.tabOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabOptions.Location = new System.Drawing.Point(0, 0);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(383, 214);
            this.tabOptions.TabIndex = 2;
            // 
            // tabComm
            // 
            this.tabComm.Location = new System.Drawing.Point(4, 22);
            this.tabComm.Name = "tabComm";
            this.tabComm.Padding = new System.Windows.Forms.Padding(3);
            this.tabComm.Size = new System.Drawing.Size(375, 188);
            this.tabComm.TabIndex = 0;
            this.tabComm.Text = "Communcations";
            this.tabComm.UseVisualStyleBackColor = true;
            // 
            // tabREPL
            // 
            this.tabREPL.Controls.Add(this.button1);
            this.tabREPL.Controls.Add(this.radioButton2);
            this.tabREPL.Controls.Add(this.textBox4);
            this.tabREPL.Controls.Add(this.label3);
            this.tabREPL.Controls.Add(this.txtRunPutty);
            this.tabREPL.Controls.Add(this.label2);
            this.tabREPL.Controls.Add(this.textBox1);
            this.tabREPL.Controls.Add(this.label1);
            this.tabREPL.Controls.Add(this.radioButton1);
            this.tabREPL.Controls.Add(this.rdoPutty);
            this.tabREPL.Location = new System.Drawing.Point(4, 22);
            this.tabREPL.Name = "tabREPL";
            this.tabREPL.Padding = new System.Windows.Forms.Padding(3);
            this.tabREPL.Size = new System.Drawing.Size(375, 188);
            this.tabREPL.TabIndex = 1;
            this.tabREPL.Text = "REPL";
            this.tabREPL.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton2.Location = new System.Drawing.Point(17, 148);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(152, 17);
            this.radioButton2.TabIndex = 17;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Internal (Experimental)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(118, 117);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(224, 20);
            this.textBox4.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 120);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Run Command:";
            // 
            // txtRunPutty
            // 
            this.txtRunPutty.Location = new System.Drawing.Point(118, 38);
            this.txtRunPutty.Name = "txtRunPutty";
            this.txtRunPutty.Size = new System.Drawing.Size(224, 20);
            this.txtRunPutty.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Run Command:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(118, 66);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(224, 20);
            this.textBox1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Session Name:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.Location = new System.Drawing.Point(17, 93);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(79, 17);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "TeraTerm";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rdoPutty
            // 
            this.rdoPutty.AutoSize = true;
            this.rdoPutty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoPutty.Location = new System.Drawing.Point(17, 16);
            this.rdoPutty.Name = "rdoPutty";
            this.rdoPutty.Size = new System.Drawing.Size(62, 17);
            this.rdoPutty.TabIndex = 9;
            this.rdoPutty.TabStop = true;
            this.rdoPutty.Text = "PuTTy";
            this.rdoPutty.UseVisualStyleBackColor = true;
            // 
            // tabMiscellaneous
            // 
            this.tabMiscellaneous.Location = new System.Drawing.Point(4, 22);
            this.tabMiscellaneous.Name = "tabMiscellaneous";
            this.tabMiscellaneous.Padding = new System.Windows.Forms.Padding(3);
            this.tabMiscellaneous.Size = new System.Drawing.Size(375, 188);
            this.tabMiscellaneous.TabIndex = 2;
            this.tabMiscellaneous.Text = "Miscellaneous";
            this.tabMiscellaneous.UseVisualStyleBackColor = true;
            // 
            // findfilePutty
            // 
            this.findfilePutty.Title = "Identify command file that invokes PuTTy";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(344, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(25, 21);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 251);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OptionsForm";
            this.Text = "Options";
            this.tabOptions.ResumeLayout(false);
            this.tabREPL.ResumeLayout(false);
            this.tabREPL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabComm;
        private System.Windows.Forms.TabPage tabREPL;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRunPutty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rdoPutty;
        private System.Windows.Forms.TabPage tabMiscellaneous;
        private System.Windows.Forms.OpenFileDialog findfilePutty;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button1;
    }
}