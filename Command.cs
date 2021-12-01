using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	class Command
	{

		public interface ICommand
		{
			// El método Execute() será aquel que el objeto que reciba la referencia
			// será capaz de ejecutar.
			void Execute();
		}

        public abstract class LucesReceiver
        {
            protected bool encendidas;
            protected int distanciaAlumbrado;

            // Propiedad de sólo lectura que devolverá el estado de las luces
            public bool Encendidas
            {
                get { return encendidas; }
            }

            // Método encargado de apagar las luces. Establece el estado del atributo 'encendidas'
            // a 'false'. Será común a todas las clases que hereden de ella.
            public void Apagar()
            {
                this.encendidas = false;
            }

            // El método Encender será distinto en cada una de las clases que hereden de esta clase.
            public abstract int Encender();
        }

        public class LucesPosicion : LucesReceiver
        {
            private const int DISTANCIA = 1;

            public override int Encender()
            {
                this.encendidas = true;
                return DISTANCIA;
            }
        }

        public class LucesCortas : LucesReceiver
        {
            private const int DISTANCIA = 40;

            public override int Encender()
            {
                this.encendidas = true;
                return DISTANCIA;
            }
        }

        public class LucesLargas : LucesReceiver
        {
            private const int DISTANCIA = 200;

            public override int Encender()
            {
                this.encendidas = true;
                return DISTANCIA;
            }
        }

        public interface IInvoker
        {
            // Inyecta un ICommand, permitiendo cambiar la operación encapsulada en
            // tiempo de ejecución
            void SetCommand(ICommand command);

            // Ejecuta el método encapsulado
            void Invoke();
        }

        public class ControladorLucesInvoker : IInvoker
        {
            ICommand command;

            public void SetCommand(ICommand command)
            {
                this.command = command;
            }

            public void Invoke()
            {
                command.Execute();
            }
        }

        public class EncenderLucesCommand : ICommand
        {
            // Referencia al objeto cuyo método se quiere encapsular
            private LucesReceiver luces;

            // El constructor inyectará el objeto cuyo método se quiere encapsular
            public EncenderLucesCommand(LucesReceiver luces)
            {
                this.luces = luces;
            }

            // El método Execute() ejecutará el método encapsulado
            public void Execute()
            {
                int distancia = luces.Encender();
                Console.WriteLine(string.Format("Encendiendo luces. Alumbrando a una distancia de {0} metros.", distancia));
            }
        }

        public class ApagarLucesCommand : ICommand
        {
            private LucesReceiver luces;

            public ApagarLucesCommand(LucesReceiver luces)
            {
                this.luces = luces;
            }

            public void Execute()
            {
                luces.Apagar();
                Console.WriteLine("Apagando las luces");
            }
        }




    }
}
