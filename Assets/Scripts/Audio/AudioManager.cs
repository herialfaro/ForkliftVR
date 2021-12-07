using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class AudioManager : MonoBehaviour
    {
        public AudioSource Forklift_AS;
        public AudioSource Elevate_AS;
        public AudioSource Rotate_AS;
        public AudioSource Reverse_AS;
        public AudioSource Going_AS;

        public AudioClip going;
        public AudioClip reverse;
        public AudioClip turnOn;
        public AudioClip turnOff;
        public AudioClip elevateUp;
        public AudioClip elevateDown;


        private void Awake()
        {
            Forklift_AS = GetComponentInChildren<AudioSource>();

        }

        public void PlayLoopWalk()
        {
            Forklift_AS.loop = true;
            Forklift_AS.clip = going;
            Forklift_AS.pitch = 1.3f;
            if (Forklift_AS != Forklift_AS.isPlaying)
            {
                Forklift_AS.Play();
            }
        }

        public void StopLoop()
        {
            Forklift_AS.loop = false;
            Forklift_AS.Stop();
        }

        public void PlayStart()
        {
            Forklift_AS.PlayOneShot(turnOn);
        }

        public void PlayStop()
        {
            Forklift_AS.PlayOneShot(turnOff);
        }

        public void PlayLoopElevateUp()
        {
            Elevate_AS.loop = true;
            Elevate_AS.clip = elevateUp;
            if (Elevate_AS != Elevate_AS.isPlaying)
            {
                Elevate_AS.Play();
            }
        }

        public void PlayLoopElevateDown()
        {
            Elevate_AS.loop = true;
            Elevate_AS.clip = elevateDown;
            if (Elevate_AS != Elevate_AS.isPlaying)
            {
                Elevate_AS.Play();
            }
        }

        public void PlayLoopRotateUp()
        {
            Rotate_AS.loop = true;
            Rotate_AS.clip = elevateUp;
            if (Rotate_AS != Rotate_AS.isPlaying)
            {
                Rotate_AS.Play();
            }
        }

        public void PlayLoopRotateDown()
        {
            Rotate_AS.loop = true;
            Rotate_AS.clip = elevateDown;
            if (Rotate_AS != Rotate_AS.isPlaying)
            {
                Rotate_AS.Play();
            }
        }

        public void StopLoopElevate()
        {
            Elevate_AS.loop = false;
            Elevate_AS.Stop();
        }

        public void StopLoopRotate()
        {
            Rotate_AS.loop = false;
            Rotate_AS.Stop();
        }

        public void PlayLoopReverse()
        {
            Reverse_AS.loop = true;
            Reverse_AS.clip = reverse;
            if (Reverse_AS != Reverse_AS.isPlaying)
            {
                Reverse_AS.Play();
            }
        }

        public void PlayLoopGoing()
        {
            Going_AS.loop = true;
            Going_AS.clip = going;
            if (Going_AS != Going_AS.isPlaying)
            {
                Going_AS.Play();
            }
        }

        public void StopLoopReverse()
        {
            Reverse_AS.loop = false;
            Reverse_AS.Stop();
        }

        public void StopLoopGoing()
        {
            Going_AS.loop = false;
            Going_AS.Stop();
        }
    }
}