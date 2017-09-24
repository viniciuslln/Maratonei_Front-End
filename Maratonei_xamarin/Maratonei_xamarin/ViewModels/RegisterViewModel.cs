﻿using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using TvDbSharper.Dto;

namespace Maratonei_xamarin.ViewModels
{
    public class RegisterViewModel : BaseViewModel, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool isBusy;
        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                RaisePropertyChanged("IsBusy");
            }
        }
        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public async Task RegisterNewUser(User p_User)
        {
            var v_HttpClient = new HttpClient();
        }
    }
}