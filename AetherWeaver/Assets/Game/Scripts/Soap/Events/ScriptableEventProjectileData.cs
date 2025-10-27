using Game.Scripts.Data;

namespace Game.Scripts.Soap.Events
{
    using Obvious.Soap;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "ScriptableEvent" + nameof(ProjectileData) , menuName = "Soap/ScriptableEvents/" + nameof(ProjectileData))]
    public class ScriptableEventProjectileData : ScriptableEvent<ProjectileData> {}
}