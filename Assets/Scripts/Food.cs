using UnityEngine;

public class Food : MonoBehaviour
{

    public BoxCollider2D gridArea; //Variable gridArea

    private void Start() { //Start Function

        RandomizePosition(); //Start RandomizePosition Function

    }

    private void RandomizePosition() { //Randomize food position
        
        Bounds bounds = this.gridArea.bounds; //The grid is the boundary

        float x = Random.Range(bounds.min.x, bounds.max.x); //Randomize x position
        float y = Random.Range(bounds.min.y, bounds.max.y); //Randomize y position

        this.transform.position = new Vector3(Mathf.Round(x),Mathf.Round(y),0.0f); //Assign the food position to random place

    }

    private void OnTriggerEnter2D(Collider2D other) { //If our game object collide with one another

        if (other.tag == "Player") { //If collide with player
        
            RandomizePosition(); //Randomize position again

        }
    }


}
