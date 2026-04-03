namespace Shell.UI.Adapters
{
    using AT.Toolbox.MSSQL;
    using AT.Toolbox.MSSQL.Browsing;
    using ERMS.UI;
    using System;
    using System.ComponentModel;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Windows.Forms;

    public class SqlConnectionForm : DialogBase
    {
        private IContainer components;
        private SimpleConnectionControl m_connection_control;

        public SqlConnectionForm()
        {
            this.InitializeComponent();
            this.m_connection_control.RoutineHandler = new DBRoutinesStub();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.m_connection_control = new SimpleConnectionControl();
            base.SuspendLayout();
            base.m_buttons.Size = new Size(0x14d, 0x1d);
            this.m_connection_control.Dock = DockStyle.Fill;
            this.m_connection_control.HelpURI = null;
            this.m_connection_control.Location = new Point(0, 0);
            this.m_connection_control.MinimumSize = new Size(0x156, 250);
            this.m_connection_control.Name = "m_connection_control";
            this.m_connection_control.RoutineHandler = null;
            this.m_connection_control.Size = new Size(0x15b, 0x10a);
            this.m_connection_control.TabIndex = 1;
            this.m_connection_control.EditValueChanged += new EventHandler(this.m_connection_control_EditValueChanged);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x15b, 0x135);
            base.Controls.Add(this.m_connection_control);
            base.Name = "SqlConnectionForm";
            this.Text = "Настройки подключения";
            base.Controls.SetChildIndex(this.m_connection_control, 0);
            base.ResumeLayout(false);
        }

        private void m_connection_control_EditValueChanged(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(this.m_connection_control.CurrentDatabase);
            base.m_buttons.EnableButton(DialogResult.OK, !string.IsNullOrEmpty(builder.InitialCatalog));
        }

        public string ConnectionString
        {
            get => 
                this.m_connection_control.CurrentDatabase;
            set => 
                this.m_connection_control.CurrentDatabase = value;
        }
    }
}

