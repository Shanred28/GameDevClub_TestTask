using UnityEngine;

public class Enemy : Destructible
{
    [SerializeField] private float speedMove;
    [SerializeField] private int damage;
    [SerializeField] private ColectableItem[] itemsPref;
    private Vector3 targetMove;
    private bool isTarget;

    private void Update()
    {
        if (isTarget) 
        { 
          transform.position= Vector3.MoveTowards(transform.position, targetMove, Time.deltaTime * speedMove);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent<Player>(out Player player))
        {
            isTarget = true;
            targetMove = player.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.root.TryGetComponent<Player>(out Player player))
        {
            targetMove = player.transform.position;
        }
        else
            isTarget = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.root.TryGetComponent<Player>(out Player player))
        {
            player.ApplyDamage(damage);
        }
    }

    /*    private void OnCollisionStay2D(Collision2D collision)
        {
            if (collision.transform.root.TryGetComponent<Player>(out Player player))
            {
                player.ApplyDamage(damage);
            }
        }*/

    protected override void OnDeath()
    {
        ColectableItem item = Instantiate(itemsPref[Random.Range(0, itemsPref.Length)], transform.position, Quaternion.identity );

        base.OnDeath();

    }

}
