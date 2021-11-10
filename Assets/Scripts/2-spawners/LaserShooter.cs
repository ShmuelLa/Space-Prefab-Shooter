using UnityEngine;

/**
 * This component spawns the given laser-prefab whenever the player clicks a given key.
 * It also updates the "scoreText" field of the new laser.
 * 
 * Assignment Edit: we added a serialized field which delay the shots by X seconds as set by the user.
 * For this we use a timestamp which prevents new shots to be spawned unless the set time is achieved.
 */
public class LaserShooter: KeyboardSpawner
{
    [SerializeField] NumberField scoreField;
    [SerializeField] float timeBetweenShots;
    private float timestamp;

    protected override GameObject spawnObject() {
        if (Time.time >= timestamp && (Input.GetKeyDown(keyToPress)))
        {
            GameObject newObject = base.spawnObject();  // base = super
            ScoreAdder newObjectScoreAdder = newObject.GetComponent<ScoreAdder>();
            if (newObjectScoreAdder)
                newObjectScoreAdder.SetScoreField(scoreField);
            timestamp = timestamp + timeBetweenShots;
            return newObject;
        }
        return null;
    }
}
