using MonoState.Data;

namespace MonoState.State
{
    public abstract class MonoStateBase
    {
        public abstract void Setup(MonoStateData data);
        public abstract void OnEntry();
        public abstract void OnExecute();
        public abstract System.Enum OnExit();
    }
}
