using System.Windows.Input;
using Caliburn.Micro;
using KeyboardToolkit.HotKeys;

namespace ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        public MainWindowViewModel()
        {
            var hotKey = HotKey.Create(Key.Left, ModifierKeys.None);
            hotKey.Register();
            hotKey.Pressed += HotKeyOnPressed;
        }

        private void HotKeyOnPressed()
        {
        }
    }
}