using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace getHardwareInformation
{
    public class database
    {
        public bool DbCheckNew()
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
                ";password=" + password + "; charset=utf8";
            MySqlConnection conn = new MySqlConnection(connStr);
            bool answer=true;
            try
            {
                conn.Open();

                string sql = "SELECT surname FROM " + props.Fields.tableName + " WHERE surname ='" + props.Fields.Surname + "'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.HasRows)
                {
                    answer = true;
                }
                else { answer = false; }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                answer = false;
            }

            conn.Close();
            return answer;
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
                ";password=" + password + "; charset=utf8";
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
    }


    }

