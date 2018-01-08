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
            _openLinkCommand = new DelegateCommand(OnOpenLink);
            this.Key = Properties.Settings.Default.AppKey;
            this.Secret = Properties.Settings.Default.AppSecret;
        }

        private string _key, _secret;
        private ICommand _searchCommand, _openLinkCommand;
        private IEnumerable<Icon> _icons;
        private bool _publicDomainOnly;
        private NounProjectService _service;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Key { get => _key; set => SetProperty(ref _key, value, changedHandler: OnKeyChanged); }
        public string Secret { get => _secret; set => SetProperty(ref _secret, value, changedHandler: OnSecretChanged); }
        public IEnumerable<Icon> Icons { get => _icons; set => SetProperty(ref _icons, value); }
        public bool PublicDomainOnly { get => _publicDomainOnly; set => SetProperty(ref _publicDomainOnly, value); }
        public ICommand SearchCommand => _searchCommand;
        public ICommand OpenLinkCommand => _openLinkCommand;

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
            Icons = await _service.GetIconsAsync(parameter?.ToString(), limitToPublicDomain: _publicDomainOnly);
        }

        private void OnOpenLink(object obj)
        {
            Uri urlToNavigate = obj as Uri;
            if (urlToNavigate == null)
                return;
            System.Diagnostics.Process.Start(urlToNavigate.AbsoluteUri);
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
