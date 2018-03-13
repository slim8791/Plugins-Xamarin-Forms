using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plugin.Battery;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Plugins
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BatteryPage : ContentPage
    {
        public BatteryPage()
        {
            InitializeComponent();
            level.Text =  CrossBattery.Current.RemainingChargePercent.ToString();
            status.Text =  CrossBattery.Current.Status.ToString();
            chargeType.Text =  CrossBattery.Current.PowerSource.ToString();
            isLow.Text =  ((CrossBattery.Current.RemainingChargePercent <= 15) ? "YES" : "NO");
            CrossBattery.Current.BatteryChanged += (sender, args) =>
            {
                level.Text = args.RemainingChargePercent.ToString();
                status.Text = args.Status.ToString();
                chargeType.Text =  args.PowerSource.ToString();
                isLow.Text =  ((args.IsLow) ? "YES" : "NO");
            };

        }

    }
}