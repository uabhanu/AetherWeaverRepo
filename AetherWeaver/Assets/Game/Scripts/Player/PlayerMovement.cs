namespace Game.Scripts.Player
{
    using Obvious.Soap;
    using System.Collections;
    using UnityEngine;

    public class PlayerMovement : MonoBehaviour
    {
        #region Variables

        private float _dashCooldownTimer;
        private bool _isDashing;
        private Camera _mainCamera;
        private Vector3 _moveInput;

        [SerializeField] private float dashCooldown;
        [SerializeField] private float dashDistance;
        [SerializeField] private float dashDuration;
        [SerializeField] private float moveSpeed;
        [SerializeField] private ScriptableEventNoParam onDashInput;
        [SerializeField] private ScriptableEventVector2 onMoveInput;
        [SerializeField] private ScriptableEventGameObject onPlayerRegistered;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _mainCamera = Camera.main;
        }
        
        private void Start()
        {
            onPlayerRegistered?.Raise(gameObject); 
        }

        private void OnEnable()
        {
            onDashInput.OnRaised += OnDashInput;
            onMoveInput.OnRaised += OnMoveInput;
        }

        private void OnDisable()
        {
            onDashInput.OnRaised -= OnDashInput;
            onMoveInput.OnRaised -= OnMoveInput;
        }

        private void Update()
        {
            if(!_isDashing)
            {
                Vector3 movement = new Vector3(_moveInput.x , _moveInput.y , 0f);
                transform.position += movement * (moveSpeed * Time.deltaTime);
            }

            ClampPlayerPosition();

            if(_dashCooldownTimer > 0) { _dashCooldownTimer -= Time.deltaTime; }
        }

        #endregion

        #region My Methods

        private void ClampPlayerPosition()
        {
            float cameraZ = _mainCamera.transform.position.z;

            Vector3 minBounds = _mainCamera.ViewportToWorldPoint(new Vector3(0 , 0 , -cameraZ));
            Vector3 maxBounds = _mainCamera.ViewportToWorldPoint(new Vector3(1 , 1 , -cameraZ));

            float playerHalfWidth = transform.localScale.x / 2f;
            float playerHalfHeight = transform.localScale.y / 2f;

            float clampedX = Mathf.Clamp(transform.position.x , minBounds.x + playerHalfWidth , maxBounds.x - playerHalfWidth);
            float clampedY = Mathf.Clamp(transform.position.y , minBounds.y + playerHalfHeight , maxBounds.y - playerHalfHeight);

            transform.position = new Vector3(clampedX , clampedY , 0f);
        }

        private IEnumerator DashCoroutine(Vector2 direction)
        {
            _isDashing = true;
            float dashSpeed = dashDistance / dashDuration;
            float startTime = Time.time;

            while(Time.time < startTime + dashDuration)
            {
                transform.position += (Vector3)direction * (dashSpeed * Time.deltaTime);
                yield return null;
            }

            _isDashing = false;
            _dashCooldownTimer = dashCooldown;
        }

        #endregion

        #region My Soap Event Listeners

        private void OnDashInput()
        {
            if(_dashCooldownTimer <= 0 && !_isDashing)
            {
                Vector2 dashDirection = _moveInput.normalized;
                
                if(dashDirection == Vector2.zero)
                {
                    dashDirection = new Vector2(0f , 1f);
                }

                StartCoroutine(DashCoroutine(dashDirection));
            }
        }

        private void OnMoveInput(Vector2 moveInput) { _moveInput = moveInput; }

        #endregion
    }
}