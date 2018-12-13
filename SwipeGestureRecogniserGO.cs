using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DigitalRubyShared;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SwipeGestureRecogniserGO : MonoBehaviour {

    private SwipeGestureRecognizer swipeGestureUp;
    private SwipeGestureRecognizer swipeGestureRight;
    private SwipeGestureRecognizer swipeGestureDown;
    private SwipeGestureRecognizer swipeGestureLeft;

    private GameObject instansiatedHat ;
    private GameObject instansiatedEffect ;


    public Animator dragonAnimator;
    public Animator milaAnimator;
    public Animator chernomorAnimator;
    public Animator finnAnimator;
    public Animator kitAnimator;
    public Animator volodymyrAnimator;
    public Animator ruslanAnimator;
    public Animator lestorAnimator;
    public Animator humsterAnimator;

    // Audio
    public AudioSource audioSource;

    //dragon tracks
    public AudioHolder dragonAudio;
    //mila tracks
    public AudioHolder milaAudio;
    //chernomor tracks
    public AudioHolder chernomorAudio;
    // finn
    public AudioHolder finnAudio;
    //kit
    public AudioHolder kitAudio;
    //volodymyr
    public AudioHolder volodymyrAudio;
    //ruslan
    public AudioHolder ruslanAudio;
    //lestor
    public AudioHolder lestorAudio;
    public AudioHolder humsterAudio;

    //mila controller
    public MilaClick milaController;
    public ChernomorClick chernomorController;
    public FinnClick finnController;
    public KitClick kitController;
    public VolodymyrClick volodymyrController;
    public RuslanClick ruslanController;
    public LestorClick lestorController;
    public HumsterClick humsterController;

   


    [HideInInspector]
    public bool animationIsRunning = false;
    //active scene
    [HideInInspector]
    public bool dragon = false;
    [HideInInspector]
    public bool mila = false;
    [HideInInspector]
    public bool chernomor = false;
    [HideInInspector]
    public bool finn = false;
    [HideInInspector]
    public bool kit = false;
    [HideInInspector]
    public bool volodymyr = false;
    [HideInInspector]
    public bool ruslan = false;
    [HideInInspector]
    public bool lestor = false;

    [HideInInspector]
    public bool humster = false;
    //
    [HideInInspector]
    public bool milaSmall = false;
    [HideInInspector]
    public bool chernomorSmall = false;
    [HideInInspector]
    public bool kitSmall = false;
    [HideInInspector]
    public bool volodymyrSmall = false;
    [HideInInspector]
    public bool ruslanSmall = false;
    [HideInInspector]
    public bool lestorSmall = false;

    //

    // Use this for initialization
    private void Awake()
    {
        Debug.Log("destroyed");
        if (FindObjectOfType<GlobalAudio>() != null)
        {
            Destroy(FindObjectOfType<GlobalAudio>().gameObject);
        }
    }

    void Start () {
        CreateSwipeGestureUp();
        CreateSwipeGestureRight();
        CreateSwipeGestureDown();
        CreateSwipeGestureLeft();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
       
	}

    private void CreateSwipeGestureUp()
    {
        swipeGestureUp = new SwipeGestureRecognizer();
        swipeGestureUp.Direction = SwipeGestureRecognizerDirection.Up;
        swipeGestureUp.StateUpdated += SwipeGestureCallbackUp;
        swipeGestureUp.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGestureUp);
    }

    private void SwipeGestureCallbackUp(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended && !animationIsRunning)
        {
            //dragon
            if(dragon){dragonFlightAnimation();}
            //mila
            if (mila){milaMovementAnimation();}
            //chernomor
            if (chernomor) { chernomorMovementAnimation();}
            //finn
            if (finn) { finnMovementAnimation(); }
            //kit
            if (kit) { kitMovementAnimation(); }
            //volodymyr
            if (volodymyr) { volodymyrMovementAnimation(); }
            //ruslan
            if (ruslan) { ruslanMovementAnimation(); }
            //lestor
            if (lestor) { lestorMovementAnimation(); }

            Debug.Log("Swiped Up");

            //StartCoroutine(WaitTwoSec(2f));

        }
    }

    private void CreateSwipeGestureRight()
    {
        swipeGestureRight = new SwipeGestureRecognizer();
        swipeGestureRight.Direction = SwipeGestureRecognizerDirection.Right;
        swipeGestureRight.StateUpdated += SwipeGestureCallbackRight;
        swipeGestureRight.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGestureRight);
    }

    private void SwipeGestureCallbackRight(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended && !animationIsRunning)
        {
            //testImageRight.GetComponent<Image>().enabled = true;
            Debug.Log("Swiped Right");
            //StartCoroutine(WaitTwoSec(2f));
        }
    }

    private void CreateSwipeGestureDown()
    {
        swipeGestureDown = new SwipeGestureRecognizer();
        swipeGestureDown.Direction = SwipeGestureRecognizerDirection.Down;
        swipeGestureDown.StateUpdated += SwipeGestureCallbackDown;
        swipeGestureDown.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGestureDown);
    }

    private void SwipeGestureCallbackDown(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended && !animationIsRunning)
        {
            //dragon
            if (dragon){dragonIntroductionAnimation();}
            //mila
            if (mila){milaIntroductionAnimation();}
            //chernomor
            if (chernomor) { chernomorIntroductionAnimation(); }
            //finn
            if (finn) { finnIntroductionAnimation(); }
            //kit
            if (kit) { kitIntroductionAnimation(); }
            //volodymyr
            if (volodymyr) { volodymyrIntroductionAnimation(); }
            //ruslan
            if (ruslan) { ruslanIntroductionAnimation(); }
            //lestor
            if (lestor) { lestorIntroductionAnimation(); }
            if (humster) { humsterIntroductionAnimation(); }

            Debug.Log("Swiped Down");
           // StartCoroutine(WaitTwoSec(2f));
        }
    }

    private void CreateSwipeGestureLeft()
    {
        swipeGestureLeft = new SwipeGestureRecognizer();
        swipeGestureLeft.Direction = SwipeGestureRecognizerDirection.Left;
        swipeGestureLeft.StateUpdated += SwipeGestureCallbackLeft;
        swipeGestureLeft.DirectionThreshold = 1.0f; // allow a swipe, regardless of slope
        FingersScript.Instance.AddGesture(swipeGestureLeft);
    }

    private void SwipeGestureCallbackLeft(GestureRecognizer gesture)
    {
        if (gesture.State == GestureRecognizerState.Ended && !animationIsRunning)
        {
            //testImageLeft.GetComponent<Image>().enabled = true;
            Debug.Log("Swiped Left");
            //StartCoroutine(WaitTwoSec(2f));
        }
    }

    IEnumerator WaitTwoSec (float time){
        Debug.Log("corutine");
        yield return new WaitForSeconds(time);
        // dragon
        dragonAnimator.SetBool("Reaction", false);
        dragonAnimator.SetBool("Flight", false);
        //mila
        milaAnimator.SetBool("introduction", false);
        milaAnimator.SetBool("move", false);
        //chernomor
        chernomorAnimator.SetBool("introduction", false);
        chernomorAnimator.SetBool("move", false);
        // 
        finnAnimator.SetBool("introduction", false);
        finnAnimator.SetBool("move", false);
        //
        kitAnimator.SetBool("introduction", false);
        kitAnimator.SetBool("move", false);
        //
        volodymyrAnimator.SetBool("introduction", false);
        volodymyrAnimator.SetBool("move", false);
        //
        ruslanAnimator.SetBool("introduction", false);
        ruslanAnimator.SetBool("move", false);
        //
        lestorAnimator.SetBool("introduction", false);
        lestorAnimator.SetBool("move", false);
        //
        humsterAnimator.SetBool("introduction", false);
        humsterAnimator.SetBool("move", false);

    }

    IEnumerator unlockAnimations()
    {
        Debug.Log("unlockAnimations");
        yield return new WaitForSeconds(12);
        //
        audioSource.Stop();

        //for all
        animationIsRunning = false;
    }

    IEnumerator milaUnlockAnimations(){
        yield return new WaitForSeconds(12);
        animationIsRunning = false;
    }

    IEnumerator milaUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(6f);
       // Destroy(instansiatedHat);
       
        var children = milaController.gameObject.GetComponentsInChildren<Renderer>(true);

        foreach (var child in children)
        {
            child.enabled = true;
        }
        animationIsRunning = false;
    }

    IEnumerator milaDissapear(){
        yield return new WaitForSeconds(3.3f);
        var children = milaController.gameObject.GetComponentsInChildren<Renderer>(true);
        milaController.hat.GetComponent<Renderer>().enabled = false;
        Destroy(instansiatedHat);
        milaController.particleDissapear.Play();
        foreach (var child in children){
            if (child.name != "MilaDissapear")
            {
                child.enabled = false;
            }
        }

    }

    IEnumerator flightAnimation(){
        yield return new WaitForSeconds(31);
        animationIsRunning = false;
    }
    /// ////////////////
    public void backButton()
    {
        SceneManager.LoadScene("ENG_0_TutorialScreenPuzzle");
    }
    public void backButtonUA()
    {
        SceneManager.LoadScene("UA_0_TutorialScreenPuzzle");
    }
    public void backButtonRU()
    {
        SceneManager.LoadScene("RU_0_TutorialScreenPuzzle");
    }
   
    /// ///////////////////////////


    private void dragonFlightAnimation(){
        animationIsRunning = true;
        dragonAnimator.SetBool("Flight", true);
        //audio
        audioSource.clip = dragonAudio.action;
        audioSource.Play();
        //
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(flightAnimation());
    }

    private void dragonIntroductionAnimation(){
        animationIsRunning = true;
        //audio
        audioSource.clip = dragonAudio.introduction;
        audioSource.Play();
        //
        dragonAnimator.SetBool("Reaction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(unlockAnimations());
    }

    private void milaMovementAnimation(){
        animationIsRunning = true;
        audioSource.clip = milaAudio.action;
        audioSource.Play();
        milaAnimator.SetBool("move", true);
        instansiatedHat = Instantiate(milaController.hat, milaController.hatAnchor);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(milaDissapear());
        StartCoroutine(milaUnlockAnimationsMove());

    }
    private void milaIntroductionAnimation(){
        animationIsRunning = true;
        audioSource.clip = milaAudio.introduction;
        audioSource.Play();
        milaAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(milaUnlockAnimations());
    }

    //chernomor part
    private void chernomorIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = chernomorAudio.introduction;
        audioSource.Play();
        chernomorAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(chernomorUnlockAnimations());
    }

    IEnumerator chernomorUnlockAnimations()
    {
        yield return new WaitForSeconds(12);
        animationIsRunning = false;
    }
    IEnumerator chernomorUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(8f);
       
        animationIsRunning = false;
    }

    private void chernomorMovementAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = chernomorAudio.action;
        audioSource.Play();
        chernomorAnimator.SetBool("move", true);

        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(chernomorUnlockAnimationsMove());

    }
    //
    // finn part

    private void finnMovementAnimation()
    {

        animationIsRunning = true;
        audioSource.clip = finnAudio.action;
        audioSource.Play();
        finnAnimator.SetBool("move", true);
        instansiatedEffect = Instantiate(finnController.magicEffects, finnController.gameObject.transform.parent.transform);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(finnUnlockAnimationsMove());

    }
    IEnumerator finnUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(13f);
        Destroy(instansiatedEffect);
        animationIsRunning = false;
    }

    private void finnIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = finnAudio.introduction;
        audioSource.Play();
        finnAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(finnUnlockAnimations());
    }

    IEnumerator finnUnlockAnimations()
    {
        yield return new WaitForSeconds(5);
        animationIsRunning = false;
    }

    //
    //kit
    private void kitIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = kitAudio.introduction;
        audioSource.Play();
        kitAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(kitUnlockAnimations());
    }

    IEnumerator kitUnlockAnimations()
    {
        yield return new WaitForSeconds(6);
        animationIsRunning = false;
    }

    private void kitMovementAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = kitAudio.action;
        audioSource.Play();
        kitAnimator.SetBool("move", true);

        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(kitUnlockAnimationsMove());

    }
    IEnumerator kitUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(6f);
        animationIsRunning = false;
    }

    //
    //volodymyr
    private void volodymyrIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = volodymyrAudio.introduction;
        audioSource.Play();
        volodymyrAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(volodymyrUnlockAnimations());
    }

    IEnumerator volodymyrUnlockAnimations()
    {
        yield return new WaitForSeconds(5);
        animationIsRunning = false;
    }

    private void volodymyrMovementAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = volodymyrAudio.action;
        audioSource.Play();
        volodymyrAnimator.SetBool("move", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(volodymyrUnlockAnimationsMove());

    }
    IEnumerator volodymyrUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(11f);
        animationIsRunning = false;
    }


    //
    //ruslan
    private void ruslanIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = ruslanAudio.introduction;
        audioSource.Play();
        ruslanAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(ruslanUnlockAnimations());
    }

    IEnumerator ruslanUnlockAnimations()
    {
        yield return new WaitForSeconds(5);
        animationIsRunning = false;
    }

    private void ruslanMovementAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = ruslanAudio.action;
        audioSource.Play();
        ruslanAnimator.SetBool("move", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(ruslanUnlockAnimationsMove());

    }
    IEnumerator ruslanUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(5f);
        animationIsRunning = false;
    }

    //lestor
    private void lestorIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = lestorAudio.introduction;
        audioSource.Play();
        lestorAnimator.SetBool("introduction", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(lestorUnlockAnimations());
    }

    IEnumerator lestorUnlockAnimations()
    {
        yield return new WaitForSeconds(5);
        animationIsRunning = false;
    }

    private void lestorMovementAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = lestorAudio.action;
        audioSource.Play();
        lestorAnimator.SetBool("move", true);
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(lestorUnlockAnimationsMove());

    }
    IEnumerator lestorUnlockAnimationsMove()
    {
        yield return new WaitForSeconds(5f);
        animationIsRunning = false;
    }
    //
    //humster
    private void humsterIntroductionAnimation()
    {
        animationIsRunning = true;
        audioSource.clip = humsterAudio.introduction;
        audioSource.Play();
        humsterAnimator.SetBool("introduction", true);
        StartCoroutine(humsterDissapear());
        StartCoroutine(WaitTwoSec(1));
        StartCoroutine(humsterUnlockAnimations());
    }

    IEnumerator humsterDissapear()
    {
        yield return new WaitForSeconds(12f);
        var children = humsterController.gameObject.GetComponentsInChildren<Renderer>(true);

        humsterController.particleDissapear.Play();
        foreach (var child in children)
        {
            if (child.name != "HumsterDissapear")
            {
                child.enabled = false;
            }
        }

    }

    IEnumerator humsterUnlockAnimations()
    {
        yield return new WaitForSeconds(14f);
        // Destroy(instansiatedHat);

        var children = humsterController.gameObject.GetComponentsInChildren<Renderer>(true);

        foreach (var child in children)
        {
            child.enabled = true;
        }
        animationIsRunning = false;
    }
}
