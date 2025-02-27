using UnityEngine;
using UnityEngine.InputSystem.XR;

public class AiSight : MonoBehaviour
{
    public AiAgent agent;

    public Transform eyes;

    // Investigation
    public float investigationTime = 1.25f;
    public float investigationTimer = 0.0f;
    private bool investigate = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        investigationTimer = investigationTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (investigate)
        {
            investigationTimer -= Time.deltaTime;
        }
        else
        {
            agent.EndInvestigate();
            investigationTimer = investigationTime;
        }
    }

    public void FixedUpdate()
    {
        investigate = false;
    }

    public void OnTriggerStay(Collider other)
    {
        // 1st Check: Are you in my Trigger Box?
        if (other.tag == "Player")
        {
            // 2nd Check: Is there no obstruction in my sight?
            RaycastHit hit;
            if (Physics.Linecast(eyes.position, other.transform.position, out hit))
            {
                // Something obstructed the view! Is it the Player?
                Debug.DrawLine(eyes.position, hit.point, Color.blue, 3f);
                // Player Check:
                if (hit.transform.tag == "Player")
                {
                    investigate = true;
                    // Stop & Check Logic:
                    if (investigationTimer <= 0.0f)
                    {
                        Debug.DrawLine(eyes.position, other.transform.position, Color.red, 1f);
                        agent.PlayerSpotted(other.transform);
                    }
                    else
                    {
                        agent.StartInvestigate();
                    }
                }
            }
            else
            {
                // No obstruction, Hostile found!

            }
        }

    }
}
