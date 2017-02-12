using System;
using OkBundle.Interfaces;

namespace OkBundle.Models
{
    public class ForModel : IPredicate
    {
        private int _initialize;
        private bool _conditions; //predicate builder
        private Func<int, int> _action;

        public ForModel(int initialize, bool conditions, Func<int, int> action)
        {
            _initialize = initialize;
            _conditions = conditions;
            _action = action;
        }
        public void PerformAction()
        {
            _action(_initialize);
        }

        public bool Execute()
        {
            return _conditions;
        }
    }
}
