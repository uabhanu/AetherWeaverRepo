namespace Game.Scripts.Player
{
    using Data;
    using Obvious.Soap;
    using Soap.Events;
    using UnityEngine;
    using UnityEngine.InputSystem;
    
    public class PlayerAttacker : MonoBehaviour
    {
        #region Variables
        
        private float _cooldownTimer;
        
        [Header("Configuration")]
        [SerializeField] private float attackCooldown;
        [SerializeField] private GameObject projectilePrefab;
        [SerializeField] private float spawnOffsetDistance;
        [SerializeField] private Transform spawnPoint;

        [Header("SOAP Events")]
        [SerializeField] private ScriptableEventNoParam onPrimaryAttackInput;
        [SerializeField] private ScriptableEventProjectileData onProjectileLaunch;

        #endregion

        #region Unity Methods

        private void Update()
        {
            if(_cooldownTimer > 0) { _cooldownTimer -= Time.deltaTime; }
        }

        private void OnEnable() { onPrimaryAttackInput.OnRaised += OnPrimaryAttack; }

        private void OnDisable() { onPrimaryAttackInput.OnRaised -= OnPrimaryAttack; }

        #endregion
        
        #region My Methods

        private void LaunchProjectile()
        {
            Vector3 direction = transform.right;
            ProjectileData projectileData = new ProjectileData { Prefab = projectilePrefab , Direction = direction , SpawnPoint = spawnPoint};
            onProjectileLaunch?.Raise(projectileData);
        }

        #endregion

        #region My Soap Event Listeners

        private void OnPrimaryAttack()
        {
            if(_cooldownTimer <= 0)
            {
                LaunchProjectile();
                _cooldownTimer = attackCooldown;
            }
        }

        #endregion
    }
}