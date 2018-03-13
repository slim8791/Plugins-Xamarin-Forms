using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Connectivity;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConnectivityPage : ContentPage
    {
        public ConnectivityPage()
        {
            InitializeComponent();
            
            CrossConnectivity.Current.ConnectivityChanged += (sender, args) =>
            {
                DisplayAlert("Connectivity Changed", "IsConnected: " + CrossConnectivity.Current.IsConnected + "  Args:" + args.IsConnected.ToString(), "OK");
            };

            CrossConnectivity.Current.ConnectivityTypeChanged += (sender, args) =>
            {
                DisplayAlert("Connectivity  Type Changed", "Types: " + args.ConnectionTypes.FirstOrDefault(), "OK");
            };
        }

        private async void Button_OnClicked(object sender, EventArgs e)
        {

            isConnected.Text = CrossConnectivity.Current.IsConnected ? "Connected" : "No Connection";
            bandwidths.Text = "";
            foreach (var band in CrossConnectivity.Current.Bandwidths)
            {
                var b = double.Parse(band.ToString()) / 1048576;
                bandwidths.Text += String.Format("{0:F2} mbps ", b);
            }
            connectionTypes.Text = "";
            var l = CrossConnectivity.Current.ConnectionTypes.Distinct().ToList();

            foreach (var band in l)
            {
                connectionTypes.Text += band.ToString() + ", ";
            }

            try
            {
                canReach1.Text = await CrossConnectivity.Current.IsReachable(host1.Text) ? "Reachable" : "Not reachable";
            }
            catch (Exception ex)
            {
            }
            try
            {
                canReach2.Text = await CrossConnectivity.Current.IsRemoteReachable(host2.Text, int.Parse(port.Text)) ? "Reachable" : "Not reachable";
            }
            catch (Exception ex)
            {
            }
        }

    }
}