using System.Runtime.InteropServices;
using KeyboardAPI.Interops.Structs;

namespace KeyboardAPI.Interops.Methods
{
    public static class SendInputInterop
    {
        /// <summary>
        ///     Synthesizes keystrokes, mouse motions, and button clicks.
        /// </summary>
        /// <param name="nInputs">The number of structures in the pInputs array.</param>
        /// <param name="pInputs">
        ///     An array of INPUT structures. Each structure represents an event to be inserted into the keyboard
        ///     or mouse input stream.
        /// </param>
        /// <param name="cbSize">
        ///     The size, in bytes, of an INPUT structure. If cbSize is not the size of an INPUT structure, the
        ///     function fails.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);
    }
}