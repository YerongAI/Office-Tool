using System;

namespace OfficeTool.Export
{
    public class UpgradeFinishDelegate : EventArgs
    {
        public UpgradeFinishDelegate()
        { }
    }

    public class UpgradeProgressDelegate : EventArgs
    {
        public UpgradeProgressDelegate(int percentage, int current, int total)
        {
            Percentage = percentage;
            Current = current;
            Total = total;
        }

        public int Percentage { get; set; } = 0;
        public int Total { get; set; } = 1;
        public int Current { get; set; } = 0;
    }

    public delegate void UpgradeFinishCompleted(object sender, UpgradeFinishDelegate e);
    public delegate void UpgradeProgressChanged(object sender, UpgradeProgressDelegate e);
}