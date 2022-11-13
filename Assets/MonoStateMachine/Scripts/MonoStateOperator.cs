using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoState.Opration
{
    public class MonoStateOperator : MonoBehaviour
    {
        public System.Action Run { get; set; }

        void Update()
        {
            Run.Invoke();
        }
    }
}
