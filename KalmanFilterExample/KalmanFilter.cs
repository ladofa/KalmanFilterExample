using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KalmanFilterExample
{
	class KalmanFilter
	{
		//estimated position and velocity
		float xp;
		float xv;

		//variance of position and velocity
		//P = [p1 p2; p3 p4]
		float p1;
		float p2;
		float p3;
		float p4;

		//time interval
		float dt;

		public void Init(float xp, float xv, float p, float dt)
		{
			this.xp = xp;
			this.xv = xv;
			this.p1 = p;
			this.p2 = 0;
			this.p3 = 0;
			this.p4 = p;
			
		}

		public void Update(float z)
		{
			//------------------------------------
			//predict
			xp = xp + dt * xv;

			float q1 = p1 + dt * p3 + dt * p2 + dt * dt * p4;
			float q2 = 

			//xv = xv;


			

			//--------------------------------------
			//correct
		}

		public float Poisition
		{
			get => xp;
		}

		public float Velocity
		{
			get => xv;
		}
	}
}
