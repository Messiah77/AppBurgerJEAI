namespace AppBurgerJEAI.Views;

using AppBurgerJEAI.Data;
using AppBurgerJEAI.Models;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        LoadData();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
        BindingContext=this;
    }

    protected override void OnAppearing()
    {
        LoadData();
    }

    public void LoadData()
    {
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
        burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
    }

    public void OnItemAdded(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BurgerItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = new Burger()
        });
        base.OnAppearing();
    }

    private async void burguersCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            var burguer = (Models.Burger)e.CurrentSelection[0];

            string action = await DisplayActionSheet("Seleccione la acción que desea realizar:", "Cancel", null, "Editar", "Borrar");

            if (action == "Editar")
            {
                await Shell.Current.GoToAsync($"{nameof(BurgerItemPage)}?{nameof(BurgerItemPage.ABItemId)}={Burger.Id}");
            }
            else if (action == "Borrar")
            {
                App.BurgerRepo.DeleteBurguer(Burger);
                LoadData();
            }
            else
            {
                LoadData();
            }

            ABburguerList.SelectedItem = null;
        }
    }



}