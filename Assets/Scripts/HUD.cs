using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TextMeshProUGUI speed;
    public GameObject lander;
    private Rigidbody2D landerbody;

    // Start is called before the first frame update
    void Start()
    {
      speed.text = "";
      landerbody = lander.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
      speed.text = "Speed: " + landerbody.velocity.magnitude.ToString("F1");

    }
}
