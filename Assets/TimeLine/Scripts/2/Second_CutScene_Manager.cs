using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.Audio;

public class Second_CutScene_Manager : MonoBehaviour
{
    public PlayableDirector playableDirector;
    public string yesDialogueTrackName = "Dialogue(1)";
    public string noDialogueTrackName = "Dialogue(2)";

    void Start()
    {
        SetTrackMuteState();
    }

    void Update()
    {
        // 필요 시 Update 메서드에 로직 추가
    }

    public void DialogueSelect()
    {
        SetTrackMuteState();
    }

    private void SetTrackMuteState()
    {
        bool isYorN = SystemMessage.instance.YorN;
        MuteTrack(yesDialogueTrackName, !isYorN);
        MuteTrack(noDialogueTrackName, isYorN);
    }

    private void MuteTrack(string trackName, bool mute)
    {
        TimelineAsset timeline = (TimelineAsset)playableDirector.playableAsset;

        foreach (var track in timeline.GetOutputTracks())
        {
            if (track.name == trackName && track is AudioTrack)
            {
                var binding = playableDirector.GetGenericBinding(track) as AudioSource;
                if (binding != null)
                {
                    binding.mute = mute;
                    Debug.Log($"Track {trackName} has been {(mute ? "muted" : "unmuted")}.");
                }
            }
        }
    }
}
