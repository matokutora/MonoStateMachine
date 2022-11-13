using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MonoState.Data
{
    public class MonoStateData
    {
        List<IMonoDatable> _monoDataList = new List<IMonoDatable>();

        public void AddMonoData(IMonoDatable datable)
        {
            _monoDataList.Add(datable);
        }

        public MonoData GetMonoData<MonoData>(string path) where MonoData : Object, IMonoDatable
        {
            IMonoDatable monoDatable = _monoDataList.Find(m => m.Path == path);
            IMonoDatableSystem<MonoData> system = monoDatable as IMonoDatableSystem<MonoData>;

            if (system != null)
            {
                return (MonoData)system;
            }
            else
            {
                IMonoDatableUni<MonoData> uni = monoDatable as IMonoDatableUni<MonoData>;
                return (MonoData)uni;
            }
        }
    }
}
