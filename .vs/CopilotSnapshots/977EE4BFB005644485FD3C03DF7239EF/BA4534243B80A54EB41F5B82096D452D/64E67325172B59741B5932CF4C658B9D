namespace Shell.UI
{
    using AT.ETL;
    using AT.ETL.DataSources;
    using DevExpress.Utils;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ERMS.Core.Common;
    using ERMS.UI;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    public class AddDataSourceForm : DialogBase
    {
        private IContainer components;
        private TableLayoutPanel m_layout_panel;
        private LabelControl m_label_name;
        private LabelControl m_label_adapter;
        private LabelControl m_label_connection;
        private LabelControl m_label_description;
        private TextEdit m_name_edit;
        private TextEdit m_description_edit;
        private ButtonEdit m_connection_edit;
        private LookUpEdit m_adapter_edit;
        private BindingSource m_binding_source;
        private DataSourceSet m_data_source_set;
        private LabelControl m_label_timeout;
        private SpinEdit m_timeout_edit;

        public AddDataSourceForm()
        {
            this.InitializeComponent();
            this.m_binding_source.DataSource = new AT.ETL.DataSources.DataSource();
            this.m_adapter_edit.Properties.DataSource = Enumerable.ToDictionary<IETLUIAdapter, IETLUIAdapter, string>(this.m_data_source_set.Adapters, ad => ad, ad2 => ad2.ToString()).ToList<KeyValuePair<IETLUIAdapter, string>>();
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
            this.components = new Container();
            this.m_layout_panel = new TableLayoutPanel();
            this.m_binding_source = new BindingSource(this.components);
            this.m_label_timeout = new LabelControl();
            this.m_label_name = new LabelControl();
            this.m_label_adapter = new LabelControl();
            this.m_label_connection = new LabelControl();
            this.m_label_description = new LabelControl();
            this.m_name_edit = new TextEdit();
            this.m_description_edit = new TextEdit();
            this.m_connection_edit = new ButtonEdit();
            this.m_adapter_edit = new LookUpEdit();
            this.m_data_source_set = new DataSourceSet(this.components);
            this.m_timeout_edit = new SpinEdit();
            this.m_layout_panel.SuspendLayout();
            ((ISupportInitialize) this.m_binding_source).BeginInit();
            this.m_name_edit.Properties.BeginInit();
            this.m_description_edit.Properties.BeginInit();
            this.m_connection_edit.Properties.BeginInit();
            this.m_adapter_edit.Properties.BeginInit();
            ((ISupportInitialize) this.m_data_source_set).BeginInit();
            this.m_timeout_edit.Properties.BeginInit();
            base.SuspendLayout();
            base.m_buttons.Size = new Size(0x202, 0x1d);
            this.m_layout_panel.ColumnCount = 2;
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 25.94697f));
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 74.05303f));
            this.m_layout_panel.Controls.Add(this.m_label_timeout, 0, 3);
            this.m_layout_panel.Controls.Add(this.m_label_name, 0, 0);
            this.m_layout_panel.Controls.Add(this.m_label_adapter, 0, 1);
            this.m_layout_panel.Controls.Add(this.m_label_connection, 0, 2);
            this.m_layout_panel.Controls.Add(this.m_label_description, 0, 4);
            this.m_layout_panel.Controls.Add(this.m_name_edit, 1, 0);
            this.m_layout_panel.Controls.Add(this.m_description_edit, 1, 4);
            this.m_layout_panel.Controls.Add(this.m_connection_edit, 1, 2);
            this.m_layout_panel.Controls.Add(this.m_adapter_edit, 1, 1);
            this.m_layout_panel.Controls.Add(this.m_timeout_edit, 1, 3);
            this.m_layout_panel.Dock = DockStyle.Fill;
            this.m_layout_panel.Location = new Point(0, 0);
            this.m_layout_panel.Name = "m_layout_panel";
            this.m_layout_panel.RowCount = 5;
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.Size = new Size(0x210, 0x83);
            this.m_layout_panel.TabIndex = 1;
            this.m_binding_source.DataSource = typeof(AT.ETL.DataSources.DataSource);
            this.m_label_timeout.Dock = DockStyle.Fill;
            this.m_label_timeout.Location = new Point(3, 0x51);
            this.m_label_timeout.Name = "m_label_timeout";
            this.m_label_timeout.Padding = new Padding(5);
            this.m_label_timeout.Size = new Size(0x7d, 0x17);
            this.m_label_timeout.TabIndex = 8;
            this.m_label_timeout.Text = "Таймаут подключения";
            this.m_label_name.Appearance.Options.UseTextOptions = true;
            this.m_label_name.Appearance.TextOptions.VAlignment = VertAlignment.Center;
            this.m_label_name.Dock = DockStyle.Fill;
            this.m_label_name.Location = new Point(3, 3);
            this.m_label_name.Name = "m_label_name";
            this.m_label_name.Padding = new Padding(5);
            this.m_label_name.Size = new Size(0x3a, 0x17);
            this.m_label_name.TabIndex = 0;
            this.m_label_name.Text = "Название";
            this.m_label_adapter.Dock = DockStyle.Fill;
            this.m_label_adapter.Location = new Point(3, 0x1d);
            this.m_label_adapter.Name = "m_label_adapter";
            this.m_label_adapter.Padding = new Padding(5);
            this.m_label_adapter.Size = new Size(0x36, 0x17);
            this.m_label_adapter.TabIndex = 1;
            this.m_label_adapter.Text = "Адаптер";
            this.m_label_connection.Dock = DockStyle.Fill;
            this.m_label_connection.Location = new Point(3, 0x37);
            this.m_label_connection.Name = "m_label_connection";
            this.m_label_connection.Padding = new Padding(5);
            this.m_label_connection.Size = new Size(120, 0x17);
            this.m_label_connection.TabIndex = 2;
            this.m_label_connection.Text = "Строка подключения";
            this.m_label_description.Dock = DockStyle.Fill;
            this.m_label_description.Location = new Point(3, 0x6b);
            this.m_label_description.Name = "m_label_description";
            this.m_label_description.Padding = new Padding(5);
            this.m_label_description.Size = new Size(0x3b, 0x17);
            this.m_label_description.TabIndex = 3;
            this.m_label_description.Text = "Описание";
            this.m_name_edit.DataBindings.Add(new Binding("EditValue", this.m_binding_source, "Name", true));
            this.m_name_edit.Dock = DockStyle.Fill;
            this.m_name_edit.Location = new Point(140, 3);
            this.m_name_edit.Name = "m_name_edit";
            this.m_name_edit.Size = new Size(0x181, 20);
            this.m_name_edit.TabIndex = 4;
            this.m_description_edit.DataBindings.Add(new Binding("EditValue", this.m_binding_source, "Description", true));
            this.m_description_edit.Dock = DockStyle.Fill;
            this.m_description_edit.Location = new Point(140, 0x6b);
            this.m_description_edit.Name = "m_description_edit";
            this.m_description_edit.Size = new Size(0x181, 20);
            this.m_description_edit.TabIndex = 5;
            this.m_connection_edit.Dock = DockStyle.Fill;
            this.m_connection_edit.Enabled = false;
            this.m_connection_edit.Location = new Point(140, 0x37);
            this.m_connection_edit.Name = "m_connection_edit";
            this.m_connection_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_connection_edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.m_connection_edit.Size = new Size(0x181, 20);
            this.m_connection_edit.TabIndex = 6;
            this.m_connection_edit.ButtonClick += new ButtonPressedEventHandler(this.m_connection_edit_ButtonClick);
            this.m_adapter_edit.DataBindings.Add(new Binding("EditValue", this.m_binding_source, "Adapter", true));
            this.m_adapter_edit.Dock = DockStyle.Fill;
            this.m_adapter_edit.Location = new Point(140, 0x1d);
            this.m_adapter_edit.Name = "m_adapter_edit";
            this.m_adapter_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton(ButtonPredefines.Combo) });
            this.m_adapter_edit.Properties.Columns.AddRange(new LookUpColumnInfo[] { new LookUpColumnInfo("Value", "Value") });
            this.m_adapter_edit.Properties.DisplayMember = "Value";
            this.m_adapter_edit.Properties.ShowFooter = false;
            this.m_adapter_edit.Properties.ShowHeader = false;
            this.m_adapter_edit.Properties.ValueMember = "Key";
            this.m_adapter_edit.Size = new Size(0x181, 20);
            this.m_adapter_edit.TabIndex = 7;
            this.m_adapter_edit.EditValueChanged += new EventHandler(this.m_adapter_edit_EditValueChanged);
            this.m_data_source_set.LoadAdapters = true;
            this.m_timeout_edit.DataBindings.Add(new Binding("EditValue", this.m_binding_source, "Timeout", true));
            this.m_timeout_edit.Dock = DockStyle.Fill;
            int[] bits = new int[4];
            this.m_timeout_edit.EditValue = new decimal(bits);
            this.m_timeout_edit.Location = new Point(140, 0x51);
            this.m_timeout_edit.Name = "m_timeout_edit";
            this.m_timeout_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_timeout_edit.Size = new Size(0x181, 20);
            this.m_timeout_edit.TabIndex = 9;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x210, 0xae);
            base.Controls.Add(this.m_layout_panel);
            base.MaximizeBox = false;
            base.Name = "AddDataSourceForm";
            this.Text = "Добавить источник данных";
            base.Controls.SetChildIndex(this.m_layout_panel, 0);
            this.m_layout_panel.ResumeLayout(false);
            this.m_layout_panel.PerformLayout();
            ((ISupportInitialize) this.m_binding_source).EndInit();
            this.m_name_edit.Properties.EndInit();
            this.m_description_edit.Properties.EndInit();
            this.m_connection_edit.Properties.EndInit();
            this.m_adapter_edit.Properties.EndInit();
            ((ISupportInitialize) this.m_data_source_set).EndInit();
            this.m_timeout_edit.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void m_adapter_edit_EditValueChanged(object sender, EventArgs e)
        {
            this.m_timeout_edit.Enabled = this.m_connection_edit.Enabled = !((this.m_adapter_edit.EditValue ?? Convert.DBNull) is DBNull);
        }

        private void m_connection_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            IETLUIAdapter adapter = this.DataSource.Adapter;
            if (adapter != null)
            {
                ConnectionEntry entry = new ConnectionEntry(this) {
                    ConnectionString = this.m_connection_edit.Text
                };
                if (adapter.RunSetupDialog(entry))
                {
                    this.m_connection_edit.Text = entry.ConnectionString;
                    this.m_connection_edit.ToolTip = entry.ConnectionString;
                }
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (base.DialogResult == DialogResult.OK)
            {
                InfoBuffer buffer = new InfoBuffer();
                bool flag = this.m_data_source_set.ValidateInsert(this.DataSource, this.m_connection_edit.Text, buffer);
                if (buffer.Count > 0)
                {
                    if (flag)
                    {
                        flag = AppManager.InfoView.Confirm(buffer);
                    }
                    else
                    {
                        AppManager.InfoView.ShowBuffer(buffer);
                    }
                    e.Cancel = !flag;
                }
            }
        }

        public AT.ETL.DataSources.DataSource DataSource =>
            this.m_binding_source.DataSource as AT.ETL.DataSources.DataSource;

        public string ConnectionString =>
            this.m_connection_edit.Text;
    }
}

