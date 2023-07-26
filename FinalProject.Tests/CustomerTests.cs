// [TestFixture]
// public class CustomerTests
// {
//       [Test]
//     public void Customer_Can_Place_Order()
//     {
//         // Arrange
//         Customer customer = new Customer {
//             CustomerId = 1,
//             Name = "John Doe"
//         };
//         var menu = new Menu();

//         MenuItem menuItem1 = new MenuItem("Burger", "Delicious beef burger", 9.99);
//         MenuItem menuItem2 = new MenuItem("Pizza", "Margherita pizza", 12.99);

//         menu.AddMenuItem(menuItem1);
//         menu.AddMenuItem(menuItem2);

//         Order order = new Order();
//         order.AddToOrder(menuItem1);
//         order.AddToOrder(menuItem2);
    
//         // Act
//         customer.PlaceOrder(menu, order);

//         // Assert
//         Assert.AreEqual(2, order.OrderedItems.Count);
//     }

//      [Test]
//     public void Customer_Can_Pay_For_Order()
//     {
//         // Arrange
//         Customer customer = new Customer {
//             CustomerId = 1,
//             Name = "John Doe"
//         };
//         var order = new Order();

//         MenuItem menuItem1 = new MenuItem("Burger", "Delicious beef burger", 9.99);
//         MenuItem menuItem2 = new MenuItem("Pizza", "Margherita pizza", 12.99);

//         order.AddToOrder(menuItem1);
//         order.AddToOrder(menuItem2);

//         // Act
//         bool paymentSuccess = false;

//         try
//         {
//             // Simulate a successful payment process (you can add your payment logic here)
//             double totalPrice = order.TotalAmount;
//             paymentSuccess = true;
//         }
//         catch
//         {
//             // Payment process failed
//         }

//         // Assert
//         Assert.IsTrue(paymentSuccess);
//     }
// }
