using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using AutoMapper;
using KeyboardAPI.Interops.Constants;
using KeyboardAPI.Interops.Enums;
using KeyboardAPI.Interops.Methods;
using KeyboardAPI.Interops.Structs;

namespace KeyboardAPI.APIs
{
    public class Keyboard : IKeyboard
    {
        private readonly IMapper _mapper;
        private WindowsHookExInterop.KeyboardHook _hookHandler;
        private IntPtr _hookId = IntPtr.Zero;

        private bool _isDisposed;

        public Keyboard(IMapper mapper)
        {
            _mapper = mapper;
        }

        public event EventHandler<KeyEventArgs> Received;

        public void Send(IEnumerable<KeyEventArgs> sequence)
        {
            var inputs = sequence.Select(arg => new INPUT
            {
                U = new INPUT_UNION
                {
                    ki = new KEYBDINPUT
                    {
                        dwFlags = arg.Action == KeyAction.KeyUp
                            ? KEYEVENTF.KEYUP
                            : 0,
                        wVk = _mapper.Map<Key, VIRTUAL_KEY_CODE>(arg.Key)
                    }
                }
            }).ToArray();

            var size = Marshal.SizeOf(inputs[0]);
            var result = SendInputInterop.SendInput((uint) inputs.Length, inputs, size);
            if (result != inputs.Length)
            {
                throw new InvalidOperationException();
            }
        }

        public void Install()
        {
            _hookHandler = HookFunc;
            _hookId = SetHook(_hookHandler);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Uninstall()
        {
            if (_hookId == IntPtr.Zero) return;
            WindowsHookExInterop.UnhookWindowsHookEx(_hookId);
            _hookId = IntPtr.Zero;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;
            if (disposing)
            {
                Uninstall();
            }

            _isDisposed = true;
        }

        ~Keyboard()
        {
            Dispose(false);
        }

        private static IntPtr SetHook(WindowsHookExInterop.KeyboardHook proc)
        {
            using (var module = Process.GetCurrentProcess().MainModule)
            {
                return WindowsHookExInterop.SetWindowsHookEx(
                    13,
                    proc,
                    GetModuleHandleInterop.GetModuleHandle(module.ModuleName),
                    0);
            }
        }

        private IntPtr HookFunc(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode < 0)
            {
                return WindowsHookExInterop.CallNextHookEx(_hookId, nCode, wParam, lParam);
            }

            var iwParam = wParam.ToInt32();

            if (iwParam == WINDOW_MESSAGE.WM_KEYDOWN || iwParam == WINDOW_MESSAGE.WM_SYSKEYDOWN)
            {
                {
                    var code = (VIRTUAL_KEY_CODE) Marshal.ReadInt32(lParam);
                    var key = _mapper.Map<VIRTUAL_KEY_CODE, Key>(code);
                    RaiseKeyEvent(new KeyEventArgs(key, KeyAction.KeyDown));
                }
            }
            else if (iwParam == WINDOW_MESSAGE.WM_KEYUP || iwParam == WINDOW_MESSAGE.WM_SYSKEYUP)
            {
                {
                    var code = (VIRTUAL_KEY_CODE) Marshal.ReadInt32(lParam);
                    var key = _mapper.Map<VIRTUAL_KEY_CODE, Key>(code);
                    RaiseKeyEvent(new KeyEventArgs(key, KeyAction.KeyUp));
                }
            }

            return WindowsHookExInterop.CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        protected virtual void RaiseKeyEvent(KeyEventArgs args)
        {
            Received?.Invoke(this, args);
        }
    }
}