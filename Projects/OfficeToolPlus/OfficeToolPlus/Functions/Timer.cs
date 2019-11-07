using System;

namespace OTP.Functions
{
    class Timer
    {
        private static DateTime dateTime = new DateTime();

        public Timer(bool reset)
        {
            if (reset)
            {
                dateTime = DateTime.Now;
            }
        }

        /// <summary>
        /// 获取 mm:ss 格式的时间
        /// </summary>
        /// <returns>返回经过的时间</returns>
        public string GetTimePassString()
        {
            return DateTime.Now.Subtract(dateTime).ToString(@"mm\:ss");
        }

        /// <summary>
        /// 获取以秒为单位的时间
        /// </summary>
        /// <returns>返回经过的时间</returns>
        public double GetTimePassed()
        {
            return DateTime.Now.Subtract(dateTime).TotalSeconds;
        }

        public string GetElcapedTime(double totalSize, double downloadedSize)
        {
            long speed = (long)(downloadedSize / DateTime.Now.Subtract(dateTime).TotalSeconds);
            if (speed == 0)
                speed = 1;
            DateTime time = new DateTime(((long)(totalSize - downloadedSize) / speed) * 10000000);
            return time.ToString(@"mm\:ss");
        }
    }
}
