using UnityEditorInternal;
using UnityEngine;

public class MittensAnimation : MonoBehaviour
{
    public Animator animator;
    public RuntimeAnimatorController idleController;
    public RuntimeAnimatorController attackController;
    public float attackAnimTimer;
    float attackAnimTimerReal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        PlayAnimation("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackAnimTimerReal > 0)
        {
            attackAnimTimerReal -= Time.deltaTime;
            if (attackAnimTimerReal <= 0)
            {
                PlayAnimation("Idle");
            }
        }
    }

    public void PlayAnimation(string animation)
    {
        switch (animation)
        {
            case "Idle":
                animator.speed = 0.5f;
                animator.runtimeAnimatorController = idleController;
                animator.Play(idleController.animationClips[0].name);
                break;

            case "Attack":
                animator.speed = 1;
                animator.runtimeAnimatorController = attackController;
                animator.Play(attackController.animationClips[0].name);
                attackAnimTimerReal = attackAnimTimer;
            break;
        }
    }
}
