namespace Shell.UI
{
    using DevExpress.XtraEditors;
    using DevExpress.XtraEditors.Controls;
    using ERMS.BLL;
    using ERMS.Core.DAL;
    using ERMS.UI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using TransportModel;

    public class VisumDatabaseForm : EditForm
    {
        private VisumDatabase m_database;
        private IContainer components;
        private ButtonEdit m_path_edit;
        private TextEdit m_name_edit;
        private LabelControl m_label_path;
        private LabelControl m_label_name;

        public VisumDatabaseForm()
        {
            this.InitializeComponent();
        }

        protected override void AssignValues()
        {
            if (this.m_database != null)
            {
                if (!string.IsNullOrEmpty(this.m_path_edit.Text))
                {
                    FileData data;
                    if (this.m_database.FileDataGuid.HasValue)
                    {
                        data = new FileData(this.m_database.FileDataGuid.Value);
                    }
                    else
                    {
                        data = new FileData();
                    }
                    data.Data = File.ReadAllBytes(this.m_path_edit.Text);
                    if (data.SaveInvariant())
                    {
                        this.m_database.FileDataGuid = new Guid?(data.ObjectGuid);
                    }
                }
                this.m_database.Name = this.m_name_edit.Text;
            }
        }

        public override void DataBind()
        {
            this.m_database = base.BusinessObject as VisumDatabase;
            if (this.m_database != null)
            {
                this.m_name_edit.Text = this.m_database.Name;
            }
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
            this.m_path_edit = new ButtonEdit();
            this.m_name_edit = new TextEdit();
            this.m_label_path = new LabelControl();
            this.m_label_name = new LabelControl();
            this.m_path_edit.Properties.BeginInit();
            this.m_name_edit.Properties.BeginInit();
            base.SuspendLayout();
            this.m_path_edit.Location = new Point(0x51, 9);
            this.m_path_edit.Name = "m_path_edit";
            this.m_path_edit.Properties.Buttons.AddRange(new EditorButton[] { new EditorButton() });
            this.m_path_edit.Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            this.m_path_edit.Size = new Size(0x113, 20);
            this.m_path_edit.TabIndex = 2;
            this.m_path_edit.ButtonClick += new ButtonPressedEventHandler(this.m_path_edit_ButtonClick);
            this.m_name_edit.Location = new Point(0x51, 0x25);
            this.m_name_edit.Name = "m_name_edit";
            this.m_name_edit.Size = new Size(0x113, 20);
            this.m_name_edit.TabIndex = 3;
            this.m_label_path.Location = new Point(12, 12);
            this.m_label_path.Name = "m_label_path";
            this.m_label_path.Size = new Size(0x45, 13);
            this.m_label_path.TabIndex = 4;
            this.m_label_path.Text = "Путь к файлу";
            this.m_label_name.Location = new Point(12, 40);
            this.m_label_name.Name = "m_label_name";
            this.m_label_name.Size = new Size(0x30, 13);
            this.m_label_name.TabIndex = 5;
            this.m_label_name.Text = "Название";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x171, 0x68);
            base.Controls.Add(this.m_label_path);
            base.Controls.Add(this.m_label_name);
            base.Controls.Add(this.m_path_edit);
            base.Controls.Add(this.m_name_edit);
            base.Name = "VisumDatabaseForm";
            this.Text = "Выбор базы данных Visum";
            base.Controls.SetChildIndex(this.m_name_edit, 0);
            base.Controls.SetChildIndex(this.m_path_edit, 0);
            base.Controls.SetChildIndex(this.m_label_name, 0);
            base.Controls.SetChildIndex(this.m_label_path, 0);
            this.m_path_edit.Properties.EndInit();
            this.m_name_edit.Properties.EndInit();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void m_path_edit_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Microsoft Access database|*.mdb"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                this.m_path_edit.Text = dialog.FileName;
                this.m_name_edit.Text = Path.GetFileNameWithoutExtension(dialog.FileName);
            }
        }
    }
}

