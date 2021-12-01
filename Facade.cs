using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class Facade
	{
		public interface IPalancaCambios
		{
			void InsertarVelocidad(int velocidad);
			void PuntoMuerto();
			int GetVelocidadActual();
		}

		public interface IEmbrague
		{
			void PresionarEmbrague();
			void SoltarEmbrague();
		}

		public interface IAcelerador
		{
			void PresionarAcelerador();
			void SoltarAcelerador();
		}

        public class PalancaCambios : IPalancaCambios
        {
            private int _velocidadActual;

            #region IPalancaCambios Members

            public void InsertarVelocidad(int velocidad)
            {
                Console.WriteLine("Introduciendo marcha " + velocidad);
                this._velocidadActual = velocidad;
            }

            public void PuntoMuerto()
            {
                Console.WriteLine("Sacando velocidad " + this._velocidadActual);
                this._velocidadActual = 0;
            }

            public int GetVelocidadActual()
            {
                return _velocidadActual;
            }

            #endregion
        }

        public class Embrague : IEmbrague
        {
            #region IEmbrague Members

            public void PresionarEmbrague()
            {
                Console.WriteLine("Embrague presionado");
            }

            public void SoltarEmbrague()
            {
                Console.WriteLine("Embrague suelto");
            }

            #endregion
        }

        public class Acelerador : IAcelerador
        {
            #region IAcelerador Members

            public void PresionarAcelerador()
            {
                Console.WriteLine("Acelerador presionado");
            }

            public void SoltarAcelerador()
            {
                Console.WriteLine("Acelerador levantado");
            }

            #endregion
        }

        public class Centralita
        {
            private IEmbrague _embrague;
            private IAcelerador _acelerador;
            private IPalancaCambios _palancaCambios;

            public Centralita(IEmbrague embrague, IAcelerador acelerador, IPalancaCambios palancaCambios)
            {
                this._embrague = embrague;
                this._acelerador = acelerador;
                this._palancaCambios = palancaCambios;
            }

            public void AumentarMarcha()
            {
                _acelerador.SoltarAcelerador();
                _embrague.PresionarEmbrague();
                _palancaCambios.PuntoMuerto();
                if (_palancaCambios.GetVelocidadActual() < 5)
                    _palancaCambios.InsertarVelocidad(_palancaCambios.GetVelocidadActual() + 1);
                _embrague.SoltarEmbrague();
                _acelerador.PresionarAcelerador();
            }

            public void ReducirMarcha()
            {
                _acelerador.SoltarAcelerador();
                _embrague.PresionarEmbrague();
                _palancaCambios.PuntoMuerto();
                if (_palancaCambios.GetVelocidadActual() > 1)
                    _palancaCambios.InsertarVelocidad(_palancaCambios.GetVelocidadActual() - 1);
                _embrague.SoltarEmbrague();
                _acelerador.PresionarAcelerador();
            }
        }



    }
}
