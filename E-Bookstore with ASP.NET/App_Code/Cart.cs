using System;
using System.Collections;

public class Cart
{
	public Cart()
	{
        items = new ArrayList();
    }
    public void addItem(string ProductID, string ProductName, double Price)
    {
        items.Add(new CartItem(ProductID, ProductName, Price));
    }
    public ArrayList getItems()
    {
        return  items;
    }
    ArrayList items;
    
}

public class CartItem
{
    public string ProductID;
    public string ProductName;
    public double Price;

    public CartItem(string prodID, string prodName, double ProdPrice)
    {
        ProductID = prodID;
        ProductName = prodName;
        Price = ProdPrice; 
    }
}


