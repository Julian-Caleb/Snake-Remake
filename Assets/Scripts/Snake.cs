using UnityEngine; //Import UnityEngine library
using System.Collections.Generic; //Import System.Collections.Generic

public class Snake : MonoBehaviour //Monobehaviour library
{
   
    private Vector2 _direction = Vector2.right; //Vector2 variable _direction
    
    private List<Transform> _segments = new List<Transform>(); //List transforms called segments

    public Transform segmentPrefab; //For the body of the snake

    public int initialSize = 4; //How many snake segments at the start

    private void Start() {

        ResetState();

    }

    private void Update() { //Function update

        if(Input.GetKeyDown(KeyCode.W)) { //If D is pressed
            _direction = Vector2.up; //Go up
        } else if(Input.GetKeyDown(KeyCode.S)) { //If S is pressed
            _direction = Vector2.down; //Down
        } else if(Input.GetKeyDown(KeyCode.D)) { //If D is pressed
            _direction = Vector2.right; //Right
        } else if(Input.GetKeyDown(KeyCode.A)) { //If A is pressed
            _direction = Vector2.left; //Left
        }

    }

    private void FixedUpdate() { //Function FixedUpdate

        for(int i = _segments.Count - 1; i > 0; i--) {

            _segments[i].position = _segments[i - 1].position;

        }

        this.transform.position = new Vector3( //Assign position to new vector3
            Mathf.Round(this.transform.position.x) + _direction.x,
            Mathf.Round(this.transform.position.y) + _direction.y,
            0.0f
        );

    }

    private void Grow() { //Grow function

        Transform segment = Instantiate(this.segmentPrefab);
        segment.position = _segments[_segments.Count - 1].position;

        _segments.Add(segment);

    }

    private void ResetState() { //Game over

        for(int i = 1; i < _segments.Count; i++) { //Removing segments

            Destroy(_segments[i].gameObject);

        }

        _segments.Clear();
        _segments.Add(this.transform); //Reset the snake

        for(int i = 1; i < initialSize; i++) {

            _segments.Add(Instantiate(this.segmentPrefab)); //Add the initial size

        }

        this.transform.position = Vector3.zero; //Reset position

    }

    private void OnTriggerEnter2D(Collider2D other) { //If our game object collide with one another

        if (other.tag == "Food") { //If collide with player
        
            Grow(); //Randomize position again

        } else if(other.tag == "Obstacle") { //If collide with obstacle
            
            ResetState(); //Reset the game

        }
    }

}
