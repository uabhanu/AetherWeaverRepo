namespace Game.Scripts.Soap.Events
{
    using Data;
    using Obvious.Soap;
    using UnityEngine;

    [CreateAssetMenu(fileName = "ScriptableEvent" + nameof(RoomLayoutSo) , menuName = "Soap/ScriptableEvents/" + nameof(RoomLayoutSo))]
    public class ScriptableEventRoomLayoutSo : ScriptableEvent<RoomLayoutSo> {}
}