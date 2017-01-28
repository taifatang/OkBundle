using OkBundle.Interfaces;

namespace OkBundle.Results
{
    public class Switch<T> : Result
    {
        public T Switcheroo { get; set; }
        public bool ExecuteDefault { get; set; } = true;

        public Switch(T switcheroo)
        {
            Switcheroo = switcheroo;
        }
        public void InhibitNextExecution()
        {
            ExecuteDefault = false;
            Execute = false;
        }
    }
}