using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage
    {
        public MenuPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
          
            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Battery",
                IconSource = "battery.png",
                TargetType = typeof(BatteryPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Connectivity",
                IconSource = "connectivity.png",
                TargetType = typeof(ConnectivityPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Device info",
                IconSource = "info.png",
                TargetType = typeof(DeviceInfoPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Geolocator",
                IconSource = "locator.png",
                TargetType = typeof(GeolocatorPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Permissions",
                IconSource = "permissions.png",
                TargetType = typeof(PermissionsPage)
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Vibrate",
                IconSource = "vibrate.png",
                TargetType = typeof(VibratePage)
            });
            listView.ItemsSource = masterPageItems;
        }
        private void MenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                listView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }
}