using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPong2 : MonoBehaviour
{
    private enum ChangePosition
    {
        Lerp,
        MoveTowards,
        LerpSlowMotion,
        TimeMotion
    }
    [SerializeField]
    private Vector3 startPoint = new Vector3(1, 1, 1);
    [SerializeField]
    private Vector3 endPoint = new Vector3(5, 5, 5);
    [SerializeField]
    private float speed = 1.0f;
    [SerializeField]
    private float MovementTime= 5.0f;
    [SerializeField]
    private ChangePosition changePosition;
    private Vector3 reverce;
    private float startTime;
    private float secondsMetertime;
    void Start()
    {
        transform.position = startPoint;
        reverce = endPoint;
        startTime = Time.time;
    }
    void Update()
    {
        ChangeMoveType();
    }
    private void ChangeMoveType()
    {
        switch (changePosition)
        {
            case ChangePosition.Lerp:
                ChangePositionLerp();
                break;
            case ChangePosition.MoveTowards:
                ChangePositionMoveTowards();
                break;
            case ChangePosition.LerpSlowMotion:
                ChangePositionLerpSlowMotion();
                break;
            case ChangePosition.TimeMotion:
                TimeMotion();
                break;
        }
    }
    private void ChangePositionLerp()
    {
        float stepTime = (Time.time - startTime);
        float step = stepTime / MovementTime;
        transform.position= Vector3.Lerp(startPoint, endPoint, step);
    }
        private void ChangePositionMoveTowards()
        {
            transform.position = Vector3.MoveTowards(transform.position, reverce, speed * Time.deltaTime);
            if (Mathf.Abs(Vector3.Distance(transform.position, endPoint)) < 0.001f)
            {
            transform.position = endPoint;
            reverce = startPoint;
            }
            if (Mathf.Abs(Vector3.Distance(transform.position, startPoint)) < 0.001f)
            {
            transform.position = startPoint;
            reverce = endPoint;
            }
        }
    private void ChangePositionLerpSlowMotion()
    {
        transform.position = Vector3.Lerp(transform.position, reverce, speed * Time.deltaTime);
        if (Mathf.Abs(Vector3.Distance(transform.position, endPoint)) < 0.001f)
        {
            transform.position = endPoint;
            reverce = startPoint;
        }
        if (Mathf.Abs(Vector3.Distance(transform.position, startPoint)) < 0.001f)
        {
            transform.position = startPoint;
            reverce = endPoint;
        }
    }
    private void TimeMotion()
    {
        float distCovered = (Time.time - startTime);
        float step = distCovered / MovementTime;
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(step, 1f));
        if (transform.position== endPoint)
        {
            Debug.Log("End");
        }
        if (Mathf.Abs(Vector3.Distance(transform.position, endPoint)) < 0.001f)
        {
            Debug.Log("End");
        }
            SecondsMeter(MovementTime);
    }
    private void SecondsMeter(float timeInSeconds)
    {
        secondsMetertime = secondsMetertime + Time.deltaTime;
        if (secondsMetertime >= timeInSeconds)
        {
            Debug.Log(secondsMetertime);
        }
    }
    IEnumerator SecondsMeter2(float timeInSeconds)
    {
        yield return new WaitForSeconds(timeInSeconds);
        Debug.Log("5 seconds remain");
    }

    #region coroutine metod
    IEnumerator MoveTowards(Transform objectToMove, Vector3 toPosition, float duration)
    {
        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            Vector3 currentPos = objectToMove.position;

            float time = Vector3.Distance(currentPos, toPosition) / (duration - counter) * Time.deltaTime;

            objectToMove.position = Vector3.MoveTowards(currentPos, toPosition, time);

            Debug.Log(counter + " / " + duration);
            yield return null;
        }
    }
    #endregion
    # region test
    //transform.position += new Vector3(speed * Time.deltaTime, 0.0f, 0.0f); большая погрешность.
    /*Собственно, функция Lerp — это и правда попросту линейная интерполяция.Но это сама функция.А вот действие кода вышеупомянутого метода Update уже не столь очевидно.
        При его применении видно, что объект сдвигается в нужном направлении, и по ходу дела замедляется.
        В случае же «истинной» линейной интерполяции объект должен начать движение, перемещаться с фиксированной скоростью, затем резко замереть.
        Именно так происходит, если обращаться к вариантам использования Lerp не из туториалов, а из официальной справки по скриптам (конкретно, по методу Lerp). 
        А вот упомянутый код ведет себя не так.*/
    #endregion
}
