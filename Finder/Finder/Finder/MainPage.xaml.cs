using System;
using System.Collections.Generic;
using System.Diagnostics;
using Plugin.Geolocator;
using Xamarin.Forms;

namespace Finder
{
	public partial class MainPage : ContentPage
	{
		double latValue, lonValue;

		public MainPage()
		{
			InitializeComponent();

			//GetLocation();

			//NavigationPage.SetHasNavigationBar(this, false);

			findBtn.Clicked += FindBtn_Clicked;
			nextBtn.Clicked += NextBtn_Clicked;
		}

		void FindBtn_Clicked(object sender, EventArgs e)
		{
			GetLocation();
		}

		async void NextBtn_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new YourPlacePage(latValue, lonValue));
		}

		async void GetLocation()
		{
			try
			{
				var locator = CrossGeolocator.Current;
				locator.DesiredAccuracy = 50;

				var position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);

				var lat = position.Latitude;
				var lon = position.Longitude;

				latValue = lat;
				lonValue = lon;

				latLabel.Text = position.Latitude.ToString();
				lonLabel.Text = position.Longitude.ToString();
			}
			catch (Exception ex)
			{
				//show pop-up message
				Debug.WriteLine("Unable to get location, may need to increase timeout: " + ex);
			}

			//NavigationPage.SetHasNavigationBar(this, false);
			//NavigationPage nav = new NavigationPage(new MainPage());
			//await nav.PushAsync(new YourPlacePage(latValue, lonValue));
		}





	}
}
