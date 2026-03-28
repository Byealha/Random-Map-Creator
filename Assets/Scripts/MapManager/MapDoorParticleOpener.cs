//스크립트 작성자: 이준호
using System;
using System.Collections.Generic;
using UnityEngine;

public class MapDoorParticleOpener : MonoBehaviour {
    public static MapDoorParticleOpener Instance;
    private MapDoorParticle mapDoorParticle;
    public event Action PortalOpenFinished;
    [SerializeField] private List<GameObject> doorParticle = new List<GameObject>();

    private void Awake() {
        if (Instance == null)
            Instance = this;
        else
            Destroy(Instance);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.V)) {
            DoorParticleOpen();
        }
        if (Input.GetKeyDown(KeyCode.B)) {
            DoorParticleClose();
        }
    }

    public void DoorParticleCurrentSave(GameObject prefab, Direction dir) {
        mapDoorParticle = prefab.GetComponent<MapDoorParticle>();
        switch (dir) {
            case Direction.Up:
                doorParticle.Add(mapDoorParticle.GetParticleTop());
                break;
            case Direction.Down:
                doorParticle.Add(mapDoorParticle.GetParticleBottom());
                break;
            case Direction.Left:
                doorParticle.Add(mapDoorParticle.GetParticleLeft());
                break;
            case Direction.Right:
                doorParticle.Add(mapDoorParticle.GetParticleRight());
                break;
            default:
                Debug.Log("Error: DoorParticleCurrentSave(GameObject prefab, Direction dir)");
                break;
        }
    }

    public void DoorParticleNextSave(GameObject prefab, Direction dir) {
        mapDoorParticle = prefab.GetComponent<MapDoorParticle>();
        switch (dir) {
            case Direction.Up:
                doorParticle.Add(mapDoorParticle.GetParticleBottom());
                break;
            case Direction.Down:
                doorParticle.Add(mapDoorParticle.GetParticleTop());
                break;
            case Direction.Left:
                doorParticle.Add(mapDoorParticle.GetParticleRight());
                break;
            case Direction.Right:
                doorParticle.Add(mapDoorParticle.GetParticleLeft());
                break;
            default:
                Debug.Log("Error: DoorParticleNextSave(GameObject prefab, Direction dir)");
                break;
        }
    }

    public void DoorParticleOpen() {
        for (int i = 0; i < doorParticle.Count; i++) {
            doorParticle[i].SetActive(false);
        }
        PortalOpenFinished?.Invoke();
    }

    public void DoorParticleClose() {
        for (int i = 0; i < doorParticle.Count; i++) {
            doorParticle[i].SetActive(true);
        }
        PortalOpenFinished?.Invoke();
    }
}
