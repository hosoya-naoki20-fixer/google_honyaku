using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
//using System.Windows.Forms;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using google_honyaku.Model.entities;

namespace google_honyaku
{
    public partial class NotifyIconWrapper : Component
    {
        public NotifyIconWrapper()
        {
            
            InitializeComponent();

            //dataTextObjectの初期設定
            DataTextEntity dataText;
            dataText = new DataTextEntity();
            dataTextObjects.data = dataText;

            //アイコンクリック時のイベントを設定
            this.notifyIcon.Click += this.notifyIcon_Click;

            //コンテキストメニューのイベントを設定
            this.toolStripMenuItem_Exit.Click += this.toolStripMenuItem_Exit_Click;

        }


        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void notifyIcon_Click(object cender, EventArgs e)
        {
            Clipboard.SetDataObject(dataTextObjects.data.HonyakuText, true);
        }

        public void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }


    }
}
