namespace Game.Scripts.Soap.Events.Listeners
{
    using Data;
    using Obvious.Soap;
    using UnityEngine;
    using UnityEngine.Events;
    
    [AddComponentMenu("Soap/EventListeners/EventListener" + nameof(RoomLayoutSo))]
    public class EventListenerRoomLayoutSo : EventListenerGeneric<RoomLayoutSo>
    {
        protected override EventResponse<RoomLayoutSo>[] EventResponses => eventResponses;
        
        [SerializeField] private EventResponse[] eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<RoomLayoutSo>
        {
            [SerializeField] private RoomLayoutSoUnityEvent response;
            [SerializeField] private ScriptableEventRoomLayoutSo scriptableEvent;
            
            public override ScriptableEvent<RoomLayoutSo> ScriptableEvent => scriptableEvent;
            public override UnityEvent<RoomLayoutSo> Response => response;
        }

        [System.Serializable]
        public class RoomLayoutSoUnityEvent : UnityEvent<RoomLayoutSo> {}
    }
}