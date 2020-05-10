using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanderController : MonoBehaviour
{
    public float thrustPower;
    public float rotateSpeed;

    public Rigidbody2D rb;

    private bool thrusting;
    private float timeThrusting;
    private int rotateDir;

    public Animator animator;

    public GameObject explosion;
    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
      // Input
      float vertical = Input.GetAxis("Vertical");
      if (vertical > 0) {
        if (!thrusting) {
          thrusting = true;
          timeThrusting = 0f;
        }
        else timeThrusting += Time.deltaTime;
      }
      else thrusting = false;

      float horizontal = Input.GetAxis("Horizontal");
      if(horizontal > 0) rotateDir = -1;
      else if(horizontal < 0) rotateDir = 1;
      else rotateDir = 0;

      animator.SetBool("Thrusting", thrusting);

      if(Input.GetKey(KeyCode.Space)) {
        Instantiate(explosion, transform.position, Quaternion.identity);
      }
    }

    void FixedUpdate() {
      // Movement
      if(thrusting) {
        float power = (timeThrusting == 0f) ? 10 * thrustPower : thrustPower;
        rb.AddForce(power * transform.up);
      }
      rb.AddTorque(rotateSpeed * rotateDir);
    }

    void OnCollisionEnter2D(Collision2D collisionInfo) {
      // spawn dust on low impact and explosion on high impact
      float impactSpeed = collisionInfo.relativeVelocity.magnitude;
      Vector2 contact = collisionInfo.GetContact(0).point;
      GameObject anim = (impactSpeed > 5) ? explosion : dust;
      GameObject animObject = Instantiate(anim, new Vector3(contact.x, contact.y, 0f), Quaternion.identity);
      animObject.transform.parent = gameObject.transform;
      float scaleFactor = (anim == explosion) ? 0.2f : 1.2f;
      animObject.transform.localScale = scaleFactor * impactSpeed * animObject.transform.localScale;
    }
}
