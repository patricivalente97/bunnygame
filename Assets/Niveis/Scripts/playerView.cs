/////////////////////////////////////////////////////////////////////////////////////////////////////////////
///////////////////////////////////////////PlayerView.cs////////////////////////////////////////////////////
// Este ficheiro representa a "Vista" no padrão MVC.
// Trata apenas da apresentação visual do jogador — animações, orientação do sprite, etc.
// Não gere lógica nem interage com os inputs diretamente.
// O Controller comunica com esta classe para atualizar a forma como o jogador é apresentado.
/////////////////////////////////////////////////////////////////////////////////////////////////////////////

using UnityEngine;

public class PlayerView
{
    private Transform transform;
    private Animator animator;

    public PlayerView(Transform transform, Animator animator)
    {
        this.transform = transform;
        this.animator = animator;
    }

    public void UpdateView(float horizontalInput, bool grounded)
    {
        if (horizontalInput > 0.01f)
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);

        animator.SetBool("run", horizontalInput != 0);
        animator.SetBool("grounded", grounded);
    }

    public void TriggerJumpAnimation()
    {
        animator.SetTrigger("jump");
    }
}
