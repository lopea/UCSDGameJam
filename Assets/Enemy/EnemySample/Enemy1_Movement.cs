
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1_Movement : MonoBehaviour
{
    Rigidbody rigbody;
    [SerializeField] private string Target = "_EnemyTarget";
    [SerializeField] float MovementSpeed = 10.0f;
    [SerializeField] float FieldOfView = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        rigbody = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        float __ZAxis = Input.GetAxis("Vertical");
        float __XAxis = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.forward * __ZAxis * MovementSpeed);
        transform.Translate(Vector3.right * __XAxis * MovementSpeed);

        AimAtTarget();
    }

    void AimAtTarget()
    {
        transform.LookAt(GlobalVariableStorage.EnemyTargetThePlayer);
        //Debug.Log("this is getting called");
        //RaycastHit[] EnemyAim;
        //EnemyAim = Physics.RaycastAll(transform.position, transform.forward, FieldOfView);
        //foreach(RaycastHit target in EnemyAim)
        //{
        //    Debug.DrawRay(transform.position, transform.forward * FieldOfView, Color.red);
        //    if(target.collider.tag == "_EnemyTarget")
        //    {
        //        transform.LookAt(target.transform);
        //    }
        //}
        //Debug.DrawRay(transform.position, transform.forward * FieldOfView, Color.red);
        //GameObject currentTarget = GameObject.FindGameObjectWithTag("_EnemyTarget");
        //transform.LookAt(currentTarget.transform);
        //if(Physics.RaycastAll(transform.position, transform.forward, out EnemyAim, FieldOfView))
        //{
        //
        //    Debug.Log(EnemyAim.collider.gameObject.tag);
        //}


    }
}
