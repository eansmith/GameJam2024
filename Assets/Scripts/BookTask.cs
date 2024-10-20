using UnityEngine;
using UnityEngine.UI;
public class BookTask : MonoBehaviour, Task
{
    public KeyCode k1;
    
    public GameManager gm;

    public Player player;
    public bool inRadius;
    public bool active;

    public GameObject L1;
    public GameObject L2;
    public GameObject L3;
    public GameObject L4;

    GameObject [] letters;
    GameObject cvs;

    public float task_timer;
    bool decreasing;
    GameObject taskUI;

    string word;
    int wordind;

    char [] lets;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        task_timer = 0;
        active = false;
        GameObject cvsc;
        cvsc = this.transform.GetChild(6).gameObject;

        //cvs = this;
        taskUI = this.gameObject.transform.GetChild(6).gameObject;
        taskUI.SetActive(false);
        //this.setActive(false);
        decreasing  = false;
        Debug.Log(taskUI.ToString());
        Debug.Log(taskUI.transform.GetChild(0).gameObject.ToString());
        
        L1 = taskUI.transform.GetChild(0).gameObject;
        L2 = taskUI.transform.GetChild(1).gameObject;
        L3 = taskUI.transform.GetChild(2).gameObject;
        L4 = taskUI.transform.GetChild(3).gameObject;


        L1.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(255,255,255);
        L2.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(255,255,255);
        L3.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(255,255,255);
        L4.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(255,255,255);


        //Activate();


    }

    // Update is called once per frame
    void Update()
    {
        if(active && inRadius){
            Debug.Log("Hey active and updating");
            Debug.Log(wordind);
            switch (wordind){
                case 0:
                    if(word[0] == 'O' && Input.GetKeyDown(KeyCode.O)){
                       wordind++;
                       L1.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);
                    }
                    else if(word[0] == 'B' && Input.GetKeyDown(KeyCode.B)){
                        wordind++;
                       L1.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[0] == 'Q' && Input.GetKeyDown(KeyCode.Q)){
                        wordind++;
                        L1.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[0] == 'K' && Input.GetKeyDown(KeyCode.K)){
                        wordind++;
                        L1.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else{
                        break;
                    }
                    break;

                case 1:
                    if(word[1] == 'O' &&  Input.GetKeyDown(KeyCode.O)){
                        wordind++;
                        L2.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[1] == 'B' &&  Input.GetKeyDown(KeyCode.B)){
                        wordind++;
                        L2.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[1] == 'Q' &&  Input.GetKeyDown(KeyCode.Q)){
                        wordind++;
                        L2.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[1] == 'K' &&  Input.GetKeyDown(KeyCode.K)){
                        wordind++;
                        L2.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else{
                        break;
                    }
                    break;



                case 2:
                    if(word[2] == 'O' &&  Input.GetKeyDown(KeyCode.O)){
                        wordind++;
                        L3.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[2] == 'B' &&  Input.GetKeyDown(KeyCode.B)){
                        wordind++;
                        L3.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[2] == 'Q' &&  Input.GetKeyDown(KeyCode.Q)){
                        wordind++;
                        L3.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else if(word[2] == 'K' &&  Input.GetKeyDown(KeyCode.K)){
                        wordind++;
                        L3.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);

                    }
                    else{
                        break;
                    }
                    break;


                case 3:
                    if(word[3] == 'O' &&  Input.GetKeyDown(KeyCode.O)){
                        wordind++;
                        L4.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);
                        Deactivate();

                    }
                    else if(word[3] == 'B' &&  Input.GetKeyDown(KeyCode.B)){
                        wordind++;
                        L4.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);
                        Deactivate();

                    }
                    else if(word[3] == 'Q' &&  Input.GetKeyDown(KeyCode.Q)){
                        wordind++;
                        L4.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);
                        Deactivate();


                    }
                    else if(word[3] == 'K' &&  Input.GetKeyDown(KeyCode.K)){
                        wordind++;
                        L4.GetComponent<TMPro.TextMeshProUGUI>().color= new Color(0,255,0);
                        Deactivate();


                    }
                    else{
                        break;
                    }
                    break;

            }
        }
    }

    public bool IsActive(){
        return active;
    }

    public void Activate(){
        Debug.Log("active");

        //this.SetActive(true);  
        taskUI.SetActive(true);         
        active = true;
        string st = "BOQK";
        //char c = st[Random.Range(0, st.Length)];

        char c = st[Random.Range(0, st.Length)];
        L1.GetComponent<TMPro.TextMeshProUGUI>().text = c.ToString();
        word+=c;

        c = st[Random.Range(0, st.Length)];
        L2.GetComponent<TMPro.TextMeshProUGUI>().text = c.ToString();
        word+=c;

        c = st[Random.Range(0, st.Length)];
        L3.GetComponent<TMPro.TextMeshProUGUI>().text = c.ToString();
        word+=c;

        c = st[Random.Range(0, st.Length)];
        L4.GetComponent<TMPro.TextMeshProUGUI>().text = c.ToString();
        word+=c;

        Debug.Log(word);

    }

     private void OnTriggerEnter(Collider other){
        if(other.tag == "Player" && active){
            inRadius = true;
        }
    }

    private void OnTriggerExit(Collider other){
        if(other.tag == "Player" && active){
            inRadius = false;
        }
    }

    public void Deactivate(){
        taskUI.SetActive(false);
        active = false;
        gm.taskActive = false;
    }

}
