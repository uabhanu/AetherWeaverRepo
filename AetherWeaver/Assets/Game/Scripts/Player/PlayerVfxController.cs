namespace Game.Scripts.Player
{
    using Obvious.Soap;
    using System.Collections;
    using UnityEngine;
    
    public class PlayerVfxController : MonoBehaviour
    {
        #region Variables
        
        private Color _originalColor;
        private SpriteRenderer _spriteRenderer;

        [Header("Dash Visuals")]
        [SerializeField] private Color dashColor;
        [SerializeField] private float dashDuration;
        [SerializeField] private float flickerRate;
        
        [Header("SOAP Events")]
        [SerializeField] private ScriptableEventNoParam onDashInput;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            
            if(_spriteRenderer) { _originalColor = _spriteRenderer.color; }
        }

        private void OnEnable()
        {
            onDashInput.OnRaised += OnDashInput;
        }

        private void OnDisable() { onDashInput.OnRaised -= OnDashInput; }

        #endregion
        
        #region My Methods

        private IEnumerator DashVFXCoroutine()
        {
            float startTime = Time.time;
            
            while(Time.time < startTime + dashDuration)
            {
                if(_spriteRenderer) { _spriteRenderer.color = dashColor; }

                yield return new WaitForSeconds(flickerRate);
                
                if(_spriteRenderer) { _spriteRenderer.color = _originalColor; }

                yield return new WaitForSeconds(flickerRate);
            }
            
            if(_spriteRenderer) { _spriteRenderer.color = _originalColor; }
        }

        #endregion

        #region My Soap Event Listeners

        private void OnDashInput()
        {
            StopAllCoroutines();
            StartCoroutine(DashVFXCoroutine());
        }

        #endregion
    }
}