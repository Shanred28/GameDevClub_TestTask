using UnityEngine;


public class Weapon : MonoBehaviour
{
    [SerializeField] private TurretMode m_Mode;
    public TurretMode Mode => m_Mode;

    [SerializeField] private WeaponProperties m_TurretProperties;
    [SerializeField] private Transform firePoint;
    private float m_RefireTimer;

    public bool CanFire => m_RefireTimer <= 0;

    private PlayerInventory inventory;
    private Player player;
    private int directionProjectile = 1; 

    [SerializeField] private AudioSource m_AudioSource;

    #region Unity Event 
    private void Start()
    {
        inventory = transform.root.GetComponent<PlayerInventory>();
        player = transform.root.GetComponent<Player>();
    }

    private void Update()
    {
        if(m_RefireTimer > 0)
                m_RefireTimer -= Time.deltaTime;
    }
    #endregion


    #region Public API

    public void Fire()
    { 
        if(m_TurretProperties == null) return;

        if (m_RefireTimer > 0) return;

        if (inventory.DrawBullet() == false) return;

        Projectile projectile = Instantiate(m_TurretProperties.ProjectilePrefab).GetComponent<Projectile>();
        projectile.SetPerentShooter(player);
        projectile.transform.position = firePoint.position; 
        projectile.Direction =  directionProjectile; 

        m_RefireTimer = m_TurretProperties.RateOfFire;

        m_AudioSource.PlayOneShot(m_TurretProperties.LaunchSFX);
            
    }

    public void AssignLoadout(WeaponProperties props)
    {
        if (m_Mode != props.Mode) return;

        m_RefireTimer = 0;
        m_TurretProperties = props;
    }

    public void SetPisitionFirePoint()
    {
        firePoint.localPosition = new Vector3(firePoint.localPosition.x * -1, firePoint.localPosition.y, 0);
        directionProjectile = directionProjectile * - 1;

    }
    #endregion
    
}

