namespace DrinkAndGo.Data.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem() { }

        public ShoppingCartItem(Drink drink, int amout, string shoppingCartId)
        {
            Drink = drink;
            Amount = amout;
            ShoppingCartId = shoppingCartId;
        }

        public int ShoppingCartItemId { get; private set; }
        public Drink Drink { get; private set; }
        public int Amount { get; private set; }
        public string ShoppingCartId { get; private set; }

        public void AddAmount() => Amount++;

        public int RemoveAmount() => Amount--;
    }
}