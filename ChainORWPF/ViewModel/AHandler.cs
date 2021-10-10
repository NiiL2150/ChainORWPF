using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainORWPF.ViewModel
{
    abstract class AHandler : IHandler
    {
        public AHandler(UserViewModel viewModel)
        {
            ViewModel = viewModel;
        }
        public IHandler Successor { get; set; }
        public UserViewModel ViewModel { get; set; }
        public virtual bool Handle(User user)
        {
            if (this.Successor != null)
            {
                return this.Successor.Handle(user);
            }
            return false;
        }
    }
}
