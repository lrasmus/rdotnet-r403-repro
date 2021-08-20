using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace RTest
{
    class REngine
    {
        [DllImport("R.dll", EntryPoint = "R_setStartTime")]
        public static extern void R_setStartTime();

        [DllImport("R.dll", EntryPoint = "R_DefParams")]
        public static extern void R_DefParams(ref RStart rs);

        [DllImport("R.dll", EntryPoint = "R_SetParams")]
        public static extern void R_SetParams(ref RStart rs);

        [DllImport("R.dll", EntryPoint = "setup_Rmainloop")]
        public static extern void setup_Rmainloop();

        [DllImport("R.dll", EntryPoint = "R_set_command_line_arguments")]
        public static extern void R_set_command_line_arguments(int argc, string[] argv);
    }
}
