using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinHardInformation
{
    class database
    {
        

        public IDataReader DbRead()
        {
            Props props = new Props();
            props.ReadXml();
            string serverName = props.Fields.server;
            string userName = props.Fields.login;
            string dbName = props.Fields.dbName;
            string port = props.Fields.port;
            string password = props.Fields.pass;
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            MySqlDataReader reader;
            string query = "SELECT * FROM " + props.Fields.tableName;
            try
            {
                using (var connection = new MySqlConnection(connStr))
                {
                    connection.Open();
                    using (var cmd = new MySqlCommand(query, connection))
                    {

                        reader = cmd.ExecuteReader();
                        var dt = new DataTable();
                        dt.Load(reader);
                        return dt.CreateDataReader();
                    }
                }
            }
            catch
            {
                return null;
            }
            
        }

        public void DbUpdate(string sqlQuery)
        {
            Props props = new Props();
            props.ReadXml();
            string serverName = props.Fields.server;
            string userName = props.Fields.login;
            string dbName = props.Fields.dbName;
            string port = props.Fields.port;
            string password = props.Fields.pass;
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();
        }

        public string dbCreate()
        {
            Props props = new Props();
            props.ReadXml();
            string serverName = props.Fields.server;
            string userName = props.Fields.login;
            string dbName = props.Fields.dbName;
            string port = props.Fields.port;
            string password = props.Fields.pass;
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";port=" + port +
                ";password=" + password + ";";
            string sqlQuery = "Create DATABASE "+ dbName;
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Хранилище создано";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Ошибка создания хранилища. ("+ ex.ToString() + ")";
            }

            
        }

        public string dbCreateTable(string table)
        {
            Props props = new Props();
            props.ReadXml();
            string serverName = props.Fields.server;
            string userName = props.Fields.login;
            string dbName = props.Fields.dbName;
            string port = props.Fields.port;
            string password = props.Fields.pass;
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
            string sqlQuery = "CREATE TABLE " +table + " (processor TEXT, procman TEXT, proc_desc TEXT, video_name TEXT, video_proc TEXT, video_driver TEXT, video_ram TEXT, cd_name TEXT, cd_drive TEXT, disc_caption TEXT, disc_size TEXT, printer_caption TEXT, baseboard_man TEXT, baseboard_prod TEXT, ram TEXT, share TEXT, surname TEXT, id INT NOT NULL PRIMARY KEY AUTO_INCREMENT, cab TEXT, Ip TEXT, Host TEXT, username TEXT, osVersion TEXT, lastupdate TEXT); "; 
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sqlQuery, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return "Таблица создана";
            }
            catch (Exception ex)
            {
                conn.Close();
                return "Ошибка создания таблицы. (" + ex.ToString() + ")";
            }


        }
    }
}
