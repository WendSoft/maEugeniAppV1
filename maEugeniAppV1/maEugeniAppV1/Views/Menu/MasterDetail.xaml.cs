using maEugeniAppV1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace maEugeniAppV1.Views.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();
            masterpage.Listview.ItemSelected += OnItemSelected;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Item = e.SelectedItem as MasterMenuItem;
            if (Item != null)
            {
                Detail = new NavigationPage((Page)Activator.CreateInstance(Item.TargetType));
                masterpage.Listview.SelectedItem = null;
                IsPresented = false;
            }

        }
    }
}