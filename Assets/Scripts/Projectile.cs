using UnityEngine;


public class Projectile : Entity
{
    [SerializeField] protected float m_Velocity;
    public float VelocityProjectile => m_Velocity;

    [SerializeField] protected float m_LifeTime;

    [SerializeField] protected int m_Damage;

    [SerializeField] protected ImpactEffect m_ImpactEffectPrefab;

    protected float m_Timer;
    public int Direction;
    protected virtual void Update()
    {
        float stepLenght = Time.deltaTime * m_Velocity;
        Vector2 step = transform.right * Direction * stepLenght;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.right * Direction, stepLenght);

            
        if (hit && hit.collider.isTrigger != true)
        { 

            Destructible dest = hit.collider.transform.root.GetComponent<Destructible>();
            if (dest != null && dest != m_Perent)
            { 
                dest.ApplyDamage(m_Damage);
                OnProjectileLifeEnd();
                /*var boom = Instantiate(m_ImpactEffectPrefab);
                boom.transform.position = this.transform.position;*/

            }

        }

        m_Timer += Time.deltaTime;
        if (m_Timer > m_LifeTime)
            Destroy(gameObject);

        transform.position += new Vector3(step.x, step.y, 0);
    }

    protected void OnProjectileLifeEnd()
    { 
        Destroy(gameObject);
    }

    private Destructible m_Perent;

    public void SetPerentShooter(Destructible perent)
    {
        m_Perent = perent;
    }

}

