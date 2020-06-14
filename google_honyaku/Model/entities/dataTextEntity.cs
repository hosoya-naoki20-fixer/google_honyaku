using google_honyaku.Model.entities.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace google_honyaku.Model.entities
{
    /// <summary>
    /// クリップボードから取得したテキストや、翻訳結果、各種フラグを格納するためのエンティティクラス
    /// </summary>
    public class DataTextEntity
    {
        /// <summary>
        /// クリップボードから取得した文字列
        /// </summary>
        public string ClipBoardText { get; set; }
        /// <summary>
        /// 翻訳後のテキスト
        /// </summary>
        public string HonyakuText { get; set; } = "";
        /// <summary>
        /// 翻訳前テキストの言語の種類
        /// </summary>
        public LanguageType LangType { get; set; }
        /// <summary>
        /// 翻訳後の言語がカタカナであるかの判定
        /// </summary>
        public bool KatakanaFlag { get; set; }
        /// <summary>
        /// カタカナだった場合の解説テキスト
        /// </summary>
        public string ExplaOfKatakana { get; set; }
    }
}
