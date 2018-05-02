using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(InputData))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private InputData ID;
    [SerializeField]
    private BoxAmount BA;

    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float jumpHeight;
    [SerializeField]
    private float sprintSpeed;

    [SerializeField]
    private GameObject Prefab;
    [SerializeField]
    private Vector3 ExtraSpace;

    [SerializeField]
    private Rigidbody2D Rb2D;

    [SerializeField]
    private Animator Anim;
    [SerializeField]
    private SpriteRenderer SR;
    [SerializeField]
    private float AnimationWait;

    [SerializeField]
    private bool Check = false;

    private bool Grounded;

    void Update()
    {
        CheckPressed();
        CheckForKeyDown();
    }

    void CheckPressed()
    {
        if (ID.Fo)
        {
            MoveLeft();
        }
        if (ID.Ba)
        {
            MoveRight();
        }
        if (ID.Ju)
        {
            Jump();
        }
        if (ID.Spf)
        {
            SprintForward();
        }
        if (ID.Spb)
        {
            SprintBackward();
        }
        if (ID.Bu)
        {
            SpawnBox();
        }
        if (ID.Es)
        {
            EscapeToMenu();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
        }
    }

    void EscapeToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void MoveLeft()
    {
        SR.flipX = false;
        Anim.SetTrigger("Walk");
        transform.Translate(walkSpeed, 0f, 0f);
        StartCoroutine(SetFalse());
    }

    void MoveRight()
    {
        SR.flipX = true;
        Anim.SetTrigger("Walk");
        transform.Translate(-walkSpeed, 0f, 0f);
        StartCoroutine(SetFalse());
    }

    void Jump()
    {
        if (ID.Spf || ID.Spb)
        {
            return;
        }
        else {
            if (Grounded)
            {
                Anim.SetTrigger("Jump");
                Rb2D.AddForce(new Vector2(0f, jumpHeight), ForceMode2D.Impulse);
                Debug.Log("Okay");
                Grounded = false;
            }
        }
        StartCoroutine(SetFalse());
    }

    void SprintForward()
    {
        SR.flipX = false;
        Anim.ResetTrigger("Walk");
        Anim.SetTrigger("Run");
        transform.Translate(sprintSpeed, 0f, 0f);
        StartCoroutine(SetFalse());
    }

    void SprintBackward()
    {
        SR.flipX = true;
        Anim.ResetTrigger("Walk");
        Anim.SetTrigger("Run");
        transform.Translate(-sprintSpeed, 0f, 0f);
        StartCoroutine(SetFalse());
    }

    void SpawnBox()
    {
        if (BA.BoxNr != 0)
        {
            if (SR.flipX)
            {
                Instantiate(Prefab, transform.position + -ExtraSpace, Quaternion.identity);
                BA.BoxNr = BA.BoxNr - 1;
            }
            else if (SR.flipX == false)
            {
                Instantiate(Prefab, transform.position + ExtraSpace, Quaternion.identity);
                BA.BoxNr = BA.BoxNr - 1;
            }
        }
        else
        {
            return;
        }
    }
    IEnumerator SetFalse()
    {
        if (Check == false)
        {
            Anim.ResetTrigger("Walk");
            Anim.ResetTrigger("Jump");
            Anim.ResetTrigger("Run");
            Anim.ResetTrigger("Dead");
            Anim.SetTrigger("Idle");
        }
        yield return null;
    }

    void CheckForKeyDown()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)
            || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)
            || Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.Space))
        {
            Check = true;
        }
        else
        {
            Check = false;
        }
    }
}
