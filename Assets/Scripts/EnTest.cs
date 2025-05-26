 
using UnityEngine;

public class EnTest : MonoBehaviour
{

    private Rigidbody rbEn;
    private Transform trEnm;
    [Range(3,8), SerializeField]
    public float timer = 5f;


    private Quaternion targetRotation;
    [Range(15, 45),SerializeField]
    private float minAngle = 30f;
    [Range(60, 120), SerializeField]
    private float maxAngle = 120f;

    private void Awake()
    {
        rbEn = GetComponent<Rigidbody>();
        trEnm = GetComponent<Transform>();
    }
    void Start()
    {
        SetRandomRotate();
    } 
    void FixedUpdate()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SetRandomRotate();
            timer = Random.Range(3f, 7f);
        }

        Rotation();
    }

    private void Rotation()
    {
        Quaternion newRot = Quaternion.Slerp(trEnm.rotation, targetRotation, 2 * Time.fixedDeltaTime);
        rbEn.MoveRotation(newRot);
    }


    void SetRandomRotate()
    { 
        float currentY = trEnm.eulerAngles.y;
         
        float turnAmount = Random.Range(minAngle, maxAngle);  
        if (Random.value > 0.5f)  
        {
            turnAmount *= -1;
        } 
        float newY = currentY + turnAmount; 
        targetRotation = Quaternion.Euler(0, newY, 0);  
    }
}
