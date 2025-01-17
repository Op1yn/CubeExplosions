using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Cube : MonoBehaviour
{
    [field: SerializeField] public float ChanceSeparation { get; private set; }
    [field: SerializeField] public int ReductionRatio { get; private set; }

    public Rigidbody Rigidbody => GetComponent<Rigidbody>();

    public void Initialization(float chanceAncestorSeparation, Vector3 sizeFaces)
    {
        transform.localScale = sizeFaces / ReductionRatio;
        ChanceSeparation = chanceAncestorSeparation / ReductionRatio;
    }

    public bool GetSplitPossibility()
    {
        float minimumNumber = 0;
        float maximumNumber = 100;
        float randomChance = Random.Range(minimumNumber, maximumNumber + 1);

        return randomChance <= ChanceSeparation;
    }
}
