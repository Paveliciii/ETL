namespace Shell.UI
{
    using DevExpress.XtraBars;
    using ERMS.UI;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class TableForm : FrameForm
    {
        private IContainer components;
        private BarSubItem m_menu_References;
        private BarButtonItem m_block_button;
        private BarManager m_bar_manager;
        private Bar m_main_menu;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;

        public TableForm()
        {
            this.InitializeComponent();
            this.m_main_menu.LinksPersistInfo.RemoveAt(2);
            this.m_main_menu.LinksPersistInfo.Insert(1, new LinkPersistInfo(this.m_menu_References));
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
            this.m_menu_References = new BarSubItem();
            this.m_block_button = new BarButtonItem();
            this.m_bar_manager = new BarManager(this.components);
            this.m_main_menu = new Bar(this.m_bar_manager);
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            base.m_dock_manager.BeginInit();
            this.m_bar_manager.BeginInit();
            base.SuspendLayout();
            base.m_log_panel.Location = new Point(0, 0xeb);
            base.m_log_panel.Options.ShowCloseButton = false;
            base.m_log_panel.Size = new Size(0x2d1, 200);
            base.m_log_panel.Text = "Log";
            this.m_menu_References.Caption = "Документы";
            this.m_menu_References.Id = 4;
            this.m_menu_References.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_block_button) });
            this.m_menu_References.Name = "m_menu_References";
            this.m_block_button.Caption = "BLOCK";
            this.m_block_button.Id = 5;
            this.m_block_button.Name = "m_block_button";
            this.m_bar_manager.Bars.AddRange(new Bar[] { this.m_main_menu });
            this.m_bar_manager.DockControls.Add(this.barDockControlTop);
            this.m_bar_manager.DockControls.Add(this.barDockControlBottom);
            this.m_bar_manager.DockControls.Add(this.barDockControlLeft);
            this.m_bar_manager.DockControls.Add(this.barDockControlRight);
            this.m_bar_manager.Form = this;
            this.m_bar_manager.Items.AddRange(new BarItem[] { this.m_menu_References, this.m_block_button });
            this.m_bar_manager.MainMenu = this.m_main_menu;
            this.m_bar_manager.MaxItemId = 6;
            this.m_main_menu.BarName = "Custom 1";
            this.m_main_menu.DockCol = 0;
            this.m_main_menu.DockRow = 0;
            this.m_main_menu.DockStyle = BarDockStyle.Top;
            this.m_main_menu.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_menu_References) });
            this.m_main_menu.OptionsBar.AllowQuickCustomization = false;
            this.m_main_menu.OptionsBar.DrawDragBorder = false;
            this.m_main_menu.OptionsBar.MultiLine = true;
            this.m_main_menu.OptionsBar.UseWholeRow = true;
            this.m_main_menu.Text = "Custom 1";
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x2d1, 0x1b3);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "TableForm";
            this.Text = "TableForm";
            base.Controls.SetChildIndex(this.barDockControlTop, 0);
            base.Controls.SetChildIndex(this.barDockControlBottom, 0);
            base.Controls.SetChildIndex(this.barDockControlRight, 0);
            base.Controls.SetChildIndex(this.barDockControlLeft, 0);
            base.Controls.SetChildIndex(base.m_log_panel, 0);
            base.m_dock_manager.EndInit();
            this.m_bar_manager.EndInit();
            base.ResumeLayout(false);
        }
    }
}

