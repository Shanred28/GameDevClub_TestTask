using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] private Player player;

    [SerializeField] private JoystickController mobileJoystick;

    [SerializeField] private PointerClickHold m_MobileFirePrimary;
  

    private void Update()
    {

        ControlMobile();
    }

    private void ControlMobile()
    {

        Vector3 dir = mobileJoystick.Value;

        var dotY = Vector2.Dot(dir, player.transform.up);
        var dotX = Vector2.Dot(dir, player.transform.right);
        player.Move(new Vector2(dotX, dotY));



      if (m_MobileFirePrimary.IsHold == true)
            player.Fire();

    }
}
