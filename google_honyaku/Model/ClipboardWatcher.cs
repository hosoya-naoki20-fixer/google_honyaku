using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace google_honyaku.Model
{
    public class ClipBoardWatcher
    {
        ClipBoardWathcerForm form;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ClipBoardWatcher() {
            form = new ClipBoardWathcerForm();
        }
        private class ClipBoardWathcerForm : Form {
            [DllImport("user32.dll", SetLastError = true)]
            private extern static void AddClipboardFormatListener(IntPtr hwnd);

            [DllImport("user32.dll", SetLastError = true)]
            private extern static void RemoveClipboardFormatListener(IntPtr hwnd);

            private const int WM_CLIPBOARDUPDATE = 0x31D;

            

            public ClipBoardWathcerForm(){
                clipBoardWatchStart();
            }

            private void clipBoardWatchStart()
            {
                AddClipboardFormatListener(Handle);
            }
            private void clipBoardWatchEnd()
            {
                Debug.WriteLine("end......................");
                RemoveClipboardFormatListener(Handle);
            }
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_CLIPBOARDUPDATE)
                {
                    OnClipboardUpdate();//クリップボードに変更があったときに実行するメソッド
                    m.Result = IntPtr.Zero;
                }
                else
                    base.WndProc(ref m);
            }

            private void OnClipboardUpdate() {
                GetClipboardTextAndHonyakuAndChangeHoverText get;
                get = new GetClipboardTextAndHonyakuAndChangeHoverText();
                get.honyaku();
            }
        }



    }
    
}