using NounSharp;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace NounWpfApp.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _searchCommand = new DelegateCommand(OnSearch);
        }

        private string _key, _secret;
        private ICommand _searchCommand;

        public string Key { get => _key; set => SetProperty(ref _key, value); }
        public string Secret { get => _secret; set => SetProperty(ref _secret, value); }
        public ICommand SearchCommand => _searchCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName]string propertyName = "")
        {
            if (object.Equals(storage, value))
                return;

            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async void OnSearch(object parameter)
        {
            NounProjectService service = new NounProjectService(this.Key, this.Secret);
            var icons = await service.GetIconsAsync(parameter?.ToString());
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
