namespace Game.Scripts.Player
{
    using Obvious.Soap;
    using UnityEngine;
    
    public class PlayerInputHandler : MonoBehaviour
    {
        #region Variables

        private PlayerInputActions _playerInputActions;
        
        [SerializeField] private ScriptableEventNoParam onDashInput;
        [SerializeField] private ScriptableEventVector2 onMoveInput;
        [SerializeField] private ScriptableEventNoParam onPrimaryAttackInput;

        #endregion

        #region Unity Methods

        private void Awake()
        {
            _playerInputActions = new PlayerInputActions();
            
            _playerInputActions.Player.Dash.performed += _ => onDashInput?.Raise();
            
            _playerInputActions.Player.Move.performed += ctx => onMoveInput?.Raise(ctx.ReadValue<Vector2>());
            _playerInputActions.Player.Move.canceled += _ => onMoveInput?.Raise(Vector2.zero);
            
            _playerInputActions.Player.PrimaryAttack.performed += _ => onPrimaryAttackInput?.Raise();
        }

        private void OnEnable() { _playerInputActions.Enable(); }

        private void OnDisable() { _playerInputActions.Disable(); }

        #endregion
    }
}