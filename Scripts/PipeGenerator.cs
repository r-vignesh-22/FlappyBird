using System.Collections;
using UnityEngine;

public class PipeGenerator : MonoBehaviour
{
    [Header("Prefab Input")]
    [SerializeField] GameObject pipePrefab;
    [Header("Limits Input")]
    [SerializeField] float minYAxis;
    [SerializeField] float MaxYAxis;
    [SerializeField] float delayTime;
    void OnEnable()
    {
        StartCoroutine(Generate());
    }

    IEnumerator Generate()
    {
        //call repeatedly
        while (true)
        {
            float yLimit = Random.Range(minYAxis, MaxYAxis);
            GameObject duplicatePipe = Instantiate(pipePrefab, new Vector2(transform.position.x, yLimit), Quaternion.identity);
            duplicatePipe.transform.SetParent(this.transform);
            yield return new WaitForSeconds(delayTime);
        }
    }
}
