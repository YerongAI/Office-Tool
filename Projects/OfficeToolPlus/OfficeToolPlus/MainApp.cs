using OfficeToolPlus;
using System;

namespace OTP
{
    class MainApp
    {
        [STAThread]
        public static void Main()
        {
            App app = new App();
            app.InitializeComponent();
            app.Run();
        }
    }
}