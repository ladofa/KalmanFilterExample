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

		float r;

		public void Init(float xp, float xv, float p, float r, float dt)
		{
			this.xp = xp;
			this.xv = xv;
			this.p1 = p;
			this.p2 = 0;
			this.p3 = 0;
			this.p4 = p;
			this.r = r;
		}

		public float Update(float z)
		{
			//------------------------------------
			//predict
			xp = xp + dt * xv;

			float q1 = p1 + dt * (p2 + p3) + dt * dt * p4;
			float q2 = p2 + dt * p4;
			float q3 = p3 + dt * p4;

			//--------------------------------------
			//correct
			float y = z - xp;
			float k1 = q1 / (q1 + r);
			float k2 = q3 / (q1 + r);

			xp = xp + k1 * y;
			xv = xv + k2 * y;

			p1 = k1 * q1;
			p2 = k1 * q2;
			p3 = k2 * q1;
			p4 = k2 * p2;

			return xp;
		}

		/// <summary>
		/// 아무 입력 없이 업데이트
		/// </summary>
		/// <returns></returns>
		public float Update()
		{
			//------------------------------------
			//predict
			xp = xp + dt * xv;

			float q1 = p1 + dt * (p2 + p3) + dt * dt * p4;
			float q2 = p2 + dt * p4;
			float q3 = p3 + dt * p4;

			//--------------------------------------
			//correct
			float y = 0;
			float k1 = q1 / (q1 + r);
			float k2 = q3 / (q1 + r);

			xp = xp + k1 * y;
			xv = xv + k2 * y;

			p1 = k1 * q1;
			p2 = k1 * q2;
			p3 = k2 * q1;
			p4 = k2 * p2;

			return xp;
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
