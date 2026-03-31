using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float turnSpeed = 150f;

    // Animator'ü (beyni) kontrol etmek için bir değişken oluşturuyoruz
    private Animator anim;

    void Start()
    {
        // Oyun başlarken karakterin üzerindeki Animator'ü bulup içine kaydediyor
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        // Klavyeden W, A, S, D tuşlarını dinle
        float vertical = Input.GetAxis("Vertical");   
        float horizontal = Input.GetAxis("Horizontal"); 

        // Fiziksel hareket komutları
        transform.Translate(Vector3.forward * vertical * walkSpeed * Time.deltaTime);
        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.deltaTime);

        // SİHİRLİ KISIM: Yürüme animasyonunu tetikleme
        // Eğer W, A, S, D tuşlarından herhangi birine basıyorsak (değer 0 değilse)
        if (vertical != 0 || horizontal != 0)
        {
            // isWalking şalterini AÇ (Yürüme animasyonu başlar)
            anim.SetBool("isWalking", true);
        }
        else
        {
            // Hiçbir tuşa basmıyorsak şalteri KAPAT (Nefes alma animasyonuna döner)
            anim.SetBool("isWalking", false);
        }
    }
}