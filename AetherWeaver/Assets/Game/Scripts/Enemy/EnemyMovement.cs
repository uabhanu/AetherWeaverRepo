namespace Game.Scripts.Enemy
{
    using Obvious.Soap;
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        #region Variables
        
        private GameObject _playerGameObject;

        [Header("Configuration")]
        [SerializeField] private float moveSpeed;

        [Header("SOAP")]
        [SerializeField] private ScriptableEventGameObject onPlayerRegistered;

        #endregion

        #region Unity Methods

        private void OnEnable() { onPlayerRegistered.OnRaised += OnPlayerRegistered; }
        
        private void OnDisable() { onPlayerRegistered.OnRaised -= OnPlayerRegistered; }

        private void Update()
        {
            if(!_playerGameObject) return;
            
            Vector3 directionToPlayer = (_playerGameObject.transform.position - transform.position).normalized;
            transform.position += directionToPlayer * (moveSpeed * Time.deltaTime);
        }

        #endregion
        
        #region My Soap Event Listeners

        private void OnPlayerRegistered(GameObject registeredPlayerGameObject)
        {
            _playerGameObject = registeredPlayerGameObject;
        }
        
        #endregion
    }
}