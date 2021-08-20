using System;
using System.Runtime.InteropServices;
using System.Text;

namespace RTest
{
    class Program
    {

        private static bool ReadConsole(string prompt, StringBuilder buffer, int count, bool history)
        {
            return false;
        }

        private static void WriteConsole(string buffer, int length)
        {
        }

        private static void WriteConsoleEx(string buffer, int length, ConsoleOutputType outputType)
        {
        }

        private static void ShowMessage(string message)
        {
        }

        private static void Busy(BusyType which)
        {
        }

        private static void Callback()
        {
        }

        private static YesNoCancel Ask(string question)
        {
            return YesNoCancel.No;
        }

        static void Main(string[] args)
        {
            REngine.R_setStartTime();

            RStart start = new RStart();
            REngine.R_DefParams(ref start);

            start.rhome = Marshal.StringToHGlobalAnsi("C:/Development/R/r-base/R-devel");
            start.home = Marshal.StringToHGlobalAnsi("C:/Development/R/r-base/R-devel");
            start.CharacterMode = UiMode.LinkDll;
            start.R_Quiet = false;
            start.R_Interactive = false;
            start.ReadConsole = ReadConsole;
            start.WriteConsole = WriteConsole;
            start.WriteConsoleEx = WriteConsoleEx;
            start.CallBack = Callback;
            start.ShowMessage = ShowMessage;
            start.Busy = Busy;
            start.RestoreAction = StartupRestoreAction.NoRestore;
            start.SaveAction = StartupSaveAction.NoSave;

            REngine.R_SetParams(ref start);
            REngine.R_set_command_line_arguments(args.Length, args);

            REngine.setup_Rmainloop();

            Console.WriteLine(start);
        }
    }
}
