using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinHardInformation
{
    public partial class dbSet : Form
    {
        public dbSet()
        {
            InitializeComponent();
        }

        private void btnNewStore_Click(object sender, EventArgs e)
        {
            newStore newDb = new newStore();
            newDb.Show();
        }

        private void dbSet_Load_1(object sender, EventArgs e)
        {
            Props props = new Props();
            props.ReadXml();
            serverTb.Text = props.Fields.server;
            portTb.Text = props.Fields.port;
            userTb.Text = props.Fields.login;
            passTb.Text = props.Fields.pass;
            baseTb.Text = props.Fields.dbName;
            tableTb.Text = props.Fields.tableName;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            Props props = new Props();
            database Db = new database();
            //заполняем поля класса из текстбоксов
            props.Fields.server =serverTb.Text;
            props.Fields.port = portTb.Text;
            props.Fields.login = userTb.Text;
            props.Fields.pass = passTb.Text;
            props.Fields.dbName = baseTb.Text;
            props.Fields.tableName = tableTb.Text;
            props.WriteXml();
            MessageBox.Show("Настройки сохранены");
            this.Dispose();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
