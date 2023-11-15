using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WPFDemo.Core
{
    /// <summary>
    /// Used for updating the UI when binding
    /// </summary>
    class ObservableObject : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name  = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
