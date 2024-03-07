<Query Kind="Program">
  <Connection>
    <ID>5e551b30-7a34-4692-be05-d86d7be9f326</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Server>.</Server>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <DeferDatabasePopulation>true</DeferDatabasePopulation>
    <Database>GroceryList</Database>
    <DriverData>
      <LegacyMFA>false</LegacyMFA>
    </DriverData>
  </Connection>
</Query>

void Main()
{
	// Query 2
	Orders.GroupBy(x => x.Store.Location)
	.Select(s => new
	{
		Location = s.Key,
		Clients = s.Select(x => new
		{
			Address = x.Customer.Address,
			City = x.Customer.City,
			Province = x.Customer.Province
		})
		.Distinct()
	})
	.Dump("Query2");

	// Query 3
	// NOT COMPLETED
	Orders
	.GroupBy(x => new { x.Store.City, x.Store.Location })
	.Select(s => new
	{
		City = s.Key.City,
		Location = s.Key.Location,
		Sales = s.Select(x => new
		{
			Date = x.OrderDate,
			NumberofOrders = x.Customer.Orders.Count, // not able to count the orders
			ProductSales = x.SubTotal,
			Gst = x.GST
		})
	})
	.Dump("Query3");

	// Query 4
	// NOT COMPLETED
	Products
		.GroupBy(s => s.Category.Description)
		.Select(x => new
		{
			Category = x.Key,
			OrderProducts = x.Select(s => new
			{
				Product = s.Description,
				Price = s.Price,
				//PickedQty = ,
				Discount = s.Discount,
				Subtotal = s.Price,
				Tax = s.Discount,
				ExtendedPrice = s.Price 
			})
			.OrderBy(x=> x.Product)
		})
		.Dump();
	//
	//OrderLists
	//	.GroupBy(s => s.Product.Category.Description)
	//	.Select(s => new {
	//		Category = s.Key,
	//		OrderProducts = s.Select(x => new {
	//			Product = x.Product.Description,
	//			Price = x.Price,
	//			PickedQty = x.QtyPicked,
	//			Discount = x.Discount,
	//			Subtotal = x.Product.Price,
	//			Tax = x.Price - x.Order.GST,
	//			ExtentedPrice = x.Product.Price + x.Order.GST
	//		})
	//	})
	//	.Dump("Query4");

}

// You can define other methods, fields, classes and namespaces here
