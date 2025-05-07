using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : BaseController
{
    private Camera camera;
    private Rigidbody2D rb;
    public float jumpForce = 5f; // ���� �� ���� ����

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertial = Input.GetAxisRaw("Vertical");        
        movementDirection = new Vector2(horizontal, vertial).normalized;

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < .9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
        //  ���� ��� �߰� �κ�
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump( ); // �����̽��� ������ ����
        }
    }
    private void Jump()
    {
        if (rb != null)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f); // ���� �ӵ� �ʱ�ȭ
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); // ���� �� ����
        }
    }
}
