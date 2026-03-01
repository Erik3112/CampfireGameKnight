using UnityEngine;

public class MoveRotate : MonoBehaviour
{
    // **Պտույտի կարգավորումներ**
    [Header("Rotation Settings")]
    // `rotationAxis`-ը որոշում է պտույտի ուղղությունը։ Սկզբնական արժեքը՝ "վերև" (Y-առանցք):
    public Vector3 rotationAxis = Vector3.up;

    public float rotationSpeed = 5;

    // **Շարժման կարգավորումներ**
    [Header("Movement Settings")]
    // `movementAxis`-ը որոշում է շարժման ուղղությունը։ Սկզբնական արժեքը՝ "վերև" (Y-առանցք):
    public Vector3 movementAxis = Vector3.up;
    public float movementSpeed = 5;
    public float Distance = 5;
    // Սահմանում է՝ արդյոք օբյեկտը շարժվում է հակառակ ուղղությամբ:
    private bool movingReverse = true;

    // Պահպանում է օբյեկտի սկզբնական դիրքը:
    private Vector3 startPos;

    // Գործարկվում է, երբ սկրիպտը մեկնարկում է:
    private void Start()
    {
        // Պահպանում է օբյեկտի սկզբնական դիրքը։
        startPos = transform.position;
    }

    // Գործարկվում է յուրաքանչյուր կադրի ժամանակ։
    void Update()
    {
        // Կառավարվում է օբյեկտի պտույտը։
        HandleRotation();
        // Ստուգվում է՝ արդյոք օբյեկտը հասել է շարժման սահմանին։
        CheckDistance();
        // Կառավարվում է օբյեկտի շարժումը։
        HandleMovement();
    }

    // Պտույտի ֆունկցիա:
    void HandleRotation()
    {
        // Պտույտ `rotationAxis`-ի շուրջ `rotationSpeed` արագությամբ:
        transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime); // TODO: Ստեղծել փոփոխական 50-ի համար
    }

    // Շարժման ֆունկցիա:
    void HandleMovement()
    {
        if (movingReverse)
        {
            // Շարժվում է հակառակ ուղղությամբ `movementAxis`-ի շուրջ `movementSpeed` արագությամբ:
            transform.Translate(movementAxis * -movementSpeed * Time.deltaTime); // TODO: Ստեղծել փոփոխական -2-ի համար
        }
        else
        {
            // Շարժվում է դեպի առաջ `movementAxis`-ի շուրջ `movementSpeed` արագությամբ:
            transform.Translate(movementAxis * movementSpeed * Time.deltaTime); // TODO: Ստեղծել փոփոխական 2-ի համար
        }
    }

    // Ստուգում է՝ ինչքան հեռու է օբյեկտը իր սկզբնական դիրքից։
    void CheckDistance()
    {
        // Հաշվում է հեռավորությունը սկզբնական դիրքից մինչև ներկայիս դիրքը։
        float currentDistance = Vector3.Distance(startPos, transform.position);

        // Եթե օբյեկտը հեռացել է չափազանց շատ, շարժման ուղղությունը փոխվում է։
        if (currentDistance >= Distance) // TODO: Ստեղծել փոփոխական 5-ի համար
        {
            // Փոխում է `movingReverse`-ի արժեքը (true-ից false կամ հակառակը):
            movingReverse = !movingReverse;

            // Թարմացնում է սկզբնական դիրքը ներկայիս դիրքով։
            startPos = transform.position;
        }
    }
}
