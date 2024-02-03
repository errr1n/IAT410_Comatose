using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// bring in cinemachine
using Cinemachine;
using StarterAssets;

public class ThirdPersonShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera; 
    [SerializeField] private float normalSensitivity; 
    [SerializeField] private float aimSensitivity; 
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask(); 
    [SerializeField] private Transform debugTransform;
    [SerializeField] private Transform pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    //crosshair
    [SerializeField] private GameObject crosshair; // makes a serialized field for the image of the crosshair to be assigned to.

    // hit scan
    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    //teleporting
    [SerializeField] GameObject teleportLocation;

    //AOE
    private bool isImmobilized = false;
    [SerializeField] private GameObject poisonParticles;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake()
    {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
        crosshair.SetActive(false); // hides the crosshair to make sure it is hidden at the start.
    }

    private void Update()
    {
        Attack();

        Vector3 mouseWorldPosition = Vector3.zero;

        //get center point of the screen (crosshair center)
        Vector2 screenCenterPoint = new Vector2(Screen.width/2f, Screen.height/2f);
        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);

        // hit scan
        Transform hitTransform = null;

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, aimColliderLayerMask))
        {
            //moves debug sphere to raycast point
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        } 

        // youtube comments
        else {
            mouseWorldPosition = ray.GetPoint(10);
            debugTransform.position = ray.GetPoint(10);
        }

        // aim mode
        if(starterAssetsInputs.aim)
        {

            // NEW HERE
            // check if clicked e
            if (Input.GetKeyDown(KeyCode.E))
            {

                // place = new Vector3()

                //hit scan
                if(hitTransform != null)
                // if not null, we hit something
                {
                    if(hitTransform.GetComponent<TeleportTarget>() != null)
                    {
                    //hit target (can play particles from here)
                    // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
                    Debug.Log("teleport");
                    //teleporting
                    // gameObject.transform.position = teleportLocation.transform.position;
                    gameObject.transform.position = mouseWorldPosition;
                    // thirdPersonController.transform.position = teleportLocation.transform.position;
                    // Debug.Log("complete");
                    // StartCoroutine(Delay());
                    } 
                    // else{
                    // // hit something else (can play particles from here)
                    // // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
                    //  Debug.Log("no teleport");
                    // }
                }
            }

            //crosshair
            crosshair.SetActive(true);

            aimVirtualCamera.gameObject.SetActive(true);
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;

            // rotate the player towards crosshair
            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f);

            // ERIN - trying to make it so can only shoot in aim mode
            if(starterAssetsInputs.shoot)
            {



            //     if(hitTransform != null)
            // // if not null, we hit something
            // {
            //     if(hitTransform.GetComponent<TeleportTarget>() != null)
            //     {
            //         //hit target (can play particles from here)
            //         // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            //         Debug.Log("teleport");
            //     } else{
            //         // hit something else (can play particles from here)
            //         // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            //          Debug.Log("no teleport");
            //     }
            // }



                // to calculate aim direction, grab mouse position, calculate direction using spawn bullet position
                Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
                Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
                // not shooting constantly
                starterAssetsInputs.shoot = false;
            }

            // teleport
            // check if they pressed E
            //
            
            // // NEW HERE
            // // check if clicked e
            // if (Input.GetKeyDown(KeyCode.E))
            // {

            //     // place = new Vector3()

            //     //hit scan
            //     if(hitTransform != null)
            //     // if not null, we hit something
            //     {
            //         if(hitTransform.GetComponent<TeleportTarget>() != null)
            //         {
            //         //hit target (can play particles from here)
            //         // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            //         Debug.Log("teleport");
            //         //teleporting
            //         // gameObject.transform.position = teleportLocation.transform.position;
            //         gameObject.transform.position = mouseWorldPosition;
            //         // thirdPersonController.transform.position = teleportLocation.transform.position;
            //         // Debug.Log("complete");
            //         // StartCoroutine(Delay());
            //         } 
            //         // else{
            //         // // hit something else (can play particles from here)
            //         // // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            //         //  Debug.Log("no teleport");
            //         // }
            //     }
            // }


        }  else
        {
            //crosshair
            crosshair.SetActive(false);
            
            aimVirtualCamera.gameObject.SetActive(false);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }


        // if(starterAssetsInputs.shoot)
        // {


        //     // hit scan
        //     // if(hitTransform != null)
        //     // // if not null, we hit something
        //     // {
        //     //     if(hitTransform.GetComponent<BulletTarget>() != null)
        //     //     {
        //     //         //hit target (can play particles from here)
        //     //         // Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
        //     //         Debug.Log("green");
        //     //     } else{
        //     //         // hit something else (can play particles from here)
        //     //         // Instantiate(vfxHitRed, transform.position, Quaternion.identity);
        //     //          Debug.Log("red");
        //     //     }
        //     // }


        //     // to calculate aim direction, grab mouse position, calculate direction using spawn bullet position
        //     Vector3 aimDir = (mouseWorldPosition - spawnBulletPosition.position).normalized;
        //     Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDir, Vector3.up));
        //     // not shooting constantly
        //     starterAssetsInputs.shoot = false;
        // }

    }

    IEnumerator Delay()
    {
        yield return null;
    }


    // AOE ATTACK
    private void Attack()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            //once attack button is pressed
            Debug.Log("attack input");
            StartCoroutine(AttackSequence());
        }
    }

    private IEnumerator AttackSequence()
    {
        yield return new WaitForSeconds(0.25f);
        Debug.Log("coroutine");
        poisonParticles.SetActive(true);
        CheckForDestructables();
        // yield return new WaitForSeconds(1f);
        // poisonParticles.SetActive(false);
    }

    private void CheckForDestructables()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, 4f);
        foreach(Collider c in colliders)
        {
            if(c.GetComponent<AOETarget>())
            {
                c.GetComponent<AOETarget>().DealDamage();
            }
        }
    }
}
