using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace google_honyaku
{
    public partial class NotifyIconWrapper : Component
    {
        public NotifyIconWrapper()
        {
            
            InitializeComponent();

            //コンテキストメニューのイベントを設定
            this.toolStripMenuItem_Exit.Click += this.toolStripMenuItem_Exit_Click;

        }


        public NotifyIconWrapper(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void toolStripMenuItem_Exit_Click(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void changeHoverText(string hoverText) {
            this.notifyIcon.Text = hoverText;
        }
    }
}
