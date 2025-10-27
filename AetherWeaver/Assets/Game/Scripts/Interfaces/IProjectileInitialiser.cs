namespace Game.Scripts.Interfaces
{
    using UnityEngine;
    
    public interface IProjectileInitialiser
    {
        void Initialize(Vector3 direction , Transform spawnPoint);
    }
}