using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shooting : MonoBehaviour
{
    public Explosions explosions;

    public Transform maincamera;

    public Transform Player;

    public GameObject missileprefab;
    public GameObject homingmissileprefab;

    public Transform shootpoint;

    public bool currentlyhoming = false;
    public bool MagDumping = false;

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

        if (Input.GetMouseButtonDown(0) && !currentlyhoming && !MagDumping)
        {
            Instantiate(missileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        else if(Input.GetMouseButtonDown(0) && currentlyhoming && !MagDumping)
        {
            Instantiate(homingmissileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        else if (Input.GetMouseButton(0) && !currentlyhoming && MagDumping)
        {
            Instantiate(missileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        else if (Input.GetMouseButton(0) && currentlyhoming && MagDumping)
        {
            Instantiate(homingmissileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            currentlyhoming = true;
        }
        if (Input.GetKeyUp(KeyCode.C))
        {
            currentlyhoming = false;
        }
        if (Input.GetKeyDown(KeyCode.E) && !MagDumping)
        {
            StartCoroutine(MagDump());
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene currentscenescene = SceneManager.GetActiveScene();
            string currentscene = currentscenescene.ToString();
            SceneManager.LoadScene(currentscene);
        }
    }

    void Fire(bool homing)
    {

    }

    IEnumerator MagDump()
    {
        MagDumping = true;
        yield return new WaitForSeconds(4f);
        MagDumping = false;
    }
}
