using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{	
	public float speed;
	public Rigidbody rb;
    public Score currentScore;
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;
    public Transform Camera;
    public int boosts = 3;
    public int boostSpeed = 250;
    public float boostingTime;
    public float boostDuration = 300.0f;
    public bool boosting = false;

    public LayerMask groundLayers;
    public float jumpPower = 10;
    public SphereCollider col;

    void Start()
	{
		rb = gameObject.GetComponent<Rigidbody> ();
        currentHealth = maxHealth;
        //healthBar.SetMaxHealth(maxHealth);
        col = GetComponent<SphereCollider>();
    }
	
	void Update ()
	{
        if (Input.GetKeyDown(KeyCode.P))
        {
            Application.Quit();
        }
    
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        if (movement.magnitude >= 0.1f)
        {
            if (Input.GetKeyDown(KeyCode.E) && boosts > 0 && boosting == false)
            {
                SpeedBoost();
            }
            float angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg + Camera.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 move = Quaternion.Euler(0f, angle, 0f) * Vector3.forward;
            rb.AddForce(move.normalized * speed * Time.deltaTime);
        }

		
		//rb.AddForce (movement * speed * Time.deltaTime);

        
        //Jump contols
        if (grounded() && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
        }

        //Reset if the player falls off
        if (rb.position.y < -30)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    private bool grounded()
    {
        return (Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers));
        
    }
	
	void OnTriggerEnter(Collider other) 
	{
        if (other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            currentScore.score++;

        } else if (other.gameObject.tag == "DontPickUp") {
            other.gameObject.SetActive(false);
            currentHealth--;
            healthBar.SetHealth(currentHealth);
            if (currentHealth == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        } 

        else if (other.gameObject.tag == "Goal" && currentScore.score >= 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}

    void SpeedBoost() //Function to increase player speed temorarily
    {
        boosting = true;

        while (boostDuration > 0)
        {
            speed = speed * 2;
            boostDuration -= Time.deltaTime;
        }
        
        if (boostDuration <= 0)
        {
            boosting = false;
            speed = 500;
        }

       
        /*if (boostDuration > 0)
        {
            speed = speed*2;
            boostDuration -= Time.deltaTime;
        }
        else
        {
            boosting = false;
            speed = 500;
        }*/
    }
}
