namespace Game.Scripts.Combat
{
    using Interfaces;
    using Obvious.Soap;
    using UnityEngine;
    
    public class Health : MonoBehaviour , IDamageTaker
    {
        #region Variables

        [Header("SOAP Variables")]
        [SerializeField] private FloatVariable currentHealthVariable;
        [SerializeField] private FloatVariable maxHealthVariable;
        [SerializeField] private ScriptableEventNoParam onDied;
        [SerializeField] private ScriptableEventFloat onTakeDamage;

        #endregion

        #region Unity Methods

        private void Start()
        {
            if(currentHealthVariable && maxHealthVariable) { currentHealthVariable.Value = maxHealthVariable.Value; }
        }

        private void OnEnable() { onTakeDamage.OnRaised += OnTakeDamage; }
        
        private void OnDisable() { onTakeDamage.OnRaised -= OnTakeDamage; }

        #endregion

        #region My Methods
        
        private void Die()
        {
            onDied?.Raise();
            Destroy(gameObject);
        }

        private void TakeDamage(float damageAmount)
        {
            if(!currentHealthVariable || currentHealthVariable.Value <= 0) return;

            currentHealthVariable.Value -= damageAmount;

            if(currentHealthVariable.Value <= 0) { Die(); }
        }

        #endregion
        
        #region My Interface Methods
        
        public ScriptableEventFloat OnTakeDamageEvent => onTakeDamage;
        
        #endregion
        
        #region My Soap Event Listeners

        private void OnTakeDamage(float damageAmount)
        {
            TakeDamage(damageAmount);
        }
        
        #endregion
    }
}