using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChainORWPF.ViewModel
{
    class PassLogInHandler : AHandler
    {
        public PassLogInHandler(UserViewModel viewModel) : base(viewModel)
        {
            Successor = new AuthLogInHandler(viewModel);
        }
        public override bool Handle(User user)
        {
            if (ViewModel.Users.Any(u => u.Name.Equals(user.Name) && u.Password.Equals(user.Password)))
            {
                return base.Handle(user);
            }
            else
            {
                MessageBox.Show("Invalid password");
                return false;
            }
        }
    }
}
