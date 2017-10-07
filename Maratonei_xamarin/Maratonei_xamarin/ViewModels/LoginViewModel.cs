﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Maratonei_xamarin.Data_Storage;
using Maratonei_xamarin.Helpers;
using Maratonei_xamarin.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Plugin.Connectivity;

namespace Maratonei_xamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel, INotifyPropertyChanged
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

        public bool NetworkStatus
        {
            get { return CrossConnectivity.Current.IsConnected; }
        }

        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public async Task<string> AutenticaUsuario(User p_User)
        {
            try
            {
                dynamic v_User = new ExpandoObject();
                v_User.nome = p_User.Nome;
                v_User.senha = p_User.Senha;
                var v_UserJson = JsonConvert.SerializeObject(v_User);
                var v_HttpClient = new HttpClient();
                var v_RequestUri = new Uri(RequestURLs.LoginURL);
                var v_Request = new HttpRequestMessage()
                {
                    RequestUri = v_RequestUri,
                    Method = HttpMethod.Post,
                    Content = new StringContent(v_UserJson, Encoding.UTF8, "application/json")
                };
                var v_Response = await v_HttpClient.SendAsync(v_Request);
                string v_ReturnString = "";
                if (v_Response.IsSuccessStatusCode)
                {
                    v_ReturnString = await v_Response.Content.ReadAsStringAsync();

                }
                return v_ReturnString;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public void ArmazenaUsuarioLocal(User p_User)
        {
            var v_UserDAO = new UserDAO();
            v_UserDAO.InsertUser(p_User);
        }

        public bool CheckNetworkStatus()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
