using UnityEngine;

// A Csovek osztály magába foglalja a fenti és a lenti csövet egyszerre.
public class Csovek : MonoBehaviour
{
    // Ezzel a sebességgel fognak közeledni
    public float speed = 5f;
    // Később feltöltött érték, a képernyő szélének értéke
    private float leftEdge;

    // Új létrehozás esetén feltöltjük a bal sarok értékét.
    private void Start(){
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x  - 1f;
    }

    // Minden frame frissítésekor, közeledjen a Galambhoz
    private void Update()
    {
        // új pozíció
        transform.position += Vector3.left * speed *Time.deltaTime;
        // Ha már nem látható a képernyőn a cső, törlődik.
        if(transform.position.x < leftEdge) {
            Destroy(gameObject);
        }
    }
}
