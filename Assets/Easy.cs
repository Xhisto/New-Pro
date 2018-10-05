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
    public float leftwarp = -7.5f;
    public float rigthwarp = 7.5f;
    public float disapear = 1f;
    readonly object AtomBomb;

    // Use this for initialization
    void Start()
    {
        other.position = new Vector3(0, 0, 0);

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

        Debug.Log(string.Format("Time (i sekunder och decimaler.... FOR NOW ):{0}", +Timer));


        if (other.position.x < -7.5f)
        {
            transform.position = new Vector3(rigthwarp, other.position.y, other.position.z);
        }

        if (other.position.x > 7.5f)
        {
            transform.position = new Vector3(leftwarp, other.position.y, other.position.z);
        }
        

    }
}
