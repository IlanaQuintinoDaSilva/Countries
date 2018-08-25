using Countries.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace Countries.ViewModels
{
    public class CountryViewModel : BaseViewModel
    {
        private string _name;

        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value; OnPropertyChanged();
            }
        }

        private Country _country = new Country();
        public Country Country
        {
            get
            {
                return _country;
            }
            set
            {
                _country = value; OnPropertyChanged();
            }
        }

        public CountryViewModel() : base("")
        {
        }

        public override async Task Initialize(object parameters)
        {
            name = parameters as string;
            Title = name;

            await LoadData();
        }

        async Task LoadData()
        {
            if (IsBusy)
                return;

            Exception error = null;

            try
            {
                IsBusy = true;

                var country = await Api.GetByNameAsync(name);
                Country = country;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                error = ex;
            }
            finally
            {
                IsBusy = false;
            }

            if (error != null)
                await ShowAlertAsync("Error!", error.Message, "OK");
        }
    }
}
