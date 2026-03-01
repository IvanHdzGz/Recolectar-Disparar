using UnityEngine;
public class RotatorInv : MonoBehaviour {
    public float rotationSpeed = 45f;
    void Update() {
        transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
    }
}