namespace Game.Scripts.Data
{
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu(fileName = "RoomLayoutSo" , menuName = "Scriptable Objects/Room Layout")]
    public class RoomLayoutSo : ScriptableObject
    {
        public bool ExitEast;
        public bool ExitNorth;
        public bool ExitSouth;
        public bool ExitWest;
        
        public List<Vector3> EnemySpawnPointsList;
        
        public GameObject RoomPrefab;
    }
}