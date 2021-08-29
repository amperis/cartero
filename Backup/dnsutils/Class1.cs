using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Collections;
using System.ComponentModel;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Net.NetworkInformation;

namespace NetUtils
{
    /**************************************************************************
     * Clase: Net
     * Objetivo: Utilidades de red
     * Funciones: IsValidIp(), ping_time(), GetSiteContents()
     **************************************************************************/
    public class Net
    {
        public Net()
        {
        }

        /*
         * Funcion: IsValidIP()
         * Objetivo: Determina si una cadena es una dirección IP valida
         * Entrada:
         *      ip: cadena con la dirección IP
         * Devuelve:
         *      bool: cierto si la dirección IP es valida.
        */ 
        public bool IsValidIP(string ip)
        {
            int i;
            const int NUMOCT = 4;
            int[] IP = new int[NUMOCT];
            string[] r = ip.Split('.');

            if (r.Length != NUMOCT)
            {
                return false;
            }
            else if (r.Length == NUMOCT)
            {
                for (i = 0; i <= (NUMOCT - 1); i++)
                {
                    try
                    {
                        IP[i] = int.Parse(r[i]);
                    }
                    catch
                    {
                        return false;
                    }
                }

                for (i = 0; i <= (NUMOCT - 1); i++)
                {
                    if (IP[i] < 0 || IP[i] > 255)
                        return false;
                }
            }

            return true;
        }

        /*
         * Funcion: GetSiteContents()
         * Objetivo: Descarga una pagina web.
         * Entrada:
         *      url: Dirección de la pagina Web de descargar.
         * Devuelve:
         *      string: El código HTML de la pagina Web.
        */
        public string GetSiteContents(string url)
        {
            StringBuilder sb = new StringBuilder();
            byte[] buf = new byte[8192];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Timeout = 1000;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                Stream resStream = response.GetResponseStream();
                string tempString = null;
                int count = 0;
                do
                {
                    count = resStream.Read(buf, 0, buf.Length);
                    if (count != 0)
                    {
                        tempString = Encoding.ASCII.GetString(buf, 0, count);
                        sb.Append(tempString);
                    }
                }
                while (count > 0);
            }
            catch
            {
            }

            return sb.ToString();
        }

