using SQLite;
using System;
using System.IO;

namespace meucaixa
{
    public static class AppConstantes
    {
        public static string AppRoot = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        public static string LogFilePath = Path.Combine(AppRoot, LOGFILENAME);
        public static string DatabasePath = Path.Combine(AppRoot, DATABASEFILENAME);
        public const string LOGFILENAME = "MeuCaixaLog.txt";
        public const string DATABASEFILENAME = "meucaixa.db3";
        public const SQLiteOpenFlags Flags = SQLiteOpenFlags.ReadWrite |
            SQLiteOpenFlags.Create |
            SQLiteOpenFlags.SharedCache;
    }
}
