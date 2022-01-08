using ARA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ARA
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ServiciuPage : ContentPage
    {
        Programari sl;
        public ServiciuPage(Programari slist)
        {
            InitializeComponent();
            sl = slist;
        }


        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ServiciuPage((Programari)
           this.BindingContext)
            {
                BindingContext = new Serviciu()
            });

        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var product = (Serviciu)BindingContext;
            await App.Database.SaveProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var product = (Serviciu)BindingContext;
            await App.Database.DeleteProductAsync(product);
            listView.ItemsSource = await App.Database.GetProductsAsync();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (Programari)BindingContext;

            listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
        }


        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            Serviciu p;
            if (e.SelectedItem != null)
            {
                p = e.SelectedItem as Serviciu;
                var lp = new ListServiciu()
                {
                    ShopListID = sl.ID,
                    ProductID = p.ID
                };
                await App.Database.SaveListProductAsync(lp);
                p.ListProducts = new List<ListServiciu> { lp };

                await Navigation.PopAsync();
            }
        }
    }
}