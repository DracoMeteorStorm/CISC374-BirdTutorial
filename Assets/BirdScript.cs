using System.Numerics;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float flapStrength;
    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
                logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) == true) {
        myRigidBody.linearVelocity = UnityEngine.Vector2.up*flapStrength;
    }}

    private void OEnter2D(Collision2D collision)
    {
        logic.gameOver();
    }
    
}
