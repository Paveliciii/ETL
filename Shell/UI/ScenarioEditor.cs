namespace Shell.UI
{
    using AT.ETL;
    using AT.Toolbox.Base;
    using AT.Toolbox.Dialogs;
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using DevExpress.XtraVerticalGrid;
    using DevExpress.XtraVerticalGrid.Events;
    using ERMS.Core.Common;
    using ERMS.UI;
    using Shell.UI.ScenarioDOM;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    public class ScenarioEditor : LocalizeableForm
    {
        private ETLConnectionPair m_pair;
        private IContainer components;
        private TreeBindingController m_tree_controller;
        private SplitContainerControl m_splitter;
        private TreeView m_tree;
        private PropertyGridControl m_property_grid;
        private BarManager m_bar_manager;
        private Bar bar2;
        private BarSubItem m_menu_file;
        private BarButtonItem m_cmd_save;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarButtonItem m_cmd_save_as;
        private BarSubItem m_menu_edit;
        private BarButtonItem m_cmd_undo;
        private BarButtonItem m_cmd_redo;
        private BarSubItem m_menu_actions;
        private BarButtonItem m_cmd_execute;

        public ScenarioEditor()
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
            this.m_tree_controller = new TreeBindingController(this.components);
            this.m_tree = new TreeView();
            this.m_splitter = new SplitContainerControl();
            this.m_property_grid = new PropertyGridControl();
            this.m_bar_manager = new BarManager(this.components);
            this.bar2 = new Bar();
            this.m_menu_file = new BarSubItem();
            this.m_cmd_save = new BarButtonItem();
            this.m_cmd_save_as = new BarButtonItem();
            this.m_menu_edit = new BarSubItem();
            this.m_cmd_undo = new BarButtonItem();
            this.m_cmd_redo = new BarButtonItem();
            this.m_menu_actions = new BarSubItem();
            this.m_cmd_execute = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.m_splitter.BeginInit();
            this.m_splitter.SuspendLayout();
            this.m_property_grid.BeginInit();
            this.m_bar_manager.BeginInit();
            base.SuspendLayout();
            this.m_tree_controller.DataSource = null;
            this.m_tree_controller.SkipSetItemHandling = true;
            this.m_tree_controller.Tree = this.m_tree;
            this.m_tree.AllowDrop = true;
            this.m_tree.Dock = DockStyle.Fill;
            this.m_tree.ForeColor = SystemColors.WindowText;
            this.m_tree.HideSelection = false;
            this.m_tree.Location = new Point(0, 0);
            this.m_tree.Name = "m_tree";
            this.m_tree.Size = new Size(0x17b, 0x1df);
            this.m_tree.TabIndex = 0;
            this.m_tree.AfterSelect += new TreeViewEventHandler(this.m_tree_AfterSelect);
            this.m_splitter.Dock = DockStyle.Fill;
            this.m_splitter.FixedPanel = SplitFixedPanel.Panel2;
            this.m_splitter.Location = new Point(0, 0x18);
            this.m_splitter.Name = "m_splitter";
            this.m_splitter.Panel1.Controls.Add(this.m_tree);
            this.m_splitter.Panel1.Text = "Panel1";
            this.m_splitter.Panel2.Controls.Add(this.m_property_grid);
            this.m_splitter.Panel2.Text = "Panel2";
            this.m_splitter.Size = new Size(0x28b, 0x1df);
            this.m_splitter.SplitterPosition = 0x10a;
            this.m_splitter.TabIndex = 0;
            this.m_splitter.Text = "splitContainerControl1";
            this.m_property_grid.AutoGenerateRows = true;
            this.m_property_grid.Dock = DockStyle.Fill;
            this.m_property_grid.Location = new Point(0, 0);
            this.m_property_grid.Name = "m_property_grid";
            this.m_property_grid.OptionsView.ShowRootCategories = false;
            this.m_property_grid.Size = new Size(0x10a, 0x1df);
            this.m_property_grid.TabIndex = 0;
            this.m_property_grid.RowChanged += new RowChangedEventHandler(this.m_property_grid_RowChanged);
            this.m_bar_manager.Bars.AddRange(new Bar[] { this.bar2 });
            this.m_bar_manager.DockControls.Add(this.barDockControlTop);
            this.m_bar_manager.DockControls.Add(this.barDockControlBottom);
            this.m_bar_manager.DockControls.Add(this.barDockControlLeft);
            this.m_bar_manager.DockControls.Add(this.barDockControlRight);
            this.m_bar_manager.Form = this;
            this.m_bar_manager.Items.AddRange(new BarItem[] { this.m_menu_file, this.m_cmd_save, this.m_cmd_save_as, this.m_menu_edit, this.m_cmd_undo, this.m_cmd_redo, this.m_menu_actions, this.m_cmd_execute });
            this.m_bar_manager.MainMenu = this.bar2;
            this.m_bar_manager.MaxItemId = 9;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_menu_file), new LinkPersistInfo(this.m_menu_edit), new LinkPersistInfo(this.m_menu_actions) });
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            this.m_menu_file.Caption = "Файл";
            this.m_menu_file.Id = 0;
            this.m_menu_file.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_save), new LinkPersistInfo(this.m_cmd_save_as) });
            this.m_menu_file.MergeType = BarMenuMerge.MergeItems;
            this.m_menu_file.Name = "m_menu_file";
            this.m_cmd_save.Caption = "Сохранить";
            this.m_cmd_save.Id = 1;
            this.m_cmd_save.ItemShortcut = new BarShortcut(Keys.Control | Keys.S);
            this.m_cmd_save.Name = "m_cmd_save";
            this.m_cmd_save.ItemClick += new ItemClickEventHandler(this.m_cmd_save_ItemClick);
            this.m_cmd_save_as.Caption = "Сохранить как";
            this.m_cmd_save_as.Id = 2;
            this.m_cmd_save_as.Name = "m_cmd_save_as";
            this.m_cmd_save_as.ItemClick += new ItemClickEventHandler(this.m_cmd_save_as_ItemClick);
            this.m_menu_edit.Caption = "Правка";
            this.m_menu_edit.Id = 3;
            this.m_menu_edit.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_undo), new LinkPersistInfo(this.m_cmd_redo) });
            this.m_menu_edit.Name = "m_menu_edit";
            this.m_cmd_undo.Caption = "Отменить";
            this.m_cmd_undo.Id = 4;
            this.m_cmd_undo.ItemShortcut = new BarShortcut(Keys.Control | Keys.Z);
            this.m_cmd_undo.Name = "m_cmd_undo";
            this.m_cmd_undo.ItemClick += new ItemClickEventHandler(this.m_cmd_undo_ItemClick);
            this.m_cmd_redo.Caption = "Вернуть";
            this.m_cmd_redo.Id = 5;
            this.m_cmd_redo.ItemShortcut = new BarShortcut(Keys.Control | Keys.Y);
            this.m_cmd_redo.Name = "m_cmd_redo";
            this.m_cmd_redo.ItemClick += new ItemClickEventHandler(this.m_cmd_redo_ItemClick);
            this.m_menu_actions.Caption = "Действия";
            this.m_menu_actions.Id = 6;
            this.m_menu_actions.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_execute) });
            this.m_menu_actions.Name = "m_menu_actions";
            this.m_cmd_execute.Caption = "Выполнить";
            this.m_cmd_execute.Id = 8;
            this.m_cmd_execute.ItemShortcut = new BarShortcut(Keys.F5);
            this.m_cmd_execute.Name = "m_cmd_execute";
            this.m_cmd_execute.ItemClick += new ItemClickEventHandler(this.m_cmd_execute_ItemClick);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x28b, 0x1f7);
            base.Controls.Add(this.m_splitter);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Name = "ScenarioEditor";
            this.Text = "Редактор сценариев";
            this.m_splitter.EndInit();
            this.m_splitter.ResumeLayout(false);
            this.m_property_grid.EndInit();
            this.m_bar_manager.EndInit();
            base.ResumeLayout(false);
        }

        private void m_cmd_execute_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataScenario dataSource = this.m_tree_controller.DataSource as DataScenario;
            if (dataSource != null)
            {
                InfoBuffer buffer = new InfoBuffer();
                bool flag = dataSource.Validate(buffer);
                if (buffer.Count > 0)
                {
                    AppManager.InfoView.ShowBuffer(buffer);
                }
                if (flag)
                {
                    RunScenarioForm form = new RunScenarioForm {
                        ConnectionPair = this.m_pair ?? new ETLConnectionPair(),
                        Source = dataSource.Source,
                        Destination = dataSource.Destination
                    };
                    if (form.ShowDialog(this) == DialogResult.OK)
                    {
                        this.m_pair.LastAccessDate = DateTime.Now;
                        AppManager.Configurator.SaveSettings();
                        RunScenarioWork work = new RunScenarioWork(dataSource, form.GetInitializer());
                        BackgroundWorkerForm form3 = new BackgroundWorkerForm {
                            Work = work
                        };
                        form3.ShowDialog(this);
                    }
                }
            }
        }

        private void m_cmd_redo_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataScenario dataSource = this.m_tree_controller.DataSource as DataScenario;
            if ((dataSource != null) && (dataSource.History != null))
            {
                dataSource.History.Redo();
            }
        }

        private void m_cmd_save_as_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SaveFile(true);
        }

        private void m_cmd_save_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.SaveFile(string.IsNullOrEmpty(this.FileName) || !File.Exists(this.FileName));
        }

        private void m_cmd_undo_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataScenario dataSource = this.m_tree_controller.DataSource as DataScenario;
            if ((dataSource != null) && (dataSource.History != null))
            {
                dataSource.History.Undo();
            }
        }

        private void m_property_grid_RowChanged(object sender, RowChangedEventArgs e)
        {
            try
            {
                if (ReferenceEquals(this.m_tree.SelectedNode.Tag, this.m_property_grid.SelectedObject) && !(this.m_tree.SelectedNode.Tag is IBindingList))
                {
                    this.m_tree.SelectedNode.Text = this.m_property_grid.SelectedObject.ToString();
                }
            }
            catch
            {
            }
        }

        private void m_tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is IBindingList)
            {
                this.m_property_grid.SelectedObject = null;
            }
            else
            {
                this.m_property_grid.SelectedObject = e.Node.Tag;
            }
            this.m_property_grid.OptionsView.ShowRootCategories = ((this.m_property_grid.SelectedObject is ColumnAction) || (this.m_property_grid.SelectedObject is UpdateAction)) || (this.m_property_grid.SelectedObject is DataScenario);
            this.m_property_grid.RetrieveFields();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            DataScenario dataSource = this.m_tree_controller.DataSource as DataScenario;
            if (((dataSource != null) && (dataSource.History != null)) && dataSource.History.IsChanged)
            {
                MessageBoxEx ex = new MessageBoxEx("АРМ НДТМ", "Сохранить изменения в файле?", MessageBoxButtons.YesNoCancel, MessageBoxEx.Icons.Question);
                switch (ex.ShowDialog(this))
                {
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;

                    case DialogResult.Yes:
                        e.Cancel = !this.SaveFile(string.IsNullOrEmpty(this.FileName) || !File.Exists(this.FileName));
                        break;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            EventHandler<CommandEventArgs> handler = null;
            base.OnLoad(e);
            if (string.IsNullOrEmpty(this.FileName))
            {
                this.m_tree_controller.DataSource = new DataScenario();
                this.m_pair = new ETLConnectionPair();
            }
            else
            {
                FileStream stream = new FileStream(this.FileName, FileMode.Open, FileAccess.Read);
                try
                {
                    this.m_tree_controller.DataSource = new DataContractSerializer(typeof(DataScenario)).ReadObject(stream);
                    string source = ((DataScenario) this.m_tree_controller.DataSource).Source;
                    string destination = ((DataScenario) this.m_tree_controller.DataSource).Destination;
                    Info info = new Info("Для открываемого сценария не существуют описания одного или обоих источников данных. Попытка выполнения сценария приведёт к ошибке", InfoLevel.Info);
                    if (!DataScenario.Moulds.ContainsKey(source))
                    {
                        info.InnerMessages.Add(InfoLevel.Warning, "Источник данных {0} не зарегистрирован", new object[] { source });
                    }
                    if (!DataScenario.Moulds.ContainsKey(destination))
                    {
                        info.InnerMessages.Add(InfoLevel.Warning, "Приёмник данных {0} не зарегистрирован", new object[] { destination });
                    }
                    if (info.InnerMessages.Count > 0)
                    {
                        InfoBuffer buffer = new InfoBuffer {
                            info
                        };
                        AppManager.InfoView.ShowBuffer(buffer);
                    }
                }
                catch (Exception exception)
                {
                    AppManager.MessageLog.Log("ScenarioEditor", new Info(exception));
                    this.m_tree_controller.DataSource = new DataScenario();
                    this.FileName = "";
                }
                finally
                {
                    if (stream != null)
                    {
                        stream.Dispose();
                    }
                }
                if (!ETLSettings.Preferences.ScenarioConnections.TryGetValue(this.FileName, out this.m_pair))
                {
                    this.m_pair = new ETLConnectionPair();
                    ETLSettings.Preferences.ScenarioConnections.Add(this.FileName, this.m_pair);
                }
                this.m_pair.LastAccessDate = DateTime.Now;
            }
            DataScenario sc = this.m_tree_controller.DataSource as DataScenario;
            if ((sc != null) && (sc.History != null))
            {
                this.UpdateItems(sc.History);
                if (handler == null)
                {
                    handler = (s, args) => this.UpdateItems(sc.History);
                }
                sc.History.StateChanged += handler;
            }
        }

        private bool SaveFile(bool showDialog)
        {
            if (showDialog)
            {
                SaveFileDialog dialog = new SaveFileDialog {
                    Filter = "Data exchange scenarios|*.scn"
                };
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.FileName = dialog.FileName;
                }
            }
            if (!string.IsNullOrEmpty(this.FileName) && (this.m_tree_controller.DataSource is DataScenario))
            {
                using (FileStream stream = new FileStream(this.FileName, FileMode.Create))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(DataScenario));
                    using (XmlTextWriter writer = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        writer.Formatting = Formatting.Indented;
                        serializer.WriteObject(writer, this.m_tree_controller.DataSource);
                    }
                    ((DataScenario) this.m_tree_controller.DataSource).History.AcceptChanges();
                    this.UpdateItems(((DataScenario) this.m_tree_controller.DataSource).History);
                    this.m_pair.LastAccessDate = DateTime.Now;
                    ETLSettings.Preferences.ScenarioConnections[this.FileName] = this.m_pair;
                    return true;
                }
            }
            return false;
        }

        private void UpdateItems(CommandHistory history)
        {
            this.m_cmd_undo.Enabled = history.CanUndo;
            this.m_cmd_redo.Enabled = history.CanRedo;
            this.Text = history.IsChanged ? ((this.m_tree_controller.DataSource ?? "").ToString() + "*") : (this.m_tree_controller.DataSource ?? "").ToString();
            this.m_property_grid.Invalidate();
            this.m_property_grid.Update();
        }

        public string FileName { get; set; }
    }
}

