using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFAdmob.Dependencies;
using XFAdmob.Controls;

namespace XFAdmob
{
	public partial class MainPage : ContentPage
	{
        IAdMob iAdMob;
		public MainPage()
		{
			InitializeComponent();
            iAdMob = DependencyService.Get<IAdMob>();
		}

        private void InterstitialFire(object sender, EventArgs e)
        {
            iAdMob.ShowInterstitialAd();
        }
    }
}
