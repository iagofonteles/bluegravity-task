
Scripts Package

>When a assembly reaches a certain maturity it can be turned into packages and uploaded in a separate repo,
like i did with YamlDotNet asset from the store. We can easily reuse its functionality withou introducing more assets to the project.  

>Drafts is me. Ive created some packages to use in my projects and game jams that are public in https://bitbucket.org/bydrafts/workspace/repositories/
The more mature ones are Inventory, Dialogue, I18n nad DataView. I have rewrite a similar version of the Inventory and DataView for this interview.

Assembly Organization

>The {assembly}View is meant to be client side features, mostly views.
Is good to create assembly definitions to avoid creating unintended dependencies like server data referencing a view.

State Machine

>States are good to create consistency of available commands at a given time, when changing state,
we can unmap all inputs and then assign new actions to the same input without generating concurrency.

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

Save Serialization

>ScriptableObject serialization can be handled with yaml automatically by implementing IYamlConvertible,
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
