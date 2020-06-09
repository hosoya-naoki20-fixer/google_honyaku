using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using google_honyaku.Model.JsonObjects;

namespace google_honyaku.Model
{
    /// <summary>
    /// json形式の返答を返す系のAPIにget通信でリクエストを送るクラス
    /// </summary>
    /// <typeparam name="T">帰ってくるjsonファイルの形式を示すクラス</typeparam>
    class GetHttpResponce<T>
    {
        async public static Task<T> getHttpResponce(string requestUrl) {
            HttpClient client = new HttpClient();
            HttpResponseMessage responce = await client.GetAsync(requestUrl).ConfigureAwait(false);
            T resJson;
            //if (responce.StatusCode == System.Net.HttpStatusCode.OK) { }
            //ここら辺に例外処理も入れる
            string resString = await responce.Content.ReadAsStringAsync();
            resJson = JsonConvert.DeserializeObject<T>(resString);
            return (resJson);

        }
    }
}
