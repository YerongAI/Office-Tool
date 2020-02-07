namespace OfficeTool.Export
{
    public class FinishEventArgs : System.EventArgs
    {
        public FinishEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public class ProgressEventArgs : System.EventArgs
    {
        public ProgressEventArgs(int current)
        {
            Current = current;
        }

        public ProgressEventArgs(int current, int maximum)
        {
            Current = current;
            Maximum = maximum;
        }

        public ProgressEventArgs(string action, int current, int maximum)
        {
            Action = action;
            Current = current;
            Maximum = maximum;
        }

        public int Current { get; set; } = -1;

        public int Maximum { get; set; } = -1;

        public string Action { get; set; } = null;
    }

    public class AbortEventArgs : System.EventArgs
    {
        public AbortEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; set; }
    }

    public delegate void FinishDelegate(object sender, FinishEventArgs e);
    public delegate void ProgressDelegate(object sender, ProgressEventArgs e);
    public delegate void AbortDelegate(object sender, AbortEventArgs e);
}
