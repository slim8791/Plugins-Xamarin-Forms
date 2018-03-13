using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.DeviceInfo;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeviceInfoPage : ContentPage
    {
        public DeviceInfoPage()
        {
            InitializeComponent();
            appId1.Text = CrossDeviceInfo.Current.GenerateAppId();
            appId2.Text = CrossDeviceInfo.Current.GenerateAppId(true);
            appId3.Text = CrossDeviceInfo.Current.GenerateAppId(true, "hello");
            appId4.Text = CrossDeviceInfo.Current.GenerateAppId(true, "hello", "world");

            id.Text = CrossDeviceInfo.Current.Id;
            model.Text = CrossDeviceInfo.Current.Model;
            platform.Text = CrossDeviceInfo.Current.Platform+"";
            version.Text = CrossDeviceInfo.Current.Version+" "+ CrossDeviceInfo.Current.VersionNumber;
            //deviceName.Text = CrossDeviceInfo.Current.DeviceName;
            //manufacturer.Text = CrossDeviceInfo.Current.Manufacturer;


        }
    }
}