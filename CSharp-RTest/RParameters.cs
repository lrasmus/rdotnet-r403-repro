using System;
using System.Runtime.InteropServices;
using System.Text;


// The following code was all taken/adapted from:
// https://github.com/rdotnet/rdotnet

// RDotNet is released under the MIT license

namespace RTest
{
    /// <summary>
    /// User's decision.
    /// </summary>
    public enum YesNoCancel
    {
        /// <summary>
        /// User agreed.
        /// </summary>
        Yes = 1,

        /// <summary>
        /// User disagreed.
        /// </summary>
        No = -1,

        /// <summary>
        /// User abandoned to answer.
        /// </summary>
        Cancel = 0,
    }

    /// <summary>
    /// Type of R's working.
    /// </summary>
    public enum BusyType
    {
        /// <summary>
        /// Terminated states of business.
        /// </summary>
        None = 0,

        /// <summary>
        /// Embarks on an extended computation
        /// </summary>
        ExtendedComputation = 1,
    }

    /// <summary>
    /// Specifies console to output.
    /// </summary>
    public enum ConsoleOutputType
    {
        /// <summary>
        /// The default value.
        /// </summary>
        None = 0,
    }

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    [return: MarshalAs(UnmanagedType.Bool)]
    internal delegate bool blah1([In][MarshalAs(UnmanagedType.LPStr)] string prompt, [MarshalAs(UnmanagedType.LPStr)] StringBuilder buffer, int length, [MarshalAs(UnmanagedType.Bool)] bool history);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void blah2([In][MarshalAs(UnmanagedType.LPStr)] string buffer, int length);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void blah3();

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void blah4([In][MarshalAs(UnmanagedType.LPStr)] string message);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate YesNoCancel blah5([In][MarshalAs(UnmanagedType.LPStr)] string question);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void blah6(BusyType which);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate void blah7([In][MarshalAs(UnmanagedType.LPStr)] string buffer, int length, ConsoleOutputType outputType);

    /// <summary>
    /// Specifies the restore action.
    /// </summary>
    public enum StartupRestoreAction
    {
        /// <summary>
        /// Not restoring.
        /// </summary>
        NoRestore = 0,

        /// <summary>
        /// Restoring.
        /// </summary>
        Restore = 1,

        /// <summary>
        /// The default value.
        /// </summary>
        Default = 2,
    }

    /// <summary>
    /// Specifies the save action.
    /// </summary>
    public enum StartupSaveAction
    {
        /// <summary>
        /// The default value.
        /// </summary>
        Default = 2,

        /// <summary>
        /// No saving.
        /// </summary>
        NoSave = 3,

        /// <summary>
        /// Saving.
        /// </summary>
        Save = 4,

        /// <summary>
        /// Asking user.
        /// </summary>
        Ask = 5,

        /// <summary>
        /// Terminates without any actions.
        /// </summary>
        Suicide = 6,
    }

    /// <summary>
    /// User interface mode
    /// </summary>
    public enum UiMode
    {
        /// <summary>
        /// R graphical user interface
        /// </summary>
        RGui,

        /// <summary>
        /// R terminal console
        /// </summary>
        RTerminal,

        /// <summary>
        /// R dynamic (shared) library
        /// </summary>
        LinkDll
    }

    [StructLayout(LayoutKind.Sequential)]
    internal struct RStart
    {
        [MarshalAs(UnmanagedType.Bool)]
        public bool R_Quiet;

        [MarshalAs(UnmanagedType.Bool)]
        public bool R_Slave;

        [MarshalAs(UnmanagedType.Bool)]
        public bool R_Interactive;

        [MarshalAs(UnmanagedType.Bool)]
        public bool R_Verbose;

        [MarshalAs(UnmanagedType.Bool)]
        public bool LoadSiteFile;

        [MarshalAs(UnmanagedType.Bool)]
        public bool LoadInitFile;

        [MarshalAs(UnmanagedType.Bool)]
        public bool DebugInitFile;

        public StartupRestoreAction RestoreAction;
        public StartupSaveAction SaveAction;
        internal UIntPtr vsize;
        internal UIntPtr nsize;
        internal UIntPtr max_vsize;
        internal UIntPtr max_nsize;
        internal UIntPtr ppsize;

        [MarshalAs(UnmanagedType.Bool)]
        public bool NoRenviron;

        public IntPtr rhome;
        public IntPtr home;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah1 ReadConsole;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah2 WriteConsole;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah3 CallBack;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah4 ShowMessage;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah5 YesNoCancel;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah6 Busy;

        public UiMode CharacterMode;

        [MarshalAs(UnmanagedType.FunctionPtr)]
        public blah7 WriteConsoleEx;
    }
}