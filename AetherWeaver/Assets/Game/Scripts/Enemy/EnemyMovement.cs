namespace Game.Scripts.Enemy
{
    using Obvious.Soap;
    using UnityEngine;

    public class EnemyMovement : MonoBehaviour
    {
        #region Variables

        private GameObject _playerGameObject;
        private float _sqrStoppingDistance;

        [Header("Configuration")]
        [SerializeField] private float moveSpeed;
        [SerializeField] private float stoppingDistance;

        [Header("SOAP")]
        [SerializeField] private ScriptableEventGameObject onPlayerRegistered;

        #endregion

        #region Unity Methods

        private void Start() { _sqrStoppingDistance = stoppingDistance * stoppingDistance; }

        private void OnEnable() { onPlayerRegistered.OnRaised += OnPlayerRegistered; }

        private void OnDisable() { onPlayerRegistered.OnRaised -= OnPlayerRegistered; }

        private void Update()
        {
            if(!_playerGameObject) return;

            Vector3 playerPosition = _playerGameObject.transform.position;

            if((playerPosition - transform.position).sqrMagnitude > _sqrStoppingDistance)
            {
                Vector3 directionToPlayer = (playerPosition - transform.position).normalized;
                transform.position += directionToPlayer * (moveSpeed * Time.deltaTime);
            }
        }

        #endregion

        #region My Soap Event Listeners

        private void OnPlayerRegistered(GameObject registeredPlayerGameObject) { _playerGameObject = registeredPlayerGameObject; }

        #endregion
    }
}