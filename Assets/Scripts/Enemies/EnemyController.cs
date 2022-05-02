using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool IsTimeFrozen => _isTimeFrozen;
    private float _frozenTimeLeft;
    private bool _isTimeFrozen;
    private float _frozenTimeStep = 0.1f;
    private YieldInstruction _delay;


    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        //caching YieldInstruction to prevent garbage collection
        _delay  = new WaitForSeconds(_frozenTimeStep);
    }
    public void FrozeTime(float seconds)
    {
        _frozenTimeLeft += seconds;
        if (!IsTimeFrozen)
        {
            _isTimeFrozen = true;
            StartCoroutine(CountFrozenTime());
        }
    }


    IEnumerator CountFrozenTime()
    {
        while (IsTimeFrozen)
        {
            yield return _delay;
            _frozenTimeLeft -= 0.1f;
            CheckForFreeze();
        }
    }

    private void CheckForFreeze()
    {
        if (_frozenTimeLeft < 0)
        {
            _isTimeFrozen = false;
            _frozenTimeLeft = 0;
        }
    }
}
