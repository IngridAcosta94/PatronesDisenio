using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronesDisenio
{
	public class Adapter
	{



		public interface USRobotsInterface
		{
			float CurrentSpeedInMilesPerHour { get; set; }
			void EnablePartialFirstLawMode();
			void Jump(float feet);
		}

        public class USRobot : USRobotsInterface
        {
            private float CurrentSpeed;

            public float CurrentSpeedInMilesPerHour
            {
                get { return CurrentSpeed; }
                set { CurrentSpeed = value; }
            }

            public USRobot()
            {
                this.CurrentSpeed = 0;
            }

            public void EnablePartialFirstLawMode()
            {
                Console.WriteLine("Partial first law enabled");
            }

            public void Jump(float feet)
            {
                Console.WriteLine("Jump !!");
            }
        }

       public interface CoolCorpInterface
        {
            float CurrentSpeedInKilometersPerHour { get; set; }
            void Jump(float meters);
        }

        //ADAPTADOR
        public class CoolCorpRobot : CoolCorpInterface
        {
            private USRobot robot;

            public CoolCorpRobot()
            {
                this.robot = new USRobot();
            }

            public float CurrentSpeedInKilometersPerHour
            {
                get
                {
                    return this.robot.CurrentSpeedInMilesPerHour * 1.6093f;
                }
                set
                {
                    this.robot.CurrentSpeedInMilesPerHour = value * 0.62137f;
                }
            }

            public void Jump(float meters)
            {
                this.robot.Jump(meters * 0.3048f);
            }
        }


    }
}