        /*
         * Funcion: ping_time()
         * Objetivo: Hacer ping sobre una IP y calcular el tiempo de los paquetes
         * Entrada:
         *      host: dirección del host de destino
         *      count: numero de ping hacer
         * Devuelve:
         *      bool: cierto si se ha podido hacer algun ping
         *      time_av: tiempo medio de las respuestas en ms.
         *      time_max: tiempo máximo de una respuesta en ms.
        */
        public bool ping_time(string host, byte count, out int time_av, out int time_max)
        {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();
            time_av = 0;
            time_max = 0;
            bool ping = false; ;

            options.DontFragment = true;
            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";   //--- 32 bytes
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;

            for (int i = 0; i < count; i++)
            {
                PingReply reply = pingSender.Send(host, timeout, buffer, options);

                if (reply.Status == IPStatus.Success)
                {
                    time_av = time_av + Convert.ToInt32(reply.RoundtripTime);
                    time_max = Math.Max(time_max, Convert.ToInt32(reply.RoundtripTime));
                    ping = true;
                }
            }

            time_av = time_av / count;

            return ping;
        }
    }
    
    /**************************************************************************
     * Clase: DnsMx
     * Objetivo: Implementa las consultas a los registros MX de un dominio.
     * Funciones: GetMXRecords()
     **************************************************************************/
    public class DnsMx
    {
        public DnsMx()
        {
        }

        /*
         * Funcion: GetMXRecords()
         * Objetivo: Consulta los registros MX de un dominio.
         * Entrada:
         *      domain: nombre del dominio a buscar.
         * Devuelve:
         *      cierto: si el dominio puede resolverse y tiene registros MX asociados.
         *      registros: contiene la lista de registros MX.
        */ 
        public static bool GetMXRecords(string domain, out ArrayList registros)
        {

            IntPtr ptr1 = IntPtr.Zero;
            IntPtr ptr2 = IntPtr.Zero;
            MXRecord recMx;

            if (Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                throw new NotSupportedException();
            }
            
            ArrayList list1 = new ArrayList();
            bool hay_registros = false;

            try
            {
                int num1 = DnsMx.DnsQuery(ref domain, QueryTypes.DNS_TYPE_MX, QueryOptions.DNS_QUERY_BYPASS_CACHE, 0, ref ptr1, 0);
                if (num1 != 0)
                {
                    hay_registros = false;
                    if (num1 == 9003)
                        list1.Add("no DNS records");                        
                }

                for (ptr2 = ptr1; !ptr2.Equals(IntPtr.Zero); ptr2 = recMx.pNext)
                {
                    recMx = (MXRecord)Marshal.PtrToStructure(ptr2, typeof(MXRecord));
                    if (recMx.wType == 15)
                    {
                        string peso = Convert.ToString(recMx.wPreference);
                        string ttl = Convert.ToString(recMx.dwTtl);
                        string host = Marshal.PtrToStringAuto(recMx.pNameExchange);
                        string[] registro = { host, peso, ttl };
                        list1.Add(registro);
                        hay_registros = true;
                    }
                }
            }
            finally
            {
                DnsMx.DnsRecordListFree(ptr1, 0);
            }
            registros = list1;

            return hay_registros;
        }

        private enum QueryOptions
        {
            DNS_QUERY_ACCEPT_TRUNCATED_RESPONSE = 1,
            DNS_QUERY_BYPASS_CACHE = 8,
            DNS_QUERY_DONT_RESET_TTL_VALUES = 0x100000,
            DNS_QUERY_NO_HOSTS_FILE = 0x40,
            DNS_QUERY_NO_LOCAL_NAME = 0x20,
            DNS_QUERY_NO_NETBT = 0x80,
            DNS_QUERY_NO_RECURSION = 4,
            DNS_QUERY_NO_WIRE_QUERY = 0x10,
            DNS_QUERY_RESERVED = -16777216,
            DNS_QUERY_RETURN_MESSAGE = 0x200,
            DNS_QUERY_STANDARD = 0,
            DNS_QUERY_TREAT_AS_FQDN = 0x1000,
            DNS_QUERY_USE_TCP_ONLY = 2,
            DNS_QUERY_WIRE_ONLY = 0x100
        }

        private enum QueryTypes
        {
            DNS_TYPE_MX = 15
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MXRecord
        {
            public IntPtr pNext;
            public string pName;
            public short wType;
            public short wDataLength;
            public int flags;
            public int dwTtl;
            public int dwReserved;
            public IntPtr pNameExchange;
            public short wPreference;
            public short Pad;
        }

        [DllImport("dnsapi", EntryPoint = "DnsQuery_W", CharSet = CharSet.Unicode, SetLastError = true, ExactSpelling = true)]
        private static extern int DnsQuery([MarshalAs(UnmanagedType.VBByRefStr)]ref string pszName, QueryTypes wType, QueryOptions options, int aipServers, ref IntPtr ppQueryResults, int pReserved);

        [DllImport("dnsapi", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern void DnsRecordListFree(IntPtr pRecordList, int FreeType);
    }


    /**************************************************************************
     * Clase: smtpMail
     * Objetivo: Envia comandos SMTP a una IP:puerto
     * Funciones: smtpMail(), Conexion(), FinConexion(), Ehlo(), Hello(), From()
     *      Rcpt(), Data(), SendData(), Rset(), Noop(), Quit(), Base64Encode, 
     *      filetoMIME().
     **************************************************************************/
    public class smtpMail
    {
        public string host;
        public string port;
        public string from;
        public string rcpt;
        public string data;
        public string helohost;
        public byte retardo;

        TcpClient tcpclient;
        SocketException excp;

        private static bool IsConnectionSuccessful = false;
        private static Exception socketexception;
        private static ManualResetEvent TimeoutObject = new ManualResetEvent(false);
        private static NetworkStream stream;
        private static StreamReader streamReader;
        private static StreamWriter streamWriter;

        //--- constructor
        public smtpMail()
        {
            host = "";
            port = "";
            from = "";
            rcpt = "";
            data = "";
            retardo = 0;
        }

        private static void CallBackMethod(IAsyncResult asyncresult)
        {
            try
            {
                IsConnectionSuccessful = false;
                TcpClient tcpclient = asyncresult.AsyncState as TcpClient;

                if (tcpclient.Client != null)
                {
                    tcpclient.EndConnect(asyncresult);
                    IsConnectionSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                IsConnectionSuccessful = false;
                socketexception = ex;
            }
            finally
            {
                TimeoutObject.Set();
            }
        }

        /*
         * Funcion: Conexion()
         * Entrada
         *      resp: Parametro de salida con la respuesta del servidor 
         * Devuelve:
         *      true: La conexión se ha podido establecer
         *      false: No se ha podido establecer la conexion
         */
        public bool Conexion(string txthost, byte retardovalue, string txtport, out string resp)
        {
            host = txthost;
            port = txtport;

            retardo = retardovalue;

            TimeoutObject.Reset();
            socketexception = null;  

            IPAddress localAddr = IPAddress.Parse(host);
            IPEndPoint remoteEndPoint = new IPEndPoint(localAddr, Int32.Parse(port));

            string serverip = Convert.ToString(remoteEndPoint.Address);
            int serverport = remoteEndPoint.Port;           
            tcpclient = new TcpClient();
        
            tcpclient.BeginConnect(serverip, serverport, new AsyncCallback(CallBackMethod), tcpclient);

            if (TimeoutObject.WaitOne(5000, false))
            {
                if (IsConnectionSuccessful)
                {
                    stream = tcpclient.GetStream();
                    streamReader = new StreamReader(stream);
                    streamWriter = new StreamWriter(stream);
                    resp = streamReader.ReadLine();
                    while (streamReader.Peek() != -1)
                        resp = resp + "\r" + streamReader.ReadLine();
                    return true;

                }
                else
                {
                    throw socketexception;
                }
            }
            else
            {
                tcpclient.Close();
                resp = "Timeout";
                return false; 
            }
            return false;         
        }

        public void FinConexion()
        {
            tcpclient.Close();
        }

        /*
         * Funcion: Ehlo()
         * Entrada:
         *      txthost: Hostname de bienvenida
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salida con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte Ehlo(string txthost, out string cmd, out string resp)
        {
            helohost = txthost;
            resp = "";

            cmd = "EHLO " + helohost;
            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek()!=-1)
                    resp = resp + "\r"+streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;

            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: Helo()
         * Entrada:
         *      txthost: Hostname de bienvenida
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salida con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
         */
        public byte Helo(string txthost, out string cmd, out string resp)
        {
            helohost = txthost;
            resp = "";

            cmd = "HELO " + helohost;
            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;

            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: From()
         * Entrada:
         *      txtfrom: Dirección de correo del remitente
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
         */
        public byte From(string txtfrom, out string cmd, out string resp)
        {
            from = txtfrom;
            resp = "";

            cmd = "MAIL FROM:<" + from + ">";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }


        /*
         * Funcion: Rcpt()
         * Entrada:
         *      txtfrom: Dirección de correo del remitente
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte Rcpt(string txtrcpt, out string cmd, out string resp)
        {
            rcpt = txtrcpt;
            resp = "";

            cmd = "RCPT TO:<" + rcpt + ">";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
          * Funcion: Data()
          * Entrada:
          *      cmd: Parametro de salida con el comando que se ha enviado
          *      resp: Parametro de salid con la respuesta del servidor
          * Devuelve:
          *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
          *      1: El comando se ha enviado pero no ha sido aceptado
          *      10: Otros errores
         */
        public byte Data(out string cmd, out string resp)
        {
            resp = "";

            cmd = "DATA";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("354"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: SendData()
         * Entrada:
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte SendData(string txtdata, out string cmd, out string resp)
        {
            data = txtdata;
            resp = "";
            cmd = data;

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.WriteLine(".");
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: Rset()
         * Entrada:
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte Rset(out string cmd, out string resp)
        {
            resp = "";
            cmd = "RSET";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: Noop()
         * Entrada:
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte Noop(out string cmd, out string resp)
        {
            resp = "";
            cmd = "NOOP";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("250"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: Quit()
         * Entrada:
         *      cmd: Parametro de salida con el comando que se ha enviado
         *      resp: Parametro de salid con la respuesta del servidor
         * Devuelve:
         *      0: El comando se ha podido enviar correctamente y el servidor lo ha aceptado
         *      1: El comando se ha enviado pero no ha sido aceptado
         *      10: Otros errores
        */
        public byte Quit(out string cmd, out string resp)
        {
            resp = "";
            cmd = "QUIT";

            try
            {
                Thread.Sleep(retardo * 1000);

                streamWriter.WriteLine(cmd);
                streamWriter.Flush();
                resp = streamReader.ReadLine();
                while (streamReader.Peek() != -1)
                    resp = resp + "\r" + streamReader.ReadLine();

                if (!resp.Contains("221"))
                    return 1;
            }
            catch (SocketException e)
            {
                excp = e;
                tcpclient.Close();
                return 10;
            }

            return 0;
        }

        /*
         * Funcion: Base64Encode()
         * Entrada:
         *      input: cadena binaria a convertir
         * Devuelve:
         *      string: cadena en base64
        */        
        public string Base64Encode(byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        /*
         * Funcion: filetoMIME()
         * Entrada:
         *      filepath: ruta de archivo a convertir en formato MIME
         * Devuelve:
         *      string: contiene el archivo binario en formato MIME
        */ 
        public string filetoMIME(string filepath)
        {
            byte[] file = null;

            FileStream fstrm = new FileStream(@filepath, FileMode.Open, FileAccess.Read);
            BinaryReader reader = new BinaryReader(fstrm);

            file = new byte[reader.BaseStream.Length];

            for (int i = 0; i < reader.BaseStream.Length; i++)
            {
                file[i] = reader.ReadByte();
            }

            string fileAsString = Base64Encode(file);
            string fileAsMIME = "";

            for (int i = 0; i < fileAsString.Length; i++)
            {
                fileAsMIME = fileAsMIME + fileAsString[i];
                if ((i + 1) % 76 == 0)
                {
                    fileAsMIME = fileAsMIME + "\r\n";
                }

            }

            return fileAsMIME;
        }
    }


    public delegate void WhoisEventHandler(object sender, WhoisEventArgs e);

    public class WhoisEventArgs : EventArgs
    {
        public string WhoisInfo
        {
            get
            {
                return this.whoisInfo;
            }
        }
        public string WhoisServer
        {
            get
            {
                return this.whoisServer;
            }
        }

        private string whoisInfo;
        private string whoisServer;

        public WhoisEventArgs(string Info, string Server)
        {
            this.whoisInfo = Info;
            this.whoisServer = Server;
        }
    }

    /**************************************************************************
     * Clase: Whois
     * Objetivo: 
     * Funciones: 
     **************************************************************************/
    public class Whois
    {
        public string WhoisServer
        {
            get
            {
                return this.whoisServer;
            }
            set
            {
                this.whoisServer = value;
            }
        }

        public event WhoisEventHandler LookupComplete;


        private string whoisServer = "";

        public void Lookup(string Domain)
        {
            string result = "";
            string[] parts = new string[] { };

            // Knock off http and www if it's in the Domain
            if (Domain.StartsWith("http://"))
            {
                Domain = Domain.Replace("http://", "");
            }

            if (Domain.StartsWith("www."))
            {
                Domain = Domain.Substring(4, Domain.Length - 4);
            }

            if (Domain.IndexOf(".tv") != -1 || Domain.IndexOf(".pro") != -1 || Domain.IndexOf(".name") != -1)
            {
                // As result says - certain domain authorities like to keep their whois service private.
                // There maybe extra tlds to add.
                result = "'.pro','.name', and '.tv' domains require an account for a whois";
            }
            else
            {
                if (Domain.IndexOf(".") != -1)
                {
                    // Find the whois server for the domain ourselves, if non set.
                    if (this.whoisServer == "")
                    {
                        this.whoisServer = this.getWhoisServer(Domain);
                    }

                    // Connect to the whois server
                    TcpClient tcpClient = new TcpClient();
                    tcpClient.Connect(this.whoisServer, 43);
                    NetworkStream networkStream = tcpClient.GetStream();

                    // Send the domain name to the whois server
                    byte[] buffer = ASCIIEncoding.ASCII.GetBytes(Domain + "\r\n");
                    networkStream.Write(buffer, 0, buffer.Length);

                    // Read back the results
                    buffer = new byte[8192];
                    int i = networkStream.Read(buffer, 0, buffer.Length);
                    while (i > 0)
                    {
                        i = networkStream.Read(buffer, 0, buffer.Length);
                        result += ASCIIEncoding.ASCII.GetString(buffer); ;
                    }
                    networkStream.Close();
                    tcpClient.Close();
                }
                else
                {
                    result = "Please enter a valid domain name.";
                }
            }

            // Fire event with the info of the lookup
            if (this.LookupComplete != null)
            {
                WhoisEventArgs whoisEventArgs = new WhoisEventArgs(result, this.whoisServer);
                this.LookupComplete(this, whoisEventArgs);
            }
        }

        private string getWhoisServer(string domainName)
        {
            string[] parts = domainName.Split('.');
            string tld = parts[parts.Length - 1];
            string host = tld + ".whois-servers.net";

            // .tk doesn't resolve, but it's whois server is public
            if (tld == "tk")
            {
                return "whois.dot.tk";
            }

            try
            {
                IPHostEntry ipHostEntry = Dns.GetHostByName(host);

                if (ipHostEntry.HostName == host)
                {
                    // No entry found, use internic as default
                    host = "whois.internic.net";
                }
                else
                {
                    host = ipHostEntry.HostName;
                }

                return host;
            }
            catch
            {
                host = "whois.internic.net";
                return host;
            }
        }
    }


}
