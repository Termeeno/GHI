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
    public partial class newStore : Form
    {
        public newStore()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Props props = new Props();
            database Db = new database();
            //заполняем поля класса из текстбоксов
            props.Fields.server = tbServer.Text;
            props.Fields.port = tbPort.Text;
            props.Fields.login = tbLogin.Text;
            props.Fields.pass = tbPass.Text;
            props.Fields.dbName = tbDbName.Text;
            props.Fields.tableName = tbTableName.Text;
            props.WriteXml();
            MessageBox.Show(Db.dbCreate());
        }

        private void newStore_Load(object sender, EventArgs e)
        {
            Props props = new Props();
            props.ReadXml();
            tbServer.Text = props.Fields.server;
            tbPort.Text = props.Fields.port;
            tbLogin.Text = props.Fields.login;
            tbPass.Text = props.Fields.pass;
            tbDbName.Text = props.Fields.dbName;
            tbTableName.Text = props.Fields.tableName;
        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            database Db = new database();
            MessageBox.Show(Db.dbCreateTable(tbTableName.Text));
            Props props = new Props();
            props.Fields.tableName = tbTableName.Text;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
