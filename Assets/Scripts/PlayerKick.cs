using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
   public Animator animator;         
    public float kickCooldown = 1f; 
    public float kickForce = 10f;      
    public float kickRange = 2f;        
    public Transform kickOrigin;  

    private float nextKickTime = 0f;

    void Update()
    {
        if (Time.time >= nextKickTime && Input.GetKeyDown(KeyCode.Space))
        {
            // Picks random kick (0, 1, or 2)
            int randomKick = Random.Range(0, 3);

            // Parameters
            animator.SetInteger("KickID", randomKick);
            animator.SetBool("Kick", true);

            // Reset Kick bool after triggering
            StartCoroutine(ResetKick());

            nextKickTime = Time.time + kickCooldown;
            TryKickObject(); 
        }
    }

    IEnumerator ResetKick()
    {
        yield return new WaitForSeconds(0.1f);
        animator.SetBool("Kick", false);
    }
    void TryKickObject()
    {
        RaycastHit hit;

        if (Physics.Raycast(kickOrigin.position, transform.forward, out hit, kickRange))
        {
            if (hit.rigidbody != null && hit.collider.gameObject.CompareTag("Kickable"))
            {
                Vector3 direction = (hit.transform.position - transform.position).normalized;
                direction.y = 0; 
                hit.rigidbody.AddForce(direction * kickForce, ForceMode.Impulse);
                Debug.Log("Kicked object: " + hit.collider.name);
            }
        }
}
}
