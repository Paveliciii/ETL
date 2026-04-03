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
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class EditDataSourceForm : DialogBase
    {
        private IContainer components;
        private TableLayoutPanel m_layout_panel;
        private LabelControl m_label_name;
        private TextEdit m_name_edit;
        private LabelControl m_label_description;
        private TextEdit m_description_edit;
        private LabelControl m_label_connection;
        private ButtonEdit m_connection_edit;
        private CheckEdit m_regenerate_edit;
        private LabelControl m_label_regenerate;
        private BindingSource m_binding_source;
        private LabelControl m_label_timeout;
        private SpinEdit m_timeout_edit;

        public EditDataSourceForm()
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

        private void InitializeComponent()
        {
            this.components = new Container();
            this.m_layout_panel = new TableLayoutPanel();
            this.m_binding_source = new BindingSource(this.components);
            this.m_label_timeout = new LabelControl();
            this.m_label_name = new LabelControl();
            this.m_name_edit = new TextEdit();
            this.m_label_description = new LabelControl();
            this.m_description_edit = new TextEdit();
            this.m_label_connection = new LabelControl();
            this.m_connection_edit = new ButtonEdit();
            this.m_regenerate_edit = new CheckEdit();
            this.m_label_regenerate = new LabelControl();
            this.m_timeout_edit = new SpinEdit();
            this.m_layout_panel.SuspendLayout();
            ((ISupportInitialize) this.m_binding_source).BeginInit();
            this.m_name_edit.Properties.BeginInit();
            this.m_description_edit.Properties.BeginInit();
            this.m_connection_edit.Properties.BeginInit();
            this.m_regenerate_edit.Properties.BeginInit();
            this.m_timeout_edit.Properties.BeginInit();
            base.SuspendLayout();
            base.m_buttons.Size = new Size(0x209, 0x1d);
            this.m_layout_panel.ColumnCount = 2;
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 29.53271f));
            this.m_layout_panel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(SizeType.Percent, 70.46729f));
            this.m_layout_panel.Controls.Add(this.m_label_timeout, 0, 4);
            this.m_layout_panel.Controls.Add(this.m_label_name, 0, 0);
            this.m_layout_panel.Controls.Add(this.m_name_edit, 1, 0);
            this.m_layout_panel.Controls.Add(this.m_label_description, 0, 1);
            this.m_layout_panel.Controls.Add(this.m_description_edit, 1, 1);
            this.m_layout_panel.Controls.Add(this.m_label_connection, 0, 3);
            this.m_layout_panel.Controls.Add(this.m_connection_edit, 1, 3);
            this.m_layout_panel.Controls.Add(this.m_regenerate_edit, 1, 2);
            this.m_layout_panel.Controls.Add(this.m_label_regenerate, 0, 2);
            this.m_layout_panel.Controls.Add(this.m_timeout_edit, 1, 4);
            this.m_layout_panel.Dock = DockStyle.Fill;
            this.m_layout_panel.Location = new Point(0, 0);
            this.m_layout_panel.Name = "m_layout_panel";
            this.m_layout_panel.RowCount = 5;
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle());
            this.m_layout_panel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
            this.m_layout_panel.Size = new Size(0x217, 0x81);
            this.m_layout_panel.TabIndex = 2;
            this.m_binding_source.DataSource = typeof(AT.ETL.DataSources.DataSource);
            this.m_label_timeout.Dock = DockStyle.Fill;
            this.m_label_timeout.Location = new Point(3, 0x6a);
            this.m_label_timeout.Name = "m_label_timeout";
            this.m_label_timeout.Padding = new Padding(5);
            this.m_label_timeout.Size = new Size(0x7d, 0x17);
            this.m_label_timeout.TabIndex = 12;
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
            this.m_name_edit.DataBindings.Add(new Binding("Text", this.m_binding_source, "Name", true));
            this.m_name_edit.Dock = DockStyle.Fill;
            this.m_name_edit.Location = new Point(160, 3);
            this.m_name_edit.Name = "m_name_edit";
            this.m_name_edit.Properties.ReadOnly = true;
            this.m_name_edit.Size = new Size(0x174, 20);
            this.m_name_edit.TabIndex = 4;
            this.m_label_description.Dock = DockStyle.Fill;
            this.m_label_description.Location = new Point(3, 0x1d);
            this.m_label_description.Name = "m_label_description";
            this.m_label_description.Padding = new Padding(5);
            this.m_label_description.Size = new Size(0x3b, 0x17);
            this.m_label_description.TabIndex = 8;
            this.m_label_description.Text = "Описание";
            this.m_description_edit.DataBindings.Add(new Binding("Text", this.m_binding_source, "Description", true));
            this.m_description_edit.Dock = DockStyle.Fill;
            this.m_description_edit.Location = new Point(160, 0x1d);
            this.m_description_edit.Name = "m_description_edit";
            this.m_description_edit.Size = new Size(0x174, 20);
            this.m_description_edit.TabIndex = 9;
            this.m_label_connection.Dock = DockStyle.Fill;
            this.m_label_connection.Location = new Point(3, 80);
            this.m_label_connection.Name = "m_label_connection";
            this.m_label_connection.Padding = new Padding(5);
            this.m_label_connection.Size = new Size(120, 0x17);
            this.m_label_connection.TabIndex = 2;
            this.m_label_connection.Text = "Строка подключения";
            this.m_connection_edit.Dock = DockStyle.Fill;
            this.m_connection_edit.Enabled = false;
            this.m_connection_edit.Location = new Point(160, 80);
            this.m_connection_edit.Name = "m_connection_edit";
            this.m_connection_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_connection_edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.m_connection_edit.Size = new Size(0x174, 20);
            this.m_connection_edit.TabIndex = 6;
            this.m_connection_edit.ButtonClick += new ButtonPressedEventHandler(this.m_connection_edit_ButtonClick);
            this.m_regenerate_edit.Dock = DockStyle.Fill;
            this.m_regenerate_edit.Location = new Point(160, 0x37);
            this.m_regenerate_edit.Name = "m_regenerate_edit";
            this.m_regenerate_edit.Properties.Caption = "";
            this.m_regenerate_edit.ShowToolTips = false;
            this.m_regenerate_edit.Size = new Size(0x174, 0x13);
            this.m_regenerate_edit.TabIndex = 10;
            this.m_regenerate_edit.CheckedChanged += new EventHandler(this.m_regenerate_edit_CheckedChanged);
            this.m_label_regenerate.Dock = DockStyle.Fill;
            this.m_label_regenerate.Location = new Point(3, 0x37);
            this.m_label_regenerate.Name = "m_label_regenerate";
            this.m_label_regenerate.Padding = new Padding(5);
            this.m_label_regenerate.Size = new Size(0x90, 0x17);
            this.m_label_regenerate.TabIndex = 11;
            this.m_label_regenerate.Text = "Перегенерировать слепок";
            this.m_timeout_edit.DataBindings.Add(new Binding("EditValue", this.m_binding_source, "Timeout", true));
            this.m_timeout_edit.Dock = DockStyle.Fill;
            int[] bits = new int[4];
            this.m_timeout_edit.EditValue = new decimal(bits);
            this.m_timeout_edit.Location = new Point(160, 0x6a);
            this.m_timeout_edit.Name = "m_timeout_edit";
            this.m_timeout_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_timeout_edit.Size = new Size(0x174, 20);
            this.m_timeout_edit.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x217, 0xac);
            base.Controls.Add(this.m_layout_panel);
            base.MaximizeBox = false;
            base.Name = "EditDataSourceForm";
            this.Text = "Изменить источник данных";
            base.Controls.SetChildIndex(this.m_layout_panel, 0);
            this.m_layout_panel.ResumeLayout(false);
            this.m_layout_panel.PerformLayout();
            ((ISupportInitialize) this.m_binding_source).EndInit();
            this.m_name_edit.Properties.EndInit();
            this.m_description_edit.Properties.EndInit();
            this.m_connection_edit.Properties.EndInit();
            this.m_regenerate_edit.Properties.EndInit();
            this.m_timeout_edit.Properties.EndInit();
            base.ResumeLayout(false);
        }

        private void m_connection_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (this.DataSource != null)
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
        }

        private void m_regenerate_edit_CheckedChanged(object sender, EventArgs e)
        {
            this.m_connection_edit.Enabled = this.m_regenerate_edit.Checked;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (base.DialogResult == DialogResult.OK)
            {
                InfoBuffer buffer = new InfoBuffer();
                if (this.m_regenerate_edit.Checked && string.IsNullOrEmpty(this.m_connection_edit.Text))
                {
                    buffer.Add("Не задана строка подключения", InfoLevel.Warning);
                }
                if (this.m_timeout_edit.Value < 1M)
                {
                    buffer.Add("Таймаут слишком мал", InfoLevel.Warning);
                }
                if (buffer.Count > 0)
                {
                    AppManager.InfoView.ShowBuffer(buffer);
                    e.Cancel = true;
                }
            }
        }

        public AT.ETL.DataSources.DataSource DataSource
        {
            get => 
                this.m_binding_source.DataSource as AT.ETL.DataSources.DataSource;
            set => 
                this.m_binding_source.DataSource = ((object) value) ?? typeof(AT.ETL.DataSources.DataSource);
        }

        public string ConnectionString
        {
            get
            {
                if (!this.m_regenerate_edit.Checked)
                {
                    return null;
                }
                return this.m_connection_edit.Text;
            }
        }
    }
}

