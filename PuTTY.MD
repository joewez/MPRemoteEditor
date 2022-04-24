# Configuring MPRemote Editor To Use The PuTTY Serial Terminal

I have found that using an external application for handling the serial REPL better for the following reasons:
1. Allows complete control over look and appearance
2. Adds support for full-screen editing with the embedded editor

---
<b>To Configure:</b>

1. Download and Install PuTTy from here https://www.putty.org/
2. Configure the PuTTy session...
    1.   Connection Type:  Serial
    2.   Window -> Appearance -> Anything you see fit to change
    3.   Window -> Behaviour -> Uncheck "Warn before closing window"
    4.   Window -> Colours -> Anything you see fit to change
    5.   Connection -> Speed:115200, Data bits:8, Stop bits:1, Flow Control:None
3. Save the session name as...
     ``mpremoteeditor``
4. Make these changes to the MPRemoteEditor.exe.config
    1.   ``<add key="REPL" value="E" />``
    2.   ``<add key="TerminalApp" value="putty" />``
        (to whatever command invokes PuTTy)
  
--- 

Now when you click on the REPL button it will invoke the PuTTY application.
