using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CoREMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SuiteEdit : ContentPage
	{
		public SuiteEdit ()
		{
            NavigationPage.SetHasBackButton(this, true);

            InitializeComponent ();
		}
	}
}