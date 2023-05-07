using DG.Tweening;

using UnityEngine;

public class HelicopMove : MonoBehaviour
{
    [SerializeField] private Rigidbody rg3d;
    [SerializeField] private float speed = 6f;
    [SerializeField] private float fly = 6f;
    [SerializeField] private float lucXoay = 10f;
    [SerializeField] private float timeXoay = 1.5f;

    private float _horizontal;
    private float _vertical;
    private float _targetRotationY;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveX();
        MoveZ();
        RolateLeft();
        RolateRight();
        Jump();
    }
    private void MoveX()
    {
        _horizontal = Input.GetAxisRaw("Horizontal");       
        rg3d.velocity = new Vector3(_horizontal * speed, rg3d.velocity.y, rg3d.velocity.z);                             
    }
    private void MoveZ()
    {
        _vertical = Input.GetAxisRaw("Vertical");        
        rg3d.velocity = new Vector3(rg3d.velocity.x, rg3d.velocity.y, _vertical * speed);
        //switch (_vertical)
        //{
        //    case > 0:
        //        rg3d.velocity = new Vector3(rg3d.velocity.x, rg3d.velocity.y, rg3d.velocity.z)+Vector3.left;
        //        break;
        //    case < 0:
        //        rg3d.velocity = new Vector3(rg3d.velocity.x, rg3d.velocity.y, rg3d.velocity.z) + Vector3.right;
        //        break;
        //}
    }
        private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rg3d.velocity = new Vector3(rg3d.velocity.x, fly, rg3d.velocity.z);
        }
    }

    public void RolateLeft()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _targetRotationY -= lucXoay;
            transform.DORotateQuaternion(Quaternion.Euler(0f, _targetRotationY, 0f), timeXoay).Play();
            
            Vector3 targetDirection = Quaternion.Euler(0f, _targetRotationY, 0f) * Vector3.forward;
            rg3d.velocity = targetDirection.normalized * speed;
            
        }
    }
    public void RolateRight()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            _targetRotationY += lucXoay;
            transform.DORotateQuaternion(Quaternion.Euler(0f, _targetRotationY, 0f), timeXoay).Play();

            Vector3 targetDirection = Quaternion.Euler(0f, _targetRotationY, 0f) * Vector3.forward;
            rg3d.velocity = targetDirection.normalized * speed;
        }

    }


}
