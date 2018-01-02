using NounSharp;
using NounSharp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace NounWpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _searchCommand = new DelegateCommand(OnSearch);
            this.Key = Properties.Settings.Default.AppKey;
            this.Secret = Properties.Settings.Default.AppSecret;
        }

        private string _key, _secret;
        private ICommand _searchCommand;
        private IEnumerable<Icon> _icons;
        private NounProjectService _service;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Key { get => _key; set => SetProperty(ref _key, value, changedHandler: OnKeyChanged); }
        public string Secret { get => _secret; set => SetProperty(ref _secret, value, changedHandler: OnSecretChanged); }
        public IEnumerable<Icon> Icons { get => _icons; set => SetProperty(ref _icons, value); }
        public ICommand SearchCommand => _searchCommand;

        private bool SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName]string propertyName = "", Action<T, T> changedHandler = null)
        {
            if (object.Equals(storage, value))
                return false;

            T old = storage;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            changedHandler?.Invoke(old, value);
            return true;
        }

        private async void OnSearch(object parameter)
        {
            if (_service == null)
            {
                _service = new NounProjectService(this.Key, this.Secret);
            }
            Icons = await _service.GetIconsAsync(parameter?.ToString());
        }

        private void OnKeyChanged(string old, string newValue)
        {
            Properties.Settings.Default.AppKey = newValue;
            Properties.Settings.Default.Save();
        }

        private void OnSecretChanged(string old, string newValue)
        {
            Properties.Settings.Default.AppSecret = newValue;
            Properties.Settings.Default.Save();
        }
    }

    public class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> execute)
        {
            _execute = execute;
        }

        private Action<object> _execute;

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
}
