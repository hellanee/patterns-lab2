using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_lab2
{
    public class Food
    {
        string data;
        public Food() => data = "Состав блюда:\n";
        public string aboutFood() => data;
        public void appendData(string type) => data += type;
    }
    public interface IFood
    {
        void addCheese();
        void addPickles();
        void addLettuce();
        void addTomato();
        void addJalapeno();
        void addHotSauce();
        void addMeat(string str);
        void createBread();
        Food getFood();
    }

    public class BurgerBuilder : IFood
    {
        private Food food;
        public BurgerBuilder() => food = new Food();
        public void addCheese() => food.appendData("Cыр\n");
        public void addPickles() => food.appendData("Огурцы\n");
        public void addLettuce() => food.appendData("Салат\n");
        public void addTomato() => food.appendData("Томаты\n");
        public void addJalapeno() => food.appendData("Халапеньо\n");
        public void addHotSauce() => food.appendData("Острый соус\n");
        public void addMeat(string str) => food.appendData("Мясо: " + str + "\n");
        public void createBread() => food.appendData("Ингредиенты в булочке с кунжутом\n");
        public Food getFood() => food;
    }
    public class RollBuilder : IFood
    {
        private Food food;
        public RollBuilder() => food = new Food();
        public void addCheese() => food.appendData("Cыр\n");
        public void addPickles() => food.appendData("Огурцы\n");
        public void addLettuce() => food.appendData("Салат\n");
        public void addTomato() => food.appendData("Томаты\n");
        public void addJalapeno() => food.appendData("Халапеньо\n");
        public void addHotSauce() => food.appendData("Острый соус\n");
        public void addMeat(string str) => food.appendData("Мясо: " + str + "\n");
        public void createBread() => food.appendData("Ингредиенты, завернутые в лаваш\n");
        public Food getFood() => food;
    }
    public class Order
    {
        private IFood food;
        public Order(IFood food) => this.food = food;
        public void setFoodType(IFood food) => this.food = food;
        public Food createCheeseburger()
        {
            food.addCheese();
            food.addMeat("котлета из говядины");
            food.addLettuce();
            food.createBread();
            return food.getFood();
        }
        public Food createHotRoll()
        {
            food.addJalapeno();
            food.addHotSauce();
            food.addLettuce();
            food.addMeat("кусочки курицы");
            food.addPickles();
            food.createBread();
            return food.getFood();
        }
        public IFood getFood() => this.food;
    }

    public class OrderMemento
    {
        private Order order;
        public OrderMemento(Order order)
        {
            this.order=new Order(order.getFood());
        }
        public void save(Order order)
        {
            this.order = order;
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
            IFood foodItem1 = new BurgerBuilder();

            Order order1 = new Order(foodItem1);

            Food burger = order1.createCheeseburger();
            Console.WriteLine(burger.aboutFood());
            OrderMemento memento = new OrderMemento(order1);

            IFood foodItem2 = new RollBuilder();
            Order order2 = new Order(foodItem2);
            order2.setFoodType(foodItem2);
  
            Food roll = order2.createHotRoll();
            Console.WriteLine(roll.aboutFood());
            memento.save(order2);

            Console.ReadKey();
        }
    }
}
