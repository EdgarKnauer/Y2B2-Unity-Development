using UnityEngine;
using System.Collections.Generic;

public class Car : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed = 1.0f;
    public List<GameObject> objects;
    public AudioClip[] soundEffectList;

    private GameObject currentObject;
    private AudioSource audioSource;
    private Transform player;

    public BoxCollider areaCollider;

    void Start()
    {
        currentObject = objects[Random.Range(0, objects.Count)];
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.playOnAwake = false;
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        currentObject.transform.position = Vector3.MoveTowards(currentObject.transform.position, pointB.position, step);

        float distance = Vector3.Distance(currentObject.transform.position, player.position);
        audioSource.volume = 1 - (distance / 30);
        if (areaCollider.bounds.Contains(player.position))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.clip = soundEffectList[Random.Range(0, soundEffectList.Length)];
                audioSource.Play();
            }
        }
        else if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        if (currentObject.transform.position == pointB.position)
        {
            currentObject.transform.position = pointA.position;
            currentObject = objects[Random.Range(0, objects.Count)];
            audioSource.clip = soundEffectList[Random.Range(0, soundEffectList.Length)];
        }
    }
}
