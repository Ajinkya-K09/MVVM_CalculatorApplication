using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_CalculatorApplication.Command
{
    public class RelayCommand : ICommand
    {
        Action<object> m_execute;
        Func<object, bool> m_canExecute;

        public RelayCommand(Action<object> executeCommand, Func<object, bool> canExecuteCommand)
        {
            m_execute = executeCommand;
            m_canExecute = canExecuteCommand;
        }

        public event EventHandler? CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }



        public bool CanExecute(object parameter)
        {
            if (m_canExecute == null)
            {
                return false;
            }
            else
            {
                return m_canExecute(parameter);
            }
        }

        public void Execute(object? parameter)
        {
            m_execute(parameter);
        }
    }
}
