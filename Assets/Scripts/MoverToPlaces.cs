using UnityEngine;

public class MoverToPlaces : MonoBehaviour
{
    [SerializeField] private Transform _placesContainer;
    [SerializeField] private Transform[] _places;
    [SerializeField] private float _speed;

    private int _currentPlaceIndex = 0;

    private void OnValidate()
    {
        _places = new Transform[_placesContainer.childCount];
        
        if(_places.Length == 0)
        {
            Debug.LogWarning("Places Container не имеет дочерних объектов!");
        }

        for (int i = 0; i < _places.Length; i++)
        {
            _places[i] = _placesContainer.GetChild(i);
        }
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _places[_currentPlaceIndex].position, _speed * Time.deltaTime);

        if (transform.position == _places[_currentPlaceIndex].position)
        {
            ChangeNextPlace();
        }
    }

    public void ChangeNextPlace()
    {
        _currentPlaceIndex = ++_currentPlaceIndex % _places.Length;
    }
}