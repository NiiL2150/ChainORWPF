using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainORWPF.ViewModel
{
    interface IHandler
    {
        IHandler Successor { get; set; }
        UserViewModel ViewModel { get; set; }
        bool Handle(User user);
    }
}
