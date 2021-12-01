using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class FactoryMethod
	{
		//--------------------------------------------------------------------------------------
		public abstract class InfoVehiculos
			{
			public abstract string informacionVehiculo();

			}
		class BMW320 : InfoVehiculos
		{
			public override string informacionVehiculo()
			{
				string informacion = "El BMW320 tiene una Velocidad máxima : 235 km/h -> Aceleración 0 - 100 km / h  7,2 s";
				return informacion;
			}
		}
		class CamaroZL1 : InfoVehiculos
		{
			public override string informacionVehiculo()
			{
				string informacion = "El Camaro ZL1 tiene una Velocidad máxima : 325 km/h -> Aceleración 0 - 100 km / h  3,5 s";
				return informacion;
			}
		}
		class Ferrarilaferrari : InfoVehiculos
		{
			public override string informacionVehiculo()
			{
				string informacion = "EL ferrari Laferrari tiene una Velocidad máxima : 350 km/h -> Aceleración 0 - 100 km / h  2,9 s";
				return informacion;
			}
		}
		public class creador
		{
			public const int BMW = 1;
			public const int Camaro = 2;
			public const int Ferrari = 3;
			public static InfoVehiculos informacion(int tipo)
			{
				switch(tipo)
				{
					case 1:
						return new BMW320();
						break;
					case 2:
						return new CamaroZL1();
						break;
					case 3:
						return new Ferrarilaferrari();
						break;
					default:
						return null;
						break;
				}
			}
		}
	}
}
