This project to exercise the OOP SOLID principles

## SINGLE RESPONSABILITY PRINCIPLE ##
- Every Object has to have a single responsibility, and that responsibility has to be encapsulated by a class.
  - Any class has to have members/methods that manage instances of that specific class type. 
  - From a class is good approach delegate other classes to change status of other objects.
- Any method has to do just an action for the instance.

EXAMPLE WRONG APPROACH 
I start the example by just considering the class “Order”, all the business logic to process an order is in it.
public class Order

```
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
```

- The Class Order
  - Has method “Checkout” that under condition call 
    - The method “Charge card”
    - The method “Reserve Inventory”
    - The method “Notify Customer”


RIGHT APPROACH - FIRST STEP
It’s clear that the class “Order” is managing actions/logic related with other entities. 
I will convert the methods in separated interfaces that give services and specialized classes will implement them. The classes are responsible to manipulate the specific instance, because depend on the type of order I need or not of that specific implementation.
- NotificationService : INotificationService 
- ReservationService : IReservationService 
- PaymentProcessor : IPaymentProcessor

Smell of abstraction! For the “order” I see that there are different types of order itself, so something enumerable, so I can create three different classes per type of order and inherit from the right one that is ABSTRACT. I will avoid to create "IF" when I have to do different actions related with different type of objects.

RIGHT APPROACH - SECOND STEP

So the second step is make the class “Order” Abstract and implement three concrete classes

- Abstract class “order” with virtual method “Checkout()”

- onlineOrder : order
  - Checkout method
    - PaymentProcessor
    - ReservationService
    - NotificationService
	
- PoSCreditOrder : order
  - Checkout method
    - PaymentProcessor

- PoSCashOrder : Order

## OPEN/CLOSE PRINCIPLE(OCP) ##
Is important learn how to avoid if/else and migrate to abstraction.
Definition: classes, modules, functions should be open to extensions but closed to modifications
- OPEN TO EXTENSIONS, new behaviour can be added in the future
- CLOSE TO MODIFICATION, changes to source or binary code are not required, so we shoudln't recompile existing code

the scenario is the method “TotalAmount()” of the class “Cart.cs”. 

WRONG IMPLEMENTATION
The focus is in the conditional logic within this method. The price logic depend on “order item” feature and for sure "cart" class is not just doing the "cart" functionality, but the "Price calculation functionality" as well!

```
public decimal TotalAmount()
  {
      decimal total = 0m;
      foreach (OrderItem orderItem in Items)
      {
          if (orderItem.Sku.StartsWith("EACH"))
          {
              total += orderItem.Quantity*5m;
          }
          else if (orderItem.Sku.StartsWith("WEIGHT"))
          {
              // quantity is in grams, price is per kg
              total += orderItem.Quantity*4m/1000;
          }
          else if (orderItem.Sku.StartsWith("SPECIAL"))
          {
              // $0.40 each; 3 for a $1.00
              total += orderItem.Quantity*.4m;
              int setsOfThree = orderItem.Quantity/3;
              total -= setsOfThree*.2m;
          }
          // more rules are coming!
      }
      return total;
  }
```

The goal is to study a solution in order to don’t update the class any time a new condition in if/else change. 
Remember that in the example for the “Single Responsability Principle” the logic was executing different subset of actions depending on the specific combinations of input parameters. In the “Open Close Principle” example, the logic in  “TotalAmount()” execute the same action, with the same return type but with different logic inside.
The best approach is add new classes any time a new condition come, less likely new problems will be introduced because:
- nothing depend on the new classes
- easy to test because not coupled

There are three approaches to achieve OCP
- parameters (set a a status of a class by attribute)
- inheritance with the "Template method PATTERN"
- composition with the "Startegy PATTERN"

RIGHT IMPLEMENTATION
In the new implementation I used the STRATEGY PATTERN that use COMPOSITION.
The client code depends on the abstraction “IPricingCalculator”, we don’t know which price rule logic calculation concrete class we are going to call, we just pass an object “orderItem”, then depend on the specific attribute in the “OrderItem”, inside the “CalculatePrice” Method of “PricingCalculator.cs” we will call the concrete implementation of one of the class that manage each of the “PriceCalculation” logic we had inside “if”.
There are comments In the code starting from the “Cart.cs” class:
-	//LD STEP1, //LD STEP2,	//LD STEP3

## THE LISKOV SUBSTITUTION PRINCIPLE ##

This princple says that subtypes must be substitutable for their base types. The child class should not:
- remove base class behaviour
- violate base class invariants(behaviour that doesn't change defined by contract sometimes)
- tip: when the substitution principle is violated, a good approach is refactor to a new base class

TELL DON'T ASK APPROACH: all the logic should be inside the specific object, the trick is demanding by asking what to do

In the example we are going to manage the calculation of a "Square" and of a "Rectangle".

WRONG IMPLEMENTATION

Class Rectangle //LD STEP4
```
    public class RectangleW
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }
```

Class Square //LD STEP5
```
    public class RectangleW
    {
        public virtual int Height { get; set; }
        public virtual int Width { get; set; }
    }
```

Method AreaCalculator //LD STEP6
```
    public class AreaCalculatorW
    {
        public static int CalculateArea(RectangleW r)
        {
            return r.Height * r.Width;
        }

        public static int CalculateArea(SquareW s)
        {
            return s.Height * s.Height;
        }
    }
```

Unit Tests //LD STEP7
```
 [TestMethod]
        public void SixFor2X3Rectangle()
        {
            var myRectangle = new RectangleW { Height = 2, Width = 3 };
            Assert.AreEqual(6, AreaCalculatorW.CalculateArea(myRectangle));
        }
       
        [TestMethod]
        public void NineFor3X3Square()
        {
            var mySquare = new SquareW() { Height = 3 };
            Assert.AreEqual(9, AreaCalculatorW.CalculateArea(mySquare));
        }

        //LD I expect this test to fail
        [TestMethod]
        public void TwentyFor4X5RectangleFromSquare()
        {
            RectangleW newRectangle = new SquareW();
            newRectangle.Width = 4;
            newRectangle.Height = 5;
            Assert.AreEqual(20, AreaCalculatorW.CalculateArea(newRectangle));
        }
```

The last UT shows that a child class item change the behaviour of the parent one, for a rectangle I expect an area of 25, not 20 

RIGHT IMPLEMENTATION

the right implementation correct the logical issue by defining a base class and in the same time use the principle "Tell don't ask", we will not have anymore the "CalculateArea" method.