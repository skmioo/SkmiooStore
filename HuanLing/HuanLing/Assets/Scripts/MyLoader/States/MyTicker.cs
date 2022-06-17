using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Skmioo.MyLoader.States
{
	class MyTicker
	{
		Action _Act;
		float _ExtTime;
		public MyTicker(Action act, float time)
		{
			_Act = act;
			_ExtTime = Time.time + time;
		}

		public void Update()
		{
			if (_Act != null && Time.time >= _ExtTime)
			{
				_Act.Invoke();
				_Act = null;
			}
		}

	}
}
