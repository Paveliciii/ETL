namespace Shell.UI
{
    using AT.ETL.DataSources;
    using AT.Toolbox.Dialogs;
    using DevExpress.XtraBars;
    using DevExpress.XtraGrid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Views.Base;
    using ERMS.Core.DbMould;
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class DataSourceForm : Form
    {
        private IContainer components;
        private GridControl m_grid;
        private GridView m_grid_view;
        private BarManager m_bar_manager;
        private Bar m_main_menu;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarSubItem m_menu_edit;
        private BarButtonItem m_cmd_add;
        private BarButtonItem m_cmd_edit;
        private BarButtonItem m_cmd_remove;
        private BarButtonItem m_cmd_download;
        private DataSourceSet m_data_sources;
        private BindingSource m_adapters_source;
        private GridColumn colName;
        private GridColumn colDescription;
        private GridColumn colAdapter;
        private GridColumn colTimeout;

        public DataSourceForm()
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

        private void Edit()
        {
            DataSource row = this.m_grid_view.GetRow(this.m_grid_view.FocusedRowHandle) as DataSource;
            if (row != null)
            {
                DataSource source2 = new DataSource {
                    Name = row.Name,
                    Description = row.Description,
                    Adapter = row.Adapter,
                    Timeout = row.Timeout
                };
                EditDataSourceForm form = new EditDataSourceForm {
                    DataSource = source2
                };
                if (form.ShowDialog(this) == DialogResult.OK)
                {
                    BackgroundWorkerForm form2 = new BackgroundWorkerForm {
                        Work = new EditDataSourceWork(this.m_data_sources, form.DataSource, form.ConnectionString)
                    };
                    if (form2.ShowDialog(this) == DialogResult.OK)
                    {
                        this.m_grid.RefreshDataSource();
                        this.UpdateParentMenu();
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.m_grid = new GridControl();
            this.m_adapters_source = new BindingSource(this.components);
            this.m_data_sources = new DataSourceSet(this.components);
            this.m_grid_view = new GridView();
            this.colName = new GridColumn();
            this.colDescription = new GridColumn();
            this.colAdapter = new GridColumn();
            this.m_bar_manager = new BarManager(this.components);
            this.m_main_menu = new Bar();
            this.m_menu_edit = new BarSubItem();
            this.m_cmd_add = new BarButtonItem();
            this.m_cmd_edit = new BarButtonItem();
            this.m_cmd_remove = new BarButtonItem();
            this.m_cmd_download = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.colTimeout = new GridColumn();
            this.m_grid.BeginInit();
            ((ISupportInitialize) this.m_adapters_source).BeginInit();
            ((ISupportInitialize) this.m_data_sources).BeginInit();
            this.m_grid_view.BeginInit();
            this.m_bar_manager.BeginInit();
            base.SuspendLayout();
            this.m_grid.DataSource = this.m_adapters_source;
            this.m_grid.Dock = DockStyle.Fill;
            this.m_grid.Location = new Point(0, 0x18);
            this.m_grid.MainView = this.m_grid_view;
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new Size(0x129, 0xf4);
            this.m_grid.TabIndex = 0;
            this.m_grid.ViewCollection.AddRange(new BaseView[] { this.m_grid_view });
            this.m_adapters_source.DataMember = "DataSources";
            this.m_adapters_source.DataSource = this.m_data_sources;
            this.m_data_sources.LoadDataSources = true;
            this.m_grid_view.Columns.AddRange(new GridColumn[] { this.colName, this.colDescription, this.colAdapter, this.colTimeout });
            this.m_grid_view.GridControl = this.m_grid;
            this.m_grid_view.Name = "m_grid_view";
            this.m_grid_view.OptionsBehavior.Editable = false;
            this.m_grid_view.OptionsView.ShowGroupPanel = false;
            this.m_grid_view.DoubleClick += new EventHandler(this.m_grid_view_DoubleClick);
            this.colName.Caption = "Название";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colDescription.Caption = "Описание";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colAdapter.Caption = "Адаптер";
            this.colAdapter.FieldName = "Adapter";
            this.colAdapter.Name = "colAdapter";
            this.colAdapter.Visible = true;
            this.colAdapter.VisibleIndex = 2;
            this.m_bar_manager.AllowCustomization = false;
            this.m_bar_manager.Bars.AddRange(new Bar[] { this.m_main_menu });
            this.m_bar_manager.DockControls.Add(this.barDockControlTop);
            this.m_bar_manager.DockControls.Add(this.barDockControlBottom);
            this.m_bar_manager.DockControls.Add(this.barDockControlLeft);
            this.m_bar_manager.DockControls.Add(this.barDockControlRight);
            this.m_bar_manager.Form = this;
            this.m_bar_manager.Items.AddRange(new BarItem[] { this.m_menu_edit, this.m_cmd_add, this.m_cmd_edit, this.m_cmd_remove, this.m_cmd_download });
            this.m_bar_manager.MainMenu = this.m_main_menu;
            this.m_bar_manager.MaxItemId = 6;
            this.m_main_menu.BarName = "Main menu";
            this.m_main_menu.DockCol = 0;
            this.m_main_menu.DockRow = 0;
            this.m_main_menu.DockStyle = BarDockStyle.Top;
            this.m_main_menu.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_menu_edit) });
            this.m_main_menu.OptionsBar.MultiLine = true;
            this.m_main_menu.OptionsBar.UseWholeRow = true;
            this.m_main_menu.Text = "Main menu";
            this.m_menu_edit.Caption = "Правка";
            this.m_menu_edit.Id = 1;
            this.m_menu_edit.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_add), new LinkPersistInfo(this.m_cmd_edit), new LinkPersistInfo(this.m_cmd_remove), new LinkPersistInfo(this.m_cmd_download) });
            this.m_menu_edit.Name = "m_menu_edit";
            this.m_cmd_add.Caption = "Добавить источник данных";
            this.m_cmd_add.Id = 2;
            this.m_cmd_add.ItemShortcut = new BarShortcut(Keys.Insert);
            this.m_cmd_add.Name = "m_cmd_add";
            this.m_cmd_add.ItemClick += new ItemClickEventHandler(this.m_cmd_add_ItemClick);
            this.m_cmd_edit.Caption = "Изменить источник данных";
            this.m_cmd_edit.Id = 3;
            this.m_cmd_edit.ItemShortcut = new BarShortcut(Keys.F2);
            this.m_cmd_edit.Name = "m_cmd_edit";
            this.m_cmd_edit.ItemClick += new ItemClickEventHandler(this.m_cmd_edit_ItemClick);
            this.m_cmd_remove.Caption = "Удалить источник данных";
            this.m_cmd_remove.Id = 4;
            this.m_cmd_remove.ItemShortcut = new BarShortcut(Keys.Delete);
            this.m_cmd_remove.Name = "m_cmd_remove";
            this.m_cmd_remove.ItemClick += new ItemClickEventHandler(this.m_cmd_remove_ItemClick);
            this.m_cmd_download.Caption = "Скачать слепок";
            this.m_cmd_download.Id = 5;
            this.m_cmd_download.ItemShortcut = new BarShortcut(Keys.Control | Keys.D);
            this.m_cmd_download.Name = "m_cmd_download";
            this.m_cmd_download.ItemClick += new ItemClickEventHandler(this.m_cmd_download_ItemClick);
            this.colTimeout.Caption = "Таймаут";
            this.colTimeout.FieldName = "Timeout";
            this.colTimeout.Name = "colTimeout";
            this.colTimeout.Visible = true;
            this.colTimeout.VisibleIndex = 3;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x129, 0x10c);
            base.Controls.Add(this.m_grid);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "DataSourceForm";
            this.Text = "Описания источников данных";
            this.m_grid.EndInit();
            ((ISupportInitialize) this.m_adapters_source).EndInit();
            ((ISupportInitialize) this.m_data_sources).EndInit();
            this.m_grid_view.EndInit();
            this.m_bar_manager.EndInit();
            base.ResumeLayout(false);
        }

        private void m_cmd_add_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddDataSourceForm form = new AddDataSourceForm();
            if (form.ShowDialog(this) == DialogResult.OK)
            {
                BackgroundWorkerForm form2 = new BackgroundWorkerForm {
                    Work = new AddDataSourceWork(this.m_data_sources, form.DataSource, form.ConnectionString)
                };
                if (form2.ShowDialog(this) == DialogResult.OK)
                {
                    this.m_grid.RefreshDataSource();
                    this.UpdateParentMenu();
                }
            }
        }

        private void m_cmd_download_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataSource row = this.m_grid_view.GetRow(this.m_grid_view.FocusedRowHandle) as DataSource;
            if (row != null)
            {
                DatabaseMould mould = this.m_data_sources.GetMould(row.Name);
                if (mould != null)
                {
                    SaveFileDialog dialog = new SaveFileDialog {
                        Filter = "Database moulds|*.mould"
                    };
                    if (dialog.ShowDialog(this) == DialogResult.OK)
                    {
                        mould.Save(dialog.FileName);
                        Process.Start(Path.GetDirectoryName(dialog.FileName));
                    }
                }
            }
        }

        private void m_cmd_edit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Edit();
        }

        private void m_cmd_remove_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataSource row = this.m_grid_view.GetRow(this.m_grid_view.FocusedRowHandle) as DataSource;
            if (row != null)
            {
                MessageBoxEx ex = new MessageBoxEx("Подтверждение удаления", "Вы действительно хотите удалить источник данных?", MessageBoxButtons.OKCancel, MessageBoxEx.Icons.Question);
                if (ex.ShowDialog(this) == DialogResult.OK)
                {
                    this.m_data_sources.RemoveDataSource(row);
                    this.m_grid.RefreshDataSource();
                    this.UpdateParentMenu();
                }
            }
        }

        private void m_grid_view_DoubleClick(object sender, EventArgs e)
        {
            this.Edit();
        }

        private void UpdateParentMenu()
        {
            MainForm mdiParent = base.MdiParent as MainForm;
            if (mdiParent != null)
            {
                mdiParent.CheckDocumentsMenuVisibility();
            }
        }
    }
}

