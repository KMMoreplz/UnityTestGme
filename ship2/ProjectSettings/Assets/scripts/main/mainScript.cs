using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class mainScript : MonoBehaviour
{
    const int eatQuanity = 21;
    int rangeOfSpawn =4;
    float sizeOfeat=0.1f;
    int counterOfEated;
 
    public GameObject player;
    public GameObject eat;
    public Camera cam;
public GameObject scoreText;
     public int score=0;
     public int scorableIntForScore=1;
     public void Count(){
         score+=scorableIntForScore;
         scoreText.GetComponent<Text>().text="Score: "+score.ToString();
     }

    public List<GameObject> eatArray = new List<GameObject>();
    

    bool collision(GameObject object1, GameObject object2)
    {
        double sizeObject1 = object1.transform.localScale.x / 2;
        double sizeObject2 = object2.transform.localScale.x / 2;

        if ((object1.transform.position.x + sizeObject1 >= object2.transform.position.x - sizeObject2) && (object1.transform.position.y + sizeObject1 >= object2.transform.position.y - sizeObject2)
        && (object1.transform.position.x - sizeObject1 <= object2.transform.position.x + sizeObject2) && (object1.transform.position.y - sizeObject1 <= object2.transform.position.y + sizeObject2))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
 

    void Start()
    {
        cam.orthographicSize=3;
        spawner();
    }

    void Update()
    {
    
        if(cam.orthographicSize / player.transform.localScale.x < 3)
        {
            cam.orthographicSize += cam.orthographicSize * Time.deltaTime * 0.1f;
        }
        int i = 0;
        do
        {
            if (eatArray.IndexOf(eatArray[i]) != -1 && eatArray[i] != null)
            {
                if (collision(player, eatArray[i]))
                {
                    Destroy(eatArray[i]);
                    player.transform.localScale += new Vector3(0.1f,0.1f,0);
                    eatArray.RemoveAt(i);
                    repeater();
                    
                    counterOfEated++;
                     player.GetComponent<moveShip>().s += 0.2f;
                    Count();
                }
                
            }
            ++i;
        } while (i < eatArray.Count);
    
    }
    void spawner()
    {
  
        int i = 0;
        do
        {
            eatArray.Add(Instantiate(eat));

            eatArray[i].transform.position = new Vector3(Random.Range(-rangeOfSpawn, rangeOfSpawn), Random.Range(-rangeOfSpawn, rangeOfSpawn), 1);
          
           
            eatArray[i].GetComponent<Renderer>().enabled = true;
            ++i;
            
        } while (i < eatQuanity-1);
        
    }
    void repeater()
    {
        if (eatArray.Count <10)
        {
            
            sizeOfeat+=0.3f;
            rangeOfSpawn+=4;
            scorableIntForScore++;
            eat.transform.localScale=new Vector3(sizeOfeat,sizeOfeat,0);
            spawner();
        }
    }
}

//player.transform.localScale += new Vector3(0.1f, 0, 0);
//player.transform.localScale += new Vector3(0, 0.1f, 0);
//Destroy(wall);