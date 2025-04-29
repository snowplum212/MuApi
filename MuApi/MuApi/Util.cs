using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.Json;
using System.Runtime.CompilerServices;

namespace MuApi
{
    public class Util
    {
        /// <summary>
        /// 프로그램 실행 중복 여부 확인
        /// </summary>
        public static class SingleInstance
        {
            private static Mutex mutex;

            /// <summary>
            /// 프로그램 실행 중복 여부 확인
            /// </summary>
            /// <param name="uniqueName">프로그램 고유 이름 (Mutex 이름)</param>
            /// <returns>이미 실행 중이면 true, 아니면 false</returns>
            public static bool IsAppRunning(string uniqueName)
            {
                bool createdNew;
                mutex = new Mutex(true, uniqueName, out createdNew);
                return !createdNew;
            }

            /// <summary>
            /// 프로그램 종료 시 Mutex 해제
            /// </summary>
            public static void Release()
            {
                if (mutex != null)
                {
                    mutex.ReleaseMutex();
                    mutex = null;
                }
            }
        }

        public static class HttpHelper
        {
            private static readonly HttpClient client = new HttpClient();

            /// <summary>
            /// 지정된 URL에서 JSON 문자열을 비동기적으로 가져옵니다.
            /// </summary>
            /// <param name="url">API URL</param>
            /// <returns>JSON 문자열</returns>
            public static async Task<string> GetJsonStringAsync(string url)
            {
                var response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }

            /// <summary>
            /// 지정된 URL에서 JSON 데이터를 지정한 타입으로 비동기적으로 가져옵니다.
            /// </summary>
            /// <typeparam name="T">파싱할 타입</typeparam>
            /// <param name="url">API URL</param>
            /// <returns>파싱된 객체</returns>
            public static async Task<T> GetJsonAsync<T>(string url)
            {
                var json = await GetJsonStringAsync(url);
                return System.Text.Json.JsonSerializer.Deserialize<T>(json);
            }
        }
    }
}
