using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class AbstractFactory
	{
		//Factoria Abstracta
		public interface IVehiculo
		{
			Neumatico CreateNeumatico();
			Freno CreateFreno();
			Nuevo CreateModificacion();
			
		}
		//Factoria Concreta

		public class CocheFactory : IVehiculo
		{
			public Neumatico CreateNeumatico()
			{
				return new CocheNeumatico();
			}

			public Freno CreateFreno()
			{
				return new CocheFreno();
			}
			public Nuevo CreateModificacion()
			{
				return new NuevoModificar();
			}
		}

		//Factoria Concreta

		public class MotoFactory : IVehiculo

		{
			public Neumatico CreateNeumatico()
			{
				return new MotoNeumatico();
			}

			public Freno CreateFreno()
			{
				return new MotoFreno();
			}
			public Nuevo CreateModificacion()
			{
				return new NuevoModificar();
			}
		}

		// Producto abstracto

		public abstract class Neumatico
		{
			public abstract void Pintar(string color);
		}

		// Producto abstracto

		public abstract class Freno
		{
			public abstract void Pintar(string color);
		}
		public abstract class Nuevo
		{
			public abstract void Pintar(string valor, string color);
		}

		// Producto Concreto (Freno para Coche)

		public class CocheFreno : Freno
		{
			public override void Pintar(string color)
			{
				Console.WriteLine( "Pintando la carcasa del coche de color " + color);
			}
		}
		// Producto Concreto (Neumático para Coche)

		public class CocheNeumatico : Neumatico
		{
			public override void Pintar(string color)
			{
				Console.WriteLine("Pintando neumatico de coche de color " + color);
			}
		}

		// Producto Concreto (Freno para Moto)

		public class MotoFreno : Freno
		{
			public override void Pintar(string color)
			{
				Console.WriteLine("Pintando base de la moto de color " + color);
			}
		}

		// Producto Concreto (Neumático para Moto)

		public class MotoNeumatico : Neumatico
		{
			public override void Pintar(string color)
			{
				Console.WriteLine("Pintando neumatico de la moto de color " + color);
			}
		}
		public class NuevoModificar : Nuevo
		{
			public override void Pintar(string valor, string color)
			{
				Console.WriteLine("Pintando " + valor + " del vehiculo de color " + color);
			}
		}
	}
}
