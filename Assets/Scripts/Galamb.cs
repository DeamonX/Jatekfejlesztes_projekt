using UnityEngine;

public class Galamb : MonoBehaviour
{
    // private propertyk megjelennek az editorban, de nem módosíthatók

    // A lecserélést végző objektum
    private SpriteRenderer spriteRenderer;
    private Vector3 direction;
    // Az animációhoz lévő kellő spriteok
    public Sprite[] sprites;
    // Aktuális állapot
    private int spriteIndex;

   

    // publik módosítható
    public float gravity = -9.8f;
    public float strength = 5f;

    // Betölti az első állapotot
    private void Awake(){
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start(){
        // 0.15 mpenként kérje le a következő spriteot
        InvokeRepeating(nameof(AnimateSprite),0.15f, 0.15f);
    }

    private void OnEnable(){
        // Minden újra indításnál reseteli a magasságot
        Vector3 pos = transform.position;
        pos.y = 0f;

        transform.position = pos;
        direction =Vector3.zero;
    }

    // Növeli a spriteIndexet és lekéri a következőt
    private void AnimateSprite(){
        spriteIndex++;
        if(spriteIndex >= sprites.Length) {
            spriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[spriteIndex];
    }

    // Az a függvény, ami framenként lefut.
    private void Update(){
        // Space vagy balklikk esetén ugorjon a galamb
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            //  Strength szorzóval tudjuk skálázni
            direction = Vector3.up * strength;
        }

        // Touchpad esetén, ha több krumplival ér hozzá, akkor is csak az elsőt dolgozza fel.
        if(Input.touchCount > 0 ){
            
            Touch touch = Input.GetTouch(0);
            
            if(touch.phase == TouchPhase.Began){
                direction = Vector3.up * strength;
            }
        }

        direction.y += gravity * Time.deltaTime;
        transform.position +=  direction * Time.deltaTime;

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Akadaly"){
            FindObjectOfType<GameManager>().GameOver();
        }else if( other.gameObject.tag == "Pontozas"){
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
