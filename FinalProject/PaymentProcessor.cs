public class PaymentProcessor
{
    public bool ProcessPayment(Order order, PaymentType paymentType)
    {
        // Simulate processing the payment based on the chosen payment type
        if (paymentType == PaymentType.Cash)
        {
            Console.WriteLine("Please provide cash payment.");
        }
        else if (paymentType == PaymentType.Card)
        {
            Console.WriteLine("Please swipe/enter your card.");
        }
        else
        {
            Console.WriteLine("Invalid payment type.");
            return false;
        }

        // Simulate payment processing delay (replace this with actual payment processing logic)
        Thread.Sleep(2000);

        // For simplicity, let's assume the payment is always successful
        order.IsPaid = true;
        return true;
    }
}

public enum PaymentType
{
    Cash,
    Card
}
