# GizmoTest

You can open the "Show Gizmos" Window by cliking on Window>Custom>Show Gizmos 
or by cliking on the button "Show Gizmos" on the bottom of each Scene Gizmo Asset (Scriptable Object)

When you click on "Show Gizmos" the text and position of each gizmo appear in the Show Gizmos Window

At this step, if you want to change value, you can't. You need to select a gizmo first

Two way of selection are possible :

1- 
Click on the edit button in the Show Window Window
The selected gizmo is now in red and the value in the Gizmo Editor are now updating when you change it's value

2-
Click on the GizmosManager gameObject in Hierarchy
The scene is now focus on the GizmosManager gameObject and a collider appear in each gizmo
If you click on a gizmo and put your mouse on the Show Gizmos Window, 
the selected gizmo is now in red and the value in the Gizmo Editor are now updating when you change it's value
To end the focus of the GizmosManager gameObject you need to click on another gameObject in the Hierarchy



In this test, I failed to instantiate and manipulate gizmos without a gameObject or script
In order to still be able to present something to you, I decided to create a gameObject (GizmoManager), put a reference script in it and instantiate other scripts inside
I haven't found how to instantiate a tool.move at my editable gizmo to easily change position values.
I also didn't have time to look at how I had to proceed for points g, h and i
