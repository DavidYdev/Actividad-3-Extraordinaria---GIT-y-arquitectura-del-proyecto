using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(Animator))]
public class TransitionManager : MonoBehaviour
{
    private static TransitionManager instance;

    public static TransitionManager Instance{

        get{
            if(instance==null){

                instance=Instantiate(Resources.Load<TransitionManager>("TransitionManager"));
                instance.Init();

             }
            return instance;

             }

        }

    public const string menu_inicio ="MenuInicio";
    public const string level_1 ="Level1";
    public const string level_2 ="level2";
    public const string Victoria ="Victoria";

    public Slider Progression;
    public TextMeshProUGUI ProgressionValue;
    [Multiline]
    


    private Animator animator;
    private int ShowAnim=Animator.StringToHash("Show");
    private void Awake(){

        if(instance==null){

                instance=this;
                Init();

             }else if(instance!=this){


                Destroy(gameObject);
                }

        }


         void Init(){

            animator=GetComponent<Animator>();
            DontDestroyOnLoad(gameObject);
            
         }


    public void LoadScene(string SceneName){

            StartCoroutine(LoadCoroutine(SceneName));

        }

    IEnumerator LoadCoroutine(string SceneName){

        animator.SetBool(ShowAnim,true);

        UpdateProgressValue(0);
        yield return new WaitForSeconds(0.5f);

        var sceneAsync = SceneManager.LoadSceneAsync(SceneName,LoadSceneMode.Single);

        while(!sceneAsync.isDone){

                UpdateProgressValue(sceneAsync.progress);
                yield return null;
             }

        UpdateProgressValue(1);
        animator.SetBool(ShowAnim,false);

        }

    void UpdateProgressValue(float progressValue){

        if(Progression !=null){
            Progression.value=progressValue;
             }
         if(ProgressionValue !=null){
            ProgressionValue.text= $"{progressValue * 100}%";
             }
            
        }

}
