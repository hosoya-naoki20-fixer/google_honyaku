using google_honyaku.Model.entities;
using google_honyaku.Model.entities.valueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using google_honyaku.Model.JsonObjects;

namespace google_honyaku.Model
{
    /// <summary>
    /// クリップボードからテキストを取得して、翻訳して、マウスオーバーテキストの結果を変える
    /// </summary>
    class GetClipboardTextAndHonyakuAndChangeHoverText
    {
        //インスタンスの宣言
        DataTextEntity dataText;

        public GetClipboardTextAndHonyakuAndChangeHoverText() {
            dataText = new DataTextEntity();
            dataTextObjects.data = dataText;
        }
        /// <summary>
        /// メインの処理
        /// </summary>
        public void honyaku() {
            dataText.ClipBoardText = getClipBoardText();
            dataText.LangType = checkLangType();
            dataText.HonyakuText = getTrancelationResult();
            if (dataText.HonyakuText.Length < 64)
            {
                classNotifyIcon.notifyIcon.Text = dataText.HonyakuText;
            }
            else 
            {
                string overText = dataText.HonyakuText.Substring(0, 62) + "…";
                //classNotifyIcon.notifyIcon.Text = dataText.HonyakuText.Substring(0, 63);
                classNotifyIcon.notifyIcon.Text = overText;
            }
        }


        /// <summary>
        /// クリップボードの内容を取得して返すメソッド
        /// </summary>
        /// <returns></returns>
        private string getClipBoardText() {
            IDataObject data = Clipboard.GetDataObject();
            string returnStr = "";
            if (data != null) {
                if (data.GetDataPresent(DataFormats.Text)) //クリップボード内のデータが文字列化を確認
                {
                    Console.WriteLine((string)data.GetData(DataFormats.Text));
                    returnStr = (string)data.GetData(DataFormats.Text);
                }
            }
            return (returnStr);
        }


        /// <summary>
        /// 文字列が何語かを判定する
        /// </summary>
        /// <returns></returns>
        private LanguageType checkLangType() {
            //今のところ、文字列内に一文字でも日本語があったら日本語。
            //なかったら英語
            bool jpneseFlag = false;
            LanguageType returnLanguageType;
            foreach (char c in dataText.ClipBoardText)
            {
                if (Regex.IsMatch(c.ToString(), @"^\p{IsHiragana}*$") || Regex.IsMatch(c.ToString(), @"^\p{IsKatakana}*$") || Regex.IsMatch(c.ToString(), @"^\p{IsCJKUnifiedIdeographs}*$"))
                {
                    jpneseFlag = true;
                    break;
                }
            }
            if (jpneseFlag == true)
            {
                returnLanguageType = LanguageType.Japanese;
                Console.WriteLine("日本語や");
            }
            else
            {
                returnLanguageType = LanguageType.English;
                Console.WriteLine("english");
            }
            return returnLanguageType;
        }

        /// <summary>
        /// 翻訳した結果を取得するメソッド
        /// </summary>
        /// <returns></returns>
        private string getTrancelationResult() 
        {
            string requestUrl;
            requestUrl = makeRequestUrl();
            Task<TrancelateAPIJsonObject> taskResultJson = GetHttpResponce<TrancelateAPIJsonObject>.getHttpResponce(requestUrl);
            TrancelateAPIJsonObject resultJson = taskResultJson.Result;
            string resultText;
            if (resultJson.code == 200)
            {
                resultText = resultJson.text;
                Console.WriteLine($"kekka{resultText}");
            }
            else {
                resultText = "結果を取得できませんでした";
            }

            return (resultText);
            
        }


        
        /// <summary>
        /// リクエストのためのURLの生成を行う
        /// </summary>
        /// <returns></returns>
        private string makeRequestUrl() 
        {
            string returnUrl;
            string baseUrl = "https://script.google.com/macros/s/AKfycbzQ1yQiZghWre8NScJzBwLUNEp9CvwME7X1DyH2txWz9o5jArkJ/exec";
            string text;
            string source;
            string target;

            

            text = Uri.EscapeDataString(dataText.ClipBoardText);
            Console.WriteLine("エスケープテキスト"+text);

            if (dataText.LangType == LanguageType.Japanese)
            {
                source = LanguageTypeExt.getLangCode(LanguageType.Japanese);
                target = LanguageTypeExt.getTargetCode(LanguageType.Japanese);
                Console.WriteLine(source);
                Console.WriteLine(target);
            }
            else if (dataText.LangType == LanguageType.English)
            {
                source = LanguageTypeExt.getLangCode(LanguageType.English);
                target = LanguageTypeExt.getTargetCode(LanguageType.English);
                Console.WriteLine(source);
                Console.WriteLine(target);
            }
            else
            {
                source = LanguageTypeExt.getLangCode(LanguageType.Unknone);
                target = LanguageTypeExt.getTargetCode(LanguageType.Unknone);
                Console.WriteLine(source);
                Console.WriteLine(target);
            }

            if (text.IndexOf("?") == -1 && text.IndexOf("&") == -1)
            {
                returnUrl = $"{baseUrl}?text={text}&source={source}&target={target}";
            }
            else
            {
                returnUrl = $"{baseUrl}?text=\'{text}\'&source={source}&target={target}";
            }


            return (returnUrl);
        }

        

    }
}
