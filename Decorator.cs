using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class Decorator
	{
		/// <summary>
		/// The abstract Component class
		/// </summary>
		public abstract class RestaurantDish
		{
			public abstract void Display();
		}

        /// <summary>
        /// A ConcreteComponent class
        /// </summary>
         public class FreshSalad : RestaurantDish
        {
            private string _greens;
            private string _cheese; //I am going to use this pun everywhere I can
            private string _dressing;

            public FreshSalad(string greens, string cheese, string dressing)
            {
                _greens = greens;
                _cheese = cheese;
                _dressing = dressing;
            }

            public override void Display()
            {
                Console.WriteLine("\nEnsalada fresca:");
                Console.WriteLine(" Verduras: {0}", _greens);
                Console.WriteLine(" Queso: {0}", _cheese);
                Console.WriteLine(" Aderezo: {0}", _dressing);
            }
        }

        /// <summary>
        /// A ConcreteComponent class
        /// </summary>
        public class Pasta : RestaurantDish
        {
            private string _pastaType;
            private string _sauce;



            public Pasta(string pastaType, string sauce)
            {
                _pastaType = pastaType;
                _sauce = sauce;
            }

            public override void Display()
            {
                Console.WriteLine("\nClassic Pasta:");
                Console.WriteLine(" Pasta: {0}", _pastaType);
                Console.WriteLine(" Salsa: {0}", _sauce);
            }
        }

        /// <summary>
        /// The abstract Decorator class.  
        /// </summary>
        public abstract class Decorator1 : RestaurantDish
        {
            protected RestaurantDish _dish;

            public Decorator1(RestaurantDish dish)
            {
                _dish = dish;
            }

            public override void Display()
            {
                _dish.Display();
            }
        }

        /// <summary>
        /// A ConcreteDecorator. This class will impart "responsibilities" onto the dishes 
        /// (e.g. whether or not those dishes have enough ingredients left to order them)
        /// </summary>
        public class Available : Decorator1
        {
            public int NumAvailable { get; set; } //How many can we make?
            protected List<string> customers = new List<string>();
            public Available(RestaurantDish dish, int numAvailable) : base(dish)
            {
                NumAvailable = numAvailable;
            }

            public void OrderItem(string name)
            {
                if (NumAvailable > 0)
                {
                    customers.Add(name);
                    NumAvailable--;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nNo hay suficientes ingredientes para la orden del cliente " + name);
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }

            public override void Display()
            {
                base.Display();

                foreach (var customer in customers)
                {
                    Console.WriteLine("Platillo ordenado por: " + customer +" !Pedido Entregado!");
                }
            }
        }
    }
}
