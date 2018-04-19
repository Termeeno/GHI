using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinHardInformation
{
    public class PropsFields
    {
        public String XMLFileName = Environment.CurrentDirectory + "\\settings.xml";
        public String IPaddress = "127.0.0.1";
        public DateTime LastStart = new DateTime(2018, 1, 9);
        public String Surname = "Тестовый";
        public String Cab = "testcab";
        // поля с настройками доступа к БД
        public string server = "localhost";
        public string login = "root";
        public string pass = "128160";
        public string dbName = "infhard";
        public string tableName = "info";
        public string port = "3306";
        //Поля с серверами и принтерами
        public string srv1c = "192.168.55.36";
        public string proxySrv = "192.168.55.64";
        public string stend = "192.168.55.27";
        public string pdc = "192.168.55.253";
        public string sozServer = "192.168.55.26";
        public string oki2 = "192.168.55.254";
        public string oki4 = "192.168.55.249";
        public string task181 = "192.168.55.252";
        public string plotter = "192.168.55.250";

    }
    class Props
    {
        public PropsFields Fields;
        public Props()
        {
            Fields = new PropsFields();
        }

        public void WriteXml()
        {
            XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
            TextWriter writer = new StreamWriter(Fields.XMLFileName);
            ser.Serialize(writer, Fields);
            writer.Close();
        }

        public void ReadXml()
        {
            if (File.Exists(Fields.XMLFileName))
            {
                XmlSerializer ser = new XmlSerializer(typeof(PropsFields));
                TextReader reader = new StreamReader(Fields.XMLFileName);
                Fields = ser.Deserialize(reader) as PropsFields;
                reader.Close();
            }
        }
    }
}
