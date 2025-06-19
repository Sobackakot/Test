 
using UnityEngine;

public class ZAudio : MonoBehaviour
{
    private ZMoveBeh moveZ;
    private ZHP hpZ;
    private ZRandomMoveBeh randomBehaviorZ;

    public AudioSource idleSource;
    public AudioSource screamerSource;
    public AudioSource deathSource;

    private void Awake()
    {
        moveZ = GetComponentInParent<ZMoveBeh>();
        randomBehaviorZ = GetComponentInParent<ZRandomMoveBeh>();
        hpZ = GetComponentInParent<ZHP>();
        idleSource = transform.GetChild(0).GetComponent<AudioSource>();
        screamerSource = transform.GetChild(1).GetComponent<AudioSource>();
        deathSource = transform.GetChild(2).GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        moveZ.onPlayAudioZombieScreamer += ScreamerAudioZ;
        hpZ.onPlayAudioZombieDeath += DeathAudioZ;
        randomBehaviorZ.onPlayAudioZombieIdle += IdleAudioZ;
    }
    private void OnDisable()
    {
        moveZ.onPlayAudioZombieScreamer -= ScreamerAudioZ;
        hpZ.onPlayAudioZombieDeath -= DeathAudioZ;
        randomBehaviorZ.onPlayAudioZombieIdle -= IdleAudioZ;
    }
    private void Start()
    {
        IdleAudioZ();
    }
    private void IdleAudioZ()
    {
        idleSource.Play();
    }
    private void DeathAudioZ()
    {
        idleSource.Stop();
        deathSource.Play();
    }
    private void ScreamerAudioZ()
    {
        screamerSource.Play();
    }
}
