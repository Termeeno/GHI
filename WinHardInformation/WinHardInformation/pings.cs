using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace WinHardInformation
{
    public class pingFields
    {
        public string srv1c;
        public string proxySrv;
        public string stend;
        public string pdc;
        public string sozServer;
        public string oki2;
        public string oki4;
        public string task181;
        public string plotter;
        public string ya;

    }

    class pings
    {
        public pingFields Fields;
        public pings()//пассивный конструктор (чтоб не забыть)
        {
            Fields = new pingFields();
        }

        public bool ping1c()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.srv1c);
                string cIp = pingReply.Address.ToString();
                Fields.srv1c = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.srv1c = "Хост оффлайн";
                return false;
            }
        }

        public bool pingProxy()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.proxySrv);
                string cIp = pingReply.Address.ToString();
                Fields.proxySrv = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.proxySrv = "Хост оффлайн";
                return false;
            }
        }

        public bool pingStend()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.stend);
                string cIp = pingReply.Address.ToString();
                Fields.stend = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.stend = "Хост оффлайн";
                return false;
            }
        }

        public bool pingPdc()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.pdc);
                string cIp = pingReply.Address.ToString();
                Fields.pdc = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.pdc = "Хост оффлайн";
                return false;
            }
        }

        public bool pingSoz()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.sozServer);
                string cIp = pingReply.Address.ToString();
                Fields.sozServer = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.sozServer = "Хост оффлайн";
                return false;
            }
        }

        public bool pingOki2()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.oki2);
                string cIp = pingReply.Address.ToString();
                Fields.oki2 = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.oki2 = "Хост оффлайн";
                return false;
            }
        }

        public bool pingOki4()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.oki4);
                string cIp = pingReply.Address.ToString();
                Fields.oki4 = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.oki4 = "Хост оффлайн";
                return false;
            }
        }

        public bool pingTask181()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.task181);
                string cIp = pingReply.Address.ToString();
                Fields.task181 = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.task181 = "Хост оффлайн";
                return false;
            }
        }

        public bool pingPlotter()
        {
            try
            {
                Props pingProps = new Props();
                pingProps.ReadXml();
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(pingProps.Fields.plotter);
                string cIp = pingReply.Address.ToString();
                Fields.plotter = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.plotter = "Хост оффлайн";
                return false;
            }
        }

        public bool yaPing()
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send("ya.ru");
                string cIp = pingReply.Address.ToString();
                Fields.ya = "Сервер в сети (" + cIp + ")";
                return true;
            }
            catch
            {
                Fields.ya = "Хост оффлайн либо отсутствует инет";
                return false;
            }
        }
    }
}
