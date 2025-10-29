namespace Game.Scripts.Dungeon
{
    using Data;
    using Soap.Events;
    using UnityEngine;

    public class RoomController : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] public ScriptableEventRoomLayoutSo onRoomLayoutSoGenerated;
        [SerializeField] private RoomLayoutSo roomLayoutSo;
        
        #endregion
        
        #region Unity Methods

        private void OnEnable()
        {
            if(onRoomLayoutSoGenerated) { onRoomLayoutSoGenerated.OnRaised += OnRoomLayoutGenerated; }
        }

        private void OnDisable()
        {
            if(onRoomLayoutSoGenerated) { onRoomLayoutSoGenerated.OnRaised -= OnRoomLayoutGenerated; }
        }
        
        #endregion
        
        #region My SOAP Event Listeners

        private void OnRoomLayoutGenerated(RoomLayoutSo generatedRoomLayoutSo)
        {
            roomLayoutSo = generatedRoomLayoutSo;

            // NOTE: Future logic (spawning, doors) will be called here.

            // CRITICAL: Unsubscribe immediately after receiving the data, as initialization only happens once.
        }

        // We will add methods later to spawn enemies, lock/unlock doors, etc.
        
        #endregion
    }
}