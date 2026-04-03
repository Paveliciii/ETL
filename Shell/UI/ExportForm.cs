namespace Shell.UI
{
    using AT.ETL;
    using AT.Toolbox.Dialogs;
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ERMS.Core.Common;
    using Shell.UI.ScenarioDOM;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class ExportForm : XtraForm
    {
        private string oldBase = "";
        private string newBase = "";
        private readonly DataScenario m_scenario;
        private IContainer components;
        private LabelControl m_label_folder;
        private LabelControl m_label_mould;
        private SimpleButton m_button_export;
        private ButtonEdit m_new_base_edit;
        private ButtonEdit m_old_base_edit;

        public ExportForm(DataScenario scenario)
        {
            if (scenario == null)
            {
                throw new ArgumentNullException("scenario");
            }
            this.m_scenario = scenario;
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
            this.m_label_folder = new LabelControl();
            this.m_label_mould = new LabelControl();
            this.m_button_export = new SimpleButton();
            this.m_new_base_edit = new ButtonEdit();
            this.m_old_base_edit = new ButtonEdit();
            this.m_new_base_edit.Properties.BeginInit();
            this.m_old_base_edit.Properties.BeginInit();
            base.SuspendLayout();
            this.m_label_folder.Location = new Point(12, 50);
            this.m_label_folder.Name = "m_label_folder";
            this.m_label_folder.Size = new Size(0x39, 13);
            this.m_label_folder.TabIndex = 10;
            this.m_label_folder.Text = "Новая база";
            this.m_label_mould.Location = new Point(12, 0x18);
            this.m_label_mould.Name = "m_label_mould";
            this.m_label_mould.Size = new Size(0x3f, 13);
            this.m_label_mould.TabIndex = 9;
            this.m_label_mould.Text = "Старая база";
            this.m_button_export.Location = new Point(0x7d, 0x4e);
            this.m_button_export.Name = "m_button_export";
            this.m_button_export.Size = new Size(0x9b, 0x17);
            this.m_button_export.TabIndex = 8;
            this.m_button_export.Text = "Выполнить";
            this.m_button_export.Click += new EventHandler(this.m_button_export_Click);
            this.m_new_base_edit.Location = new Point(0x7d, 0x2f);
            this.m_new_base_edit.Name = "m_new_base_edit";
            this.m_new_base_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_new_base_edit.Size = new Size(0x9b, 20);
            this.m_new_base_edit.TabIndex = 7;
            this.m_new_base_edit.ButtonClick += new ButtonPressedEventHandler(this.m_new_base_edit_ButtonClick);
            this.m_old_base_edit.Location = new Point(0x7d, 0x15);
            this.m_old_base_edit.Name = "m_old_base_edit";
            this.m_old_base_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_old_base_edit.Size = new Size(0x9b, 20);
            this.m_old_base_edit.TabIndex = 6;
            this.m_old_base_edit.ButtonClick += new ButtonPressedEventHandler(this.m_old_base_edit_ButtonClick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x71);
            base.Controls.Add(this.m_label_folder);
            base.Controls.Add(this.m_label_mould);
            base.Controls.Add(this.m_button_export);
            base.Controls.Add(this.m_new_base_edit);
            base.Controls.Add(this.m_old_base_edit);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = "ExportForm";
            base.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Выполнение сценария";
            this.m_new_base_edit.Properties.EndInit();
            this.m_old_base_edit.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void m_button_export_Click(object sender, EventArgs e)
        {
            InfoBuffer buffer = new InfoBuffer();
            if (string.IsNullOrEmpty(this.m_old_base_edit.Text))
            {
                buffer.Add(new Info("Не задан путь к исходной базе данных", InfoLevel.Warning));
            }
            if (string.IsNullOrEmpty(this.m_new_base_edit.Text))
            {
                buffer.Add(new Info("Не задан путь к конечной базе данных", InfoLevel.Warning));
            }
            if (buffer.Count > 0)
            {
                AppManager.InfoView.ShowBuffer(buffer);
            }
            else
            {
                AccessDatabaseDataSourceInitializer initializer = new AccessDatabaseDataSourceInitializer {
                    SourceFile = this.m_old_base_edit.ToolTip,
                    DestinationFile = this.m_new_base_edit.ToolTip
                };
                foreach (string str in ETLSettings.Preferences.DataSources.Keys)
                {
                    initializer.DataSourceNames.Add(str);
                }
                RunScenarioWork work = new RunScenarioWork(this.m_scenario, initializer);
                new BackgroundWorkerForm { Work = work }.ShowDialog(this);
                base.Close();
                GC.Collect();
            }
        }

        private void m_new_base_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = "Microsoft Access database|*.mdb"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.newBase = dialog.FileName;
                this.m_new_base_edit.Text = SystemExtensions.TruncatePath(dialog.FileName, this.m_new_base_edit.Font, this.m_new_base_edit.Width - 15);
                this.m_new_base_edit.ToolTip = dialog.FileName;
            }
        }

        private void m_old_base_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Microsoft Access database|*.mdb"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.oldBase = dialog.FileName;
                this.m_old_base_edit.Text = SystemExtensions.TruncatePath(dialog.FileName, this.m_old_base_edit.Font, this.m_old_base_edit.Width - 15);
                this.m_old_base_edit.ToolTip = dialog.FileName;
            }
        }
    }
}

