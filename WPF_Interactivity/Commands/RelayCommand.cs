using System;
using System.Windows.Input;

namespace WPF_Interactivity.Commands
{
    public class RelayCommand : ICommand
    {
        Action _handler;
        public RelayCommand(Action h)
        {
            _handler = h;
        }

        public bool CanExecute(object parameter)
        {
            bool action = false;

            if (_handler != null)
            {
                action = true;
            }
            return action;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _handler();
        }
    }
}
