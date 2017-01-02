using System;

namespace FundManager.Model
{
    public class DataEventArgs<T> : EventArgs
    {
        public T Data { get; private set; }

        public DataEventArgs(T data)
        {
            Data = data;
        }
    }
}
