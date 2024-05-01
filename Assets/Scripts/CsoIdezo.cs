using UnityEngine;


// Ez az osztály készíti a csöveket.
public class CsoIdezo : MonoBehaviour
{

    // ő a cső.
    public GameObject prefab;
    // csövek idézésének gyakorisága
    public float spawnRate = 1f;
    // Hol legyen a lyuk.
    public float minHeight = -1f;
    public float maxHeight = 1f;

    // Függvény indítása esetén idézési sebességenként hozzon létre csövet.
    private void OnEnable(){
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    // Hagyja abba a cső idézést.
    private void OnDisable(){
        CancelInvoke(nameof(Spawn));
    }
    // Létrehozási folyamat
    private void Spawn(){
        // Új csövek a képernyő jobb szélére.
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        
        // Csövek magasságának beállítása, hogy ne ugyan ott legyen a lyuk.
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
        
    }
}
