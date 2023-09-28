# Data-Persistence-Starter-Files
The basic package


# Unity-Repository
 UnityProjectRepository
 This is unity tutoral The "Submission: Data persistence in a new repo" work.
 The tutoral is not very detailed. So i make this tutoral to solve it.
 
 Engine version number:2022.3.4f1

1.first one.I need to tell you that everything of need to set instance things, don't add the "DontDestroyOnLoad“ code into its code.
You can take the code of need to set instance into a new creat object as MainUI MenuUI object and them code.
example: some button code in the MenuManager, it's wrong. When you use the "DontDestroyOnLoad“ code Unity will to tell you have not set instance.
so set up a MenuUI object and MenuUI script are used to need to set instance things as text and button.

2.In the last Unity tutoral,make the MainManager move to menu scene from the main scene.but this project don't do that.
you need to make the MenuManager add ”public MenuManager Instance",then use it in MainManager code,like this MenuManager.Instance.Value.
Because when you start the game Unity tell you "not set instance" the MainManager Instance did not be call,so that is a mistake.(that's why make the MenuManager Instance)

3. In my code I add a delete the savefile method it is very useful.Also you can use the UI-inputField make the input words of frame. use the new 
TextMeshPro instead older Text method.

Finally, I do not creat the MainUI object,that is not very well.Because I find the method in the end.
