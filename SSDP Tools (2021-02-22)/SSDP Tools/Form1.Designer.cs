
namespace SSDP_Tool
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mInterfaceCombo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.Source_IP_Address = new System.Windows.Forms.Label();
            this.Source_IP_Address_Text = new System.Windows.Forms.TextBox();
            this.Destination_IP_Address = new System.Windows.Forms.Label();
            this.Destination_IP_Address_Text = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SpeedBar = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.PacketSpeed_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Packet_Send_labal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Source_Mac_Address_Text = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Destination_Mac_Address_Text = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Notify_Message = new System.Windows.Forms.ToolStripStatusLabel();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mInterfaceCombo
            // 
            this.mInterfaceCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.mInterfaceCombo.FormattingEnabled = true;
            this.mInterfaceCombo.Location = new System.Drawing.Point(184, 36);
            this.mInterfaceCombo.Name = "mInterfaceCombo";
            this.mInterfaceCombo.Size = new System.Drawing.Size(258, 20);
            this.mInterfaceCombo.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.SteelBlue;
            this.button1.Location = new System.Drawing.Point(448, 32);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.DimGray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.listView1.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(28, 70);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(509, 178);
            this.listView1.TabIndex = 2;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 70;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Source";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Destination";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 140;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Protocol";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 70;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Length";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 80;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("궁서체", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(144, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "10";
            this.label1.Visible = false;
            // 
            // Source_IP_Address
            // 
            this.Source_IP_Address.AutoSize = true;
            this.Source_IP_Address.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Source_IP_Address.Location = new System.Drawing.Point(22, 321);
            this.Source_IP_Address.Name = "Source_IP_Address";
            this.Source_IP_Address.Size = new System.Drawing.Size(111, 12);
            this.Source_IP_Address.TabIndex = 5;
            this.Source_IP_Address.Text = "Source IP Address";
            this.Source_IP_Address.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Source_IP_Address_MouseClick);
            this.Source_IP_Address.MouseLeave += new System.EventHandler(this.Source_IP_Address_MouseLeave);
            this.Source_IP_Address.MouseHover += new System.EventHandler(this.Source_IP_Address_MouseHover);
            // 
            // Source_IP_Address_Text
            // 
            this.Source_IP_Address_Text.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Source_IP_Address_Text.Enabled = false;
            this.Source_IP_Address_Text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Source_IP_Address_Text.ForeColor = System.Drawing.Color.Black;
            this.Source_IP_Address_Text.Location = new System.Drawing.Point(24, 347);
            this.Source_IP_Address_Text.Name = "Source_IP_Address_Text";
            this.Source_IP_Address_Text.Size = new System.Drawing.Size(129, 26);
            this.Source_IP_Address_Text.TabIndex = 7;
            // 
            // Destination_IP_Address
            // 
            this.Destination_IP_Address.AutoSize = true;
            this.Destination_IP_Address.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Destination_IP_Address.Location = new System.Drawing.Point(20, 393);
            this.Destination_IP_Address.Name = "Destination_IP_Address";
            this.Destination_IP_Address.Size = new System.Drawing.Size(133, 12);
            this.Destination_IP_Address.TabIndex = 9;
            this.Destination_IP_Address.Text = "Destination IP Address";
            this.Destination_IP_Address.MouseLeave += new System.EventHandler(this.Destination_IP_Address_MouseLeave);
            this.Destination_IP_Address.MouseHover += new System.EventHandler(this.Destination_IP_Address_MouseHover);
            // 
            // Destination_IP_Address_Text
            // 
            this.Destination_IP_Address_Text.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Destination_IP_Address_Text.Enabled = false;
            this.Destination_IP_Address_Text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Destination_IP_Address_Text.Location = new System.Drawing.Point(22, 418);
            this.Destination_IP_Address_Text.Name = "Destination_IP_Address_Text";
            this.Destination_IP_Address_Text.Size = new System.Drawing.Size(131, 26);
            this.Destination_IP_Address_Text.TabIndex = 11;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.Enabled = false;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(448, 344);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(83, 29);
            this.button3.TabIndex = 16;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button4.Enabled = false;
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(448, 418);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 31);
            this.button4.TabIndex = 18;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // SpeedBar
            // 
            this.SpeedBar.Location = new System.Drawing.Point(22, 262);
            this.SpeedBar.Name = "SpeedBar";
            this.SpeedBar.Size = new System.Drawing.Size(527, 45);
            this.SpeedBar.TabIndex = 20;
            this.SpeedBar.Scroll += new System.EventHandler(this.SpeedBar_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(350, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "Packet Speed";
            // 
            // PacketSpeed_label
            // 
            this.PacketSpeed_label.AutoSize = true;
            this.PacketSpeed_label.ForeColor = System.Drawing.Color.LightCoral;
            this.PacketSpeed_label.Location = new System.Drawing.Point(384, 353);
            this.PacketSpeed_label.Name = "PacketSpeed_label";
            this.PacketSpeed_label.Size = new System.Drawing.Size(11, 12);
            this.PacketSpeed_label.TabIndex = 24;
            this.PacketSpeed_label.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(350, 395);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 12);
            this.label6.TabIndex = 26;
            this.label6.Text = "Packet Send";
            // 
            // Packet_Send_labal
            // 
            this.Packet_Send_labal.AutoSize = true;
            this.Packet_Send_labal.ForeColor = System.Drawing.Color.Red;
            this.Packet_Send_labal.Location = new System.Drawing.Point(384, 418);
            this.Packet_Send_labal.Name = "Packet_Send_labal";
            this.Packet_Send_labal.Size = new System.Drawing.Size(11, 12);
            this.Packet_Send_labal.TabIndex = 28;
            this.Packet_Send_labal.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(154, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 29;
            this.label2.Text = "Source Mac Address";
            // 
            // Source_Mac_Address_Text
            // 
            this.Source_Mac_Address_Text.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Source_Mac_Address_Text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Source_Mac_Address_Text.ForeColor = System.Drawing.Color.Black;
            this.Source_Mac_Address_Text.Location = new System.Drawing.Point(161, 347);
            this.Source_Mac_Address_Text.Name = "Source_Mac_Address_Text";
            this.Source_Mac_Address_Text.Size = new System.Drawing.Size(175, 26);
            this.Source_Mac_Address_Text.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(159, 393);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 12);
            this.label4.TabIndex = 31;
            this.label4.Text = "Destination Mac Address";
            // 
            // Destination_Mac_Address_Text
            // 
            this.Destination_Mac_Address_Text.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Destination_Mac_Address_Text.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Destination_Mac_Address_Text.ForeColor = System.Drawing.Color.Black;
            this.Destination_Mac_Address_Text.Location = new System.Drawing.Point(161, 418);
            this.Destination_Mac_Address_Text.Name = "Destination_Mac_Address_Text";
            this.Destination_Mac_Address_Text.Size = new System.Drawing.Size(175, 26);
            this.Destination_Mac_Address_Text.TabIndex = 32;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(448, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 23);
            this.button2.TabIndex = 33;
            this.button2.Text = "↕";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.statusStrip1.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Notify_Message});
            this.statusStrip1.Location = new System.Drawing.Point(20, 457);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(517, 22);
            this.statusStrip1.TabIndex = 34;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Notify_Message
            // 
            this.Notify_Message.ForeColor = System.Drawing.Color.DarkRed;
            this.Notify_Message.Name = "Notify_Message";
            this.Notify_Message.Size = new System.Drawing.Size(141, 17);
            this.Notify_Message.Text = "toolStripStatusLabel1";
            this.Notify_Message.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(557, 499);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Destination_Mac_Address_Text);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Source_Mac_Address_Text);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Packet_Send_labal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PacketSpeed_label);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SpeedBar);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Destination_IP_Address_Text);
            this.Controls.Add(this.Destination_IP_Address);
            this.Controls.Add(this.Source_IP_Address_Text);
            this.Controls.Add(this.Source_IP_Address);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.mInterfaceCombo);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Resizable = false;
            this.Text = "SSDP Tool";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.SpeedBar)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox mInterfaceCombo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Source_IP_Address;
        private System.Windows.Forms.TextBox Source_IP_Address_Text;
        private System.Windows.Forms.Label Destination_IP_Address;
        private System.Windows.Forms.TextBox Destination_IP_Address_Text;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar SpeedBar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label PacketSpeed_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Packet_Send_labal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Source_Mac_Address_Text;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Destination_Mac_Address_Text;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Notify_Message;
    }
}

