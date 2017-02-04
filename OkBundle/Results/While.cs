namespace OkBundle.Results
{
    public class While : Result
    {
        public bool Predicate { get; set; }

        public While(bool predicate)
        {
            Predicate = predicate;
        }
    }
}