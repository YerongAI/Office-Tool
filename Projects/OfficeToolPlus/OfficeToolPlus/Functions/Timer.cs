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

        public string GetTimePass()
        {
            return DateTime.Now.Subtract(dateTime).ToString(@"mm\:ss");
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
