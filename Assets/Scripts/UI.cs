using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
  
 
    public Slider angleSlider; 
    public Slider forceSlider; 
    public Slider horizontalSlider; 
    public Slider verticalSlider; 
    public Button shootButton; 

    private Projectile projectileLauncher;

    private void Start()
    {
        projectileLauncher = FindObjectOfType<Projectile>();

        
        angleSlider.onValueChanged.AddListener(delegate { UpdateLaunchParameters(); });
        forceSlider.onValueChanged.AddListener(delegate { UpdateLaunchParameters(); });
        horizontalSlider.onValueChanged.AddListener(delegate { UpdateLaunchParameters(); });
        verticalSlider.onValueChanged.AddListener(delegate { UpdateLaunchParameters(); });

        
        shootButton.onClick.AddListener(Shoot);
    }

    public void UpdateLaunchParameters()
    {
        float angle = angleSlider.value; 
        float force = forceSlider.value; 
        float horizontal = horizontalSlider.value; 
        float vertical = verticalSlider.value; 

        projectileLauncher.SetLaunchParameters(angle, force, horizontal, vertical);
    }

    public void Shoot()
    {
        projectileLauncher.Shoot(); 
    }
}







