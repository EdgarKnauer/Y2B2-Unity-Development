using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCheck : MonoBehaviour
{
    [SerializeField] GameObject pouringFlask;
    private bool isSnapped = false;
    private float RotationSpeed = 60f;
    private bool isRotating = true;
    public ColorChange colorChange;

    private void Start()
    {
        colorChange = GameObject.FindObjectOfType(typeof(ColorChange)) as ColorChange;
    }
    private void FixedUpdate()
    {
        if(isSnapped == true)
        {

            transform.position = pouringFlask.transform.position + new Vector3(0f, 0.3f, 0.1f);
            if(isRotating == true)
            {
                transform.Rotate(Vector3.left * (RotationSpeed * Time.deltaTime));
                Rotation();
            }
        }
    }

    private void Rotation()
    {
        StartCoroutine(RotatingCoroutine());
    }

    public IEnumerator RotatingCoroutine()
    {
        yield return new WaitForSeconds(2);
        isRotating = false;
        //pouringFlask.GetComponent<ColorChange>().Color();
        colorChange.Color();
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Flask_02")
        {
            isSnapped = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Flask_02")
        {
            isSnapped = false;
        }
    }
}
