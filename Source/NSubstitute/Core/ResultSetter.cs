namespace NSubstitute.Core
{
    public class ResultSetter : IResultSetter
    {
        private readonly ICallStack _callStack;
        private readonly ICallResults _configuredResults;
        private readonly ICallSpecificationFactory _callSpecificationFactory;

        public ResultSetter(ICallStack callStack, ICallResults configuredResults, ICallSpecificationFactory callSpecificationFactory)
        {
            _callStack = callStack;
            _configuredResults = configuredResults;
            _callSpecificationFactory = callSpecificationFactory;
        }

        public void SetResultForLastCall(IReturn valueToReturn)
        {
            var lastCall = _callStack.Pop();
            SetResultForCall(lastCall, valueToReturn);
        }

        public void SetResultForCall(ICall call, IReturn valueToReturn)
        {
            var callSpecification = _callSpecificationFactory.CreateFrom(call);
            _configuredResults.SetResult(callSpecification, valueToReturn);
        }
    }
}