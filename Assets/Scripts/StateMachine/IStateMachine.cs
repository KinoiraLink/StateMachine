using System;
using System.Collections;

namespace StateMachine.StateMachine
{
    public interface IStateMachine
    {
        public void Init(int stateCounts);
        public void SetProcess(int st, Action begin, Action tick, Action end, Func<IEnumerator> coroutine);
       
    }
}