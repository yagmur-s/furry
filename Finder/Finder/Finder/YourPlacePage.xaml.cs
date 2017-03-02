using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Finder
{
	public partial class YourPlacePage : ContentPage
	{
		double lattitude = 0, longitude = 0;
		public YourPlacePage(double latValue, double lonValue)
		{
			InitializeComponent();

			latLabel.Text = latValue.ToString();
			lonLabel.Text = lonValue.ToString();

			lattitude = latValue;
			longitude = lonValue;

			var position = new Position(latValue, lonValue);

			var pin = new Pin
			{
				Type = PinType.Place,
				Position = position,
				Label = "Izmir Fuar",
				Address = "Izmir Fuar address"
			};

			//MyMap.Pins.Add(pin);
			MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
				position, Distance.FromMiles(1.0)));

			findPlaceBtn.Clicked += FindPlaceBtn_Clicked;
		}

		async void FindPlaceBtn_Clicked(object sender, EventArgs e)
		{
			if (lattitude != 0 && longitude != 0) { 
				await Navigation.PushAsync(new RandomResultPage(lattitude, longitude));
			}
		}



	}
}
