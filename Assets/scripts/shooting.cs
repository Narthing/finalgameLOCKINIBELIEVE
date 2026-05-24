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
    public GameObject EnemyPrefab;
    public GameObject ShootParticlePrefab;

    public Transform ParticlePoint;
    public Transform shootpoint;

    public bool currentlyhoming = false;
    public bool MagDumping = false;

    public Vector3 pointrot;
    public Vector3 shootparticlerot;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        pointrot = new Vector3(maincamera.eulerAngles.x, Player.eulerAngles.y, 0f);
        shootpoint.rotation = Quaternion.Euler(pointrot);

        if (Input.GetMouseButtonDown(0) && !currentlyhoming && !MagDumping)
        {
            Fire(false, false);
        }
        else if (Input.GetMouseButtonDown(0) && currentlyhoming && !MagDumping)
        {
            Fire(true, false);
        }
        else if (Input.GetMouseButton(0) && !currentlyhoming && MagDumping)
        {
            Fire(false, true);
        }
        else if (Input.GetMouseButton(0) && currentlyhoming && MagDumping)
        {
            Fire(true, true);
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
        if (Input.GetKeyDown(KeyCode.G))
        {
            Instantiate(EnemyPrefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        if (Input.GetKeyDown(KeyCode.R)) //reset scene
        {
            Scene currentscenescene = SceneManager.GetActiveScene();
            string currentscene = currentscenescene.ToString();
            SceneManager.LoadScene(currentscene);
        }
    }

    void Fire(bool homing, bool magdumping) //helper method for instantiating missiles
    {
        shootparticlerot = new Vector3(ParticlePoint.eulerAngles.x, ParticlePoint.eulerAngles.y, 0f); //get rotation of particle point
        ParticlePoint.rotation = Quaternion.Euler(shootparticlerot); //put that onto the particle point
        Instantiate(ShootParticlePrefab, new Vector3(ParticlePoint.position.x, ParticlePoint.position.y, ParticlePoint.position.z), Quaternion.Euler(pointrot), parent: ParticlePoint);
        if (!homing)
        {
            Instantiate(missileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        if (homing)
        {
            Instantiate(homingmissileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        
    }

    IEnumerator MagDump()
    {
        MagDumping = true;
        yield return new WaitForSeconds(4f);
        MagDumping = false;
    }
}
