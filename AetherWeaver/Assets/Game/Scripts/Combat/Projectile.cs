namespace Game.Scripts.Combat
{
    using Interfaces;
    using UnityEngine;

    public class Projectile : MonoBehaviour , IProjectileInitialiser
    {
        #region Variables

        private Vector3 _direction;

        [SerializeField] private float lifetime;
        [SerializeField] private float speed;

        #endregion

        #region Unity Methods

        private void Start() { Destroy(gameObject , lifetime); }

        private void Update() { transform.position += _direction * (speed * Time.deltaTime); }

        #endregion

        #region My Methods

        private void SetDirection(Vector3 direction)
        {
            _direction = direction;
            float angle = Mathf.Atan2(_direction.y , _direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f , 0f , angle - 90f);
        }

        #endregion

        #region My Interface Methods

        public void Initialize(Vector3 direction , Transform transform) { SetDirection(direction); }

        #endregion
    }
}