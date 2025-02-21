using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AiSight : MonoBehaviour
{
    public AiAgent agent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay(Collider other)
    {
        // 1st Check: Are you in my Trigger Box?
        if (other.tag == "Hostile")
        {
            // 2nd Check: Is there no obstruction in my sight?
            RaycastHit hit;
            if (Physics.Linecast(eyes.position, other.transform.position, out hit))
            {
                // Something obstructed the view!
                Debug.DrawLine(eyes.position, hit.point, Color.red, 3f);
                agent
            }
            else
            {
                // No obstruction, Hostile found!
                agent.HostileSpotted(other.transform);
            }
        }

    }
}
