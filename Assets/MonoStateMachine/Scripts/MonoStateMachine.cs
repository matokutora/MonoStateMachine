using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;

namespace MonoState
{
    using MonoState.State;
    using MonoState.Data;
    using MonoState.Opration;

    public class MonoStateMachine<User> where User : Object
    {
        User _user;

        bool _isRun = false;
        string _currentKey = null;

        MonoStateBase _currentState = null;
        Dictionary<string, MonoStateBase> _stateDic = new Dictionary<string, MonoStateBase>();
        MonoStateData _data = new MonoStateData();

        public bool IsRun
        {
            get => _isRun;

            set
            {
                _isRun = value;
                SetRun(value);
            }
        }

        public MonoStateMachine(User user)
        {
            _user = user;
        }

        public MonoStateMachine<User> AddState(System.Enum stateKey, MonoStateBase state)
        {
            _stateDic.Add(stateKey.ToString(), state);
            return this;
        }

        public MonoStateMachine<User> AddMonoData(IMonoDatable datable)
        {
            _data.AddMonoData(datable);
            return this;
        }

        void SetRun(bool isRun)
        {
            System.Action action = isRun ? Setup : () => Object.Destroy(_user.GetComponent<MonoStateOperator>());
            action.Invoke();
        }

        void Setup()
        {
            foreach (MonoStateBase state in _stateDic.Values)
            {
                state.Setup(_data);
            }

            OnNext(_stateDic.Keys.First());

            MonoStateOperator monoStateOperator = _user.AddComponent<MonoStateOperator>();
            monoStateOperator.Run = OnProcess;
        }

        void OnProcess()
        {
            

        }

        void OnNext(string nextState)
        {
            MonoStateBase stateBase = _stateDic.First(s => s.Key == nextState).Value;
            stateBase.OnEntry();

            _currentState = stateBase;
            _currentKey = nextState;
        }
    }
}