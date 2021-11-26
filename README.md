# ftp-deploy
deployment helper for a very controlled php file deployment

## description

ftp-deploy is a tool with which you can control a syncronization of well, stuff that you need to upload. 
It is actually a tool to help you implement a 5 step process which you can also use for security related checking.

The main aim is to make sure that the target is really exactly like the source after execution while also allowing for specific ignores.

Each step is documented and produces files with detailed information that you can use to check if it really does/did want you want it to do. This also opens ways to change the behaviour of the tool.

- step 1: 
  - Tell ftp-deploy to deliver you information about the contents of a local directory (recursivly, respecting your ignores, like files or directorys, that you do not wish to list)
  - Tell ftp-deploy to deliver you information about the contents of a remote directory (recursivly, respecting your ignores, like files or directorys, that you do not wish to list)

- step 2:
  - You now have 2 directory listings in the same format (source and target). Perform any manipulation you like, e.g. using powershell. This way you can control in detail which folders are recognized by the synchronization process.

- step 3:
  - Tell ftp-deploy to prepare a list of commands that will synchronize both. The result is another text file which contains upload and delete-commands for each file that will need a change.

- step 4:
  - If you like you may now manipulate the list of commands as you like (its a text file again). This way you can manipulate commands that have been prepared for a certain file. Or even simply react to the difference, e.g. if you use it as a security precausion.

- step 5: 
  - Tell ftp-deploy to perform the tasks as contained in the command file.

All text files which are created or used are in the json format which should make the tool pretty compatible with almost everything. 

Although this is the recommended process you are not bound to it. You may generate your command list yourself, there is nothing that will keep you from doing it. 

## examples

### create a listing of a local directory
```
ftpdeploy --describe-dir --local C:\path\ --ignores ignore-something.json --output C:\listing.json
```
This operation creates a json file with loads of information about all the local files. It respects the given ignores.

### create a listing of a remote directory
```
ftpdeploy --describe-dir --ftp --user xxx --password yyy  --host somehost.com --root / --ignores ignore-something.json --output C:\remote-listing.json
```
This operation creates the very same structure but for a remote ftp directory.

### create the difference view between both
```
ftpdeploy --find-differences --source listing.json --target remote-listing.json --output differences-between-source-and-target.json
```

This will create a file listing which will only tell you which files exist, which of those are different or the same.

### create a command list to synchronize both
```
ftpdeploy --create-synchronization-commands --differences differences-between-source-and-target.json --output C:\synchronization-commands.json
```

This will generate a list of commands that are neccessary to make the target the same as the source.

### perform a list of operations
```
ftpdeploy --execute-synchronization --commands C:\synchronization-commands.json --ftp --user xxx --password yyy --host somehost.com --root /
```

This will execute all prepared commands.






