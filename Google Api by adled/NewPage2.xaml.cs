using System.Collections.ObjectModel;
using Google_Api_by_adled.Model;

namespace Google_Api_by_adled;

public partial class NewPage2 : ContentPage
{
    Ubicacion ub = null;
    public ObservableCollection<Ubicacion> ListUbicacion { get; set; }
    public NewPage2(List<Ubicacion> ubicacions)
    {
        InitializeComponent();
        ListUbicacion = new ObservableCollection<Ubicacion>(ubicacions);
        this.BindingContext = this;

    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        var boton = sender as Button;

        int id = Convert.ToInt32(boton?.CommandParameter);
        await Navigation.PushAsync(new NewPage1(id));
    }
    private async void Button_Clicked2(object sender, EventArgs e)
    {

        var boton = sender as Button;
        int id = Convert.ToInt32(boton?.CommandParameter);
        bool veri = await DisplayAlert("Verificacón", "¿Seguro que desea eliminar este favorito?", "si", "no");
        if (veri!=false)
        {
            ub = await App.dataBase.GetOne(id);
            await App.dataBase.Delete(ub);
            var itemToRemove = ListUbicacion.FirstOrDefault(u => u.Id == id);
            ListUbicacion.Remove(itemToRemove);
        }
        

    }
}