using System;
using System.Collections;

namespace StateMachine.StateMachine
{
    public class StateMachine : IStateMachine
    {
        private StateInfo[] _stateInfos;

        public StateInfo[] StateInfos
        {
            get => _stateInfos;
            set => _stateInfos = value;
        }

        private int _stateCounter;
        public void Init(int stateCounts)
        {
            _stateInfos = new StateInfo[stateCounts];
            _stateCounter = 0;
        }

 

        public void SetProcess(int st, Action begin, Action tick, Action end, Func<IEnumerator> coroutine)
        {
            StateInfo stateInfo = new StateInfo()
            {
                st = st,
                begin = begin,
                tick = tick,
                end = end,
                coroutine = coroutine
            };
            _stateInfos[_stateCounter] = stateInfo;
            _stateCounter++;
        }


    }
}