namespace Game.Scripts.Combat
{
    using Data;
    using Interfaces;
    using Soap.Events;
    using UnityEngine;

    public class ProjectileSpawner : MonoBehaviour
    {
        #region Variables

        [Header("SOAP Events")]
        [SerializeField] private ScriptableEventProjectileData onProjectileLaunch;

        #endregion

        #region Unity Methods

        private void OnEnable() { onProjectileLaunch.OnRaised += SpawnProjectile; }

        private void OnDisable() { onProjectileLaunch.OnRaised -= SpawnProjectile; }

        #endregion

        #region My Methods

        private void SpawnProjectile(ProjectileData projectileData)
        {
            GameObject projectileObject = Instantiate(projectileData.Prefab , projectileData.SpawnPoint.position , Quaternion.identity);

            IProjectileInitialiser iProjectileInitializer = projectileObject.GetComponent<IProjectileInitialiser>();

            iProjectileInitializer?.Initialize(projectileData.Direction , projectileData.SpawnPoint);
        }

        #endregion
    }
}