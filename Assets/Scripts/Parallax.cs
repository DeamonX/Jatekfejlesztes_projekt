using UnityEngine;

// Ez az osztály felel az animációért, amitől úgy látszik, hogy a galamb halad előre.
public class Parallax : MonoBehaviour
{
    // Renderelő objektum
    private MeshRenderer meshRenderer;

    // Mozgás sebessége
    public float animationSpeed = 1f;

    /* Futtatáskor hozzárendeli a játék motorjából a 
    renderelésért felelős objektumot a saját paraméterünkhöz. */
    private void Awake(){
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Minden framefrissítéskor lefutó kódrész
    private void Update(){
        // Itt történik a mozgatás logikáját
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime,0);
    }
}
