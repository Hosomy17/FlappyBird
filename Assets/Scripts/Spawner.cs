using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    //variaveis de chamada do prefab, as vezes que ele vai surgir no mapa, assim como sua altura minima e maxima
    public GameObject prefab;
    public float spawnRate = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;

    private void OnEnable()
    {
        //OnEnable e utilizado para habilitar algo, mas que esse "algo" pode acabar quando ocorrer outro evento
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }

    private void Spawn()
    {
        //serve para o objeto ser instanciado, ou seja, clonado sem que o objeto inicial saia do lugar
        //Quaternion.identity e para o objeto nao precisar rotacionar
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity);
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight);
    }
}
