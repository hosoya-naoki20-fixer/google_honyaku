using google_honyaku.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using google_honyaku.Model.entities;

namespace google_honyaku
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// タスクトレイに表示するアイコン
        /// </summary>
        public NotifyIconWrapper notifyIcon;


        


        /// <summary>
        /// クリップボードを監視
        /// </summary>
        private ClipBoardWatcher clipBoardWatcher;

        /// <summary>
        /// System.Windows.Application.Startup イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している StartupEventArgs</param>
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            this.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            this.notifyIcon = new NotifyIconWrapper();
            classNotifyIcon.notifyIcon = this.notifyIcon;
            this.clipBoardWatcher = new ClipBoardWatcher();
        }
        /// <summary>
        /// System.Windows.Application.Exit イベント を発生させます。
        /// </summary>
        /// <param name="e">イベントデータ を格納している ExitEventArgs</param>
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            this.notifyIcon.Dispose();
        }
    }

}
