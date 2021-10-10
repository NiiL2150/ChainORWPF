using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ChainORWPF.Service.Command
{
    public class RelayCommand : ICommand
    {
        private Action<object> _exec;
        private Func<bool> _canExec;
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return this._canExec();
        }

        public void Execute(object parameter)
        {
            this._exec(parameter);
        }

        public RelayCommand(Action<object> exec, Func<bool> canExec)
        {
            this._exec = exec;
            this._canExec = canExec;
        }

        public RelayCommand(Action<object> exec) : this(exec, () => true) { }
    }
}
