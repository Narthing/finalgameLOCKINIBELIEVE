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
    public GameObject ShootGoldParticlePrefab;
    public GameObject BackfirePrefab;

    public Transform ParticlePoint;
    public Transform shootpoint;
    public Transform BackfirePoint;

    public bool currentlyhoming = false;
    public bool MagDumping = false;

    public Vector3 pointrot;
    public Vector3 shootparticlerot;
    public Vector3 goldparticlerot;

    public Transform RPG;
    public GameObject BigSparkleGold;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player").transform;
        BigSparkleGold.SetActive(false);
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
        if (Input.GetMouseButtonDown(1))
        {
            Backfire();
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

    void Backfire()
    {

        Instantiate(BackfirePrefab, new Vector3(BackfirePoint.position.x, BackfirePoint.position.y, BackfirePoint.position.z), Quaternion.identity);
    }
    void Fire(bool homing, bool magdumping) //helper method for instantiating missiles
    {
        shootparticlerot = new Vector3(ParticlePoint.eulerAngles.x, ParticlePoint.eulerAngles.y, 0f); //get rotation of particle point
        ParticlePoint.rotation = Quaternion.Euler(shootparticlerot); //put that onto the particle point
        if (!magdumping)
        {
            Instantiate(ShootParticlePrefab, new Vector3(ParticlePoint.position.x, ParticlePoint.position.y, ParticlePoint.position.z), Quaternion.Euler(pointrot), parent: ParticlePoint);
        }
        if (magdumping)
        {
            Instantiate(ShootGoldParticlePrefab, new Vector3(ParticlePoint.position.x, ParticlePoint.position.y, ParticlePoint.position.z), Quaternion.Euler(pointrot), parent: ParticlePoint);
        }
        
        if (!homing)
        {
            Instantiate(missileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        if (homing)
        {
            Instantiate(homingmissileprefab, new Vector3(shootpoint.position.x, shootpoint.position.y, shootpoint.position.z), Quaternion.Euler(pointrot));
        }
        
    }

    public SkinnedMeshRenderer rpgpart1;
    public SkinnedMeshRenderer rpgpart2;
    public SkinnedMeshRenderer rpgpart3;
    public Material Sheen;

    public Transform goldrpgspawnpoint;
    public GameObject goldrpgparticleprefab;

    

    IEnumerator MagDump()
    {
        Material ogtexture1 = rpgpart1.material; //get original textures for normal rpg
        Material ogtexture2 = rpgpart2.material;
        Material ogtexture3 = rpgpart3.material;

        MagDumping = true; 

        rpgpart1.material = Sheen; 
        rpgpart2.material = Sheen; //make rpg gold
        rpgpart3.material = Sheen;

        BigSparkleGold.SetActive(true);
        Instantiate(goldrpgparticleprefab, new Vector3(goldrpgspawnpoint.position.x, goldrpgspawnpoint.position.y, goldrpgspawnpoint.position.z), Quaternion.Euler(RPG.rotation.x, RPG.rotation.y, RPG.rotation.z), parent: RPG); //spawn in the particle
        yield return new WaitForSeconds(4f);

        BigSparkleGold.SetActive(false);
        rpgpart1.material = ogtexture1;
        rpgpart2.material = ogtexture2;
        rpgpart3.material = ogtexture3;
        MagDumping = false;
    }
}
