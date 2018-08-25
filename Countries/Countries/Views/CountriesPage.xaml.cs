using Countries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Countries.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CountriesPage : ContentPage
	{
        private CountryViewModel _vm;
        public CountryViewModel ViewModel
        {
            get
            {
                if (_vm == null)
                    _vm = new CountryViewModel();

                BindingContext = _vm;

                return (BindingContext as CountryViewModel);
            }
        }

        public CountriesPage ()
		{
			InitializeComponent ();
		}
	}
}