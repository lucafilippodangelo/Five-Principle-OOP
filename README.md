# FivePrincipleOOPTests

## SINGLE RESPONSABILITY PRINCIPLE ##
•	Every Object has to have a single responsibility, and that responsibility has to be encapsulated by a class.
o	Any class has to have members/methods that manage instances of that specific class type. 
o	From a class is good approach delegate other classes to change status of other objects.
•	Any method has to do just an action for the instance.
EXAMPLE WRONG APPROACH 
I start the example by just considering the class “Order”, all the business logic to process an order is in it.
public class Order
    {
        public void Checkout(Cart cart, PaymentDetails paymentDetails, bool notifyCustomer)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                ChargeCard(paymentDetails, cart);
            }

            ReserveInventory(cart);

            if(notifyCustomer)
            {
                NotifyCustomer(cart);
            }
        }

        public void NotifyCustomer(Cart cart){}

        public void ReserveInventory(Cart cart) {}

        public void ChargeCard(PaymentDetails paymentDetails, Cart cart) {}
    }

?	The Class Order
o	Has method “Checkout” that under condition call 
?	The method “Charge card”
?	The method “Reserve Inventory”
?	The method “Notify Customer”
RIGHT APPROACH - FIRST STEP
It’s clear that the class “Order” is managing actions/logic related with other entities. 
I will convert the methods in separated interfaces that give services and specialized classes will implement them. The classes are responsible to manipulate the specific instance, because depend on the type of order I need or not of that specific implementation.
?	NotificationService : INotificationService 
?	ReservationService : IReservationService 
?	PaymentProcessor : IPaymentProcessor
Smell of abstraction! For the “order” I see that there are different types of order itself, so something enumerable, so I can create three different classes per type of order and inherit from the right one that is ABSTRACT. I will avoid to create "IF" when I have to do different actions related with different type of objects.
RIGHT APPROACH - SECOND STEP
So the second step is make the class “Order” Abstract and implement three concrete classes
•	Abstract class “order” with virtual method “Checkout()”
o	onlineOrder : order
?	Checkout method
•	PaymentProcessor
•	ReservationService
•	NotificationService
o	PoSCreditOrder : order
?	Checkout method
•	PaymentProcessor
o	PoSCashOrder : Order
