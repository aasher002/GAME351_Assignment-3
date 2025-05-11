using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public Animator animator;
    
    public void Die() {
        int randKick = Random.Range(1, 3);
        
        animator.SetInteger("deathID", randKick);
        animator.SetBool("isDead", true);
    }
}
