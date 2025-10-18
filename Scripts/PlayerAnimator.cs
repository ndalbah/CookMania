using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private const string IS_WALKING = "IsWalking";

    [SerializeField] private Player player;

    private Animator animator;

    private void Awake()
    {
        // get reference to animator component
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        // modify parameter for idle vs. walk
        animator.SetBool(IS_WALKING, player.IsWalking());
    }
}
