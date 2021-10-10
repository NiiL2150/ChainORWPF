using ChainORWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ChainORWPF.ViewModel
{
    class NickSignInHandler : AHandler
    {
        public NickSignInHandler(UserViewModel viewModel) : base(viewModel) { }
        public override bool Handle(User user)
        {
            if (ViewModel.Users.Any(u => u.Name.Equals(user.Name)))
            {
                MessageBox.Show("Such user exists");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
