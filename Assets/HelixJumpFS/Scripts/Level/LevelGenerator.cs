using UnityEngine;
public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform axis;
    [SerializeField] private Floor floorPrefab;

    [Header("Settings")]
    [SerializeField] private int defaultfloorAmount;
    [SerializeField] private float floorHeight;
    [SerializeField] private int amountEmptySegment;
    [SerializeField] private int minTrapSegment;
    [SerializeField] private int maxTrapSegment;      

    private float floorAmount = 0;
    public float FloorAmount => floorAmount;
    private float lastFoorY = 0;
    public float LastFloorY => lastFoorY;
    public void Generate(int level)
    {
        DestroyChild();

        floorAmount = defaultfloorAmount + level;

        axis.transform.localScale = new Vector3(1, floorAmount * floorHeight + floorHeight, 1);

        for (int i = 0; i < floorAmount; i++)
        {
            Floor floor = Instantiate(floorPrefab, transform);
            floor.transform.Translate(0, i * floorHeight, 0);
            floor.name = "Floor" + i;

            if (i == 0)
            {
                floor.SetFinishAllSegment();
            }
            if (i > 0 && i < floorAmount - 1)
            {
                floor.SetRandomRotation();
                floor.AddEmptySegment(amountEmptySegment);
                floor.AddRandomTrapSegment(Random.Range(minTrapSegment, maxTrapSegment + 1));
            }
            if (i == floorAmount - 1)
            {
                floor.AddEmptySegment(2);
                lastFoorY = floor.transform.position.y;
            }                        
        }
    }
    private void DestroyChild()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i) == axis) continue;

            Destroy(transform.GetChild(i).gameObject);
        }
    }
}