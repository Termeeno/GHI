using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace WinHardInformation
{
    public partial class Form1 : Form
    {
        database Db = new database();
        pings pingsServer = new pings();
        //инты для интервалов тймеров
        int mainTimerInt = 30000;
        int tmrInt = 30000;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            System.Timers.Timer tmr = new System.Timers.Timer(); 
            System.Timers.Timer tmrProxy = new System.Timers.Timer(); 
            System.Timers.Timer tmrStend = new System.Timers.Timer(); 
            System.Timers.Timer tmrSoz = new System.Timers.Timer(); 
            System.Timers.Timer tmrOki2 = new System.Timers.Timer(); 
            System.Timers.Timer tmrTask181 = new System.Timers.Timer();
            System.Timers.Timer tmrPlotter = new System.Timers.Timer();
            System.Timers.Timer tmrOki4 = new System.Timers.Timer();
            System.Timers.Timer tmrPdc = new System.Timers.Timer();
            System.Timers.Timer tmrYa = new System.Timers.Timer();
            //TODO дописать отдельные таймеры и методы для пинга принтеров
            System.Windows.Forms.Timer mainTimer = new System.Windows.Forms.Timer(); //таймер для обновления осн данных
            //новые таймеры для пингов
            tmr.Elapsed += new ElapsedEventHandler(cTimer);
            tmrProxy.Elapsed += new ElapsedEventHandler(proxyTimer);
            tmrStend.Elapsed += new ElapsedEventHandler(stendTimer);
            tmrSoz.Elapsed += new ElapsedEventHandler(sozTimer);
            tmrOki2.Elapsed += new ElapsedEventHandler(oki2Timer);
            tmrTask181.Elapsed += new ElapsedEventHandler(task181Timer);
            tmrPlotter.Elapsed += new ElapsedEventHandler(plotterTimer);
            tmrOki4.Elapsed += new ElapsedEventHandler(oki4Timer);
            tmrPdc.Elapsed += new ElapsedEventHandler(pdcTimer);
            tmrYa.Elapsed += new ElapsedEventHandler(yaTimer);
            //задаем им интервал
            tmr.Interval = tmrInt; 
            tmrProxy.Interval = tmrInt;
            tmrStend.Interval = tmrInt;
            tmrSoz.Interval = tmrInt;
            tmrOki2.Interval = tmrInt;
            tmrTask181.Interval = tmrInt;
            tmrPlotter.Interval = tmrInt;
            tmrOki4.Interval = tmrInt;
            tmrPdc.Interval = tmrInt;
            tmrYa.Interval = tmrInt;
            //включаем таймеры
            tmr.Enabled = true; 
            tmrProxy.Enabled = true; 
            tmrStend.Enabled = true; 
            tmrSoz.Enabled = true; 
            tmrOki2.Enabled = true; 
            tmrOki4.Enabled = true; 
            tmrTask181.Enabled = true; 
            tmrPlotter.Enabled = true;
            tmrPdc.Enabled = true;
            tmrYa.Enabled = true;

            mainTimer.Interval = 10000;
            mainTimer.Enabled = true;
            mainTimer.Tick += event2;

        }

        private void cTimer(object source, ElapsedEventArgs e) //метод для 1с таймера
        {
            pingsServer.ping1c();
            cLabel.Text = pingsServer.Fields.srv1c;
            if (pingsServer.ping1c() == true)
            {
                cLabel.ForeColor = Color.Green;
            }
            else cLabel.ForeColor = Color.Red;
            //pingsMainDot();
        }

        private void proxyTimer(object source, ElapsedEventArgs e) //метод для прокси таймера
        {
            pingsServer.pingProxy();
            proxyLabel.Text = pingsServer.Fields.proxySrv;
            if (pingsServer.pingProxy() == true)
            {
                proxyLabel.ForeColor = Color.Green;
            }
            else proxyLabel.ForeColor = Color.Red;
        }

        private void stendTimer(object source, ElapsedEventArgs e) //метод для стенд таймера
        {
            pingsServer.pingStend();
            stendLabel.Text = pingsServer.Fields.stend;
            if (pingsServer.pingStend() == true)
            {
                stendLabel.ForeColor = Color.Green;
            }
            else stendLabel.ForeColor = Color.Red;
        }

        private void sozTimer(object source, ElapsedEventArgs e) //метод для соз таймера
        {
            pingsServer.pingSoz();
            sozLabel.Text = pingsServer.Fields.sozServer;
            if (pingsServer.pingSoz() == true)
            {
                sozLabel.ForeColor = Color.Green;
            }
            else sozLabel.ForeColor = Color.Red;
        }

        private void oki2Timer(object source, ElapsedEventArgs e) //метод для оки2 таймера
        {
            pingsServer.pingOki2();
            oki2Label.Text = pingsServer.Fields.oki2;
            if (pingsServer.pingOki2() == true)
            {
                oki2Label.ForeColor = Color.Green;
            }
            else oki2Label.ForeColor = Color.Red;
        }

        private void oki4Timer(object source, ElapsedEventArgs e) //метод для оки4 таймера
        {
            pingsServer.pingOki4();
            oki4Label.Text = pingsServer.Fields.oki4;
            if (pingsServer.pingOki4() == true)
            {
                oki4Label.ForeColor = Color.Green;
            }
            else oki4Label.ForeColor = Color.Red;
        }

        private void task181Timer(object source, ElapsedEventArgs e) //метод для тасальфа таймера
        {
            pingsServer.pingTask181();
            task181Label.Text = pingsServer.Fields.task181;
            if (pingsServer.pingTask181() == true)
            {
                task181Label.ForeColor = Color.Green;
            }
            else task181Label.ForeColor = Color.Red;
        }

        private void plotterTimer(object source, ElapsedEventArgs e) //метод для плоттер таймера
        {
            pingsServer.pingPlotter();
            plotterLabel.Text = pingsServer.Fields.plotter;
            if (pingsServer.pingPlotter() == true)
            {
                plotterLabel.ForeColor = Color.Green;
            }
            else plotterLabel.ForeColor = Color.Red;
        }

        private void pdcTimer(object source, ElapsedEventArgs e) //метод для контроллера домена таймера
        {
            pingsServer.pingPdc();
            pdcLabel.Text = pingsServer.Fields.pdc;
            if (pingsServer.pingPdc() == true)
            {
                pdcLabel.ForeColor = Color.Green;
            }
            else pdcLabel.ForeColor = Color.Red;
        }

        private void yaTimer(object source, ElapsedEventArgs e) //метод для яндекс таймера
        {
            pingsServer.yaPing();
            yaLabel.Text = pingsServer.Fields.ya;
            if (pingsServer.yaPing() == true)
            {
                yaLabel.ForeColor = Color.Green;
            }
            else yaLabel.ForeColor = Color.Red;
        }

        private void event2(object sender, EventArgs e) //метод для главного таймера
        {
            flp1.Controls.Clear(); //стираем старые контролы
            dataUp(); //метод формирования новых контролов на основе данных из базы
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataUp(); 
        }

        private void dataUp()
        {
            var dbData = Db.DbRead();

            int x = 20;
            int y = 120;

            int grWidth = 200;
            int grHeight = 140;
            try
            {
                while (dbData.Read())
                {
                    GroupBox gr1 = new GroupBox();
                    gr1.Parent = flp1;
                    gr1.Text = dbData["surname"].ToString() + " (" + dbData["cab"].ToString() + ")";
                    gr1.Location = new Point(x, y);
                    gr1.Size = new Size(grWidth, grHeight);

                    string surname = dbData["surname"].ToString();
                    string username = dbData["username"].ToString();
                    string host = dbData["host"].ToString();
                    string ipp = dbData["ip"].ToString();
                    string cab = dbData["cab"].ToString();
                    string processor = dbData["processor"].ToString();
                    string proc_desc = dbData["proc_desc"].ToString();
                    string procman = dbData["procman"].ToString();
                    string video_name = dbData["video_name"].ToString();
                    string video_proc = dbData["video_proc"].ToString();
                    string video_driver = dbData["video_driver"].ToString();
                    string video_ram = dbData["video_ram"].ToString();
                    string cd_name = dbData["cd_name"].ToString();
                    string cd_drive = dbData["cd_drive"].ToString();
                    string disc_caption = dbData["disc_caption"].ToString();
                    string disc_size = dbData["disc_size"].ToString();
                    string printer_caption = dbData["printer_caption"].ToString();
                    //делаем массив со списокм принтеров, разделяя переменную printer_caption
                    string[] prntList = printer_caption.Split(';');
                    string baseboard_man = dbData["baseboard_man"].ToString();
                    string baseboard_prod = dbData["baseboard_prod"].ToString();
                    string ram = dbData["ram"].ToString();
                    string share = dbData["share"].ToString();
                    string[] shareList = share.Split(';');
                    string osVersion = dbData["osVersion"].ToString();
                    string lastUpdate = dbData["lastUpdate"].ToString();

                    Button btn = new Button();
                    btn.Parent = gr1;
                    btn.Text = "Подробнее";
                    btn.Tag = dbData["surname"];
                    btn.Location = new Point(120, 115);
                    btn.Click += new EventHandler(btn_Click);
                    void btn_Click(object btn_sender, EventArgs btn_e)
                    {
                        extraForm newExtraForm = new extraForm();
                        newExtraForm.Show();
                        newExtraForm.Text = btn.Tag.ToString();
                        newExtraForm.AutoSize = true;

                        Label mainHeader = new Label();
                        mainHeader.Parent = newExtraForm;
                        mainHeader.Location = new Point(80, 5);
                        mainHeader.AutoSize = true;
                        mainHeader.ForeColor = Color.DarkBlue;
                        mainHeader.Text = "Основная информация";

                        Label surnameLabel = new Label();
                        surnameLabel.Parent = newExtraForm;
                        surnameLabel.Location = new Point(30, 30);
                        surnameLabel.AutoSize = true;
                        surnameLabel.Text = "Клиент: " + surname;

                        Label cabLabel = new Label();
                        cabLabel.Parent = newExtraForm;
                        cabLabel.Location = new Point(30, 45);
                        cabLabel.AutoSize = true;
                        cabLabel.Text = "Кабинет №: " + cab;

                        Label usernameLabel = new Label();
                        usernameLabel.Parent = newExtraForm;
                        usernameLabel.Location = new Point(30, 60);
                        usernameLabel.AutoSize = true;
                        usernameLabel.Text = "Имя пользователя: " + username;

                        Label hostLabel = new Label();
                        hostLabel.Parent = newExtraForm;
                        hostLabel.Location = new Point(30, 75);
                        hostLabel.AutoSize = true;
                        hostLabel.Text = "Имя хоста: " + host;

                        Ping ping = new Ping();
                        PingReply pingReply = ping.Send(host);

                        Label ippLabel = new Label();
                        ippLabel.Parent = newExtraForm;
                        ippLabel.Location = new Point(30, 90);
                        ippLabel.AutoSize = true;
                        ippLabel.Text = "Ip-адрес: " + pingReply.Address.ToString();

                        Label hardHeader = new Label();
                        hardHeader.Parent = newExtraForm;
                        hardHeader.Location = new Point(80, 115);
                        hardHeader.AutoSize = true;
                        hardHeader.ForeColor = Color.DarkBlue;
                        hardHeader.Text = "Железо";
                        //Раздел с описанием железяк
                        Label procLabel = new Label();
                        procLabel.Parent = newExtraForm;
                        procLabel.Location = new Point(30, 140);
                        procLabel.AutoSize = true;
                        procLabel.Text = "Процессор: " + processor;

                        Label prosdescLabel = new Label();
                        prosdescLabel.Parent = newExtraForm;
                        prosdescLabel.Location = new Point(30, 155);
                        prosdescLabel.AutoSize = true;
                        prosdescLabel.Text = "Семейство: " + proc_desc;

                        Label procmanLabel = new Label();
                        procmanLabel.Parent = newExtraForm;
                        procmanLabel.Location = new Point(30, 170);
                        procmanLabel.AutoSize = true;
                        procmanLabel.Text = "Производитель: " + procman;

                        Label videonameLabel = new Label();
                        videonameLabel.Parent = newExtraForm;
                        videonameLabel.Location = new Point(30, 185);
                        videonameLabel.AutoSize = true;
                        videonameLabel.Text = "Видеокарта: " + video_name;

                        Label videoprocLabel = new Label();
                        videoprocLabel.Parent = newExtraForm;
                        videoprocLabel.Location = new Point(30, 200);
                        videoprocLabel.AutoSize = true;
                        videoprocLabel.Text = "Видеопроцессор: " + video_proc;

                        Label videodrvLabel = new Label();
                        videodrvLabel.Parent = newExtraForm;
                        videodrvLabel.Location = new Point(30, 215);
                        videodrvLabel.AutoSize = true;
                        videodrvLabel.Text = "Видеодрайвер: " + video_driver;

                        Label videoramLabel = new Label();
                        videoramLabel.Parent = newExtraForm;
                        videoramLabel.Location = new Point(30, 230);
                        videoramLabel.AutoSize = true;
                        videoramLabel.Text = "Объем видеопамяти: " + video_ram;

                        Label cdLabel = new Label();
                        cdLabel.Parent = newExtraForm;
                        cdLabel.Location = new Point(30, 245);
                        cdLabel.AutoSize = true;
                        cdLabel.Text = "CD-привод: " + cd_name;

                        Label cddriveLabel = new Label();
                        cddriveLabel.Parent = newExtraForm;
                        cddriveLabel.Location = new Point(30, 260);
                        cddriveLabel.AutoSize = true;
                        cddriveLabel.Text = "Буква CD-привода: " + cd_drive;

                        Label hddLabel = new Label();
                        hddLabel.Parent = newExtraForm;
                        hddLabel.Location = new Point(30, 275);
                        hddLabel.AutoSize = true;
                        hddLabel.Text = "Жесткий диск: " + disc_caption;

                        Label hddSizeLabel = new Label();
                        hddSizeLabel.Parent = newExtraForm;
                        hddSizeLabel.Location = new Point(30, 290);
                        hddSizeLabel.AutoSize = true;
                        hddSizeLabel.Text = "Объем диска: " + disc_size;


                        Label printerLabel = new Label();
                        printerLabel.Parent = newExtraForm;
                        printerLabel.Location = new Point(30, 305);
                        printerLabel.AutoSize = true;
                        string prntText = "Принтеры: ";
                        for (int k = 0; k < prntList.Length; k++)
                        {
                            prntText = prntText + prntList[k] + "\n";
                        }
                        printerLabel.Text = prntText;

                        Label baseBoardManLabel = new Label();
                        baseBoardManLabel.Parent = newExtraForm;
                        baseBoardManLabel.Top = printerLabel.Bottom;
                        baseBoardManLabel.Left = 30;
                        baseBoardManLabel.AutoSize = true;
                        baseBoardManLabel.Text = "Производитель MB: " + baseboard_man;

                        Label baseBoardProdLabel = new Label();
                        baseBoardProdLabel.Parent = newExtraForm;
                        baseBoardProdLabel.Top = baseBoardManLabel.Bottom;
                        baseBoardProdLabel.Left = 30;
                        baseBoardProdLabel.AutoSize = true;
                        baseBoardProdLabel.Text = "Название: " + baseboard_prod;

                        Label ramLabel = new Label();
                        ramLabel.Parent = newExtraForm;
                        ramLabel.Top = baseBoardProdLabel.Bottom;
                        ramLabel.Left = 30;
                        ramLabel.AutoSize = true;
                        ramLabel.Text = "RAM: " + ram;

                        Label softHeader = new Label();
                        softHeader.Parent = newExtraForm;
                        softHeader.Left = 80;
                        softHeader.Top = ramLabel.Bottom + 10;
                        softHeader.AutoSize = true;
                        softHeader.ForeColor = Color.DarkBlue;
                        softHeader.Text = "Софт";
                        //Раздел с описанием софтовой части

                        Label shareLabel = new Label();
                        shareLabel.Parent = newExtraForm;
                        shareLabel.Top = softHeader.Bottom + 10;
                        shareLabel.Left = 30;
                        shareLabel.AutoSize = true;
                        string shareText = "Шара: ";
                        for (int k = 0; k < shareList.Length; k++)
                        {
                            shareText = shareText + shareList[k] + "\n";
                        }
                        shareLabel.Text = shareText;

                        Label osLabel = new Label();
                        osLabel.Parent = newExtraForm;
                        osLabel.Top = shareLabel.Bottom;
                        osLabel.Left = 30;
                        osLabel.AutoSize = true;
                        osLabel.Text = "ОС: " + osVersion;
                    }

                    PictureBox comp = new PictureBox();
                    comp.Parent = gr1;
                    comp.Image = Properties.Resources.computer;
                    comp.Size = new Size(16, 16);
                    comp.Location = new Point(5, 15);

                    PictureBox user = new PictureBox();
                    user.Parent = gr1;
                    user.Image = Properties.Resources.user;
                    user.Size = new Size(16, 16);
                    user.Location = new Point(5, 35);

                    PictureBox login = new PictureBox();
                    login.Parent = gr1;
                    login.Image = Properties.Resources.login;
                    login.Size = new Size(16, 16);
                    login.Location = new Point(5, 55);

                    PictureBox ip = new PictureBox();
                    ip.Parent = gr1;
                    ip.Image = Properties.Resources.ip;
                    ip.Size = new Size(16, 16);
                    ip.Location = new Point(5, 75);

                    PictureBox status = new PictureBox();
                    status.Parent = gr1;
                    status.Image = Properties.Resources.status;
                    status.Size = new Size(16, 16);
                    status.Location = new Point(5, 95);

                    Label hostName = new Label();
                    hostName.Parent = gr1;
                    hostName.AutoSize = true;
                    hostName.Text = "Хост: " + dbData["host"].ToString();
                    hostName.Location = new Point(22, 17);

                    Label userName = new Label();
                    userName.Parent = gr1;
                    userName.AutoSize = true;
                    userName.Text = "Юзер: " + dbData["username"].ToString();
                    userName.Location = new Point(22, 37);

                    Label loginDate = new Label();
                    loginDate.Parent = gr1;
                    loginDate.AutoSize = true;
                    loginDate.Text = "Вход: " + dbData["lastUpdate"].ToString();
                    loginDate.Location = new Point(22, 57);

                    Label ipaddr = new Label();
                    ipaddr.Parent = gr1;
                    ipaddr.AutoSize = true;
                    ipaddr.Location = new Point(22, 77);

                    Label pingResult = new Label();
                    pingResult.Parent = gr1;
                    pingResult.AutoSize = true;
                    pingResult.Location = new Point(22, 97);
                    try
                    {
                        Ping ping = new Ping();
                        PingReply pingReply = ping.Send(dbData["host"].ToString());
                        pingResult.ForeColor = Color.Green;
                        pingResult.Text = "Статус хоста: хост в сети";
                        ipaddr.Text = pingReply.Address.ToString();
                    }
                    catch
                    {
                        pingResult.ForeColor = Color.Red;
                        pingResult.Text = "Статус хоста: хост оффлайн";
                        ipaddr.Text = "Адрес не определен";
                    }
                    //TODO сделать отображение при разворачивании на весь экран

                    int grCount = this.Width / grWidth;
                    if (x < (grCount * grWidth) - grWidth)
                    {
                        x += 200;
                    }
                    else
                    {
                        x = 20;
                        y += 140;
                    }


                }
            }
            catch
            {
                MessageBox.Show("Шеф, нет коннекта к базе ");
            }
            dbData.Dispose();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            dbSet dbSet = new dbSet();
            dbSet.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Пока недописал, увы :-((");
        }
    }
}
