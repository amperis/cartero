using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NetUtils;
using System.IO;
using System.Collections;


namespace cartero
{
    public partial class formCartero : Form
    {
        /***
         * Declaración de constantes
         ***/
        string APP_NAME    = "Cartero";
        string APP_VERSION = "v0.2";
        string APP_OWNER   = "amperis";

        string APP_DESCRIPRION = "http://www.amperisblog.com\namperisblog@gmail.com\nGNU license";
        string URL_SPAMHAUS = "http://www.spamhaus.org/query/bl?ip=";
        string EICAR_FILE = "X5O!P%@AP[4\\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H* ";
        string URL_APP_UPDATES = "http://code.google.com/p/cartero/downloads/list";
        
        string MIME_BODY =
            "MIME-Version: 1.0\n" +
            "Subject: [!subject]\n" +
            "Content-Type: multipart/mixed; boundary=frontera\n" +
            "--frontera\n" +
            "Content-Type: text/plain; charset=UTF-8\n" +
            "Content-Transfer-Encoding: 7bit\n\n" +
            "[!data]\n" +
            "--frontera\n";

        string MIME_ATTACHMENT = 
            "--frontera\n" +
            "Content-Type: [!filetype]; name=\"[!filename]\"\n" +
            "Content-Disposition: attachment; filename=\"[!filename]\"\n" +
            "Content-Transfer-Encoding: base64\n\n" +
            "[!filedata]\n"+
            "--frontera--\n";
        
        /***
         * Funcion: tabSMTPdebugMultiLines()
         * Parametros:
         *    string debug: cadena a mostrar
         * Descripción: nuestra los comandos y resultados en la conexion SMTP.
         ***/
        private void tabSMTPdebug(string debug)
        {
            char[] salto  = { Convert.ToChar(13) };
            string[] cadenas = debug.Split(salto);

            foreach (string cadena in cadenas)
                listDebug1.Items.Add(cadena);
            listDebug1.Refresh();
        }

        /***
         * Funcion: tabSMTPformatear_datos()
         * Parametros:
         * Descripción: Formatea los datos antes de ser usados.
         ***/
        private void tabSMTPformatear_datos()
        {
            textHost.Text = textHost.Text.Trim();
            textPort.Text = textPort.Text.Trim();
        }

