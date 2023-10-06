using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] Vector2 screenBoundaries;
    [SerializeField] float rotationFactor;
    [SerializeField] float rotationSpeed;
    [SerializeField] List<ParticleSystem> bullets;


    float horizontalValue, verticalValue;

    void Update()
    {
        Movement();
        Rotation();
        Fire();
    }

    void Rotation()
    {
        float xRot = -verticalValue * rotationFactor;
        float yRot = horizontalValue * rotationFactor;
        float zRot = -horizontalValue * rotationFactor;
        Quaternion targetRot = Quaternion.Euler(xRot, yRot, zRot);

        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRot, rotationSpeed);
    }


    void Movement()
    {
        horizontalValue = Input.GetAxis("Horizontal");

        verticalValue = Input.GetAxis("Vertical");

        float xPos = Mathf.Clamp(transform.localPosition.x + horizontalValue * moveSpeed * Time.deltaTime,
            -screenBoundaries.x, screenBoundaries.x);

        float yPos = Mathf.Clamp(transform.localPosition.y + verticalValue * moveSpeed * Time.deltaTime, -screenBoundaries.y, screenBoundaries.y);



        transform.localPosition = new Vector3(xPos, yPos, transform.localPosition.z);
    }


    void Fire()
    {
        if (Input.GetButton("Fire1"))
        {

            ActivateBullets(true);
        }
        else
        {

            ActivateBullets(false);
        }
    }


    void ActivateBullets(bool active)
    {
        foreach (ParticleSystem bullet in bullets)
        {
            var emission = bullet.emission;
            emission.enabled = active;
        }
    }
}
