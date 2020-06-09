using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace google_honyaku.Model.entities.valueObjects
{
    /// <summary>
    /// 言語の種類
    /// </summary>
    public enum LanguageType
    {
        /// <summary>
        /// 日本語
        /// </summary>
        Japanese = 0,
        /// <summary>
        /// 英語
        /// </summary>
        English = 1,
        /// <summary>
        /// 不明
        /// </summary>
        Unknone = 9,
    }
    /// <summary>
    /// 言語の種類に対応したコード？を返す
    /// </summary>
    static class LanguageTypeExt {
        public static string getLangCode(this LanguageType languageType) {
            string[] codes = { "ja", "en", "","","","","","","","auto"};
            return (codes[(int)languageType]);
        }
        /// <summary>
        /// それぞれの言語を何語に変換するかを定める
        /// 例えば、ja(日本語)はen(英語)に翻訳したいので、getLangCodeメソッドのjaと同じところにenを置いておく
        /// </summary>
        /// <param name="languageType"></param>
        /// <returns></returns>
        public static string getTargetCode(this LanguageType languageType) {
            string[] codes = { "en", "ja","","","","","","","","ja" };
            return (codes[(int)languageType]);
        }
    }
}
