/////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////PlayerController.cs///////////////////////////////////////////////
// Este ficheiro representa o "Controller" no padrão MVC.
// É o único módulo que herda de MonoBehaviour e, por isso, é anexado ao GameObject no Unity.
// A sua função é :
// ----Captar os inputs do jogador (como teclas premidas)
// ----Detetar colisões e fazer a ligação entre o Modelo (movimento e salto)
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    private PlayerModel model;
    private PlayerView view;

    private Rigidbody2D body;
    private Animator animator;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        model = new PlayerModel(speed, body);
        view = new PlayerView(transform, animator);
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        model.Move(horizontalInput);

        if (Input.GetKeyDown(KeyCode.Space) && model.Grounded)
        {
            model.Jump();
            view.TriggerJumpAnimation();
        }

        view.UpdateView(horizontalInput, model.Grounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            model.Grounded = true;
        }
    }
}
