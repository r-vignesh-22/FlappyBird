using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerScript : MonoBehaviour
{
    Bird bird;//generated script form unity(InputAction)
    Rigidbody2D rigid;
    [SerializeField] private float jumpForce;

    public bool canJump ;   
        
    void Awake()
    {       
        
        rigid = GetComponent<Rigidbody2D>();
        canJump = true;

        //prevent from rotating 
        rigid.freezeRotation = true;
               
    }
    void OnEnable(){
        
        bird = new Bird();
        bird.Enable();

        bird.Player.Fly.performed += OnFly;
    }    
    void OnDisable()
    {
        if (bird != null)
        {
            bird.Player.Fly.performed -= OnFly;
            bird.Disable();
        }
    }
    
    
    
    void OnFly(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && canJump)
        {
            rigid.linearVelocity = Vector2.up * jumpForce;
        }
        
    }
}
