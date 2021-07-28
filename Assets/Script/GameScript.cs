
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    [SerializeField] private Transform emptySpace = null;
    private Camera _camera;
    [SerializeField] private TilesScript[] tiles;
    int emptySapceIndex = 12 ;
    private bool isFinished;
    [SerializeField] private GameObject endPannel;

    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main;
        Shuffle();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit)
            {
                if(Vector2.Distance(emptySpace.position, hit.transform.position) < 2)
                {
                    Vector2 lastEmptySpacePosition = emptySpace.position;
                    TilesScript thisTile = hit.transform.GetComponent<TilesScript>();
                   // emptySpace.position = hit.transform.position;
                   // hit.transform.position = lastEmptySpacePosition;
                    emptySpace.position = thisTile.targetPosition;
                    thisTile.targetPosition = lastEmptySpacePosition;
                    int tileInd = findIndex(thisTile);
                    tiles[emptySapceIndex] = tiles[tileInd];
                    tiles[tileInd] = null;
                    emptySapceIndex = tileInd;

                }
            }
        }
        if (!isFinished)
        {
            int correctTiles = 0;
            foreach (var a in tiles)
            {
                if (a != null)
                {
                    if (a.inRightPlace)
                    {
                        correctTiles++;
                    }
                }
                if (correctTiles == tiles.Length - 1)
                {
                    PlayerFpsScript.num_of_comp_missions++; // if puzzle is solved num of player mission inc by 1
                    isFinished = true;
                    endPannel.SetActive(true);
                }
            }
        }
    }
    public void BackToMainGame()
    {
        //SceneManager.LoadScene(SceneManager.)
    }
    public void Shuffle()
    {
        if(emptySapceIndex != 15)
        {
            var tileOn15LastPos = tiles[15].targetPosition;
            tiles[15].targetPosition = emptySpace.position;
            emptySpace.position = tileOn15LastPos;
            tiles[emptySapceIndex] = tiles[15];
            tiles[15] = null;
            emptySapceIndex = 15;
        }
        int invertion;
        do
        {

            for (int i = 0; i < 15; i++)
            {

                var lastPos = tiles[i].targetPosition;
                int randomInd = Random.Range(0, 14);
                tiles[i].targetPosition = tiles[randomInd].targetPosition;
                tiles[randomInd].targetPosition = lastPos;
                var tile = tiles[i];
                tiles[i] = tiles[randomInd];
                tiles[randomInd] = tile;

            }
            invertion = getInversion();
            Debug.Log("puzzle shuffeld");
        } while (invertion % 2 != 0);
    }
    public int findIndex(TilesScript ts)
    {
        for (int i = 0; i < tiles.Length; i++)
        {
            if (tiles[i] != null)
            {
                if (tiles[i] == ts)
                {
                    return i;
                }
            }
            
        }
        return -1;
    }

    public int getInversion()
    {
        int inversionSum = 0;
        for (int i = 0; i < tiles.Length; i++)
        {
            int thisTileInvertion = 0;
            for (int j = i; j < tiles.Length; j++)
            {
                if(tiles[j] != null)
                {
                    if(tiles[i].number > tiles[j].number)
                    {
                        thisTileInvertion++;
                    }
                }
            }
            inversionSum += thisTileInvertion;
        }
        return inversionSum;
    }
    

}
