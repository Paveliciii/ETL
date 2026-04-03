namespace Shell.UI
{
    using AT.ETL;
    using AT.ETL.DataSources;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ERMS.Core.Common;
    using ERMS.UI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class RunScenarioForm : DialogBase
    {
        private string m_source;
        private string m_destination;
        private IContainer components;
        private TableLayoutPanel m_layout_panel;
        private LabelControl m_label_source;
        private LabelControl m_label_destination;
        private ButtonEdit m_source_edit;
        private ButtonEdit m_destination_edit;
        private BindingSource m_connection_source;
        private DataSourceSet m_data_sources;

        public RunScenarioForm()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        public IDataSourceInitializer GetInitializer() => 
            this.m_data_sources.GetInitializer(this.m_source, this.m_destination, this.ConnectionPair);

        private void InitializeComponent()
        {
            this.components = new Container();
            this.m_layout_panel = new TableLayoutPanel();
            this.m_label_source = new LabelControl();
            this.m_label_destination = new LabelControl();
            this.m_source_edit = new ButtonEdit();
            this.m_connection_source = new BindingSource(this.components);
            this.m_destination_edit = new ButtonEdit();
            this.m_data_sources = new DataSourceSet(this.components);
            this.m_layout_panel.SuspendLayout();
            this.m_source_edit.Properties.BeginInit();
            ((ISupportInitialize) this.m_connection_source).BeginInit();
            this.m_destination_edit.Properties.BeginInit();
            ((ISupportInitialize) this.m_data_sources).BeginInit();
            base.SuspendLayout();
            this.m_layout_panel.ColumnCount = 2;
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 39.19598f));
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 60.80402f));
            this.m_layout_panel.Controls.Add(this.m_label_source, 0, 0);
            this.m_layout_panel.Controls.Add(this.m_label_destination, 0, 1);
            this.m_layout_panel.Controls.Add(this.m_source_edit, 1, 0);
            this.m_layout_panel.Controls.Add(this.m_destination_edit, 1, 1);
            this.m_layout_panel.Dock = DockStyle.Fill;
            this.m_layout_panel.Location = new Point(0, 0);
            this.m_layout_panel.Name = "m_layout_panel";
            this.m_layout_panel.RowCount = 2;
            this.m_layout_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.m_layout_panel.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
            this.m_layout_panel.Size = new Size(0x18e, 0x36);
            this.m_layout_panel.TabIndex = 1;
            this.m_label_source.Location = new Point(3, 3);
            this.m_label_source.Name = "m_label_source";
            this.m_label_source.Padding = new Padding(5);
            this.m_label_source.Size = new Size(0x49, 0x17);
            this.m_label_source.TabIndex = 0;
            this.m_label_source.Text = "labelControl1";
            this.m_label_destination.Location = new Point(3, 30);
            this.m_label_destination.Name = "m_label_destination";
            this.m_label_destination.Padding = new Padding(5);
            this.m_label_destination.Size = new Size(0x49, 0x17);
            this.m_label_destination.TabIndex = 1;
            this.m_label_destination.Text = "labelControl2";
            this.m_source_edit.DataBindings.Add(new Binding("EditValue", this.m_connection_source, "SourceConnection", true));
            this.m_source_edit.Dock = DockStyle.Fill;
            this.m_source_edit.Location = new Point(0x9f, 3);
            this.m_source_edit.Name = "m_source_edit";
            this.m_source_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_source_edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.m_source_edit.Size = new Size(0xec, 20);
            this.m_source_edit.TabIndex = 2;
            this.m_source_edit.ButtonClick += new ButtonPressedEventHandler(this.m_source_edit_ButtonClick);
            this.m_source_edit.EditValueChanged += new EventHandler(this.m_source_edit_EditValueChanged);
            this.m_connection_source.DataSource = typeof(ETLConnectionPair);
            this.m_destination_edit.DataBindings.Add(new Binding("EditValue", this.m_connection_source, "DestinationConnection", true));
            this.m_destination_edit.Dock = DockStyle.Fill;
            this.m_destination_edit.Location = new Point(0x9f, 30);
            this.m_destination_edit.Name = "m_destination_edit";
            this.m_destination_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_destination_edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.m_destination_edit.Size = new Size(0xec, 20);
            this.m_destination_edit.TabIndex = 3;
            this.m_destination_edit.ButtonClick += new ButtonPressedEventHandler(this.m_destination_edit_ButtonClick);
            this.m_destination_edit.EditValueChanged += new EventHandler(this.m_destination_edit_EditValueChanged);
            this.m_data_sources.LoadDataSources = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x18e, 0x61);
            base.Controls.Add(this.m_layout_panel);
            base.MaximizeBox = false;
            base.Name = "RunScenarioForm";
            this.Text = "Выполнение сценария";
            base.Controls.SetChildIndex(this.m_layout_panel, 0);
            this.m_layout_panel.ResumeLayout(false);
            this.m_layout_panel.PerformLayout();
            this.m_source_edit.Properties.EndInit();
            ((ISupportInitialize) this.m_connection_source).EndInit();
            this.m_destination_edit.Properties.EndInit();
            ((ISupportInitialize) this.m_data_sources).EndInit();
            base.ResumeLayout(false);
        }

        private void m_destination_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.SetupConnection(this.m_destination, this.m_destination_edit);
        }

        private void m_destination_edit_EditValueChanged(object sender, EventArgs e)
        {
            this.m_destination_edit.ToolTip = this.m_destination_edit.Text;
        }

        private void m_source_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            this.SetupConnection(this.m_source, this.m_source_edit);
        }

        private void m_source_edit_EditValueChanged(object sender, EventArgs e)
        {
            this.m_source_edit.ToolTip = this.m_source_edit.Text;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (base.DialogResult == DialogResult.OK)
            {
                InfoBuffer buffer = new InfoBuffer();
                if (string.IsNullOrEmpty(this.m_source_edit.Text))
                {
                    buffer.Add("Не задана строка подключения для источника", InfoLevel.Warning);
                }
                if (string.IsNullOrEmpty(this.m_destination_edit.Text))
                {
                    buffer.Add("Не задана строка подключения для приёмника", InfoLevel.Warning);
                }
                if (buffer.Count > 0)
                {
                    AppManager.InfoView.ShowBuffer(buffer);
                    e.Cancel = true;
                }
            }
        }

        private void SetupConnection(string dataSourceName, ButtonEdit button)
        {
            if ((this.ConnectionPair != null) && !string.IsNullOrEmpty(dataSourceName))
            {
                ConnectionEntry entry = new ConnectionEntry(this) {
                    ConnectionString = button.Text
                };
                if (Enumerable.Single<DataSource>(this.m_data_sources.DataSources, ds => ds.Name == dataSourceName).Adapter.RunSetupDialog(entry))
                {
                    button.Text = entry.ConnectionString;
                }
            }
        }

        public ETLConnectionPair ConnectionPair
        {
            get => 
                this.m_connection_source.DataSource as ETLConnectionPair;
            set => 
                this.m_connection_source.DataSource = ((object) value) ?? typeof(ETLConnectionPair);
        }

        public string Source
        {
            get => 
                this.m_source;
            set
            {
                this.m_source = value;
                this.m_label_source.Text = $"Источник ({value})";
            }
        }

        public string Destination
        {
            get => 
                this.m_destination;
            set
            {
                this.m_destination = value;
                this.m_label_destination.Text = $"Приёмник ({value})";
            }
        }
    }
}

