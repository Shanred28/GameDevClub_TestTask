using UnityEngine;

public class Player : Destructible
{

    [SerializeField] private float speedMove;
    [SerializeField] private SpriteRenderer [] sprites;
    [SerializeField] private Weapon weapon;


    private Vector2 move;
    private bool isRigrht;
    private void Update()
    {
        transform.position += new Vector3(move.x, move.y, 0) * Time.deltaTime * speedMove;
    }

    public void Move(Vector2 vectorMove)
    {
        move = vectorMove;

        if (isRigrht == false && move.x < 0)
        {
            foreach (var sprite in sprites)
            {
                sprite.flipX = true;
                isRigrht = true;
                weapon.SetPisitionFirePoint();
            }
        }
        else if(isRigrht == true && move.x > 0)
        {
            foreach (var sprite in sprites)
            {
                weapon.SetPisitionFirePoint();
                sprite.flipX = false; 
                isRigrht = false;
            }
        }
    }

    public void Fire()
    {
        weapon.Fire();
    }
}
