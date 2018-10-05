using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : MonoBehaviour
{
    public float Speed;

    [Range(-720, 720)]
    public float RotationSpeed;
    public SpriteRenderer Rend;
    public Transform other;
    public float Timer;



    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, RotationSpeed * Time.deltaTime);
            Rend.color = new Color(0f, 0f, 200f);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0f, 0f, -RotationSpeed * Time.deltaTime);
            Rend.color = new Color(0f, 200f, 0f);

        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Speed / 2 * Time.deltaTime, 0, 0, Space.Self);
        }

        transform.Translate(Speed * Time.deltaTime, 0, 0, Space.Self);


        Timer += Time.deltaTime;

        Debug.Log(string.Format("[0]", +Timer));
    }
}
