using UnityEngine;

public class Objects : MonoBehaviour
{
    public void DestroyObject()
    {
        
        Debug.Log("¡Objeto destruido!");
        Destroy(gameObject);
    }
}
