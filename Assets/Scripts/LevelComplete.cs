using UnityEngine;

public class LevelComplete : MonoBehaviour
{
    
    [SerializeField] GameObject levelCompletePanel; 
    [Header("Celebration")] 
    [Tooltip("Confetti prefab spawned in front of the camera when the level is cleared.")] 
    [SerializeField] GameObject confettiEffect; 
    [Tooltip("How far in front of the camera the confetti appears. Keep it further than the Level Complete canvas Plane Distance, and closer than the player.")] 
    [SerializeField] float confettiDistance = 1.2f; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


void OnTriggerEnter(Collider other) 
    { 
        if (!other.CompareTag("Player")) return; 
 
        if (levelCompletePanel != null) 
        { 
            levelCompletePanel.SetActive(true); 
        } 
    

        // celebrate: the confetti uses unscaled time, so it keeps playing while the game is paused 
        SpawnConfetti(); 

        // pause the game so the robot stops moving behind the panel 
        Time.timeScale = 0f; 
 
        // the third person controller locks the cursor, so free it to click the button 
        StarterAssets.StarterAssetsInputs input = FindFirstObjectByType<StarterAssets.StarterAssetsInputs>(); 
        if (input != null) 
        { 
            input.cursorLocked = false; 
            input.cursorInputForLook = false; 
        } 
        Cursor.lockState = CursorLockMode.None; 
        Cursor.visible = true; 
    }
    // Update is called once per frame
    void SpawnConfetti() 
    { 
        if (confettiEffect == null) return; 
    
        // use the same camera the Level Complete canvas is drawn by, so the confetti lines up with it 
        Camera cam = Camera.main; 
        Canvas canvas = levelCompletePanel != null ? levelCompletePanel.GetComponentInParent<Canvas>() : null; 
        if (canvas != null && canvas.worldCamera != null) cam = canvas.worldCamera; 
        if (cam == null) return; 
    
        // half the height of the screen at that distance, so we can find the bottom edge 
        float halfHeight = confettiDistance * Mathf.Tan(cam.fieldOfView * 0.5f * Mathf.Deg2Rad); 
        Vector3 position = cam.transform.position 
                        + cam.transform.forward * confettiDistance 
                        - cam.transform.up * halfHeight; 
    
        // a particle system fires along its local Z axis, so tip it to point up the screen 
        Quaternion rotation = cam.transform.rotation * Quaternion.Euler(-90f, 0f, 0f); 
    
        Instantiate(confettiEffect, position, rotation); 
    } 
}
