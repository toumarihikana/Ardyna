using UnityEngine.EventSystems;

namespace com.AmberSyndrome.Ardyna
{
    public interface IMessageReciever : IEventSystemHandler
    {
        void OnRecieve();
    }
}