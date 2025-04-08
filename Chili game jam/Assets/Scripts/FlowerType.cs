using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerType : MonoBehaviour
{
    public enum FlowerTypeEnum
    {
        White, Yellow, Purple, Blue, Leaf
    }

    public FlowerTypeEnum flowerType;

    private void Start()
    {
        GameManager.instance.flowerData[flowerType] = 0;
    }

    //look at camera
    private void Update()
    {
        // Rotate the flower to face the camera only along the y-axis
        Vector3 direction = Camera.main.transform.position - transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);

        // Keep the current x and z rotation, only change the y rotation
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    //Onclick remove the flower and update the gamemanager
    private void OnMouseDown()
    {
        // Remove the flower from the scene
        Destroy(gameObject);

        // Update the GameManager
        GameManager.instance.flowerData[flowerType]++;
        print("Flower collected: " + flowerType);
        print("Total " + flowerType + ": " + GameManager.instance.flowerData[flowerType]);

    }
}
