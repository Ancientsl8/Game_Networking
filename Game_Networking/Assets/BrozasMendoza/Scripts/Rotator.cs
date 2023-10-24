using UnityEngine;

namespace DebateClub {
public class Rotator : MonoBehaviour {
    [Header("References")]
    [SerializeField, Range(4f, 100f)] private float rotateSpeed = 4f;
    [SerializeField] private Direction direction;
    
    private void Update() {
        Rotate();
    }

    private void Rotate() {
        switch (direction) {
            case Direction.Left:
                this.transform.Rotate(Vector3.left * (rotateSpeed * Time.deltaTime));
                break;
            case Direction.Right:
                this.transform.Rotate(Vector3.right * (rotateSpeed * Time.deltaTime));
                break;
        }
    }
}

public enum Direction {
    Invalid,
    Left,
    Right
}
}