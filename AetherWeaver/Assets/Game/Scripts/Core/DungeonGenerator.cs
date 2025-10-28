namespace Game.Scripts.Core
{
    using Data;
    using Soap.Events;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class DungeonGenerator : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] private List<RoomLayoutSo> availableRoomsSosList;
        [SerializeField] private int numberOfRooms;
        [SerializeField] private ScriptableEventRoomLayoutSo onRoomLayoutGenerated;
        [SerializeField] private float roomSpacing;
        [SerializeField] private RoomLayoutSo startingRoomLayoutSo;
        
        #endregion
        
        #region Unity Methods
        private void Start() { GenerateDungeon(); }
        
        #endregion
        
        #region My Methods

        private void GenerateDungeon()
        {
            RoomLayoutSo currentRoomLayoutSo = startingRoomLayoutSo;
            Vector3 currentPosition = Vector3.zero;

            if(currentRoomLayoutSo)
            {
                Instantiate(currentRoomLayoutSo.RoomPrefab , currentPosition , Quaternion.identity , transform);
                onRoomLayoutGenerated.Raise(currentRoomLayoutSo);
            }
            
            for(int i = 1 ; i < numberOfRooms ; i++)
            {
                currentPosition += new Vector3(0 , roomSpacing , 0);
                RoomLayoutSo nextRoomLayoutSo = availableRoomsSosList[Random.Range(0 , availableRoomsSosList.Count)];
                Instantiate(nextRoomLayoutSo.RoomPrefab , currentPosition , Quaternion.identity , transform);
                onRoomLayoutGenerated.Raise(nextRoomLayoutSo);
            }
        }
        
        #endregion
    }
}