using UnityEngine;

public class Galamb : MonoBehaviour
{
    // private propertyk megjelennek az editorban, de nem módosíthatók

    // A lecserélést végző objektum
    private SpriteRenderer spriteRenderer;
    // Galamb magasságának értéke
    private Vector3 direction;
    // Az animációhoz kellő spriteok
    public Sprite[] sprites;
    // Aktuális sprite indexe
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

    // Minden újra indításnál reseteli a magasságot
    private void OnEnable(){
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
    // Objektum érintés esetén lefutó függvény
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Ha Akadályhoz ér hozzá vége
        if(other.gameObject.tag == "Akadaly"){
            FindObjectOfType<GameManager>().GameOver();
        // Ha a két cső közé esik akkor plusz pont.
        }else if( other.gameObject.tag == "Pontozas"){
            FindObjectOfType<GameManager>().IncreaseScore();
        }
    }
}
