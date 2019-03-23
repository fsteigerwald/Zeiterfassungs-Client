namespace Zeiterfassungs_Client
{
    partial class FrmMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProgInfo = new System.Windows.Forms.Label();
            this.listBoxNamen = new System.Windows.Forms.ListBox();
            this.cmdExit = new System.Windows.Forms.Button();
            this.lblPasswordInfo = new System.Windows.Forms.Label();
            this.txtPasswordBox = new System.Windows.Forms.TextBox();
            this.cmdArrive = new System.Windows.Forms.Button();
            this.cmdLeave = new System.Windows.Forms.Button();
            this.txtInfoToSelection = new System.Windows.Forms.TextBox();
            this.lblInfo = new System.Windows.Forms.Label();
            this.cmdReadData = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cmdRaedSeq = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.cmdInsertRecord = new System.Windows.Forms.Button();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmdWriteTable = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProgInfo
            // 
            this.lblProgInfo.AutoSize = true;
            this.lblProgInfo.Location = new System.Drawing.Point(12, 9);
            this.lblProgInfo.Name = "lblProgInfo";
            this.lblProgInfo.Size = new System.Drawing.Size(197, 13);
            this.lblProgInfo.TabIndex = 0;
            this.lblProgInfo.Text = "Bitte zunächst einen Namen auswählen ";
            // 
            // listBoxNamen
            // 
            this.listBoxNamen.FormattingEnabled = true;
            this.listBoxNamen.Location = new System.Drawing.Point(15, 25);
            this.listBoxNamen.Name = "listBoxNamen";
            this.listBoxNamen.Size = new System.Drawing.Size(194, 95);
            this.listBoxNamen.TabIndex = 1;
            this.listBoxNamen.SelectedIndexChanged += new System.EventHandler(this.listBoxNamen_SelectedIndexChanged);
            // 
            // cmdExit
            // 
            this.cmdExit.Location = new System.Drawing.Point(273, 173);
            this.cmdExit.Name = "cmdExit";
            this.cmdExit.Size = new System.Drawing.Size(211, 23);
            this.cmdExit.TabIndex = 2;
            this.cmdExit.Text = "Speichern und Programm beenden";
            this.cmdExit.UseVisualStyleBackColor = true;
            this.cmdExit.Click += new System.EventHandler(this.cmdExit_Click);
            // 
            // lblPasswordInfo
            // 
            this.lblPasswordInfo.AutoSize = true;
            this.lblPasswordInfo.Location = new System.Drawing.Point(12, 123);
            this.lblPasswordInfo.Name = "lblPasswordInfo";
            this.lblPasswordInfo.Size = new System.Drawing.Size(185, 13);
            this.lblPasswordInfo.TabIndex = 3;
            this.lblPasswordInfo.Text = "Bitte jetzt hier das Kennwort eingeben";
            this.lblPasswordInfo.Visible = false;
            // 
            // txtPasswordBox
            // 
            this.txtPasswordBox.Location = new System.Drawing.Point(15, 139);
            this.txtPasswordBox.Name = "txtPasswordBox";
            this.txtPasswordBox.PasswordChar = '*';
            this.txtPasswordBox.Size = new System.Drawing.Size(194, 20);
            this.txtPasswordBox.TabIndex = 4;
            this.txtPasswordBox.Visible = false;
            this.txtPasswordBox.TextChanged += new System.EventHandler(this.txtPasswordBox_TextChanged);
            // 
            // cmdArrive
            // 
            this.cmdArrive.Location = new System.Drawing.Point(232, 25);
            this.cmdArrive.Name = "cmdArrive";
            this.cmdArrive.Size = new System.Drawing.Size(118, 37);
            this.cmdArrive.TabIndex = 5;
            this.cmdArrive.Text = "Kommen";
            this.cmdArrive.UseVisualStyleBackColor = true;
            this.cmdArrive.Visible = false;
            this.cmdArrive.Click += new System.EventHandler(this.cmdArrive_Click);
            // 
            // cmdLeave
            // 
            this.cmdLeave.Location = new System.Drawing.Point(366, 25);
            this.cmdLeave.Name = "cmdLeave";
            this.cmdLeave.Size = new System.Drawing.Size(118, 37);
            this.cmdLeave.TabIndex = 6;
            this.cmdLeave.Text = "Gehen";
            this.cmdLeave.UseVisualStyleBackColor = true;
            this.cmdLeave.Visible = false;
            this.cmdLeave.Click += new System.EventHandler(this.cmdLeave_Click);
            // 
            // txtInfoToSelection
            // 
            this.txtInfoToSelection.Enabled = false;
            this.txtInfoToSelection.Location = new System.Drawing.Point(232, 93);
            this.txtInfoToSelection.Multiline = true;
            this.txtInfoToSelection.Name = "txtInfoToSelection";
            this.txtInfoToSelection.Size = new System.Drawing.Size(252, 66);
            this.txtInfoToSelection.TabIndex = 7;
            this.txtInfoToSelection.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(229, 77);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(261, 13);
            this.lblInfo.TabIndex = 8;
            this.lblInfo.Text = "Hier können erklärende Hinweise eingegeben werden";
            this.lblInfo.Visible = false;
            // 
            // cmdReadData
            // 
            this.cmdReadData.Location = new System.Drawing.Point(15, 221);
            this.cmdReadData.Name = "cmdReadData";
            this.cmdReadData.Size = new System.Drawing.Size(103, 23);
            this.cmdReadData.TabIndex = 9;
            this.cmdReadData.Text = "read data Tabel";
            this.cmdReadData.UseVisualStyleBackColor = true;
            this.cmdReadData.Click += new System.EventHandler(this.cmdReadData_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 250);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 10;
            // 
            // cmdRaedSeq
            // 
            this.cmdRaedSeq.Location = new System.Drawing.Point(360, 225);
            this.cmdRaedSeq.Name = "cmdRaedSeq";
            this.cmdRaedSeq.Size = new System.Drawing.Size(124, 23);
            this.cmdRaedSeq.TabIndex = 11;
            this.cmdRaedSeq.Text = "Read Sequentiell";
            this.cmdRaedSeq.UseVisualStyleBackColor = true;
            this.cmdRaedSeq.Click += new System.EventHandler(this.cmdRaedSeq_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUsername);
            this.groupBox1.Controls.Add(this.cmdInsertRecord);
            this.groupBox1.Controls.Add(this.txtPassWord);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 415);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(240, 107);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Record anfügen";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(70, 22);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(100, 20);
            this.txtUsername.TabIndex = 17;
            // 
            // cmdInsertRecord
            // 
            this.cmdInsertRecord.Location = new System.Drawing.Point(159, 74);
            this.cmdInsertRecord.Name = "cmdInsertRecord";
            this.cmdInsertRecord.Size = new System.Drawing.Size(75, 23);
            this.cmdInsertRecord.TabIndex = 13;
            this.cmdInsertRecord.Text = "Record anfügen";
            this.cmdInsertRecord.UseVisualStyleBackColor = true;
            this.cmdInsertRecord.Click += new System.EventHandler(this.cmdInsertRecord_Click);
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(70, 48);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(100, 20);
            this.txtPassWord.TabIndex = 16;
            this.txtPassWord.Text = "Kennwort nurich";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Passwort:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Username:";
            // 
            // cmdWriteTable
            // 
            this.cmdWriteTable.Location = new System.Drawing.Point(160, 221);
            this.cmdWriteTable.Name = "cmdWriteTable";
            this.cmdWriteTable.Size = new System.Drawing.Size(95, 23);
            this.cmdWriteTable.TabIndex = 13;
            this.cmdWriteTable.Text = "write data Tabel";
            this.cmdWriteTable.UseVisualStyleBackColor = true;
            this.cmdWriteTable.Click += new System.EventHandler(this.cmdWriteTable_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(273, 416);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(211, 106);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Record löschen";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 534);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmdWriteTable);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmdRaedSeq);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmdReadData);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.txtInfoToSelection);
            this.Controls.Add(this.cmdLeave);
            this.Controls.Add(this.cmdArrive);
            this.Controls.Add(this.txtPasswordBox);
            this.Controls.Add(this.lblPasswordInfo);
            this.Controls.Add(this.cmdExit);
            this.Controls.Add(this.listBoxNamen);
            this.Controls.Add(this.lblProgInfo);
            this.Name = "FrmMain";
            this.Text = "Zeiterfassungs-Client";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblProgInfo;
        private System.Windows.Forms.ListBox listBoxNamen;
        private System.Windows.Forms.Button cmdExit;
        private System.Windows.Forms.Label lblPasswordInfo;
        private System.Windows.Forms.TextBox txtPasswordBox;
        private System.Windows.Forms.Button cmdArrive;
        private System.Windows.Forms.Button cmdLeave;
        private System.Windows.Forms.TextBox txtInfoToSelection;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button cmdReadData;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cmdRaedSeq;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button cmdInsertRecord;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Button cmdWriteTable;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

