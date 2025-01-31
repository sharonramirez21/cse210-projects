class Order 
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product); // we add product to the list
    }

    public double GetTotalCost() // calcute the total of all the products with the discount if the person lives in USA
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        double shippingCost = _customer.LiveInUSA() ? 5 : 35;
        return total + shippingCost;
    }

    public string GetPackingLabel() // We generate the packaging label
    {
        string label = "Packing List";
        foreach (var product in _products)
        {
            label += product.GetProductInfo();
        }
        return label;
    } 

    public string GetShippingLabel()
    {
        return $"Ship to: {_customer.GetCustomerInfo()}";
    } 
}