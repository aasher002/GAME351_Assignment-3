using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    public Animator animator;
    public Animation anim;
    
    public void Die() {
        Debug.Log("bandit dead");
    }
}
