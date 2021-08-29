namespace cartero
{
    partial class formCartero
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(formCartero));
            this.barraBotones = new System.Windows.Forms.ToolStrip();
            this.botonRefrescar = new System.Windows.Forms.ToolStripButton();
            this.botonSalir = new System.Windows.Forms.ToolStripButton();
            this.botonAcercade = new System.Windows.Forms.ToolStripButton();
            this.buttonBorrarDebug = new System.Windows.Forms.ToolStripButton();
            this.buttonSalir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonAcercaDe = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabSMTP = new System.Windows.Forms.TabPage();
            this.buttonEnviar = new System.Windows.Forms.Button();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.checkRsetNoop = new System.Windows.Forms.CheckBox();
            this.retardo = new System.Windows.Forms.NumericUpDown();
            this.checkVirus = new System.Windows.Forms.CheckBox();
            this.buttonBuscar = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.listDebug1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonVerificarHeloHost = new System.Windows.Forms.Button();
            this.textHeloHost = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textFrom = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.typeEhlo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.textSubject = new System.Windows.Forms.TextBox();
            this.textPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.typeHelo = new System.Windows.Forms.RadioButton();
            this.textRcpt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richData = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.tabMX = new System.Windows.Forms.TabPage();
            this.listViewMX = new System.Windows.Forms.ListView();
            this.columnHost = new System.Windows.Forms.ColumnHeader();
            this.columnIP = new System.Windows.Forms.ColumnHeader();
            this.columnMX = new System.Windows.Forms.ColumnHeader();
            this.columnSMTP = new System.Windows.Forms.ColumnHeader();
            this.columnAlive = new System.Windows.Forms.ColumnHeader();
            this.columnSpam = new System.Windows.Forms.ColumnHeader();
            this.columnTTL = new System.Windows.Forms.ColumnHeader();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label10 = new System.Windows.Forms.Label();
            this.pingNumber = new System.Windows.Forms.NumericUpDown();
            this.buttonResolver = new System.Windows.Forms.Button();
            this.textDomainNane = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tabWhois = new System.Windows.Forms.TabPage();
            this.richTextBoxWhois = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxWhois = new System.Windows.Forms.TextBox();
            this.buttonWhois = new System.Windows.Forms.Button();
            this.tabUpdates = new System.Windows.Forms.TabPage();
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.barraBotones.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabSMTP.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.retardo)).BeginInit();
            this.tabMX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingNumber)).BeginInit();
            this.tabWhois.SuspendLayout();
            this.tabUpdates.SuspendLayout();
            this.SuspendLayout();
            // 
            // barraBotones
            // 
            this.barraBotones.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonRefrescar,
            this.botonSalir,
            this.botonAcercade});
            this.barraBotones.Location = new System.Drawing.Point(0, 0);
            this.barraBotones.Name = "barraBotones";
            this.barraBotones.Size = new System.Drawing.Size(746, 25);
            this.barraBotones.TabIndex = 0;
            this.barraBotones.Text = "toolStrip1";
            // 
            // botonRefrescar
            // 
            this.botonRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonRefrescar.Image = global::cartero.Properties.Resources.refrescar;
            this.botonRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonRefrescar.Name = "botonRefrescar";
            this.botonRefrescar.Size = new System.Drawing.Size(23, 22);
            this.botonRefrescar.Text = "Clear";
            this.botonRefrescar.Click += new System.EventHandler(this.buttonBorrarDebug_Click);
            // 
            // botonSalir
            // 
            this.botonSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonSalir.Image = global::cartero.Properties.Resources.atras;
            this.botonSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonSalir.Name = "botonSalir";
            this.botonSalir.Size = new System.Drawing.Size(23, 22);
            this.botonSalir.Text = "Exit";
            this.botonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // botonAcercade
            // 
            this.botonAcercade.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonAcercade.Image = global::cartero.Properties.Resources.about;
            this.botonAcercade.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonAcercade.Name = "botonAcercade";
            this.botonAcercade.Size = new System.Drawing.Size(23, 22);
            this.botonAcercade.Text = "About...";
            this.botonAcercade.Click += new System.EventHandler(this.buttonAcercaDe_Click);
            // 
            // buttonBorrarDebug
            // 
            this.buttonBorrarDebug.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonBorrarDebug.Image = global::cartero.Properties.Resources.refrescar;
            this.buttonBorrarDebug.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonBorrarDebug.Name = "buttonBorrarDebug";
            this.buttonBorrarDebug.Size = new System.Drawing.Size(23, 22);
            this.buttonBorrarDebug.Text = "Clear debug";
            this.buttonBorrarDebug.Click += new System.EventHandler(this.buttonBorrarDebug_Click);
            // 
            // buttonSalir
            // 
            this.buttonSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonSalir.Image = global::cartero.Properties.Resources.atras;
            this.buttonSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonSalir.Name = "buttonSalir";
            this.buttonSalir.Size = new System.Drawing.Size(23, 22);
            this.buttonSalir.Text = "Exit";
            this.buttonSalir.Click += new System.EventHandler(this.buttonSalir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // buttonAcercaDe
            // 
            this.buttonAcercaDe.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.buttonAcercaDe.Image = global::cartero.Properties.Resources.about;
            this.buttonAcercaDe.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonAcercaDe.Name = "buttonAcercaDe";
            this.buttonAcercaDe.Size = new System.Drawing.Size(23, 22);
            this.buttonAcercaDe.Text = "About to...";
            this.buttonAcercaDe.Click += new System.EventHandler(this.buttonAcercaDe_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.statusStrip.Location = new System.Drawing.Point(0, 598);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(746, 22);
            this.statusStrip.TabIndex = 1;
            this.statusStrip.Text = "statusStrip1";
            // 
            // status
            // 
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripLabel
            // 
            this.toolStripLabel.Name = "toolStripLabel";
            this.toolStripLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tabSMTP);
            this.tabControl.Controls.Add(this.tabMX);
            this.tabControl.Controls.Add(this.tabWhois);
            this.tabControl.Controls.Add(this.tabUpdates);
            this.tabControl.Location = new System.Drawing.Point(0, 28);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(746, 567);
            this.tabControl.TabIndex = 2;
            // 
            // tabSMTP
            // 
            this.tabSMTP.Controls.Add(this.buttonEnviar);
            this.tabSMTP.Controls.Add(this.comboBox);
            this.tabSMTP.Controls.Add(this.checkRsetNoop);
            this.tabSMTP.Controls.Add(this.retardo);
            this.tabSMTP.Controls.Add(this.checkVirus);
            this.tabSMTP.Controls.Add(this.buttonBuscar);
            this.tabSMTP.Controls.Add(this.label8);
            this.tabSMTP.Controls.Add(this.listDebug1);
            this.tabSMTP.Controls.Add(this.label1);
            this.tabSMTP.Controls.Add(this.buttonVerificarHeloHost);
            this.tabSMTP.Controls.Add(this.textHeloHost);
            this.tabSMTP.Controls.Add(this.label7);
            this.tabSMTP.Controls.Add(this.textFrom);
            this.tabSMTP.Controls.Add(this.label6);
            this.tabSMTP.Controls.Add(this.typeEhlo);
            this.tabSMTP.Controls.Add(this.label5);
            this.tabSMTP.Controls.Add(this.textSubject);
            this.tabSMTP.Controls.Add(this.textPort);
            this.tabSMTP.Controls.Add(this.label3);
            this.tabSMTP.Controls.Add(this.typeHelo);
            this.tabSMTP.Controls.Add(this.textRcpt);
            this.tabSMTP.Controls.Add(this.label2);
            this.tabSMTP.Controls.Add(this.richData);
            this.tabSMTP.Controls.Add(this.label4);
            this.tabSMTP.Controls.Add(this.textHost);
            this.tabSMTP.Location = new System.Drawing.Point(4, 25);
            this.tabSMTP.Name = "tabSMTP";
            this.tabSMTP.Padding = new System.Windows.Forms.Padding(3);
            this.tabSMTP.Size = new System.Drawing.Size(738, 538);
            this.tabSMTP.TabIndex = 0;
            this.tabSMTP.Text = "SMTP";
            this.tabSMTP.UseVisualStyleBackColor = true;
            // 
            // buttonEnviar
            // 
            this.buttonEnviar.Location = new System.Drawing.Point(260, 4);
            this.buttonEnviar.Name = "buttonEnviar";
            this.buttonEnviar.Size = new System.Drawing.Size(75, 23);
            this.buttonEnviar.TabIndex = 20;
            this.buttonEnviar.Text = "Send";
            this.buttonEnviar.UseVisualStyleBackColor = true;
            this.buttonEnviar.Click += new System.EventHandler(this.tabSMTPbuttonEnviar_Click);
            // 
            // comboBox
            // 
            this.comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "(none)"});
            this.comboBox.Location = new System.Drawing.Point(11, 441);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(166, 21);
            this.comboBox.TabIndex = 21;
            // 
            // checkRsetNoop
            // 
            this.checkRsetNoop.AutoSize = true;
            this.checkRsetNoop.Location = new System.Drawing.Point(10, 503);
            this.checkRsetNoop.Name = "checkRsetNoop";
            this.checkRsetNoop.Size = new System.Drawing.Size(148, 17);
            this.checkRsetNoop.TabIndex = 13;
            this.checkRsetNoop.Text = "RSET and  NOOP finalize";
            this.checkRsetNoop.UseVisualStyleBackColor = true;
            // 
            // retardo
            // 
            this.retardo.Location = new System.Drawing.Point(686, 6);
            this.retardo.Name = "retardo";
            this.retardo.Size = new System.Drawing.Size(43, 20);
            this.retardo.TabIndex = 14;
            // 
            // checkVirus
            // 
            this.checkVirus.AutoSize = true;
            this.checkVirus.Location = new System.Drawing.Point(10, 480);
            this.checkVirus.Name = "checkVirus";
            this.checkVirus.Size = new System.Drawing.Size(126, 17);
            this.checkVirus.TabIndex = 12;
            this.checkVirus.Text = "Virus attach  (EICAR)";
            this.checkVirus.UseVisualStyleBackColor = true;
            // 
            // buttonBuscar
            // 
            this.buttonBuscar.Location = new System.Drawing.Point(183, 440);
            this.buttonBuscar.Name = "buttonBuscar";
            this.buttonBuscar.Size = new System.Drawing.Size(59, 23);
            this.buttonBuscar.TabIndex = 11;
            this.buttonBuscar.Text = "Open...";
            this.buttonBuscar.UseVisualStyleBackColor = true;
            this.buttonBuscar.Click += new System.EventHandler(this.buttonBuscar_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(523, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(161, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Delay between commands (seg.)";
            // 
            // listDebug1
            // 
            this.listDebug1.BackColor = System.Drawing.Color.White;
            this.listDebug1.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listDebug1.ForeColor = System.Drawing.Color.Black;
            this.listDebug1.FormattingEnabled = true;
            this.listDebug1.HorizontalScrollbar = true;
            this.listDebug1.ItemHeight = 15;
            this.listDebug1.Location = new System.Drawing.Point(263, 33);
            this.listDebug1.Name = "listDebug1";
            this.listDebug1.Size = new System.Drawing.Size(469, 499);
            this.listDebug1.TabIndex = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Host IP or host name";
            // 
            // buttonVerificarHeloHost
            // 
            this.buttonVerificarHeloHost.Location = new System.Drawing.Point(183, 77);
            this.buttonVerificarHeloHost.Name = "buttonVerificarHeloHost";
            this.buttonVerificarHeloHost.Size = new System.Drawing.Size(59, 23);
            this.buttonVerificarHeloHost.TabIndex = 6;
            this.buttonVerificarHeloHost.Text = "Verify";
            this.buttonVerificarHeloHost.UseVisualStyleBackColor = true;
            this.buttonVerificarHeloHost.Click += new System.EventHandler(this.tabSMTPbuttonVerificarHeloHost_Click);
            // 
            // textHeloHost
            // 
            this.textHeloHost.Location = new System.Drawing.Point(11, 79);
            this.textHeloHost.MaxLength = 255;
            this.textHeloHost.Name = "textHeloHost";
            this.textHeloHost.Size = new System.Drawing.Size(166, 20);
            this.textHeloHost.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 208);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Subject";
            // 
            // textFrom
            // 
            this.textFrom.Location = new System.Drawing.Point(11, 127);
            this.textFrom.MaxLength = 255;
            this.textFrom.Name = "textFrom";
            this.textFrom.Size = new System.Drawing.Size(221, 20);
            this.textFrom.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 426);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(54, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Attach file";
            // 
            // typeEhlo
            // 
            this.typeEhlo.AutoSize = true;
            this.typeEhlo.Checked = true;
            this.typeEhlo.Location = new System.Drawing.Point(10, 59);
            this.typeEhlo.Name = "typeEhlo";
            this.typeEhlo.Size = new System.Drawing.Size(68, 17);
            this.typeEhlo.TabIndex = 3;
            this.typeEhlo.TabStop = true;
            this.typeEhlo.Text = "ehlo host";
            this.typeEhlo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 257);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Data";
            // 
            // textSubject
            // 
            this.textSubject.Location = new System.Drawing.Point(11, 224);
            this.textSubject.MaxLength = 1024;
            this.textSubject.Name = "textSubject";
            this.textSubject.Size = new System.Drawing.Size(221, 20);
            this.textSubject.TabIndex = 9;
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(183, 25);
            this.textPort.MaxLength = 5;
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(49, 20);
            this.textPort.TabIndex = 2;
            this.textPort.Text = "25";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "From";
            // 
            // typeHelo
            // 
            this.typeHelo.AutoSize = true;
            this.typeHelo.Location = new System.Drawing.Point(84, 59);
            this.typeHelo.Name = "typeHelo";
            this.typeHelo.Size = new System.Drawing.Size(68, 17);
            this.typeHelo.TabIndex = 4;
            this.typeHelo.TabStop = true;
            this.typeHelo.Text = "helo host";
            this.typeHelo.UseVisualStyleBackColor = true;
            // 
            // textRcpt
            // 
            this.textRcpt.Location = new System.Drawing.Point(11, 176);
            this.textRcpt.MaxLength = 255;
            this.textRcpt.Name = "textRcpt";
            this.textRcpt.Size = new System.Drawing.Size(221, 20);
            this.textRcpt.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(180, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Port";
            // 
            // richData
            // 
            this.richData.Location = new System.Drawing.Point(10, 273);
            this.richData.MaxLength = 1024;
            this.richData.Name = "richData";
            this.richData.Size = new System.Drawing.Size(222, 132);
            this.richData.TabIndex = 10;
            this.richData.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Rcpt";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(11, 25);
            this.textHost.MaxLength = 15;
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(166, 20);
            this.textHost.TabIndex = 1;
            // 
            // tabMX
            // 
            this.tabMX.Controls.Add(this.listViewMX);
            this.tabMX.Controls.Add(this.progressBar);
            this.tabMX.Controls.Add(this.label10);
            this.tabMX.Controls.Add(this.pingNumber);
            this.tabMX.Controls.Add(this.buttonResolver);
            this.tabMX.Controls.Add(this.textDomainNane);
            this.tabMX.Controls.Add(this.label9);
            this.tabMX.Location = new System.Drawing.Point(4, 25);
            this.tabMX.Name = "tabMX";
            this.tabMX.Padding = new System.Windows.Forms.Padding(3);
            this.tabMX.Size = new System.Drawing.Size(738, 538);
            this.tabMX.TabIndex = 1;
            this.tabMX.Text = "MX";
            this.tabMX.UseVisualStyleBackColor = true;
            // 
            // listViewMX
            // 
            this.listViewMX.BackColor = System.Drawing.Color.White;
            this.listViewMX.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHost,
            this.columnIP,
            this.columnMX,
            this.columnSMTP,
            this.columnAlive,
            this.columnSpam,
            this.columnTTL});
            this.listViewMX.FullRowSelect = true;
            this.listViewMX.Location = new System.Drawing.Point(185, 0);
            this.listViewMX.Name = "listViewMX";
            this.listViewMX.Size = new System.Drawing.Size(545, 532);
            this.listViewMX.TabIndex = 12;
            this.listViewMX.UseCompatibleStateImageBehavior = false;
            this.listViewMX.View = System.Windows.Forms.View.Details;
            this.listViewMX.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // columnHost
            // 
            this.columnHost.Text = "Host";
            this.columnHost.Width = 110;
            // 
            // columnIP
            // 
            this.columnIP.Text = "IP";
            this.columnIP.Width = 98;
            // 
            // columnMX
            // 
            this.columnMX.Text = "MX";
            // 
            // columnSMTP
            // 
            this.columnSMTP.Text = "SMTP";
            // 
            // columnAlive
            // 
            this.columnAlive.Text = "Alive (Av/Max)";
            this.columnAlive.Width = 89;
            // 
            // columnSpam
            // 
            this.columnSpam.Text = "Spam";
            this.columnSpam.Width = 56;
            // 
            // columnTTL
            // 
            this.columnTTL.Text = "TTL";
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.progressBar.Location = new System.Drawing.Point(8, 78);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(157, 15);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(5, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 13);
            this.label10.TabIndex = 17;
            this.label10.Text = "Ping number";
            // 
            // pingNumber
            // 
            this.pingNumber.Location = new System.Drawing.Point(8, 121);
            this.pingNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pingNumber.Name = "pingNumber";
            this.pingNumber.Size = new System.Drawing.Size(48, 20);
            this.pingNumber.TabIndex = 16;
            this.pingNumber.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // buttonResolver
            // 
            this.buttonResolver.Location = new System.Drawing.Point(8, 49);
            this.buttonResolver.Name = "buttonResolver";
            this.buttonResolver.Size = new System.Drawing.Size(75, 23);
            this.buttonResolver.TabIndex = 15;
            this.buttonResolver.Text = "Search";
            this.buttonResolver.UseVisualStyleBackColor = true;
            this.buttonResolver.Click += new System.EventHandler(this.tabMXbuttonResolver_Click);
            // 
            // textDomainNane
            // 
            this.textDomainNane.Location = new System.Drawing.Point(8, 23);
            this.textDomainNane.MaxLength = 255;
            this.textDomainNane.Name = "textDomainNane";
            this.textDomainNane.Size = new System.Drawing.Size(157, 20);
            this.textDomainNane.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(5, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 13;
            this.label9.Text = "Domain name";
            // 
            // tabWhois
            // 
            this.tabWhois.Controls.Add(this.richTextBoxWhois);
            this.tabWhois.Controls.Add(this.label11);
            this.tabWhois.Controls.Add(this.textBoxWhois);
            this.tabWhois.Controls.Add(this.buttonWhois);
            this.tabWhois.Location = new System.Drawing.Point(4, 25);
            this.tabWhois.Name = "tabWhois";
            this.tabWhois.Size = new System.Drawing.Size(738, 538);
            this.tabWhois.TabIndex = 3;
            this.tabWhois.Text = "Whois";
            this.tabWhois.UseVisualStyleBackColor = true;
            // 
            // richTextBoxWhois
            // 
            this.richTextBoxWhois.BackColor = System.Drawing.Color.White;
            this.richTextBoxWhois.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxWhois.Location = new System.Drawing.Point(187, 7);
            this.richTextBoxWhois.Name = "richTextBoxWhois";
            this.richTextBoxWhois.Size = new System.Drawing.Size(543, 528);
            this.richTextBoxWhois.TabIndex = 3;
            this.richTextBoxWhois.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 7);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Domain name";
            // 
            // textBoxWhois
            // 
            this.textBoxWhois.Location = new System.Drawing.Point(8, 23);
            this.textBoxWhois.MaxLength = 255;
            this.textBoxWhois.Name = "textBoxWhois";
            this.textBoxWhois.Size = new System.Drawing.Size(157, 20);
            this.textBoxWhois.TabIndex = 1;
            // 
            // buttonWhois
            // 
            this.buttonWhois.Location = new System.Drawing.Point(8, 49);
            this.buttonWhois.Name = "buttonWhois";
            this.buttonWhois.Size = new System.Drawing.Size(75, 23);
            this.buttonWhois.TabIndex = 0;
            this.buttonWhois.Text = "Search";
            this.buttonWhois.UseVisualStyleBackColor = true;
            this.buttonWhois.Click += new System.EventHandler(this.buttonWhois_Click);
            // 
            // tabUpdates
            // 
            this.tabUpdates.Controls.Add(this.webBrowser);
            this.tabUpdates.Location = new System.Drawing.Point(4, 25);
            this.tabUpdates.Name = "tabUpdates";
            this.tabUpdates.Size = new System.Drawing.Size(738, 538);
            this.tabUpdates.TabIndex = 2;
            this.tabUpdates.Text = "Updates";
            this.tabUpdates.UseVisualStyleBackColor = true;
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 0);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(738, 538);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.Url = new System.Uri("http://code.google.com/p/cartero/downloads/list", System.UriKind.Absolute);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "All (*.*)|*.*|Image  (jpg)|*.jpg|Word document (doc)|*.doc|Video (avi)|*.avi|Adob" +
                "e Reader (pdf)|*.pdf";
            this.openFileDialog.SupportMultiDottedExtensions = true;
            this.openFileDialog.Title = "Attach this file";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // formCartero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(746, 620);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.barraBotones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "formCartero";
            this.Text = "Cartero";
            this.Load += new System.EventHandler(this.formCartero_Load);
            this.barraBotones.ResumeLayout(false);
            this.barraBotones.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabSMTP.ResumeLayout(false);
            this.tabSMTP.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.retardo)).EndInit();
            this.tabMX.ResumeLayout(false);
            this.tabMX.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pingNumber)).EndInit();
            this.tabWhois.ResumeLayout(false);
            this.tabWhois.PerformLayout();
            this.tabUpdates.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip barraBotones;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabSMTP;
        private System.Windows.Forms.Button buttonEnviar;
        private System.Windows.Forms.ListBox listDebug1;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.ToolStripButton buttonBorrarDebug;
        private System.Windows.Forms.ToolStripButton buttonSalir;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonAcercaDe;
        private System.Windows.Forms.TextBox textHeloHost;
        private System.Windows.Forms.RadioButton typeEhlo;
        private System.Windows.Forms.RadioButton typeHelo;
        private System.Windows.Forms.Button buttonVerificarHeloHost;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textFrom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textRcpt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richData;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textSubject;
        private System.Windows.Forms.CheckBox checkRsetNoop;
        private System.Windows.Forms.CheckBox checkVirus;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown retardo;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Button buttonBuscar;
        private System.Windows.Forms.TabPage tabUpdates;
        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.TabPage tabMX;
        private System.Windows.Forms.ListView listViewMX;
        private System.Windows.Forms.ColumnHeader columnHost;
        private System.Windows.Forms.ColumnHeader columnIP;
        private System.Windows.Forms.ColumnHeader columnMX;
        private System.Windows.Forms.ColumnHeader columnSMTP;
        private System.Windows.Forms.ColumnHeader columnAlive;
        private System.Windows.Forms.ColumnHeader columnSpam;
        private System.Windows.Forms.ColumnHeader columnTTL;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown pingNumber;
        private System.Windows.Forms.Button buttonResolver;
        private System.Windows.Forms.TextBox textDomainNane;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabPage tabWhois;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxWhois;
        private System.Windows.Forms.Button buttonWhois;
        private System.Windows.Forms.RichTextBox richTextBoxWhois;
        private System.Windows.Forms.ToolStripButton botonRefrescar;
        private System.Windows.Forms.ToolStripButton botonSalir;
        private System.Windows.Forms.ToolStripButton botonAcercade;
        private System.Windows.Forms.ToolStripStatusLabel status;
    }
}

