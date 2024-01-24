using System;

namespace CV7Library
{
    public class SetXYEventArgs : EventArgs
    {
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
