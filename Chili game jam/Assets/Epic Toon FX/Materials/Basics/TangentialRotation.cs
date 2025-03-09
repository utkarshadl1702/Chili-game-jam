
using UnityEngine;

public class DynamicParticleSpawner : MonoBehaviour
{
    public ParticleSystem particleSystem; // Assign in Inspector
    public Transform circleTransform; // The 2D circle sprite's Transform
    public float spawnRate = 10f; // Adjust as needed

    private float nextSpawn = 0f;

    void Update()
    {
        if (Time.time > nextSpawn)
        {
            SpawnParticle();
            nextSpawn = Time.time + 1f / spawnRate;
        }
    }

    void SpawnParticle()
    {
        // Instantiate a particle at the circle's position or slightly offset as needed
        Vector3 spawnPosition = circleTransform.position;

        // Calculate direction from the circle's center to the particle's position
        // For simplicity, let's assume particles spawn on the circle's edge
        float angle = Random.Range(0f, 360f); // Random angle around the circle
        Vector3 direction = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad), 0);

        // Calculate the rotation needed to face away from the center
        Quaternion rotation = Quaternion.LookRotation(-direction, Vector3.forward);

        // Spawn the particle with the calculated rotation
        // Since we can't directly control particle rotation through the ParticleSystem,
        // we'll instantiate a GameObject to represent our particle
        GameObject particle = new GameObject("Star");
        particle.transform.position = spawnPosition + direction * 0.5f; // Adjust the radius as needed
        particle.transform.rotation = rotation;

        // Optionally, add a SpriteRenderer or any visual representation to the particle GameObject
        SpriteRenderer spriteRenderer = particle.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("YourStarSprite"); // Assign your star sprite here

        // Destroy the particle after a certain time or based on your game's logic
        Destroy(particle, 2f); // Example: destroy after 2 seconds
    }
}