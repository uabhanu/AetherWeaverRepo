namespace Game.Scripts.Core
{
    using Data;
    using Soap.Events;
    using System.Collections.Generic;
    using UnityEngine;

    public class DungeonGenerator : MonoBehaviour
    {
        #region Helper Classes

        private class RoomConnection
        {
            public string ExitDirection;
            public Vector3 Position;
            public RoomLayoutSo RoomLayoutSo;
        }

        #endregion

        #region Variables

        private HashSet<Vector3> _occupiedPositionsHashSet;
        private List<RoomConnection> _roomOpenConnectionsList;

        [SerializeField] private List<RoomLayoutSo> availableRoomsSosList;
        [SerializeField] private int numberOfRooms;
        [SerializeField] private ScriptableEventRoomLayoutSo onRoomLayoutGenerated;
        [SerializeField] private float roomSpacing;
        [SerializeField] private RoomLayoutSo startingRoomLayoutSo;

        #endregion

        #region Unity Methods

        private void Start()
        {
            _occupiedPositionsHashSet = new HashSet<Vector3>();
            _roomOpenConnectionsList = new List<RoomConnection>();
            GenerateDungeon();
        }

        #endregion

        #region My Methods

        private void AddOpenConnections(RoomLayoutSo roomLayoutSo , Vector3 roomPosition)
        {
            if(roomLayoutSo.ExitNorth) _roomOpenConnectionsList.Add(new RoomConnection { Position = roomPosition , ExitDirection = "North" });
            if(roomLayoutSo.ExitEast) _roomOpenConnectionsList.Add(new RoomConnection { Position = roomPosition , ExitDirection = "East" });
            if(roomLayoutSo.ExitSouth) _roomOpenConnectionsList.Add(new RoomConnection { Position = roomPosition , ExitDirection = "South" });
            if(roomLayoutSo.ExitWest) _roomOpenConnectionsList.Add(new RoomConnection { Position = roomPosition , ExitDirection = "West" });
        }

        private void GenerateDungeon()
        {
            RoomLayoutSo currentRoomLayoutSo = startingRoomLayoutSo;
            Vector3 currentPosition = Vector3.zero;
            Vector3 quantizedStartPos = new Vector3(Mathf.Round(currentPosition.x) , Mathf.Round(currentPosition.y) , Mathf.Round(currentPosition.z));

            if(currentRoomLayoutSo)
            {
                Instantiate(currentRoomLayoutSo.RoomPrefab , currentPosition , Quaternion.identity , transform);
                _occupiedPositionsHashSet.Add(quantizedStartPos);
                onRoomLayoutGenerated.Raise(currentRoomLayoutSo);
                AddOpenConnections(currentRoomLayoutSo , currentPosition);
            }

            for(int i = 1 ; i < numberOfRooms ; i++)
            {
                if(_roomOpenConnectionsList.Count == 0)
                {
                    Debug.LogWarning("Dungeon generation stopped early: No open connections left.");
                    break;
                }

                int randomIndex = Random.Range(0 , _roomOpenConnectionsList.Count);
                RoomConnection connectionPoint = _roomOpenConnectionsList[randomIndex];
                _roomOpenConnectionsList.RemoveAt(randomIndex);

                Vector3 newRoomPosition = connectionPoint.Position + GetDirectionOffset(connectionPoint.ExitDirection);
                Vector3 quantizedNewPosition = new Vector3(Mathf.Round(newRoomPosition.x) , Mathf.Round(newRoomPosition.y) , Mathf.Round(newRoomPosition.z));

                if(_occupiedPositionsHashSet.Contains(newRoomPosition))
                {
                    i--;
                    continue;
                }

                RoomLayoutSo nextRoomLayoutSo = availableRoomsSosList[Random.Range(0 , availableRoomsSosList.Count)];

                GameObject newRoomInstance = Instantiate(nextRoomLayoutSo.RoomPrefab , newRoomPosition , Quaternion.identity , transform);
                newRoomInstance.name = nextRoomLayoutSo.name + $" (Connected {connectionPoint.ExitDirection})";
                _occupiedPositionsHashSet.Add(quantizedNewPosition);

                onRoomLayoutGenerated.Raise(nextRoomLayoutSo);
                AddOpenConnections(nextRoomLayoutSo , newRoomPosition);
            }
        }

        private Vector3 GetDirectionOffset(string direction)
        {
            return direction switch
            {
                "East" => new Vector3(roomSpacing , 0 , 0) ,
                "North" => new Vector3(0 , roomSpacing , 0) ,
                "South" => new Vector3(0 , -roomSpacing , 0) ,
                "West" => new Vector3(-roomSpacing , 0 , 0) , _ => Vector3.zero
            };
        }

        #endregion
    }
}