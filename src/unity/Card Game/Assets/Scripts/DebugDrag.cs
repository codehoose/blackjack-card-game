using UnityEngine;

/// <summary>
/// Debug version of the drag and drop class.
/// </summary>
public class DebugDrag : MonoBehaviour
{

    // The camera that will cast the ray through to the world
    public Camera cam;

    // The currently selected object
    GameObject obj;

    // The offset from the currently selected object
    Vector3 offset;

    // The previous zorder of the sprite
    int previousZOrder;

	// Update is called once per frame
	void Update ()
    {

        // Check to see if the player depressed the button this frame, but
        // not held from the last frame
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray into the screen
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            // This will get filled in if the raycast works
            RaycastHit hit;

            // Check if we have a hit
            if (Physics.Raycast(ray, out hit))
            {
                // Oh yeah! Set the current object data
                obj = hit.collider.gameObject;

                // The offset is the point away from the object's origin where the
                // player grabbed the card
                offset = hit.transform.position - hit.point;

                // Grab the current sorting order
                var sprite = hit.collider.GetComponent<SpriteRenderer>();
                previousZOrder = sprite.sortingOrder;

                // Set the new order above everything else
                sprite.sortingOrder = 100;
            }
        }		
        else if (Input.GetMouseButtonUp(0) && obj != null)
        {
            // Reset the sorting order
            var sprite = obj.GetComponent<SpriteRenderer>();
            sprite.sortingOrder = previousZOrder;

            // The player released the mouse button
            obj = null;
            
            // TODO: Signal something happened
        }

        // If the current object isn't null then we can drag it around the screen
        if (obj != null)
        {
            // Get the current mouse position
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

            // Set the object's depth because the screen to world point puts z=0
            mousePos.z = obj.transform.position.z;

            // FINALLY set the object's current position to the mouse position
            // We add the offset because that's the point where the player grabbed 
            // the card
            obj.transform.position = mousePos + offset;
        }
	}
}
