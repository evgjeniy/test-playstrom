using Services;
using UnityEngine;

namespace Moving
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(CapsuleCollider))]
    public class RocketMovement : MovableObject<Rigidbody>
    {
        [SerializeField, Min(0.0f)] private float flyingSpeed = 7.0f;
        [SerializeField, Min(0.0f)] private float movementSpeed = 2.5f;
        [SerializeField, Min(0.0f)] private float maxAngularVelocity = 1.0f;

        [Header("Effects")] 
        [SerializeField] private ParticleSystem rocketEngine;
    
        private void Start() => Component = GetComponent<Rigidbody>();

        private void Update() => GlobalEvents.OnRocketMoved?.Invoke((int)Transform.position.y);

        protected override void Move(Touch touch)
        {
            if (rocketEngine.isStopped) rocketEngine.Play();
        
            var moveDirection = new Vector3(touch.deltaPosition.x, flyingSpeed, 0.0f);
        
            Component.AddForce(moveDirection * (movementSpeed * Time.deltaTime), ForceMode.Impulse);
        
            Component.rotation = Quaternion.Euler(
                Vector3.Lerp(Transform.eulerAngles, moveDirection.normalized * -90.0f, Time.deltaTime / 0.5f));
        }

        protected override void Rotate(Touch touch)
        {
            if (rocketEngine.isPlaying) rocketEngine.Stop();
        
            Component.angularVelocity = new Vector3(
                Random.Range(-maxAngularVelocity, maxAngularVelocity),
                Random.Range(-maxAngularVelocity, maxAngularVelocity),
                Random.Range(-maxAngularVelocity, maxAngularVelocity));
        }
    }
}