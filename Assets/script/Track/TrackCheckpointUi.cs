using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpointUi : MonoBehaviour
{
   [SerializeField] private TrackCheckpoint trackCheckpoint;

    private void Start()
    {
        trackCheckpoint.OnPlayerCorrectCheckpoint += TrackCheckpoints_OnPlayerCorrectCheckpoint;
        trackCheckpoint.OnPlayerWrongCheckpoint += TrackCheckpoints_OnPlayerWrongCheckpoint;

        Hide();
    }

    private void TrackCheckpoints_OnPlayerCorrectCheckpoint(object sender,System.EventArgs e)
    {
       Hide();
    }

    private void TrackCheckpoints_OnPlayerWrongCheckpoint(object sender,System.EventArgs e)
    {
        Show();
        
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
}
