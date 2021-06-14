using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{
    public float fullHealth;
    //public GameObject deathFX;
    //public AudioClip playerHurt;

    //public restartGame theGameManager;

    float curruntHealth;

    playerContoller contrlMovement;

    //AudioSource playerAS;
    //public AudioClip playerDeathSound;

    //HUD Variables
    public Slider healthSlider;
    public Image damageScreen;
    public Text gameOverScreen;

    bool damaged = false;

    Color damagedColour = new Color(0f, 0f, 0f, 0.5f);
    float smoothColour = 5f;

    // Start is called before the first frame update
    void Start()
    {
        curruntHealth = fullHealth;

        //get access to player controller
        contrlMovement = GetComponent<playerContoller>();

        //HUD Initialization
        healthSlider.maxValue = fullHealth;
        healthSlider.value = fullHealth;

        damaged = false;

        //playerAS.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (damaged)
        {
            damageScreen.color = damagedColour;
        }
        else
        {
            //change damageScreen color smoothly to 0
            damageScreen.color = Color.Lerp(damageScreen.color, Color.clear, smoothColour * Time.deltaTime);
        }
        damaged = false;
    }

    public void addDamage(float damage)
    {
        //if it does 0 damage
        if (damage <= 0) return; 
        curruntHealth -= damage; //if it does damage

         //playerAS.clip = playerHurt;
         //playerAS.Play();
         //playerAS.PlayOneShot(playerHurt);

        healthSlider.value = curruntHealth;//adjust the slider
        damaged = true;


        if (curruntHealth <= 0)
        {
            makeDead();
        }
    }

    public void addHealth(float healthAmount)
    {
        curruntHealth += healthAmount;
        if(curruntHealth > fullHealth)   curruntHealth = fullHealth; 
        healthSlider.value = curruntHealth;
        
    }

    public void makeDead()
    {
        //Instantiate(deathFX, transform.position, transform.rotation);
        Destroy(gameObject);

        //AudioSource.PlayClipAtPoint(playerDeathSound, transform.position);

        damageScreen.color = damagedColour;

        Animator gameOverAnimator = gameOverScreen.GetComponent<Animator>();
        gameOverAnimator.SetTrigger("gameOver");

        Debug.Log("Game Restart");
        //theGameManager.restartTheGame(); 
    }
}
