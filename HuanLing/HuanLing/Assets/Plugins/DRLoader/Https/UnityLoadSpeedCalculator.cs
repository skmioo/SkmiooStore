using System;
using System.Collections.Generic;

namespace UnityEngine.Networking
{
    /// <summary>
    /// 下载速度计算器
    /// </summary>
    class UnityLoadSpeedCalculator
    {
        private float _LongTimeSpan;
        private float _ShortTimeSpan;

        private float _LongSpanStartTime;
        private long _LongSpanBytes;
        private float _LongSpanSpeed;

        private float _ShortSpanStartTime;
        private long _ShortSpanBytes;
        private float _ShortSpanSpeed;
        public UnityLoadSpeedCalculator(float shortTimeSpan =2.0f, float longTimeSpan =5.0f)
        {
            _ShortTimeSpan = shortTimeSpan;
            _LongTimeSpan = longTimeSpan;
            _LongSpanSpeed = 0.0f;
            _ShortSpanSpeed = 0.0f;
            Reset();
        }
        /// <summary>
        /// 最近一段时间的平均速度
        /// </summary>
        public float speed
        {
            get
            {
                return _LongSpanSpeed;
            }
        }
        /// <summary>
        /// 当前的即时速度
        /// </summary>
        public float nowSpeed
        {
            get
            {
                return _ShortSpanSpeed;
            }
        }
        /// <summary>
        /// 重新开始计算速度
        /// </summary>
        public void Reset()
        {
            _LongSpanStartTime = Time.time;
            _LongSpanBytes = 0;
            _ShortSpanStartTime = Time.time;
            _ShortSpanBytes = 0;
        }
        /// <summary>
        /// 记录一次速度
        /// </summary>
        /// <param name="spd"></param>
        public void RecordSpeed(long byteNum)
        {
            _ShortSpanBytes += byteNum;
            if (Time.time -_ShortSpanStartTime > _ShortTimeSpan)
            {
                _ShortSpanSpeed = _ShortSpanBytes / (Time.time - _ShortSpanStartTime);
                _ShortSpanBytes = 0;
                _ShortSpanStartTime = Time.time;
                if (_LongSpanSpeed <= 0.0f)
                    _LongSpanSpeed = _ShortSpanSpeed;
            }

            _LongSpanBytes += byteNum;
            if (Time.time -_LongSpanStartTime > _LongTimeSpan)
            {
                _LongSpanSpeed = _LongSpanBytes / (Time.time - _LongSpanStartTime);
                _LongSpanBytes = 0;
                _LongSpanStartTime = Time.time;
            }
        }
    }
}
