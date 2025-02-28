using System.Numerics;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource BGM;
    public AudioSource flap;
    public AudioSource death;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
                BGM.Play();
                }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) {
        myRigidBody.linearVelocity = UnityEngine.Vector2.up*flapStrength;
        flap.Play();
    }
        if (transform.position.y < -30){
            logic.gameOver();
            birdIsAlive = false;
            BGM.Stop();
        }
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
        death.Play();
        BGM.Stop();
    }
    
}
