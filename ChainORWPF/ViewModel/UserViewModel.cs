using ChainORWPF.Model;
using ChainORWPF.Service;
using ChainORWPF.Service.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainORWPF.ViewModel
{
    class UserViewModel : INotifyPropertyChanged
    {
        NickLogInHandler LogInHandler { get; set; }
        NickSignInHandler SignInHandler { get; set; }

        private Random _random = new Random();
        private IFileService _fileService;
        public ObservableCollection<User> Users { get; set; } 
            = new ObservableCollection<User>();
        public UserViewModel(IFileService fileService)
        {
            _fileService = fileService;
            LogInHandler = new NickLogInHandler(this);
            SignInHandler = new NickSignInHandler(this);
            OpenCommand.Execute(Users);
        }

        private string _newNick;
        private string _newPass;
        private int _newCode;

        public string NewNick
        {
            get => _newNick;
            set
            {
                _newNick = value;
                OnPropertyChanged(nameof(NewNick));
            }
        }

        public string NewPass
        {
            get => _newPass;
            set
            {
                _newPass = value;
                OnPropertyChanged(nameof(NewPass));
            }
        }

        public int NewCode
        {
            get => _newCode;
            set
            {
                _newCode = value;
                OnPropertyChanged(nameof(NewCode));
            }
        }

        private string _oldNick;
        private string _oldPass;
        private int _oldCode;

        public string OldNick
        {
            get => _oldNick;
            set
            {
                _oldNick = value;
                OnPropertyChanged(nameof(OldNick));
            }
        }

        public string OldPass
        {
            get => _oldPass;
            set
            {
                _oldPass = value;
                OnPropertyChanged(nameof(OldPass));
            }
        }

        public int OldCode
        {
            get => _oldCode;
            set
            {
                _oldCode = value;
                OnPropertyChanged(nameof(OldCode));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private RelayCommand _saveCommand;
        private RelayCommand _openCommand;
        private RelayCommand _addCommand;
        private RelayCommand _logInCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _saveCommand ?? (_saveCommand = new RelayCommand(obj =>
                _fileService.Save("users.json", Users.Select(u => new User
                {
                    Code = u.Code,
                    Name = u.Name,
                    Password = u.Password
                }).ToList())
                ));
            }
        }

        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ?? (_openCommand = new RelayCommand(obj =>
                {
                    var users = _fileService.Open("users.json");
                    Users.Clear();
                    foreach (var u in users)
                    {
                        Users.Add(u);
                    }
                }
                ));
            }
        }

        public RelayCommand AddCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new RelayCommand(obj =>
                {
                    User user = new User();
                    NewCode = _random.Next(100000, 1000000);
                    user.Code = NewCode;
                    user.Name = NewNick;
                    user.Password = NewPass;
                    if (SignInHandler.Handle(user))
                    {
                        Users.Add(user);
                    }
                    else
                    {
                        NewCode = 0;
                    }
                    NewNick = "";
                    NewPass = "";
                    if (SaveCommand.CanExecute(Users))
                        SaveCommand.Execute(Users);
                }));
            }
        }

        public RelayCommand LogInCommand
        {
            get
            {
                return _logInCommand ?? (_logInCommand = new RelayCommand(obj =>
                {
                    User user = new User();
                    user.Code = OldCode;
                    user.Name = OldNick;
                    user.Password = OldPass;
                    LogInHandler.Handle(user);
                }));
            }
        }
    }
}
