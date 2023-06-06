using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace patterns_lab2
{
    public class Burger
    {
        private bool cheese = false;
        private bool pickles = false;
        private bool lettuce = false;
        private bool tomato = false;
        private bool jalapeno = false;
        private bool hotsauce = false;
        private string meat = "";
        public Burger(BurgerBuilder builder)
        {
            this.meat = builder.meat;
            this.pickles = builder.pickles;
            this.lettuce = builder.lettuce;
            this.tomato = builder.tomato;
            this.jalapeno = builder.jalapeno;
            this.hotsauce = builder.hotsauce;
            this.cheese = builder.cheese;
        }
    }
    public class BurgerBuilder
    {
        public string meat = "";
        public bool cheese = false;
        public bool pickles = false;
        public bool lettuce = false;
        public bool tomato = false;
        public bool jalapeno = false;
        public bool hotsauce = false;
        public BurgerBuilder()
        {
        }
        public BurgerBuilder(string meat)
        {
            this.meat = meat;
            Console.WriteLine("Ingredients:");
            Console.WriteLine(meat);
        }
        public BurgerBuilder useMeat(string meat)
        {
            this.meat = meat;
            Console.WriteLine(meat);
            return this;
        }
        public BurgerBuilder addCheese()
        {
            this.cheese = true;
            Console.WriteLine("Cheese");
            return this;
        }
        public BurgerBuilder addPickles()
        {
            this.pickles = true;
            Console.WriteLine("Pickles");
            return this;
        }
        public BurgerBuilder addLettuce()
        {
            this.lettuce = true;
            Console.WriteLine("Lettuce");
            return this;
        }
        public BurgerBuilder addTomato()
        {
            this.tomato = true;
            Console.WriteLine("Tomato");
            return this;
        }
        public BurgerBuilder addJalapeno()
        {
            this.jalapeno = true;
            Console.WriteLine("Jalapeno");
            return this;
        }
        public BurgerBuilder addHotsauce()
        {
            this.hotsauce = true;
            Console.WriteLine("Hot Sauce");
            return this;
        }
        public Burger build()
        {
            Console.WriteLine("Your burger is made!\n");
            return new Burger(this);
        }
    }
    public class Recipe
    {
        private BurgerBuilder builder;
        private string name;
        public Recipe()
        {
            builder = new BurgerBuilder();
        }
        public BurgerBuilder getBuilder()
        {
            return this.builder;
        }
        public void makeCheeseBurger()
        {
            name = "Cheeseburger";
            Console.WriteLine(name);
            builder.useMeat("Beef");
            builder.addCheese();
            builder.build();
        }
        public void makeHotChickenBurger()
        {
            name = "Chickenburger";
            Console.WriteLine(name);
            builder.useMeat("Chicken");
            builder.addHotsauce();
            builder.addJalapeno();
            builder.build();
        }
        public void makePickleFishBurger()
        {
            name = "Pickle Fish Burger";
            Console.WriteLine(name);
            builder.useMeat("Fish");
            builder.addPickles();
            builder.build();
        }
        public void makeBigBurger()
        {
            name = "Big Burger";
            Console.WriteLine(name);
            builder.useMeat("Beef");
            builder.addCheese();
            builder.addLettuce();
            builder.addTomato();
            builder.addPickles();
            builder.addHotsauce();
            builder.addJalapeno();
            builder.build();
        }
        public string getName()
        {
            return this.name;
        }

    }
    public class OrderMemento
    {
        private BurgerBuilder builder;
        private string name;
        public OrderMemento()
        {
            builder=new BurgerBuilder();
        }
        public void save(BurgerBuilder order)
        {
            this.name = "Custom Burger";
            this.builder = order;
        }
        public void save(Recipe order)
        {
            this.name = order.getName();
            this.builder = order.getBuilder();
        }
        public void restore()
        {
            Console.WriteLine(this.name);
            this.builder.build();
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            //создание объекта для сохранения заказа
            OrderMemento memento = new OrderMemento();

            //создание собственного бургера через конструктор
            BurgerBuilder order1 = new BurgerBuilder("Chicken");
            order1.addCheese();
            order1.addLettuce();
            order1.addTomato();
            order1.build();
            memento.save(order1);

            //создание бургера через класс с готовыми рецептами, использующий конструктор
            Recipe order2 = new Recipe();
            order2.makeBigBurger();
            memento.save(order2);

            //повтор предыдущего сохраненного заказа
            memento.restore();

            Console.ReadKey();
        }
    }
}
