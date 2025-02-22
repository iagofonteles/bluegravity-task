
Assets Organization

>I like to isolate the assets for entites in a single folder, this makes easier to track dependencies.
The entity folder does this. Becaus the scenario assets are reused most of the times, i separate them in the enviorement folder.

>Prefabs for entities should have the most important configuration script on root so it can easily be editted wihout open the prefab
(see entity/gather spot prefab variants).

>We should avoid overriding prefab on scene when possible, specially if the modification is not in the root.
That why ive put a wrapper to player prefabs (player props) in the scene that sends data to the prefabs.

BlockingTask

>To stop player actions use the BlockingTask by simply activate and deactivate the component in any object.
Multiple tasks may exist. Usually i put this a BlockingTask in prefabs like Dialogues and Shops.

State Machine

>States are good to create consistency of available commands at a given time, when changing state,
we can unmap all inputs and then assign new actions to the same input without generating concurrency.

Scripts Package

>When a assembly reaches a certain maturity it can be turned into packages and uploaded in a separate repo,
like i did with YamlDotNet asset from the store. We can easily reuse its functionality withou introducing more assets to the project.  

>Drafts is me. Ive created some packages to use in my projects and game jams that are public in https://bitbucket.org/bydrafts/workspace/repositories/
The more mature ones are Inventory, Dialogue, I18n and DataView. I have rewrite a similar version of the Inventory and DataView for this interview.

Assembly Organization

>The {assembly}View is meant to be client side features, mostly views.
Is good to create assembly definitions to avoid creating unintended dependencies like server data referencing a view.

UI View and Controller

>The DataView class creates an easy and flexible way to propagate data throught the ui.
Similar to MVC, i like to separate methods that modify data in a Controller class and leave the View just for display.

>For Generic classes is best to have a non generic underlying interface so we dont need do create many Views for each used type.

>When creating a View for a class with multiple interfaces, create the interface view first and then, the class View with only the remaining fields.
Then, use the DataView.onDataChanged to propagate the object to the multiple views.

SerializeReference

>With the help of some Editor tools SerializeReference becomes very powerful for unique behaviors. 
It avoids creating multiple SOs that will be only referenced once. 
Although we shouldnt use it too much sinsce it is vulnerable to code refactoring.

Addressables

>Database items that comes from ScriptableObjects needs special treatment.
We want to fetch it from a existing list instead of create new SOs on deserialization.
To do this i created the Database class that fetch SOs from addressables on startup.

>If there are many items, may be better to create a dictionary using ResourceLocation  strings instead of actually loading all items.
Using soft references to sprites and prefabs will also increase startup time.

Save Serialization

>ScriptableObject serialization can be handled with yaml automatically by implementing IYamlConverter,
this eliminates the need of Player.Serialization.cs (but i didnt have time to implement it)

>I personally like yaml better cause it has less atifacts nad is more compact and readable,
but when shipping the game may be better to change the serializer to a less readable format though.

Reutilized Code

>The following scripts where borrowed from my package or other projects
So, were not written for the interview.
Aside from StateMachine, they are mostly editor tools

    Scripts/Inventory/Editor/SlotDrawer.cs
    Scripts/Utility/StateMachine/*
    Scripts/Utility/Search/*
    Scripts/Utility/TypeCache/*
    Packages/DraftsInternationalization
