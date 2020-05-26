using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

// ReSharper disable once CheckNamespace
namespace Vic485.Drm
{
    public class SimpleRegionLock : MonoBehaviour
    {
        [SerializeField] private List<string> allowedRegions = new List<string>();
        [SerializeField] private List<string> blockedRegions = new List<string>();

        private void Awake()
        {
            var tz = TimeZoneInfo.Local;

            // Check if we are in an allowed region or not in a blocked region. If so, continue to load the next scene
            // in the game. If not, do nothing so we can display a message to the user or perform any other actions.
            if (allowedRegions.Any(x => TimeZoneInfo.FindSystemTimeZoneById(x).Equals(tz)) ||
                !blockedRegions.Any(x => TimeZoneInfo.FindSystemTimeZoneById(x).Equals(tz)))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
