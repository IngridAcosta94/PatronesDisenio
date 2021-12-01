using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PatronesDisenio.AbstractFactory;
using static PatronesDisenio.ChainOfResponsability1;
using static PatronesDisenio.Command;
using static PatronesDisenio.Decorator;
using static PatronesDisenio.Facade;
using static PatronesDisenio.FactoryMethod;
using static PatronesDisenio.Interpreter;
using System.Threading;
using static PatronesDisenio.Adapter;

namespace PatronesDisenio
{
	class Program
	{
		static void Main(string[] args)
		{
			bool salir = false;

			while (!salir)
			{

				try
				{
					
					Console.WriteLine("********************************************************");
					Console.WriteLine("Seleccione una opción para revisar");
					Console.WriteLine("1.Factory Method");
					Console.WriteLine("2.Abstract Factory");
					Console.WriteLine("3.Decorator");
					Console.WriteLine("4.Facade");
					Console.WriteLine("5.Chain Of Responsability");
					Console.WriteLine("6.Command");
					Console.WriteLine("7.Interpreter");
					Console.WriteLine("8.Adapter");
					Console.WriteLine("0.Salir del sistema");
					Console.WriteLine("********************************************************");

					switch (Console.ReadLine())
					{
						case "1":
							bool cerrar = false;

							while (!cerrar)
							{
								Console.WriteLine();
								Console.WriteLine("seleccione una opción para ver la informacion del vehiculo");
								Console.WriteLine("(1-BMW320),(2-CAMARO ZL1),(3-Ferrari LaFerrari),(0-cerrar factory method)");
								Console.WriteLine();
								int tipo = Convert.ToInt32(Console.ReadLine());
								if (tipo == 0 )
								{
									cerrar = true;
								}
								else
								{
									InfoVehiculos objVehiculo = creador.informacion(tipo);
									if (objVehiculo != null)
									{
										Console.WriteLine(objVehiculo.informacionVehiculo());
									}
									else
									{
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("por favor, seleccione una opción correcta.");
										Console.ForegroundColor = ConsoleColor.White;
									}
								}
							}
							
							break;
						case "2":

							Console.WriteLine();
							Console.WriteLine("Indique el vehiculo que desea crear:");
							Console.WriteLine("1-coche | 2-Moto | 0-Salir");

							int dato = Convert.ToInt32(Console.ReadLine());
							if(dato==0)
							{
								Console.WriteLine("Eligio la opción salir");
							}
							else
							{
								Console.WriteLine("Indique el color que desea pintar los neumaticos");
								string colorllanta = Console.ReadLine();
								Console.WriteLine("Indique el color que desea pintar la carcasa del vahiculo");
								string colorinterior = Console.ReadLine();
								IVehiculo factory2 = new CocheFactory();
								switch (dato)
								{
									case 1:
										Freno freno = factory2.CreateFreno();
										Neumatico neumatico = factory2.CreateNeumatico();

										neumatico.Pintar(colorllanta);
										freno.Pintar(colorinterior);
										break;
									case 2:
										factory2 = new MotoFactory();
										freno = factory2.CreateFreno();
										neumatico = factory2.CreateNeumatico();

										neumatico.Pintar(colorllanta);
										freno.Pintar(colorinterior);
										break;
									default:
										Console.ForegroundColor = ConsoleColor.Red;
										Console.WriteLine("Por favor elija una opción correcta");
										Console.ForegroundColor = ConsoleColor.White;
										break;
								}
								Console.WriteLine("¿Desea pintar algo mas del vehiculo?");
								if(Console.ReadLine()=="si")
								{
									Console.WriteLine("¿Que desea pintar?");
									string objeto = Console.ReadLine();
									Console.WriteLine("¿de que color lo desea pintar?");
									string color = Console.ReadLine();

									factory2 = new MotoFactory();
									Nuevo freno = factory2.CreateModificacion();
									freno = factory2.CreateModificacion();
									freno.Pintar(objeto,color
										);
								}
							}
							break;
						case "3":
							//Step 1: Define some dishes, and how many of each we can make
							FreshSalad caesarSalad = new FreshSalad("Lechuga romana crujiente", " Queso parmesano recién rallado", "Aderezo César casero");
							caesarSalad.Display();

							Pasta fettuccineAlfredo = new Pasta("Pasta fresca del día", "Salsa Alfredo cremosa de ajo");
							fettuccineAlfredo.Display();

							Console.WriteLine("\n Haciendo que estos platos estén disponibles");
							Console.WriteLine("Ensaldas disponibles: 3");
							Console.WriteLine("Pastas disponibles: 4");
							Console.WriteLine();
							Console.WriteLine("Nueva orden de ensalada: John");
							Console.WriteLine("Nueva orden de pasta: Sally");
							Console.WriteLine("Nueva orden de ensalada: Sally");
							Console.WriteLine("Nueva orden de ensalada: Manush");
							Console.WriteLine("Nueva orden de pasta: Francis");
							Console.WriteLine("Nueva orden de pasta: Venkat");
							Console.WriteLine("Nueva orden de pasta: Diana");
							Console.WriteLine("Nueva orden de pasta: Dennis");

							//Step 2: Decorate the dishes; now if we attempt to order them once we're out of ingredients, we can notify the customer
							Available caesarAvailable = new Available(caesarSalad, 3);
							Available alfredoAvailable = new Available(fettuccineAlfredo, 4);

							//Step 3: Order a bunch of dishes
							caesarAvailable.OrderItem("John");
							caesarAvailable.OrderItem("Sally");
							caesarAvailable.OrderItem("Manush");

							alfredoAvailable.OrderItem("Sally");
							alfredoAvailable.OrderItem("Francis");
							alfredoAvailable.OrderItem("Venkat");
							alfredoAvailable.OrderItem("Diana");
							alfredoAvailable.OrderItem("Dennis"); //There won't be enough for this order.

							caesarAvailable.Display();
							alfredoAvailable.Display();
							break;
						case "4":
							IAcelerador acelerador = new Acelerador();
							IEmbrague embrague = new Embrague();
							IPalancaCambios palancaCambios = new PalancaCambios();

							Centralita centralita = new Centralita(embrague, acelerador, palancaCambios);
							centralita.AumentarMarcha();
							break;
						case "5":
							bool repetir = false;

							while (!repetir)
							{
								ATM atm = new ATM();
								Console.WriteLine("Ingrese monto que desea retirar del cajero (solo multiplos de $100)");
								int monto = Convert.ToInt32(Console.ReadLine());
								if (monto % 100 == 0)
								{
									atm.withdraw(monto);
									repetir = true;
								}
								else
								{
									Console.WriteLine("intente de nuevo con un multiplo de $100");
								}
							}
							break;
						case "6":
							// objetos que implementan ICommand
							LucesReceiver lucesPosicion = new LucesPosicion();
							LucesReceiver lucesCortas = new LucesCortas();
							LucesReceiver lucesLargas = new LucesLargas();

							// Creamos los objetos Command que encapsulan los métodos de las clases anteriores
							ICommand encenderPosicion = new EncenderLucesCommand(lucesPosicion);
							ICommand apagarPosicion = new ApagarLucesCommand(lucesPosicion);

							ICommand encenderCortas = new EncenderLucesCommand(lucesCortas);
							ICommand apagarCortas = new ApagarLucesCommand(lucesCortas);

							ICommand encenderLargas = new EncenderLucesCommand(lucesLargas);
							ICommand apagarLargas = new ApagarLucesCommand(lucesLargas);

							// Creamos un nuevo Invoker (el objeto que será desacoplado de las luces)
							IInvoker invoker = new ControladorLucesInvoker();

							Console.WriteLine("¿Que luces desea probar?");
							Console.WriteLine("1-Luces de corta distancia \n2-Luces de distancia media \n3-Luces de larga distancia");
							int luz = Convert.ToInt32(Console.ReadLine());

							switch(luz)
							{
								case 1:
									// Luces cortas
									invoker.SetCommand(encenderPosicion);
									invoker.Invoke();
									Console.WriteLine("Validando que todo este correcto...");
									Thread.Sleep(4000);
									// Realizamos lo mismo con el resto de instancias que implementan ICommand.
									// Como podemos ver, el ICommand puede asignarse en tiempo de ejecucion
									invoker.SetCommand(apagarPosicion);
									invoker.Invoke();
									break;
								case 2:
									// Luces Medias
									invoker.SetCommand(encenderCortas);
									invoker.Invoke();
									Console.WriteLine("Validando que todo este correcto...");
									Thread.Sleep(4000);
									invoker.SetCommand(apagarCortas);
									invoker.Invoke();
									break;
								case 3:
									// Luces largas
									invoker.SetCommand(encenderLargas);
									invoker.Invoke();
									Console.WriteLine("Validando que todo este correcto...");
									Thread.Sleep(4000);
									invoker.SetCommand(apagarLargas);
									invoker.Invoke();
									break;
								default:
									Console.WriteLine("Elige una opción correcta");
									break;
							}
							break;
						case "7":
							Context context = new Context();

							// Usually a tree 
							ArrayList list = new ArrayList();

							// Populate 'abstract syntax tree' 
							list.Add(new TerminalExpression());
							list.Add(new NonterminalExpression());
							list.Add(new TerminalExpression());
							list.Add(new TerminalExpression());

							// Interpret 
							foreach (AbstractExpression exp in list)
							{
								exp.Interpret(context);
							}

							break;

						case"8":
							CoolCorpInterface robot = new CoolCorpRobot();
							robot.CurrentSpeedInKilometersPerHour = 3;
							robot.Jump(12);
							Console.ReadKey();
							break;
						case "0":
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("Ha elegido la opción de salir de la aplicación");
							salir = true;
							break;
						default:
							Console.ForegroundColor = ConsoleColor.Red;
							Console.WriteLine("por favor selecciona una opción correcta");
							Console.ForegroundColor = ConsoleColor.White;
							break;
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
			}
			Console.ReadKey();
		}
	}
}

