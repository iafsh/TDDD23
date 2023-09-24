using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Animator animator;
    private float cooldownTimer = Mathf.Infinity;
    [SerializeField] public float attackCooldown;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J) && cooldownTimer > attackCooldown) {
            startAttack();
        }
        cooldownTimer += Time.deltaTime;
    }
    private void startAttack()
    {
        animator.SetTrigger("attack");
        cooldownTimer = 0;
    }

}
