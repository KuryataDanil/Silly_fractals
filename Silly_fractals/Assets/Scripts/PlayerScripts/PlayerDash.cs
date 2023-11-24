using System.Collections;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashDistance = 5f; // ���������� ��� �����
    private float dashCooldown; // ����� ����������� � ��������
    private float lastDashTime;

    public Rigidbody2D rb;

    void Start()
    {
        dashCooldown = PlayerManager.instance.player.GetComponent<PlayerStats>().dashCooldown;
        rb = GetComponent<Rigidbody2D>();
        lastDashTime = -dashCooldown; // ������������� ����� ���������� ����� ���, ����� ����� ��� ������������ ��� ����� �� ����� ������ ����
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
        // ��������� ����� ������������� �����
        lastDashTime = Time.time;

        // ���������� ����������� �����
        Vector2 dashDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        
        // ��������� �����
        rb.AddForce(dashDirection * 7, ForceMode2D.Impulse);
        
    }
}
