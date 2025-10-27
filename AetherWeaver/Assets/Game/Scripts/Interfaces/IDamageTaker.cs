namespace Game.Scripts.Interfaces
{
    using Obvious.Soap;
    
    public interface IDamageTaker
    {
        ScriptableEventFloat OnTakeDamageEvent { get; }
    }
}
