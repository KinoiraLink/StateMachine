using System;
using System.Collections;
using UnityEngine;

namespace StateMachine.StateMachine
{
    public class StateMachineMono : MonoBehaviour, IStateMachine
    {
        private StateMachine _stateMachine;
        
        private int _currentState = -1;
        public int CurrentState
        {
            get => _currentState;
            set
            {
                _isSwitching = true;
                if (_currentState != -1) 
                    _stateMachine.StateInfos[_currentState].end?.Invoke();
                _currentState = value;
                _stateMachine.StateInfos[_currentState].begin?.Invoke();
                if(_stateMachine.StateInfos[_currentState].coroutine != null)
                    StartCoroutine(_stateMachine.StateInfos[_currentState].coroutine.Invoke());
                _isSwitching = false;
            } 
           
        }

        private bool _isSwitching;

        public void Init(int stateCounts)
        {
            _stateMachine = new StateMachine();
            _stateMachine.Init(stateCounts);
        }

        public void SetProcess(int st, Action begin, Action tick, Action end, Func<IEnumerator> coroutine)
        {
            _stateMachine.SetProcess(st, begin, tick, end, coroutine);
        }
        
        private void Update()
        {
            if (CurrentState == -1)
            {
                return;
            }
            if(_isSwitching) 
                return;
            _stateMachine.StateInfos[_currentState].tick?.Invoke();
        }
    }
}