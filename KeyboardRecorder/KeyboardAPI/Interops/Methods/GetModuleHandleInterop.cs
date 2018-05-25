using System;
using System.Runtime.InteropServices;

namespace KeyboardAPI.Interops.Methods
{
    public static class GetModuleHandleInterop
    {
        /// <summary>
        ///     Retrieves a module handle for the specified module. The module must have been loaded by the calling process.
        /// </summary>
        /// <param name="lpModuleName">The name of the loaded module.</param>
        /// <returns></returns>
        [DllImport("kernel32.dll")]
        internal static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}