namespace Shell.UI
{
    using AT.ETL;
    using AT.Toolbox;
    using AT.Toolbox.Dialogs;
    using AT.Toolbox.Help;
    using DevExpress.LookAndFeel;
    using DevExpress.XtraBars;
    using ERMS.Core.Common;
    using ERMS.Core.DAL;
    using ERMS.UI;
    using GUOP;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using TransportModel;

    public class MainForm : FrameForm
    {
        private IContainer components;
        private DefaultLookAndFeel m_look_and_feel;
        private BarButtonItem m_cmd_scenarios;
        private BarButtonItem m_cmd_corect;
        private BarButtonItem m_cmd_db;
        private BarSubItem m_menu_service;
        private BarManager m_bar_manager;
        private Bar m_main_menu;
        private BarDockControl barDockControlTop;
        private BarDockControl barDockControlBottom;
        private BarDockControl barDockControlLeft;
        private BarDockControl barDockControlRight;
        private BarSubItem m_menu_file;
        private BarButtonItem m_cmd_open;
        private BarButtonItem m_cmd_create;
        private BarButtonItem m_cmd_exchange_modules;
        private BarSubItem m_menu_view;
        private BarButtonItem m_cmd_check_modules;
        private BarButtonItem m_cmd_settings;
        private BarButtonItem m_coord_insert_button;
        private BarSubItem m_menu_help;
        private BarButtonItem m_cmd_help;
        private BarButtonItem m_cmd_about;
        private BarButtonItem m_add_data_source_button;
        private BarButtonItem m_cmd_plugins;
        private BarSubItem m_menu_documents;
        private BarButtonItem barButtonItem1;
        private Bar m_status_bar;
        private BarStaticItem m_guop_cnn_string;

        public MainForm()
        {
            this.InitializeComponent();
        }

