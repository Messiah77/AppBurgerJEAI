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

    public void OnSelected(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(BurgerItemPage), true, new Dictionary<string, object>
        {
            ["Item"] = Burger ()
        });
        base.OnAppearing();

    }
}