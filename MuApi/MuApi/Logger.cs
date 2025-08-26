using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MuApi
{
    public class Logger
    {
        public static class LogHelper
        {
            private static readonly string baseLogDir = @"C:\MyDebugLogs";

            private static string GetLogFolderPath()
            {
                string programName = Assembly.GetEntryAssembly()?.GetName().Name ?? "UnknownProgram";
                return Path.Combine(baseLogDir, programName);
            }

            private static string GetLogFilePath()
            {
                string folder = GetLogFolderPath();
                string fileName = $"Log_{System.DateTime.Now:yyyyMMdd}.txt";
                return Path.Combine(folder, fileName);
            }

            /// <summary>
            /// 로그 저장 (호출 위치 정보 포함)
            /// </summary>
            /// <param name="message">로그 메시지</param>
            /// <param name="callerFilePath">호출한 소스 파일 경로 (자동 전달)</param>
            /// <param name="callerMemberName">호출한 메서드 이름 (자동 전달)</param>
            /// <param name="callerLineNumber">호출한 소스 코드 라인 번호 (자동 전달)</param>
            public static void Log(string message = "",
                [CallerFilePath] string callerFilePath = "",
                [CallerMemberName] string callerMemberName = "",
                [CallerLineNumber] int callerLineNumber = 0)
            {
                try
                {
                    string folderPath = GetLogFolderPath();
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string logFilePath = GetLogFilePath();
                    string timestamp = System.DateTime.Now.ToString("MM/dd HH:mm:ss");
                    string programName = Assembly.GetEntryAssembly()?.GetName().Name ?? "UnknownProgram";

                    string fileName = Path.GetFileName(callerFilePath);

                    string logEntry = $"{programName} {timestamp} [{fileName}:{callerLineNumber} {callerMemberName}] : {message}";

                    using (StreamWriter writer = new StreamWriter(logFilePath, true))
                    {
                        writer.WriteLine(logEntry);
                    }
                }
                catch
                {
                    // 예외 무시 또는 별도 처리
                }
            }

            public static void Error(Exception ex,
                                    [CallerFilePath] string callerFilePath = "",
                                    [CallerMemberName] string callerMemberName = "",
                                    [CallerLineNumber] int callerLineNumber = 0)
            {
                try
                {
                    string message = $"[ERROR] {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}";
                    Log(message, callerFilePath, callerMemberName, callerLineNumber);
                }
                catch
                {
                    // 예외 무시
                }
            }

        }
    }
}