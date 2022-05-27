using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace DRLoader.Update
{
    class Ticker
    {
        Action _Action;
        float _ExeTime;
        public Ticker(Action action, float time)
        {
            _Action = action;
            _ExeTime = Time.time + time;
        }

        public void Update()
        {
            if(_Action != null && Time.time >= _ExeTime)
            {
                var temp = _Action;
                _Action = null;
                temp();
            }
        }
    }
}
