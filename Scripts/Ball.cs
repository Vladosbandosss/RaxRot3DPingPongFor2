using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 InitialImpulse;

    private Vector3 initialPosition;

    [SerializeField]  private float impulseForce = 20f;

    public Text Player1Scoretext, Player2Scoretext;
    private int p1Score, p2Score;
    private void Awake()
    {
        initialPosition = transform.position;

        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {

        SetScore();

        if (Random.Range(0, 2) > 0)
        {
            impulseForce *= -1f;
        }

        InitialImpulse = new Vector3(impulseForce, 0f, impulseForce);

        StartCoroutine(nameof(BallStartMovement));
    }
    IEnumerator BallStartMovement()
    {
        yield return new WaitForSeconds(2f);
        rb.AddForce(InitialImpulse,ForceMode.Impulse);
        
    }

    void SetScore()
    {
        Player1Scoretext.text = "Player1: " + p1Score;
        Player2Scoretext.text = "Player2:" + p2Score;
    }

    void ResetMoveMent()
    {
        rb.velocity = Vector3.zero;
        transform.position = initialPosition;
        StartCoroutine(nameof(BallStartMovement));
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1Score")
        {
            p2Score++;
            SetScore();
            ResetMoveMent();
        }
        if (other.tag == "Player2Score")
        {
            p1Score++;
            SetScore();
            ResetMoveMent();
        }
    }
}
