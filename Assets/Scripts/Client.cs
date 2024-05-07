using System.Collections;
using StateMachine.StateMachine;
using UnityEngine;

namespace StateMachine
{
    public class Client : MonoBehaviour
    {
        [SerializeField]
        private StateMachineMono stateMachineMono;

        private const int ST_FIRST = 0;
        private const int ST_NEXT = 1;
        private const int ST_FINAL = 2;

        private void Awake()
        {
            stateMachineMono.Init(3);
            stateMachineMono.SetProcess(ST_FIRST,Begin,Tick,End,Coroutine);
            stateMachineMono.SetProcess(ST_NEXT,BeginNext,TickNext,null,null);
            stateMachineMono.SetProcess(ST_NEXT,BeginFinal,null,null,CoroutineFinal);

        }

        private void Start()
        {
            stateMachineMono.CurrentState = 0;
        }

        private void Update()
        {
            if (Input.anyKey)
            {
                print("-");
                stateMachineMono.CurrentState = ST_FINAL; 
            }
        }

        private void Begin()
        {
            print("Begin");
        }
        private void BeginNext()
        {
            print("BeginNext");
        }
        private void BeginFinal()
        {
            print("BeginFinal");
        }

        private void Tick()
        {
            print("Tick");
        }
        
        private void TickNext()
        {
            print("TickNext");
        }

        private void End()
        {
            print("End");
        }

        private IEnumerator Coroutine()
        {
            yield return new WaitForSeconds(5f);
            print("Coroutine");
            stateMachineMono.CurrentState = 1;

        }
        
        private IEnumerator CoroutineFinal()
        {
            yield return new WaitForSeconds(5f);
            print("CoroutineFinal");
            stateMachineMono.CurrentState = 0;
        }
    }
}
