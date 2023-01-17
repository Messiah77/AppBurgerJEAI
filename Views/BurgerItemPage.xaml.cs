
using AppBurgerJEAI.Data;
using AppBurgerJEAI.Models;

namespace AppBurgerJEAI.Views;

[QueryProperty("Item", "Item")]
public partial class BurgerItemPage : ContentPage
{
    //Burger Item = new Burger();
    bool _flag;
   
    public Burger Item
    {
        get => BindingContext as Burger;
        set => BindingContext = value;
    }
    public BurgerItemPage()
	{
		InitializeComponent();
	}
    public int ItemId
    {
        set { LoadBurger(value); }
    }
    private void OnSaveClicked(object sender, EventArgs e)
    {
        //Item.Name = nameB.Text;
        //Item.Description = descB.Text;
        //Item.WithExtraCheese = _flag;

        if (SaveButton.Text == "Editar")
        {
            App.BurgerRepo.UpdateUser(Item);
        }
        else
        {
            App.BurgerRepo.AddNewBurger(Item);
        }

        Shell.Current.GoToAsync("..");
    }

    private void OnCancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("..");
    }

    private void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        _flag = e.Value;
    }
    public void LoadBurguer(int value = -1)
    {
        if (value > -1)
        {
            Item = App.BurgerRepo.GetBurguer(value);
            SaveButton.Text = "Editar";
        }

        BindingContext = Item;

    }
}