using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform maincamera;

    public Transform Player;

    public GameObject missileprefab;

    public Transform shootpoint;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pointrot = new Vector3(maincamera.eulerAngles.x, Player.eulerAngles.y, 0f);
        shootpoint.rotation = Quaternion.Euler(pointrot);

        if (Input.GetMouseButton(0))
        {
            Instantiate(missileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
    }
}
