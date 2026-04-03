namespace Shell.UI
{
    using AT.ETL;
    using AT.Toolbox.Base;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Base;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class PluginsForm : LocalizeableForm
    {
        private IContainer components;
        private PluginEntrySet m_plugins;
        private GridControl m_grid;
        private GridView m_grid_view;
        private GridColumn colAssemblyName;

        public PluginsForm()
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
            this.m_plugins = new PluginEntrySet(this.components);
            this.m_grid = new GridControl();
            this.m_grid_view = new GridView();
            this.colAssemblyName = new GridColumn();
            this.m_grid.BeginInit();
            this.m_grid_view.BeginInit();
            base.SuspendLayout();
            this.m_grid.DataSource = this.m_plugins;
            this.m_grid.Dock = DockStyle.Fill;
            this.m_grid.Location = new Point(0, 0);
            this.m_grid.MainView = this.m_grid_view;
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new Size(0x124, 0x113);
            this.m_grid.TabIndex = 0;
            this.m_grid.ViewCollection.AddRange(new BaseView[] { this.m_grid_view });
            this.m_grid_view.Columns.AddRange(new GridColumn[] { this.colAssemblyName });
            this.m_grid_view.GridControl = this.m_grid;
            this.m_grid_view.Name = "m_grid_view";
            this.m_grid_view.OptionsBehavior.Editable = false;
            this.m_grid_view.OptionsView.ShowGroupPanel = false;
            this.colAssemblyName.FieldName = "AssemblyName";
            this.colAssemblyName.Name = "colAssemblyName";
            this.colAssemblyName.Visible = true;
            this.colAssemblyName.VisibleIndex = 0;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x113);
            base.Controls.Add(this.m_grid);
            base.Name = "PluginsForm";
            this.Text = "Модули расширения функциональности";
            this.m_grid.EndInit();
            this.m_grid_view.EndInit();
            base.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.m_plugins.Load();
        }
    }
}

