using UnityEngine;

public class CelestialBody : MonoBehaviour 
{
    #region Fields

    private Rigidbody _rigidbody;

    [Header("Gravitation")]
    [SerializeField] public float radius;
    [SerializeField] public float surfaceGravity;
    [SerializeField] public Vector3 initialVelocity;
    
    [Header("Rotating")]
    [SerializeField] public bool enableRotation;
    [SerializeField] public float rotationSpeed;

    public float mass { get; private set; }
    
    #endregion

    #region Events

    private void Start() 
    {
        mass = surfaceGravity * radius * radius / Constants.GravitationalConstant;
        transform.localScale = Vector3.one * radius;
        
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.mass = mass;
        _rigidbody.velocity = initialVelocity;
    }
    
    #endregion

    #region Public Methods

    public void UpdateVelocity(Vector3 acceleration) 
    {
        _rigidbody.AddForce(acceleration, ForceMode.Acceleration);
    }
    
    public void Rotate(Vector3 direction, float radius, float speed)
    {
        float rotationSpeed = 2 * Mathf.PI * radius * speed * Constants.RotationalConstant;
        Vector3 forceDirection = direction * rotationSpeed;
        transform.Rotate(forceDirection);
    }
    
    #endregion
}