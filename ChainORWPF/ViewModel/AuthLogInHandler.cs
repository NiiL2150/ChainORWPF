using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChainORWPF.ViewModel
{
    class AuthLogInHandler : AHandler
    {
        public AuthLogInHandler(UserViewModel viewModel) : base(viewModel) { }
        public override bool Handle(User user)
        {
            if (ViewModel.Users.Any(u => u.Name.Equals(user.Name) && u.Password.Equals(user.Password) && u.Code.Equals(user.Code)))
            {
                MessageBox.Show($"Welcome back, {user.Name}");
                return true;
            }
            else
            {
                MessageBox.Show("Invalid auth code");
                return false;
            }
        }
    }
}
