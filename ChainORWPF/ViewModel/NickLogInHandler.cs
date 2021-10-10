using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChainORWPF.ViewModel
{
    class NickLogInHandler : AHandler
    {
        public NickLogInHandler(UserViewModel viewModel) : base(viewModel)
        {
            Successor = new PassLogInHandler(viewModel);
        }
        public override bool Handle(User user)
        {
            if (ViewModel.Users.Any(u => u.Name.Equals(user.Name)))
            {
                return base.Handle(user);
            }
            else
            {
                MessageBox.Show("No user is found");
                return false;
            }
        }
    }
}
