using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UAG.Player{
public class PlayerCam : MonoBehaviour
    {
        public static PlayerCam instance;

        public Transform player_head;
        
        public Transform sceneCam;
        public Transform weaponCam;
        
        public float shake_duration = 0.1f, shake_force = 0.1f;

        public float bob_amplitude, bob_period;
        
        private float current_time = 0;
        private bool shaking;
        
        private Vector3 start_pos, player_pos, shake_offset = Vector3.zero, bob_offset = Vector3.zero;

        private float x = 0;
        
        
        
        private void Awake()
        {
            instance = this;
            start_pos = transform.position;
            
            
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        private void Update()
        {
            Bob();
            
            if (shaking)
            {
                Shake();
                current_time -= Time.deltaTime;
            }

            if (shaking && !(current_time > 0))
            {
                StopShake();
            }

            player_pos = player_head.position;

            transform.position = player_pos + shake_offset + bob_offset;
        }

        public void StartShake()
        {
            current_time = shake_duration;
            shaking = true;
        }

        private void Shake()
        {
            shake_offset = ((Vector3)Random.insideUnitCircle * shake_force);
        }

        private void StopShake()
        {
            shake_offset = Vector3.zero;
            shaking = false;
        }
        
        private void Bob()
        {
            float magnitude = PlayerMovement.instance.GetComponent<Rigidbody>().velocity.magnitude;

            if (Mathf.Abs(magnitude) >= 0.05f)
            {
                

                x += Mathf.Abs(magnitude) * Time.deltaTime;

            
            
                // sin curve on a set period that runs through delta pos
                bob_offset = new Vector3(0,  Mathf.Abs(Mathf.Sin(x / bob_period)), 0) * bob_amplitude;
            }
            else
            {
                x = 0;
                bob_offset = Vector3.Lerp(bob_offset, Vector3.zero, 0.1f);
            }
        }
        

    }
}
