using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_lab2
{
    public class Burger
    {
        string data;
        public Burger() => data = "Состав блюда:\n";
        public string aboutBurger() => data;
        public void appendData(string type) => data += type;
    }
    public class Roll
    {
        string data;
        public Roll() => data = "Состав блюда:\n";
        public string aboutRoll() => data;
        public void appendData(string type) => data += type;
    }
    public interface IBurger
    {
        void addCheese();
        void addPickles();
        void addLettuce();
        void addTomato();
        void addJalapeno();
        void addHotSauce();
        void addMeat(string str);
        void createBread();
        Burger getBurger();
    }
    public interface IRoll
    {
        void addCheese();
        void addPickles();
        void addLettuce();
        void addTomato();
        void addJalapeno();
        void addHotSauce();
        void addMeat(string str);
        void createBread();
        Roll getRoll();
    }

    public class BurgerBuilder : IBurger
    {
        private Burger food;
        public BurgerBuilder() => food = new Burger();
        public void addCheese() => food.appendData("Cыр\n");
        public void addPickles() => food.appendData("Огурцы\n");
        public void addLettuce() => food.appendData("Салат\n");
        public void addTomato() => food.appendData("Томаты\n");
        public void addJalapeno() => food.appendData("Халапеньо\n");
        public void addHotSauce() => food.appendData("Острый соус\n");
        public void addMeat(string str) => food.appendData("Мясо: " + str + "\n");
        public void createBread() => food.appendData("Ингредиенты в булочке с кунжутом\n");
        public Burger getBurger() => food;
    }
    public class RollBuilder : IRoll
    {
        private Roll food;
        public RollBuilder() => food = new Roll();
        public void addCheese() => food.appendData("Cыр\n");
        public void addPickles() => food.appendData("Огурцы\n");
        public void addLettuce() => food.appendData("Салат\n");
        public void addTomato() => food.appendData("Томаты\n");
        public void addJalapeno() => food.appendData("Халапеньо\n");
        public void addHotSauce() => food.appendData("Острый соус\n");
        public void addMeat(string str) => food.appendData("Мясо: " + str + "\n");
        public void createBread() => food.appendData("Ингредиенты, завернутые в лаваш\n");
        public Roll getRoll() => food;
    }
    public class Order
    {
        private IBurger burger;
        private IRoll roll;
        public Order(IBurger burger) => this.burger = burger;
        public void setFoodType(IBurger burger) => this.burger = burger;
        public Order(IRoll roll) => this.roll = roll;
        public void setFoodType(IRoll roll) => this.roll = roll;
        public Burger createCheeseburger()
        {
            burger.addCheese();
            burger.addMeat("котлета из говядины");
            burger.addLettuce();
            burger.createBread();
            return burger.getBurger();
        }
        public Roll createHotRoll()
        {
            roll.addJalapeno();
            roll.addHotSauce();
            roll.addLettuce();
            roll.addMeat("кусочки курицы");
            roll.addPickles();
            roll.createBread();
            return roll.getRoll();
        }
        public IBurger getBurger() => this.burger;
        public IRoll getRoll() => this.roll;
    }

    public class OrderMemento
    {
        private Order order;
        public OrderMemento(Order order, string type)
        {
            if(type=="бургер")
                this.order=new Order(order.getBurger());
            if (type == "ролл")
                this.order = new Order(order.getRoll());
        }
        public void save(Order order, string type)
        {
            if (type == "бургер")
                this.order = new Order(order.getBurger());
            if (type == "ролл")
                this.order = new Order(order.getRoll());
        }
        public Order restore()
        {
            return this.order;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            IBurger foodItem1 = new BurgerBuilder();

            Order order1 = new Order(foodItem1);

            Burger burger = order1.createCheeseburger();
            Console.WriteLine(burger.aboutBurger());
            OrderMemento memento = new OrderMemento(order1, "бургер");

            IRoll foodItem2 = new RollBuilder();
            Order order2 = new Order(foodItem2);
            order2.setFoodType(foodItem2);
  
            Roll roll = order2.createHotRoll();
            Console.WriteLine(roll.aboutRoll());
            memento.save(order2, "ролл");

            Console.ReadKey();
        }
    }
}
