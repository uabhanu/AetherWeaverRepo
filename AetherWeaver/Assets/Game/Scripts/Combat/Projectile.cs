namespace Game.Scripts.Combat
{
    using Interfaces;
    using Obvious.Soap;
    using UnityEngine;

    public class Projectile : MonoBehaviour , IProjectileInitialiser
    {
        #region Variables

        private Vector3 _direction;
        private ScriptableEventFloat _onTakeDamage;

        [SerializeField] private FloatVariable damageVariable;
        [SerializeField] private float lifetime;
        [SerializeField] private float speed;

        #endregion

        #region Unity Methods

        private void Start() { Destroy(gameObject , lifetime); }

        private void Update() { transform.position += _direction * (speed * Time.deltaTime); }

        private void OnTriggerEnter2D(Collider2D other)
        {
            IDamageTaker iDamageTaker = other.GetComponent<IDamageTaker>();

            if(iDamageTaker != null)
            {
                ScriptableEventFloat targetTakeDamage = iDamageTaker.OnTakeDamageEvent;

                if(targetTakeDamage) { targetTakeDamage.Raise(damageVariable.Value); }

                Destroy(gameObject);
            }
        }

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

        public void Initialize(Vector3 direction) { SetDirection(direction); }

        #endregion
    }
}