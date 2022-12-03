using Character;

public class TurretUnit : Unit
{
    private TurretUnitStats turretStats;
    private float duration;
    
    public void Initialize(float duration)
    {
        this.duration = duration;
    }
    
    protected override void Awake()
    {
        base.Awake();

        if (baseStats is TurretUnitStats turretUnitStats)
        {
            turretStats = turretUnitStats;
        }
    }

    protected virtual void Update()
    {
        if (turretStats == null)
        {
            return;
        }
    }
    
    public override void Die()
    {
        Destroy(gameObject);
    }
}