        public void CheckDocumentsMenuVisibility()
        {
            this.m_menu_documents.Visibility = RecordManager.DataSources.Contains(GUOPContext.DataSourceName) ? BarItemVisibility.Always : BarItemVisibility.Never;
            if (this.m_menu_documents.Visibility == BarItemVisibility.Always)
            {
                Program.Preferences.GUOPConnectionString = RecordManager.DataSources[GUOPContext.DataSourceName].RecordBinder.ConnectionString;
                this.m_guop_cnn_string.Caption = Program.Preferences.GUOPConnectionString;
            }
            else
            {
                this.m_guop_cnn_string.Caption = "";
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
            this.components = new Container();
            CollectionFormAction item = new CollectionFormAction();
            CollectionFormAction action2 = new CollectionFormAction();
            ComponentResourceManager manager = new ComponentResourceManager(typeof(MainForm));
            this.m_cmd_scenarios = new BarButtonItem();
            this.m_cmd_db = new BarButtonItem();
            this.m_bar_manager = new BarManager(this.components);
            this.m_main_menu = new Bar();
            this.m_menu_file = new BarSubItem();
            this.m_cmd_create = new BarButtonItem();
            this.m_cmd_open = new BarButtonItem();
            this.m_cmd_settings = new BarButtonItem();
            this.m_menu_documents = new BarSubItem();
            this.m_menu_service = new BarSubItem();
            this.m_add_data_source_button = new BarButtonItem();
            this.m_cmd_plugins = new BarButtonItem();
            this.m_menu_view = new BarSubItem();
            this.m_cmd_exchange_modules = new BarButtonItem();
            this.m_cmd_check_modules = new BarButtonItem();
            this.m_menu_help = new BarSubItem();
            this.m_cmd_help = new BarButtonItem();
            this.m_cmd_about = new BarButtonItem();
            this.barDockControlTop = new BarDockControl();
            this.barDockControlBottom = new BarDockControl();
            this.barDockControlLeft = new BarDockControl();
            this.barDockControlRight = new BarDockControl();
            this.m_cmd_corect = new BarButtonItem();
            this.m_coord_insert_button = new BarButtonItem();
            this.barButtonItem1 = new BarButtonItem();
            this.m_look_and_feel = new DefaultLookAndFeel(this.components);
            this.m_status_bar = new Bar();
            this.m_guop_cnn_string = new BarStaticItem();
            base.m_dock_manager.BeginInit();
            ((ISupportInitialize) base.m_action_set).BeginInit();
            this.m_bar_manager.BeginInit();
            base.SuspendLayout();
            base.m_dock_manager.DockingOptions.ShowCloseButton = false;
            base.m_log_panel.Options.ShowCloseButton = false;
            base.m_log_panel.Size = new Size(0x32b, 200);
            base.m_log_panel.Text = "Log";
            item.BusinessObjectType = typeof(Scenario);
            item.MenuItem = this.m_cmd_scenarios;
            action2.BusinessObjectType = typeof(VisumDatabase);
            action2.MenuItem = this.m_cmd_db;
            base.m_action_set.Actions.Add(item);
            base.m_action_set.Actions.Add(action2);
            this.m_cmd_scenarios.Caption = "barButtonItem1";
            this.m_cmd_scenarios.Id = 5;
            this.m_cmd_scenarios.Name = "m_cmd_scenarios";
            this.m_cmd_db.Caption = "barButtonItem1";
            this.m_cmd_db.Id = 6;
            this.m_cmd_db.Name = "m_cmd_db";
            this.m_bar_manager.Bars.AddRange(new Bar[] { this.m_main_menu, this.m_status_bar });
            this.m_bar_manager.DockControls.Add(this.barDockControlTop);
            this.m_bar_manager.DockControls.Add(this.barDockControlBottom);
            this.m_bar_manager.DockControls.Add(this.barDockControlLeft);
            this.m_bar_manager.DockControls.Add(this.barDockControlRight);
            this.m_bar_manager.Form = this;
            this.m_bar_manager.Items.AddRange(new BarItem[] { 
                this.m_cmd_scenarios, this.m_cmd_corect, this.m_cmd_db, this.m_menu_service, this.m_menu_file, this.m_cmd_open, this.m_cmd_create, this.m_cmd_exchange_modules, this.m_menu_view, this.m_cmd_check_modules, this.m_cmd_settings, this.m_coord_insert_button, this.m_menu_help, this.m_cmd_help, this.m_cmd_about, this.m_add_data_source_button,
                this.m_cmd_plugins, this.m_menu_documents, this.barButtonItem1, this.m_guop_cnn_string
            });
            this.m_bar_manager.MainMenu = this.m_main_menu;
            this.m_bar_manager.MaxItemId = 0x22;
            this.m_bar_manager.StatusBar = this.m_status_bar;
            this.m_main_menu.BarName = "Custom 1";
            this.m_main_menu.DockCol = 0;
            this.m_main_menu.DockRow = 0;
            this.m_main_menu.DockStyle = BarDockStyle.Top;
            this.m_main_menu.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_menu_file), new LinkPersistInfo(this.m_menu_documents), new LinkPersistInfo(this.m_menu_service), new LinkPersistInfo(this.m_menu_view), new LinkPersistInfo(this.m_menu_help) });
            this.m_main_menu.OptionsBar.AllowQuickCustomization = false;
            this.m_main_menu.OptionsBar.DrawDragBorder = false;
            this.m_main_menu.OptionsBar.MultiLine = true;
            this.m_main_menu.OptionsBar.UseWholeRow = true;
            this.m_main_menu.Text = "Custom 1";
            this.m_menu_file.Caption = "Файл";
            this.m_menu_file.Id = 11;
            this.m_menu_file.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_create), new LinkPersistInfo(this.m_cmd_open), new LinkPersistInfo(this.m_cmd_settings, true) });
            this.m_menu_file.MergeType = BarMenuMerge.MergeItems;
            this.m_menu_file.Name = "m_menu_file";
            this.m_cmd_create.Caption = "Создать сценарий";
            this.m_cmd_create.Id = 13;
            this.m_cmd_create.Name = "m_cmd_create";
            this.m_cmd_create.ItemClick += new ItemClickEventHandler(this.m_cmd_create_ItemClick);
            this.m_cmd_open.Caption = "Открыть сценарий";
            this.m_cmd_open.Id = 12;
            this.m_cmd_open.Name = "m_cmd_open";
            this.m_cmd_open.ItemClick += new ItemClickEventHandler(this.m_cmd_open_ItemClick);
            this.m_cmd_settings.Caption = "Настройки";
            this.m_cmd_settings.Id = 20;
            this.m_cmd_settings.MergeOrder = 10;
            this.m_cmd_settings.Name = "m_cmd_settings";
            this.m_cmd_settings.ItemClick += new ItemClickEventHandler(this.m_cmd_settings_ItemClick);
            this.m_menu_documents.Caption = "Документы";
            this.m_menu_documents.Id = 0x1c;
            this.m_menu_documents.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_db), new LinkPersistInfo(this.m_cmd_scenarios) });
            this.m_menu_documents.MergeOrder = 10;
            this.m_menu_documents.MergeType = BarMenuMerge.MergeItems;
            this.m_menu_documents.Name = "m_menu_documents";
            this.m_menu_service.Caption = "Сервис";
            this.m_menu_service.Id = 7;
            this.m_menu_service.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_add_data_source_button), new LinkPersistInfo(this.m_cmd_plugins) });
            this.m_menu_service.MergeOrder = 20;
            this.m_menu_service.Name = "m_menu_service";
            this.m_add_data_source_button.Caption = "Описания источников данных";
            this.m_add_data_source_button.Id = 0x19;
            this.m_add_data_source_button.Name = "m_add_data_source_button";
            this.m_add_data_source_button.ItemClick += new ItemClickEventHandler(this.m_add_data_source_button_ItemClick);
            this.m_cmd_plugins.Caption = "Модули расширения функциональности";
            this.m_cmd_plugins.Id = 0x1b;
            this.m_cmd_plugins.Name = "m_cmd_plugins";
            this.m_cmd_plugins.ItemClick += new ItemClickEventHandler(this.m_cmd_plugins_ItemClick);
            this.m_menu_view.Caption = "Вид";
            this.m_menu_view.Id = 0x12;
            this.m_menu_view.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_exchange_modules), new LinkPersistInfo(this.m_cmd_check_modules) });
            this.m_menu_view.MergeOrder = 30;
            this.m_menu_view.Name = "m_menu_view";
            this.m_menu_view.Visibility = BarItemVisibility.Never;
            this.m_cmd_exchange_modules.Caption = "Модули обмена данными";
            this.m_cmd_exchange_modules.Id = 0x11;
            this.m_cmd_exchange_modules.Name = "m_cmd_exchange_modules";
            this.m_cmd_exchange_modules.ItemClick += new ItemClickEventHandler(this.m_cmd_modules_ItemClick);
            this.m_cmd_check_modules.Caption = "Модули проверки НДТМ";
            this.m_cmd_check_modules.Id = 0x13;
            this.m_cmd_check_modules.Name = "m_cmd_check_modules";
            this.m_menu_help.Caption = "Справка";
            this.m_menu_help.Id = 0x16;
            this.m_menu_help.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_cmd_help), new LinkPersistInfo(this.m_cmd_about) });
            this.m_menu_help.MergeOrder = 100;
            this.m_menu_help.Name = "m_menu_help";
            this.m_cmd_help.Caption = "Руководство оператора";
            this.m_cmd_help.Id = 0x17;
            this.m_cmd_help.Name = "m_cmd_help";
            this.m_cmd_help.ItemClick += new ItemClickEventHandler(this.m_cmd_help_ItemClick);
            this.m_cmd_about.Caption = "О программе";
            this.m_cmd_about.Id = 0x18;
            this.m_cmd_about.Name = "m_cmd_about";
            this.m_cmd_about.ItemClick += new ItemClickEventHandler(this.m_cmd_about_ItemClick);
            this.m_cmd_corect.Caption = "Корректировка координат";
            this.m_cmd_corect.Id = 10;
            this.m_cmd_corect.Name = "m_cmd_corect";
            this.m_cmd_corect.ItemClick += new ItemClickEventHandler(this.m_cmd_corect_ItemClick);
            this.m_coord_insert_button.Caption = "Заполнение координат для точек дороги";
            this.m_coord_insert_button.Id = 0x15;
            this.m_coord_insert_button.Name = "m_coord_insert_button";
            this.barButtonItem1.Id = 0x20;
            this.barButtonItem1.Name = "barButtonItem1";
            this.m_look_and_feel.LookAndFeel.SkinName = "Black";
            this.m_status_bar.BarName = "Custom 3";
            this.m_status_bar.CanDockStyle = BarCanDockStyle.Bottom;
            this.m_status_bar.DockCol = 0;
            this.m_status_bar.DockRow = 0;
            this.m_status_bar.DockStyle = BarDockStyle.Bottom;
            this.m_status_bar.LinksPersistInfo.AddRange(new LinkPersistInfo[] { new LinkPersistInfo(this.m_guop_cnn_string) });
            this.m_status_bar.OptionsBar.AllowQuickCustomization = false;
            this.m_status_bar.OptionsBar.DrawDragBorder = false;
            this.m_status_bar.OptionsBar.UseWholeRow = true;
            this.m_status_bar.Text = "Custom 3";
            this.m_guop_cnn_string.Caption = "CNN";
            this.m_guop_cnn_string.Id = 0x21;
            this.m_guop_cnn_string.Name = "m_guop_cnn_string";
            this.m_guop_cnn_string.TextAlignment = StringAlignment.Near;
            this.AllowDrop = true;
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x34c, 0x293);
            base.Controls.Add(this.barDockControlLeft);
            base.Controls.Add(this.barDockControlRight);
            base.Controls.Add(this.barDockControlBottom);
            base.Controls.Add(this.barDockControlTop);
            base.Icon = (Icon) manager.GetObject("$this.Icon");
            base.Name = "MainForm";
            this.Text = "АРМ ФНДТМ";
            base.Controls.SetChildIndex(this.barDockControlTop, 0);
            base.Controls.SetChildIndex(this.barDockControlBottom, 0);
            base.Controls.SetChildIndex(this.barDockControlRight, 0);
            base.Controls.SetChildIndex(this.barDockControlLeft, 0);
            base.m_dock_manager.EndInit();
            ((ISupportInitialize) base.m_action_set).EndInit();
            this.m_bar_manager.EndInit();
            base.ResumeLayout(false);
        }

        private void m_add_data_source_button_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataSourceForm form = null;
            foreach (Form form2 in base.MdiChildren)
            {
                form = form2 as DataSourceForm;
                if (form != null)
                {
                    break;
                }
            }
            if (form == null)
            {
                form = new DataSourceForm {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void m_cmd_about_ItemClick(object sender, ItemClickEventArgs e)
        {
            new AboutBox().ShowDialog(this);
        }

        private void m_cmd_corect_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Text files|*.txt"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                CorrectCoordinatesWork work = new CorrectCoordinatesWork {
                    FileName = dialog.FileName
                };
                new BackgroundWorkerForm { Work = work }.ShowDialog(this);
            }
        }

        private void m_cmd_create_ItemClick(object sender, ItemClickEventArgs e)
        {
            new ScenarioEditor { MdiParent = this }.Show();
        }

        private void m_cmd_help_ItemClick(object sender, ItemClickEventArgs e)
        {
            ApplicationHelp.ShowFullHelp();
        }

        private void m_cmd_modules_ItemClick(object sender, ItemClickEventArgs e)
        {
        }

        private void m_cmd_open_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = "Data exchange scenarios|*.scn"
            };
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                new ScenarioEditor { 
                    FileName = dialog.FileName,
                    MdiParent = this
                }.Show();
            }
        }

        private void m_cmd_plugins_ItemClick(object sender, ItemClickEventArgs e)
        {
            PluginsForm form = null;
            foreach (Form form2 in base.MdiChildren)
            {
                form = form2 as PluginsForm;
                if (form != null)
                {
                    break;
                }
            }
            if (form == null)
            {
                form = new PluginsForm {
                    MdiParent = this
                };
                form.Show();
            }
            else
            {
                form.Activate();
            }
        }

        private void m_cmd_settings_ItemClick(object sender, ItemClickEventArgs e)
        {
            new SettingsForm().ShowDialog(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.CheckDocumentsMenuVisibility();
            if (!RecordManager.DataSources.Contains(GUOPContext.DataSourceName))
            {
                this.m_menu_documents.Visibility = BarItemVisibility.Never;
            }
            string[] strArray = (from kv in ETLSettings.Preferences.ScenarioConnections
                orderby kv.Value.LastAccessDate descending
                select kv.Key into file
                where File.Exists(file)
                select file).Take<string>(10).ToArray<string>();
            for (int i = 0; i < strArray.Length; i++)
            {
                string name = strArray[i];
                BarButtonItem item = new BarButtonItem();
                item.Caption = SystemExtensions.TruncatePath(name, item.Font, 200);
                item.MergeOrder = i + 100;
                item.ItemClick += (s, ea) => new ScenarioEditor {
                    FileName = name,
                    MdiParent = this
                }.Show();
                this.m_menu_file.ItemLinks.Add(item, i == 0);
            }
            Dictionary<string, Action> dictionary = new Dictionary<string, Action>();
            foreach (Assembly assembly in AppInstance.ToolboxAssemblies)
            {
                foreach (System.Type type in assembly.GetTypes())
                {
                    if ((!type.IsAbstract && typeof(IRunnable).IsAssignableFrom(type)) && (type.GetConstructor(System.Type.EmptyTypes) != null))
                    {
                        IRunnable item = (IRunnable) Activator.CreateInstance(type);
                        dictionary[type.GetDisplayName()] = () => item.Run(this);
                    }
                }
            }
            if (dictionary.Count > 0)
            {
                BarSubItem item = new BarSubItem {
                    Caption = "Процессы",
                    MergeType = BarMenuMerge.MergeItems,
                    MergeOrder = 15
                };
                this.m_main_menu.ItemLinks.Insert(2, item);
                foreach (KeyValuePair<string, Action> pair in dictionary)
                {
                    BarButtonItem item3 = new BarButtonItem {
                        Caption = pair.Key
                    };
                    Action action = pair.Value;
                    item3.ItemClick += (s, ea) => action();
                    item.ItemLinks.Add(item3);
                }
            }
            base.ShowLog = true;
        }
    }
}

