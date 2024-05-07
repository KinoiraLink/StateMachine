using System;
using System.Collections;

namespace StateMachine.StateMachine
{
    public class StateInfo
    {
        public int st;
        public Action begin;
        public Action tick;
        public Action end; 
        public Func<IEnumerator> coroutine;
    }
}