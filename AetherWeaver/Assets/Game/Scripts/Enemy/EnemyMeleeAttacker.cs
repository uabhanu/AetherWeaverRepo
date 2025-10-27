namespace Game.Scripts.Enemy
{
    using Interfaces;
    using Obvious.Soap;
    using UnityEngine;

    public class EnemyMeleeAttacker : MonoBehaviour
    {
        #region Variables

        private float _attackTimer;
        private IDamageTaker _damageTaker;
        private bool _isAttacking;

        [Header("SOAP Variables")]
        [SerializeField] private FloatVariable meleeAttackDamage;
        [SerializeField] private FloatVariable meleeAttackRate;

        #endregion

        #region Unity Methods

        private void Update()
        {
            if(_attackTimer > 0) { _attackTimer -= Time.deltaTime; }
            
            if(_isAttacking && _attackTimer <= 0) { TryDamageTarget(); }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _damageTaker = other.GetComponent<IDamageTaker>();

            if(_damageTaker != null)
            {
                _isAttacking = true;
                _attackTimer = 0f;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if(_damageTaker != null)
            {
                _isAttacking = false;
                _damageTaker = null;
                _attackTimer = 0f;
            }
        }

        #endregion

        #region My Methods

        private void TryDamageTarget()
        {
            if(_attackTimer > 0 || _damageTaker == null) { return; }

            ScriptableEventFloat targetTakeDamage = _damageTaker.OnTakeDamageEvent;

            if(targetTakeDamage)
            {
                targetTakeDamage.Raise(meleeAttackDamage.Value);
                _attackTimer = meleeAttackRate.Value;
            }
        }

        #endregion
    }
}