        /***
         * Funcion: tabSMTPverificar_datos()
         * Parametros:
         * Descripción: Verifica si los datos introducidos dentro del tabSMTP son correctos.
         ***/
        private bool tabSMTPverificar_datos()
        {
            //-- el campo de Host IP no puede estar vacio
            if (textHost.Text == "")
            {
                MessageBox.Show(
                    "Field Host IP cannot be empty.", 
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            //--- el campo de Puerto no puede estar vacio
            if (textPort.Text == "")
            {
                MessageBox.Show(
                    "Field Port cannot be empty.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return false;
            }

            //--- la dirección Host IP tiene que ser correcta
            Net utilsnet = new Net();
            if ( !utilsnet.IsValidIP(textHost.Text) )
            {
                MessageBox.Show(
                    "Field Host IP is not a valid IP.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            //--- el campo puerto tiene que ser un numero
            double num;
            if (!double.TryParse(textPort.Text, out num))
            {
                MessageBox.Show(
                    "Field Port is not a numeric value.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public formCartero()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public string textToBase64(string sAscii)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(sAscii);
            return System.Convert.ToBase64String(bytes, 0, bytes.Length);
        }

        /***
         * Funcion: buttonSalir_Click
         * Descripcion: Salida de la aplicacion
         ***/
        private void buttonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /***
         * Funcion: buttonBorrarDebug_Click
         * Descripcion: Elimina el contenido de las diferentes ventanas con informacion: 
         * tabSMTP
         * tabMX
         * tabWhois
         * tabUpdate
         ***/
        private void buttonBorrarDebug_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabSMTP"   : 
                    listDebug1.Items.Clear();
                    textHost.Text = "";
                    textPort.Text = "25";
                    typeEhlo.Checked = false;
                    textHeloHost.Text = "";
                    textFrom.Text = "";
                    textRcpt.Text = "";
                    textSubject.Text = "";
                    richData.Text = "";
                    comboBox.Items.Clear();
                    checkVirus.Checked = false;
                    checkRsetNoop.Checked = false;
                    retardo.Value = 0;
                    break;
                case "tabMX"     : 
                    listViewMX.Items.Clear();
                    textDomainNane.Text = "";
                    pingNumber.Value = 3;
                    break;
                case "tabWhois"  : 
                    richTextBoxWhois.Clear();
                    textBoxWhois.Text = "";
                    break;
                case "tabUpdates": 
                    webBrowser.Navigate(URL_APP_UPDATES); 
                    break;
            }
        }

        
        /***
         * Funcion: buttonAcercaDe_Click()
         * Descripcion: Muestra informacion sobre el creador del programa
         ***/
        private void buttonAcercaDe_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                APP_NAME + " " + APP_VERSION + " ~ by " + APP_OWNER + "\r\n\r\n" +
                APP_DESCRIPRION,
                APP_NAME,
                MessageBoxButtons.OK,
                MessageBoxIcon.Question);
        }

        /***
         * Funcion: tabSMTPbuttonEnviar_Click()
         * Descripcion: Accion que envia un email al servidor SMTP y muestra los mensaje en el debug.
         ***/
        private void tabSMTPbuttonEnviar_Click(object sender, EventArgs e)
        {
            string cmd = "";
            string resp = "";
            byte cod = 0;

            tabSMTPformatear_datos();

            //--- convertimos el Host name a su dirección IP
            textHost.Text = HostNameToIP(textHost.Text);

            if ( !tabSMTPverificar_datos() )
                return;

            smtpMail mail = new smtpMail();

            resp = "";
            tabSMTPdebug("-> Connecting to " + textHost.Text + " on port " + textPort.Text + "...");
            if (mail.Conexion(textHost.Text, Convert.ToByte(retardo.Value), textPort.Text, out resp))
            {
                tabSMTPdebug(resp);
            }
            else
            {
                tabSMTPdebug("Connection error or connection timeout.");
                return;
            }

            if (typeHelo.Checked)
            {
                cmd = "";
                resp = "";
                cod = mail.Helo(textHeloHost.Text, out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug(resp);
                if (cod != 0)
                {
                    mail.FinConexion();
                    tabSMTPdebug("End connection.");
                    return;
                }

            }
            else
            {
                cod = mail.Ehlo(textHeloHost.Text, out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug(resp);
                if (cod != 0)
                {
                    mail.FinConexion();
                    tabSMTPdebug("End connection.");
                    return;
                }
            }

            cod = mail.From(textFrom.Text, out cmd, out resp);
            tabSMTPdebug("-> " + cmd);
            tabSMTPdebug(resp);

            if (cod != 0)
            {
                mail.FinConexion();
                tabSMTPdebug("End connection.");
                return;
            }

            cod = mail.Rcpt(textRcpt.Text, out cmd, out resp);
            tabSMTPdebug("-> " + cmd);
            tabSMTPdebug(resp);

            if (cod != 0)
            {
                mail.FinConexion();
                tabSMTPdebug("End connection.");
                return;
            }

            cod = mail.Data(out cmd, out resp);
            tabSMTPdebug("-> " + cmd);
            tabSMTPdebug(resp);

            if (cod != 0)
            {
                mail.FinConexion();
                tabSMTPdebug("End connection.");
                return;
            }

            string senddata = "";

            if (checkVirus.Checked)
            {
                senddata = MIME_BODY.Replace("[!subject]", textSubject.Text);
                senddata = senddata.Replace("[!data]", richData.Text);
                senddata =
                    senddata +
                    MIME_ATTACHMENT.Replace("[!filename]", "eicar_test_file");
                senddata = senddata.Replace("[!filetype]", "application/octet-stream");
                senddata = senddata.Replace("[!filedata]", textToBase64(EICAR_FILE));

                if ( (comboBox.SelectedItem.ToString() != "(none)") || (comboBox.SelectedItem.ToString() != "") )
                {
                    senddata =
                        senddata +
                        MIME_ATTACHMENT.Replace("[!filename]", Path.GetFileName(comboBox.SelectedItem.ToString()));
                    senddata = senddata.Replace("[!filetype]", "application/octet-stream");
                    senddata = senddata.Replace("[!filedata]", mail.filetoMIME(comboBox.SelectedItem.ToString()));
                }
            }
            else
            {
                if (textSubject.Text != "")
                {
                    senddata = MIME_BODY.Replace("[!subject]", textSubject.Text);
                    senddata = senddata.Replace("[!data]", richData.Text);
                } else
                    senddata = richData.Text;

                if (comboBox.SelectedItem.ToString() != "(none)")
                {
                    senddata =
                        senddata +
                        MIME_ATTACHMENT.Replace("[!filename]", Path.GetFileName(comboBox.SelectedItem.ToString()));
                    senddata = senddata.Replace("[!filetype]", "application/octet-stream");
                    senddata = senddata.Replace("[!filedata]", mail.filetoMIME(comboBox.SelectedItem.ToString()));
                }
            }

            cod = mail.SendData(senddata,out cmd, out resp);
            tabSMTPdebug("-> " + cmd.Replace(Convert.ToChar(10), Convert.ToChar(13)));
            tabSMTPdebug(resp);

            if (cod != 0)
            {
                mail.FinConexion();
                tabSMTPdebug("End connection.");
                return;
            }

            if (checkRsetNoop.Checked)
            {
                cod = mail.Rset(out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug(resp);

                cod = mail.Noop(out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug(resp);
            }

            cod = mail.Quit(out cmd, out resp);
            tabSMTPdebug("-> " + cmd);
            tabSMTPdebug(resp);


            mail.FinConexion();
            tabSMTPdebug("End connection.");
        }

        /***
         * Funcion: HostNameToIP()
         * Parametros:
         *    name: Nombre del Host name
         * Descripcion: Devuelve la dirección IP de un nombre de host. Si este no existe el resultado es
         *    una cadena vacia.
         ***/
        private string HostNameToIP(string name)
        {
            try
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(name);
                if (addresslist.Length > 0)
                    return addresslist[0].ToString();
                else
                    return "";
            }
            catch (Exception expt)
            {
                return "";
            }
        }

        /***
         * Funcion: tabSMTPbuttonVerificarHeloHost_Click()
         * Descripcion: Acción que verifica si la dirección del Helo Host es correcta.
         ***/
        private void tabSMTPbuttonVerificarHeloHost_Click(object sender, EventArgs e)
        {
            textHeloHost.Text = textHeloHost.Text.Trim();

            if (textHeloHost.Text == "")
            {
                MessageBox.Show(
                    "Field Helo host cannot be empty to be verified.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                return;
            }

            string howip = textHeloHost.Text;

            try
            {
                IPAddress[] addresslist = Dns.GetHostAddresses(howip);
                string ips = "";
                foreach (IPAddress theaddress in addresslist)
                {
                    ips = ips + theaddress.ToString() + "\r\n";
                }
                MessageBox.Show(
                    "Correct translation:\r\n" + ips, 
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception expt)
            {
                MessageBox.Show(
                    "Cannot translate domain " + textHeloHost.Text + ".\r\nIt is possible that it does not have translate or that you are a problem with DNS.", 
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;

            }
        }

        private void toolstrip(string txt)
        {
            status.Text = txt;
            statusStrip.Update();
        }

        /***
         * Funcion: tabMXbuttonResolver_Click
         * Descripcion: Busca todos los registros MX de un dominio y realiza diferentes pruebas:
         *    ping
         *    peso
         *    spam
         ***/
        private void tabMXbuttonResolver_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(tabMXExecute));
            thread.Start();
        }

        private void tabMXExecute()
        {
            bool primera;
            int time_av;
            int time_max;
            string time;
            string spam="", respuesta_smtp = "";
            smtpMail mail = new smtpMail();

            textDomainNane.Text = textDomainNane.Text.Trim();            

            if (textDomainNane.Text == "")
            {
                MessageBox.Show(
                    "A Domain name must write to translate.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                
                return;
            }

            ArrayList registros = new ArrayList();
            toolstrip("Search...");
            buttonResolver.Enabled = false;

            //--- buscamos todos los registros MX del dominio
            bool mx = NetUtils.DnsMx.GetMXRecords(textDomainNane.Text, out registros);

            if (mx)
            {
                int num_ips_progressbar = 0;

                Net netutils = new Net();

                toolstrip("Search... (search all SMTP servers of " + textDomainNane.Text.Trim() + ")");
                foreach (string[] s in registros)
                {
                    IPAddress[] addresslist = Dns.GetHostAddresses(s[0]);
                    num_ips_progressbar = num_ips_progressbar + addresslist.Length;
                }

                progressBar.Maximum = num_ips_progressbar;

                ListViewGroup group = new ListViewGroup(textDomainNane.Text,textDomainNane.Text);
                listViewMX.Groups.Add(group);

                foreach (string[] s in registros)
                {
                    IPAddress[] addresslist = Dns.GetHostAddresses(s[0]);
                    string[] linea = {};
                    primera = true;

                    toolstrip("Search... (search IPs of " + s[0].Trim() + ")");
                    foreach (IPAddress theaddress in addresslist)
                    {
                        time_av = 0;
                        time_max = 0;

                        toolstrip("Search... (ping to " + theaddress.ToString().Trim() + ")");
                        if (netutils.ping_time(theaddress.ToString(), Convert.ToByte(pingNumber.Value), out time_av, out time_max))
                            time = Convert.ToString(time_av) + "/" + Convert.ToString(time_max);
                        else
                            time = "No ping";

                        toolstrip("Search... (connecting to " + theaddress.ToString().Trim() + ":25)");
                        if (mail.Conexion(theaddress.ToString(), 0, Convert.ToString(25), out respuesta_smtp))
                            respuesta_smtp = "Ok";
                        else
                            respuesta_smtp = "Error";

                        toolstrip("Search... (search IP spammer " + theaddress.ToString().Trim() + ")");
                        if (!es_spam(theaddress.ToString(), out spam))
                            spam = "No";
    
                        if (primera)
                        {
                            linea = new string[] { s[0], theaddress.ToString(), s[1], respuesta_smtp, time, spam, s[2] };
                            primera = false;
                        }
                        else
                            linea = new string[] { "", theaddress.ToString(), "", respuesta_smtp, time, spam, s[2] };

                        
                        ListViewItem item = new ListViewItem(linea);
                        item.Group = group;
                        listViewMX.Items.Add(item);                      
                        listViewMX.Update();

                        progressBar.Value++;
                   }
                }
                listViewMX.Update();
                MessageBox.Show(
                    "Have been " + num_ips_progressbar + " SMTP server in " + textDomainNane.Text,
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            }
            else
                MessageBox.Show(
                    "Domain does not exist or it does not contain MX registers.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            buttonResolver.Enabled = true;
            progressBar.Value = 0;
            toolstrip("");
        }

        private void buttonBuscar_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            comboBox.Items.Clear();
            comboBox.Items.Add(openFileDialog.FileName);
            comboBox.Items.Add("(none)");
            comboBox.SelectedIndex = 0;
        }

        private void formCartero_Load(object sender, EventArgs e)
        {
            comboBox.SelectedIndex = 0;
        }

        private bool es_spam(string host, out string site_db)
        {
            Net netutils = new Net();

            bool spamhaus = netutils.GetSiteContents(URL_SPAMHAUS + host).Contains("is listed in");

            site_db = "";
            if (spamhaus)
                site_db = "spamhaus";

            return spamhaus;
        }

        private void buttonehloSMTP_Click(object sender, EventArgs e)
        {
            if (listViewMX.SelectedItems.Count > 0)
            {
                smtpMail mail = new smtpMail();

                string resp = "";
                string host = listViewMX.SelectedItems[0].SubItems[1].Text;
                if (mail.Conexion(host, 0, Convert.ToString(25), out resp))
                {
                    tabSMTPdebug("-> Connect to " + mail.host + ":" + mail.port + "...");
                    tabSMTPdebug("<- " + resp);
                }
                else
                    tabSMTPdebug("Connection error.");

                string cmd = "";
                resp = "";
                int cod;
                cod = mail.Ehlo("smtp1.google.com", out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug("<- " + resp);
                if (cod != 0)
                {
                    mail.FinConexion();
                    tabSMTPdebug("End connection.");
                    return;
                }

                cmd = "";
                resp = "";
                cod = mail.Quit(out cmd, out resp);
                tabSMTPdebug("-> " + cmd);
                tabSMTPdebug("<- " + resp);

                mail.FinConexion();
                tabSMTPdebug("End connection.");
            }
            else
                MessageBox.Show(
                    "It must select SMTP server.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
        }

        private void buttonWhois_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(whoisThread));
            thread.Start();
        }

        private void whoisThread()
        {
            buttonWhois.Enabled = false;
            Whois whois1 = new Whois();

            //--- buscamos dentro de whois.internic.com
            whois1.LookupComplete += new WhoisEventHandler(this.OnLookupComplete1);
            whois1.WhoisServer = "whois.internic.net";
            toolstrip("Search Whois... (" + whois1.WhoisServer + ")");
            whois1.Lookup(textBoxWhois.Text.Trim());                        
        }

        private void OnLookupComplete1(object sender, WhoisEventArgs e)
        { 
            string res_whois1 = e.WhoisInfo;

            if (res_whois1.IndexOf("No match for")>0)
            {
                richTextBoxWhois.Text = res_whois1;
                MessageBox.Show(
                    "The registry whois.internic.net database contains ONLY .COM, .NET, .EDU domains and Registrars.",
                    APP_NAME,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
                toolstrip("");
                buttonWhois.Enabled = true; 
                return;
            }

            int pos1 = res_whois1.IndexOf("Whois Server:",0);
            int pos2 = res_whois1.IndexOf("Referral URL:", 0);

            string host_whois2 = res_whois1.Substring(pos1 + 14, pos2 - pos1 - 14).Trim();

            Whois whois2 = new Whois();

            whois2.LookupComplete += new WhoisEventHandler(this.OnLookupComplete2);
            whois2.WhoisServer = host_whois2;
            toolstrip("Search Whois... (" + whois2.WhoisServer + ")");
            whois2.Lookup(textBoxWhois.Text.Trim()); 
        }

        private void OnLookupComplete2(object sender, WhoisEventArgs e)
        {
            richTextBoxWhois.Text = e.WhoisInfo;
            toolstrip("");
            buttonWhois.Enabled = true; 
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            tabControl.SelectedTab = tabSMTP;
            textHost.Text = listViewMX.SelectedItems[0].SubItems[1].Text;
        }

    }
}