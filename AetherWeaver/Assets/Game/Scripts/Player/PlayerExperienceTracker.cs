namespace Game.Scripts.Player
{
    using Obvious.Soap;
    using UnityEngine;
    
    public class PlayerExperienceTracker : MonoBehaviour
    {
        #region Variables

        [Header("SOAP Variables")]
        [SerializeField] private ScriptableEventFloat onPlayerExperienceGained;
        [SerializeField] private FloatVariable playerExperienceVariable;

        #endregion

        #region Unity Methods

        private void OnEnable() { onPlayerExperienceGained.OnRaised += OnPlayerExperienceGained; }

        private void OnDisable() { onPlayerExperienceGained.OnRaised -= OnPlayerExperienceGained; }

        #endregion

        #region My SOAP Event Listeners

        private void OnPlayerExperienceGained(float amount)
        {
            if(playerExperienceVariable)
            {
                playerExperienceVariable.Value += amount;
                // NOTE: Level-up logic would be checked here in the future.
            }
        }

        #endregion
    }
}