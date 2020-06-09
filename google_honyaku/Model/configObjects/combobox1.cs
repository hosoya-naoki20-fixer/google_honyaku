using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace google_honyaku.Model.configObjects
{
    public class Combobox1
    {
        /// <summary>
        /// 設定1の選択肢
        /// </summary>
        public ComboBoxCustomItem[] combobox1()
        {
            ComboBoxCustomItem cbci1 = new ComboBoxCustomItem();
            cbci1.text = "要素1";
            cbci1.id = 1001;
            cbci1.key = "Key1";
        }
    }
}
