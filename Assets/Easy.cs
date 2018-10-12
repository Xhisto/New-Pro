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
    public float leftwarp = -9.4f;
    public float upwarp = 5.5f;
    public float downwarp = -5.5f;
    public float rigthwarp = 9.4f;
    public float ColorR;
    public float ColorG;
    public float ColorB;
    public float PositionX;
    public float PositionY;
    public float TimerSec;
    public float TimerMin;
    public float TimerHours;

    // Use this for initialization
    void Start()
    {
        PositionX = Random.Range(-9.0f, 9.0f);
        PositionY = Random.Range(-4.5f, 4.5f);
        // ger mina random values till postioneerna X och Y, men Z måste alltid vara över Z annars overlappar min camera med mitt skepp.
        other.position = new Vector3(PositionX, PositionY, 0f);
        //vart skeppet kommer starta i början av spelet.
        Speed = Random.Range(10, 15);
        // min skepps hastighets random generator.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0f, 0f, (RotationSpeed / 2) * Time.deltaTime);
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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ColorR = Random.Range(0f, 1f);
            ColorG = Random.Range(0f, 1f);
            ColorB = Random.Range(0f, 1f);
            // ger röd, grön och blå random values för att randomize:a det resulterade färgen. 
            Rend.color = new Color(ColorR, ColorG, ColorB, 1f);
            // lägger till det resulterade färgen
        }

        transform.Translate(Speed * Time.deltaTime, 0, 0, Space.Self);
        // Transform.rotate är det som gör så att skeppet svänger vänster och höger. 
        // Och Transform.Translate är det som bestämmer hur snabbt eller långsam det är.
        // Rend.color visar vilken färg det byts till.
        // if koderna visar bara vad som händer om jag trycker på det valda keyboards knappen.
        // get key checkar förendringar på när knappen trycks ner och släpps up, medan getkeydown och getkeydown checkar bara de.

        Timer += Time.deltaTime;
        // koden för timer per sekunder istället för per frame
        TimerSec = (int)Timer % 60;
        TimerMin = (int)(Timer / 60) % 60;
        TimerHours = (int)(Timer / 3600) % 60;
        // Fixar Timer:ns Min visare och Tim visare så det blir 0 efter 60.
        print(string.Format("{0:0}:{1:00}:{2:00}", TimerHours, TimerMin, TimerSec));
        // printar timer i sekduner, minuter och i timmar.


        if (other.position.x < -9.4f)
        {
            transform.position = new Vector3(9.4f, other.position.y, other.position.z);
        }

        if (other.position.x > 9.4f)
        {
            transform.position = new Vector3(-9.4f, other.position.y, other.position.z);
        }

        if (other.position.y < -5.5)
        {
            transform.position = new Vector3(other.position.x, upwarp, other.position.z);
        }

        if (other.position.y > 5.5)
        {
            transform.position = new Vector3(other.position.x, downwarp, other.position.z);
        }
        // är koderna som gör så att om skeppet åker till ett särskilt punkt, kommer spawnas i ett annat punkt. alltså "warpar".


    }
}
