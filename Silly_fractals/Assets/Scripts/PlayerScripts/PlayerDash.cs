using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // –ассто€ние дл€ рывка
    private float dashCooldown; // ¬рем€ перезар€дки в секундах
    private float lastDashTime;

    public Rigidbody2D rb;

    void Start()
    {
        dashCooldown = PlayerManager.instance.player.GetComponent<PlayerStats>().dashCooldown;
        rb = GetComponent<Rigidbody2D>();
        lastDashTime = -dashCooldown; // ”станавливаем врем€ последнего рывка так, чтобы игрок мог использовать его сразу же после начала игры
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && Time.time - lastDashTime > dashCooldown)
        {
            Debug.Log("12437905435323");
            Dash();
        }
    }

    void Dash()
    {
        // —охран€ем врем€ использовани€ рывка
        lastDashTime = Time.time;

        // ќпредел€ем направление рывка
        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        
        // ѕримен€ем рывок
        rb.AddForce(dashDirection * 7, ForceMode2D.Impulse);
        
    }
}
