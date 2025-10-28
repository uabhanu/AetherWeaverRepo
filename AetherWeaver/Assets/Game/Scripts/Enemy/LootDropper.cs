namespace Game.Scripts.Enemy
{
    using Obvious.Soap;
    using UnityEngine;
    
    public class LootDropper : MonoBehaviour
    {
        #region Variables
        
        [SerializeField] private FloatVariable enemyXpValueVariable;
        [SerializeField] private ScriptableEventNoParam onDied;
        [SerializeField] private ScriptableEventFloat onPlayerExperienceGained;

        #endregion

        #region Unity Methods

        private void OnEnable() { onDied.OnRaised += OnDied; }

        private void OnDisable() { onDied.OnRaised -= OnDied; }

        #endregion

        #region My SOAP Event Listeners

        private void OnDied()
        {
            if(onPlayerExperienceGained && enemyXpValueVariable) { onPlayerExperienceGained.Raise(enemyXpValueVariable.Value); }

            // NOTE: Future development will include spawning pickup objects (Aether Shards, etc.) here.
        }

        #endregion
    }
}