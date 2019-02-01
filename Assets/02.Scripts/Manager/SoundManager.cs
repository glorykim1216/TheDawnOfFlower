using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoSingleton<SoundManager>
{
    static int soundMaxNum = 5; // 최대 동시 사운드 출력 갯수
    public AudioSource[] audioSource = new AudioSource[soundMaxNum]; 
    private Dictionary<string, AudioClip> DicAudioClip = new Dictionary<string, AudioClip>();

    public void LoadSound()
    {
        AudioClip[] resourcesAudioClip = Resources.LoadAll<AudioClip>("Sound");
        for (int i = 0; i < resourcesAudioClip.Length; i++)
        {
            DicAudioClip.Add(resourcesAudioClip[i].name, resourcesAudioClip[i]);
        }
    }

    // 음원 재생 (음원, 반복 여부, 음량)
    public void PlaySound(string _clip, bool _loop = false, float _volume = 1.0f)
    {
        for (int i = 0; i < soundMaxNum; i++)
        {
            // 재생 중이 아닌 오디오 소스 탐색
            if(audioSource[i].isPlaying == false)
            {
                //오디오 클립 변경
                audioSource[i].clip = DicAudioClip[_clip];

                // 반복 설정
                audioSource[i].loop = _loop;

                // 볼륨 설정
                audioSource[i].volume = _volume;

                // 재생
                audioSource[i].Play();

                break;
            }
        }
    }

    // 음원 정지
    public void StopSound(string _clip)
    {
        for (int i = 0; i < soundMaxNum; i++)
        {
            // 재생 중인 오디오 소스 탐색
            if(audioSource[i].isPlaying == true)
            {
                // 오디오 클립 이름 확인
                if(audioSource[i].clip.name == _clip)
                {
                    // 정지
                    audioSource[i].Stop();
                }
            }
        }
    }

    // 모든 음원 재생 정지
    public void StopAllSound()
    {
        for (int i = 0; i < soundMaxNum; i++)
        {
            audioSource[i].Stop();
        }
    }
}
