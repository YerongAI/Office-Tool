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
    }
}
