class Product 
{
    private string _name;
    private string _product;
    private double _price;
    private int _quantity;

    public Product(string name, string product, double price, int quantity)
    {
        _name = name;
        _product = product;
        _price = price;
        _quantity = quantity;
    }

    public double GetTotalCost()
    {
        return _price * _quantity; // we calcute the total cost
    }

    public string GetProductInfo()
    {
        return $"Product: {_name}, Code of product: {_product}, Price: ${_price}, Quantity: {_quantity}";
    }

}