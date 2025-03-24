/////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////PlayerModel.cs////////////////////////////////////////////////////
// Este ficheiro representa o "Modelo" no padrão MVC.
// É responsável por conter a lógica do movimento e do salto,
// ou seja, o comportamento do jogador, independentemente de como é controlado ou apresentado.
// Não herda de MonoBehaviour nem interage diretamente com o Unity,
// sendo utilizado pelo Controller para aplicar a lógica de jogo.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerModel
{
    private float speed;
    private Rigidbody2D body;

    public bool Grounded { get; set; }

    public PlayerModel(float speed, Rigidbody2D body)
    {
        this.speed = speed;
        this.body = body;
    }

    public void Move(float horizontalInput)
    {
        body.linearVelocity = new Vector2(horizontalInput * speed, body.linearVelocity.y);
    }

    public void Jump()
    {
        if (Grounded)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            Grounded = false;
        }
    }
}
