namespace AppBurgerJEAI.Views;
using AppBurgerJEAI.Models;

public partial class BurgerListPage : ContentPage
{
    public BurgerListPage()
    {
        InitializeComponent();
        LoadData();
        List<Burger> burger = App.BurgerRepo.GetAllBurgers();
        burgerList.ItemsSource = burger;
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
         Shell.Current.GoToAsync(nameof(BurgerItemPage));
        base.OnAppearing();
    }
}