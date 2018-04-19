namespace WinHardInformation
{
    partial class dbSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dbSet));
            this.serverTb = new System.Windows.Forms.TextBox();
            this.baseTb = new System.Windows.Forms.TextBox();
            this.tableTb = new System.Windows.Forms.TextBox();
            this.userTb = new System.Windows.Forms.TextBox();
            this.passTb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnNewStore = new System.Windows.Forms.Button();
            this.portTb = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // serverTb
            // 
            this.serverTb.Location = new System.Drawing.Point(105, 57);
            this.serverTb.Name = "serverTb";
            this.serverTb.Size = new System.Drawing.Size(100, 20);
            this.serverTb.TabIndex = 0;
            // 
            // baseTb
            // 
            this.baseTb.Location = new System.Drawing.Point(105, 91);
            this.baseTb.Name = "baseTb";
            this.baseTb.Size = new System.Drawing.Size(100, 20);
            this.baseTb.TabIndex = 1;
            // 
            // tableTb
            // 
            this.tableTb.Location = new System.Drawing.Point(105, 161);
            this.tableTb.Name = "tableTb";
            this.tableTb.Size = new System.Drawing.Size(100, 20);
            this.tableTb.TabIndex = 2;
            // 
            // userTb
            // 
            this.userTb.Location = new System.Drawing.Point(105, 197);
            this.userTb.Name = "userTb";
            this.userTb.Size = new System.Drawing.Size(100, 20);
            this.userTb.TabIndex = 3;
            // 
            // passTb
            // 
            this.passTb.Location = new System.Drawing.Point(105, 231);
            this.passTb.Name = "passTb";
            this.passTb.Size = new System.Drawing.Size(100, 20);
            this.passTb.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Сервер БД";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Имя базы";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Таблица";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Пользователь";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пароль";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(17, 275);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(75, 23);
            this.saveBtn.TabIndex = 10;
            this.saveBtn.Text = "Сохранить";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(130, 275);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Отмена";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Настройка параметров подключения";
            // 
            // btnNewStore
            // 
            this.btnNewStore.Location = new System.Drawing.Point(50, 315);
            this.btnNewStore.Name = "btnNewStore";
            this.btnNewStore.Size = new System.Drawing.Size(112, 23);
            this.btnNewStore.TabIndex = 13;
            this.btnNewStore.Text = "Новое хранилище";
            this.btnNewStore.UseVisualStyleBackColor = true;
            this.btnNewStore.Click += new System.EventHandler(this.btnNewStore_Click);
            // 
            // portTb
            // 
            this.portTb.Location = new System.Drawing.Point(105, 125);
            this.portTb.Name = "portTb";
            this.portTb.Size = new System.Drawing.Size(100, 20);
            this.portTb.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(57, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Порт";
            // 
            // dbSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 350);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.portTb);
            this.Controls.Add(this.btnNewStore);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.passTb);
            this.Controls.Add(this.userTb);
            this.Controls.Add(this.tableTb);
            this.Controls.Add(this.baseTb);
            this.Controls.Add(this.serverTb);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dbSet";
            this.Text = "Настройка";
            this.Load += new System.EventHandler(this.dbSet_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox serverTb;
        private System.Windows.Forms.TextBox baseTb;
        private System.Windows.Forms.TextBox tableTb;
        private System.Windows.Forms.TextBox userTb;
        private System.Windows.Forms.TextBox passTb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnNewStore;
        private System.Windows.Forms.TextBox portTb;
        private System.Windows.Forms.Label label7;
    }
}