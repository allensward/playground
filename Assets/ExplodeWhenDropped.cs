using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeWhenDropped : MonoBehaviour
{
    private Rigidbody cube;
    private ParticleSystem ps;
    private bool hasSploded = false;

    // Start is called before the first frame update
    void Start()
    {
        cube = GetComponent<Rigidbody>();
        ps = cube.GetComponent<ParticleSystem>();
        if (ps)
        {
            ps.Stop(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (cube.position.y < 0 && ps && ps.isStopped && hasSploded == false)
        {
            ps.Play();
            hasSploded = true;
            cube.GetComponent<Renderer>().enabled = false;
        }
    }
}
