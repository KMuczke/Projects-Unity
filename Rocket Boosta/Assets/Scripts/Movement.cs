using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField] float ThrustStrength = 100f;
    [SerializeField] float RotationStrength = 50f;
    [SerializeField] AudioClip mainEngineSFX;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem LThrustParticles;
    [SerializeField] ParticleSystem RThrustParticles;


    Rigidbody rb;
    AudioSource audioSource;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {

        thrust.Enable();
        rotation.Enable();

    }
    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }
    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        
        { startThrusting(); }
        else
        { stopThrusting(); }
    }
    private void startThrusting()
    {
        rb.AddRelativeForce(Vector3.up * ThrustStrength * Time.fixedDeltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngineSFX);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }
    private void stopThrusting()
    {
        audioSource.Stop();
        mainEngineParticles.Stop();
    }
    private void ProcessRotation()
    {
        float rotationInput = rotation.ReadValue<float>();
        if (rotationInput < 0)
        { RotateLeft(); }

        else if (rotationInput > 0)
        { RotateRight(); }

        else
        { StopRotating(); }
    }
    private void RotateLeft()

    {
        ApplyRotation(RotationStrength);
            if (!LThrustParticles.isPlaying)
            {
                RThrustParticles.Stop();
                LThrustParticles.Play();
            }
    }
    private void RotateRight()
    {
        ApplyRotation(-RotationStrength);
            if (!RThrustParticles.isPlaying)
            {
                LThrustParticles.Stop();
                RThrustParticles.Play();
            }
    }
    private void StopRotating()
    {
        RThrustParticles.Stop();
        LThrustParticles.Stop();
    }
    private void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.fixedDeltaTime);
        rb.freezeRotation = false;
    }





}