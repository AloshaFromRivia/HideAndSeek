using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public PlayersAction action;
    private Rigidbody2D rig;
    public bool facingRight = false;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        FacingCheck();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A) | Input.GetKey(KeyCode.D) | Input.GetKey(KeyCode.W) | Input.GetKey(KeyCode.S))
        {
            action = PlayersAction.Walk;
            float xAxis = Input.GetAxis("Horizontal");
            float yAxis = Input.GetAxis("Vertical");

            rig.velocity = new Vector2(xAxis * speed * Time.deltaTime, yAxis * speed * Time.deltaTime);
        }
        else
        {
            rig.velocity = Vector2.zero;
            action = PlayersAction.Stand;
        }
    }

    private void FacingCheck()
    {
        Vector2 scaleChange = new Vector2(-1, 1);
        if (rig.velocity.x > 0 & facingRight == false)
        {
            transform.localScale *= scaleChange;
            facingRight = true;
        }
        else if (rig.velocity.x < 0 & facingRight == true)
        {
            transform.localScale *= scaleChange;
            facingRight = false;
        }
    }
}