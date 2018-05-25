using System;
using System.Runtime.InteropServices;

namespace KeyboardAPI.Interops.Methods
{
    public static class WindowsHookExInterop
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam">Determins key action like UP and DOWN</param>
        /// <param name="lParam">Determins Virtual Key Code</param>
        /// <returns></returns>
        internal delegate IntPtr KeyboardHook(
            int nCode,
            IntPtr wParam,
            IntPtr lParam);

        /// <summary>
        ///     Installs an application-defined hook procedure into a hook chain. You would install a hook procedure to monitor the
        ///     system for certain types of events. These events are associated either with a specific thread or with all threads
        ///     in the same desktop as the calling thread.
        /// </summary>
        /// <param name="idHook">The type of hook procedure to be installed.</param>
        /// <param name="lpfn">
        ///     A pointer to the hook procedure. If the dwThreadId parameter is zero or specifies the identifier of
        ///     a thread created by a different process, the lpfn parameter must point to a hook procedure in a DLL. Otherwise,
        ///     lpfn can point to a hook procedure in the code associated with the current process.
        /// </param>
        /// <param name="hMod">
        ///     A handle to the DLL containing the hook procedure pointed to by the lpfn parameter. The hMod
        ///     parameter must be set to NULL if the dwThreadId parameter specifies a thread created by the current process and if
        ///     the hook procedure is within the code associated with the current process.
        /// </param>
        /// <param name="dwThreadId">
        ///     The identifier of the thread with which the hook procedure is to be associated. For desktop
        ///     apps, if this parameter is zero, the hook procedure is associated with all existing threads running in the same
        ///     desktop as the calling thread. For Windows Store apps, see the Remarks section.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr SetWindowsHookEx(
            int idHook,
            KeyboardHook lpfn,
            IntPtr hMod,
            uint dwThreadId);

        /// <summary>
        ///     Removes a hook procedure installed in a hook chain by the SetWindowsHookEx function.
        /// </summary>
        /// <param name="hhk">
        ///     A handle to the hook to be removed. This parameter is a hook handle obtained by a previous call to
        ///     SetWindowsHookEx.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool UnhookWindowsHookEx(IntPtr hhk);

        /// <summary>
        ///     Passes the hook information to the next hook procedure in the current hook chain. A hook procedure can call this
        ///     function either before or after processing the hook information.
        /// </summary>
        /// <param name="hhk">This parameter is ignored.</param>
        /// <param name="nCode">
        ///     The hook code passed to the current hook procedure. The next hook procedure uses this code to
        ///     determine how to process the hook information.
        /// </param>
        /// <param name="wParam">
        ///     The wParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <param name="lParam">
        ///     The lParam value passed to the current hook procedure. The meaning of this parameter depends on
        ///     the type of hook associated with the current hook chain.
        /// </param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        internal static extern IntPtr CallNextHookEx(
            IntPtr hhk,
            int nCode,
            IntPtr wParam,
            IntPtr lParam);
    }
}