using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CactusSpawner : MonoBehaviour
{
    [SerializeField] List<CactusWaveConfig> waveConfigs;
    [SerializeField] TextMeshProUGUI score;
    bool hasWaited = false;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
    }

    private IEnumerator SpawnAllWaves()
    {

        var currentWave = waveConfigs[(int)Random.Range(0, waveConfigs.Count)];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        
    }

    private IEnumerator SpawnAllEnemiesInWave(CactusWaveConfig waveConfig)
    {
        if (!hasWaited)
        {
            hasWaited = true;
            yield return new WaitForSeconds(2.5f);
        }
        for (int enemyCount = 0; enemyCount < waveConfig.GetNumberOfEnemies(); enemyCount++)
        {
            var newCactus = Instantiate(
                waveConfig.GetEnemyPrefab(),
                waveConfig.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            newCactus.GetComponent<CactusPathing>().SetWaveConfig(waveConfig);
            yield return new WaitForSeconds(ComputeTimeBetweenSpawns());

        }
    }
    public float ComputeTimeBetweenSpawns()
    {
        int scoreValue = score.GetComponent<CDscore>().scoreValue;
        if (scoreValue > 0)
        {
            float waitTime = Random.Range(1f, 1 + (float)(4f / Mathf.Pow(scoreValue, 0.5f)));
            return waitTime;
        }
        else
        {
            return 5f;
        }
    }
}
