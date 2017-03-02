using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Finder
{
	public partial class RandomResultPage : ContentPage
	{
		double lat, lon;
		public RandomResultPage(double latValue, double lonValue)
		{
			InitializeComponent();

			lat = latValue;
			lon = lonValue;

			againBtn.Clicked += AgainBtn_Clicked;
		}

		void randomSelect(){
			

		}

		async void AgainBtn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}
	}
}
