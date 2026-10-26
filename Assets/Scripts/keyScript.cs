using UnityEngine;

public class KeyScript : MonoBehaviour
{
    [SerializeField] AudioClip collectSound; 
    [SerializeField] float volume = 1f; 
    [SerializeField] GameObject collectEffect;
    public GameObject player;
    private PlayerInventory playerInventory;
    public bool IsLeftKey;
    
 
    void Start() 
    { 
        playerInventory = player.GetComponent<PlayerInventory>();
    } 
 
    void OnTriggerEnter(Collider other) 
    { 
        if (!other.CompareTag("Player")) return; 

        if (IsLeftKey)
        {
            playerInventory.LeftKey = true;
        } else
        {
            playerInventory.RightKey = true;
        }
        
        if (collectSound != null) 
        { 
            AudioSource.PlayClipAtPoint(collectSound, transform.position, volume); 
        } 
 
        // instantiate the prefab collect effect 
        if (collectEffect != null) 
        { 
            Instantiate(collectEffect, transform.position, collectEffect.transform.rotation); 
        } 
    
        gameObject.SetActive(false); 
    } 
}
