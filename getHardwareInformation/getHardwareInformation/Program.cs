using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Management;
using System.IO;
using System.Threading;
using System.Net;
using System.Timers;
using System.Windows.Forms;
using System.Drawing;

namespace getHardwareInformation
{
    class Program
    {
        static string query;
        static Props props = new Props();
        static String path = Environment.CurrentDirectory + "\\settings.xml";
        // метод, выполняющийся в таймере
        public static void getInf(object source, ElapsedEventArgs e)
        {
            //запускаем поиск основной инфы из WMI
            GetHardwareInfo("Win32_Processor", "Name", "processor");
            GetHardwareInfo("Win32_Processor", "Manufacturer", "procman");
            GetHardwareInfo("Win32_Processor", "Description", "proc_desc");
            GetHardwareInfo("Win32_VideoController", "Name", "video_name");
            GetHardwareInfo("Win32_VideoController", "VideoProcessor", "video_proc");
            GetHardwareInfo("Win32_VideoController", "DriverVersion", "video_driver");
            GetHardwareInfo("Win32_VideoController", "AdapterRAM", "video_ram");
            GetHardwareInfo("Win32_CDROMDrive", "Name", "cd_name");
            GetHardwareInfo("Win32_CDROMDrive", "Drive", "cd_drive");
            GetHardwareInfo("Win32_DiskDrive", "Caption", "disc_caption");
            GetHardwareInfo("Win32_DiskDrive", "Size", "disc_size");
            GetHardwareInfo("Win32_Printer", "Caption", "printer_caption");
            GetHardwareInfo("Win32_BaseBoard", "Manufacturer", "baseboard_man");
            GetHardwareInfo("Win32_BaseBoard", "Product", "baseboard_prod");
            GetHardwareInfo("Win32_PhysicalMemory", "Capacity", "ram");
            GetHardwareInfo("Win32_Share", "Name", "share");
            //Находим некоторую инфу
            string Host = Dns.GetHostName();
            string osVersion = Environment.OSVersion.ToString();
            string username = Environment.UserName;
            string dateTime = DateTime.Now.ToString("dd MMMM yyyy | HH:mm:ss");
            string ipadr = "";
            IPHostEntry ip;                             //переменная типа iphostentry
            ip = Dns.GetHostEntry(Host);                //даем ей массив с адресами
            foreach (IPAddress ipaddress in ip.AddressList)
            {
                ipadr = ipadr + " " + ipaddress;
            }
            props.ReadXml();
            //инициируем проверку на наличие записи в базе
            database dBase = new database();
            bool answer = dBase.DbCheckNew();
            //формируем скуль-запрос
            query = query + "cab= '" + props.Fields.Cab + "', Ip= '" + ipadr + "', Host= '" + Host + "', username= '" + username + "', osVersion= '" + osVersion + "', lastUpdate= '" + dateTime + "'";
            //цикл, в зависимости от наличия записи в базе, либо апдейтит, либо вставляет (ыыыыы=)))
            if (answer == true)
            {
                string sqlQuery = "UPDATE " + props.Fields.tableName + " SET " + query + " WHERE surname='" + props.Fields.Surname + "'";
                dBase.DbUpdate(sqlQuery);
                query = "";
                Console.WriteLine("Данные отправлены..");
                GC.Collect();
            }
            else
            {
                string sqlQuery = "INSERT INTO " + props.Fields.tableName + " (surname) VALUES ('" + props.Fields.Surname + "')";
                Console.WriteLine("Данный компьютер зарегистрирован..");
                Thread.Sleep(2000);
                dBase.DbUpdate(sqlQuery);
                sqlQuery = "UPDATE " + props.Fields.tableName + " SET " + query + " WHERE surname='" + props.Fields.Surname + "'";
                dBase.DbUpdate(sqlQuery);
                query = "";
                Console.WriteLine("Данные отправлены..");
                GC.Collect();
            }
        }
        // код для помещения проги в трей
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [System.Runtime.InteropServices.DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();

        static void Main(string[] args)
        {
            //сворачиваем в область уведомлений
            //ShowWindow(GetConsoleWindow(), 0);

            //Указываем компонент, который создает значок в области уведомлений.
            //Этот класс не может наследоваться.
            NotifyIcon icon = new NotifyIcon();

            //Задаем текущий значок. 
            //Иконка расположена рядом с exe файлом
            icon.Icon = new System.Drawing.Icon("icon.ico");

            //Задаем значение, указывающее, виден ли значок в области уведомлений
            //в панели задач.
            icon.Visible = true;

            //Задаем текст подсказки, отображаемый при наведении указателя
            //мыши на значок в области уведомлений.
            icon.Text = "Запущен мониторинг оборудования";

            //Отображаем всплывающую подсказку с указанным заголовком, текстом 
            //и значком в панели задач в течении заданного периода времени.
            icon.ShowBalloonTip(2000, "Система мониторинга оборудования 'Геоплан'", "Программа запущена..", ToolTipIcon.Info);

            //ShowWindow(GetConsoleWindow(), 1);//показываем 
            //icon.Visible = false;  //убираем иконку из области уведомлений

            //настройка таймера
            System.Timers.Timer myTimer = new System.Timers.Timer();
            myTimer.Elapsed += new ElapsedEventHandler(getInf);
            myTimer.Interval = 600000;
            // Если нет файла с настройками- сначала создаем, потом таймер
            FileInfo fileInf = new FileInfo(path);
            if (!fileInf.Exists)
            {
                Console.WriteLine("Введите фамилию пользователя:");
                props.Fields.Surname = Console.ReadLine();
                Console.WriteLine("Введите кабинет:");
                props.Fields.Cab = Console.ReadLine();
                props.WriteXml();
                myTimer.Start();
            } else myTimer.Start();
            props.ReadXml();
            //Приветствие, цвет и прочая фигня
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("================================================================================");
            Console.WriteLine("<<<<<<<<<<   ЗАПУЩЕНА СИСТЕМА СБОРА ИНФОРМАЦИИ ОБ ОБОРУДОВАНИИ    >>>>>>>>>>>");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.ReadLine();
        }

        //метод поиска инфы в WMI
        private static void GetHardwareInfo(string WIN32_Class, string ClassItemField, string column)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM " + WIN32_Class);
            string sql="";
            try
            {
                foreach (ManagementObject obj in searcher.Get())
                {
                    sql = sql+ obj[ClassItemField].ToString().Trim()+";";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            query = query + column+"= '"+sql+"', ";
            
        }


    }
}