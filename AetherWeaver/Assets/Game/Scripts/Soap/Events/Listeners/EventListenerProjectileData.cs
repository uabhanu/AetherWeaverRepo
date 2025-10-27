using Game.Scripts.Data;

namespace Game.Scripts.Soap.Events.Listeners
{
    using Obvious.Soap;
    using UnityEngine;
    using UnityEngine.Events;

    [AddComponentMenu("Soap/EventListeners/EventListener" + nameof(ProjectileData))]
    public class EventListenerProjectileData : EventListenerGeneric<ProjectileData>
    {
        protected override EventResponse<ProjectileData>[] EventResponses => eventResponses;
        
        [SerializeField] private EventResponse[] eventResponses;

        [System.Serializable]
        public class EventResponse : EventResponse<ProjectileData>
        {
            [SerializeField] private ProjectileDataUnityEvent response;
            [SerializeField] private ScriptableEventProjectileData scriptableEvent;
            
            public override ScriptableEvent<ProjectileData> ScriptableEvent => scriptableEvent;
            public override UnityEvent<ProjectileData> Response => response;
        }

        [System.Serializable]
        public class ProjectileDataUnityEvent : UnityEvent<ProjectileData> {}
    }
}