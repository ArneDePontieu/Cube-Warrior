using Character;

public class TurretUnit : Unit
{
    private TurretUnitStats turretStats;
    
    protected override void Awake()
    {
        base.Awake();

        if (stats is TurretUnitStats turretUnitStats)
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