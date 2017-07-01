# RemoteQueryTool
This was created forever ago and can largely be replaced by PowerShell scripts.

The Remote Query Tool is primarily an administrative tool designed to pull information from a large list of computers in parallel. It then outputs the information into an excel compatible XML file. It is designed to use multiple threads and checks that the computers are running before attempting potentially time consuming commands. These features allow the tool to query a list of machines for information on their registry, services, processes. It's use can be further extended with custom commands. 

## Using the applications general features

1. Select either a single computer or a list of computers to query.
    1. To query single computer, click the “Perform query on one computer” radio button, and enter the IP or name of the machine.
    2. To query a list of computers, click the “Perform query on a list of computers” radio button. Then click browse, and select the file that contains your list of computers. The list should be a regular ANSI/ASCII/UTF8 file that has each machine name or IP entered on separate lines.
2. Next select an output file.
    1. Click browse, then type in a file name. In the “types” box, you can select a file format. There are currently two options; an Excel compatible XML format, and a tab delimited txt file. (XML is generally best)
    2. Select the amount of simultaneous queries to perform. This can increases the speed at which the application processes a list of machines. The best selection for this option depends on how powerful your computer is, how many cores you have, and what query you are performing. Your minimum without losing speed is about 1 query per core; most computers can handle more though.

The next steps depend on what query you perform. Note that all machines to be queried are pinged first, if the ping fails, the query will not be attempted on the machine. If you wish to save your layout and all the options you have set, you can click "File">"Save Setup". When you want to load the layout again, you can click "File">"Load Setup", and select the file that you previously saved.

## Query one or more machine's registries

1. Select which ever hive key you are interested in.
2. Insert a key path (excluding the hive key). Example: "SOFTWARE\Microsoft\COM3\BuildType"
    - If you want to browse for a specific key, click “Help Me”
        1. When the dialog box pops up, type in the machine name or IP of the machine you are interested in browsing.
        2. When you have selected a key, click “OK” and the path will be auto filled on the main form.
3. Click which type of query you are interested. (Whether the key exists, if the key’s value is equal to something specific, or just list the values)
    -Enter a value to compare the key against if you selected “Is value equal to”
4. Click go and wait for the threads to finish.
5. When finished, you can click “Open Output” to open the generated log in the default program.

## Query a process or service

1. Click the Processes/Services tab.
2. Select whether it is a process or service you are interested in.
3. Select which query you are interested in performing (Find a specific process/services, or list processes/services)
    1. If you select “Find” then type in the name of the process/service.
        - If you are Finding a specific service, you also have the option to remotely restart it if found.
    2. If you selected “List all”, it will list all non - device driver services or all running applications. Device services or processes that are not running will not be listed.
4. Click go and wait for the threads to finish.
5. When finished, you can click “Open Output” to open the generated log in the default program.

## Run custom commands

1. Enter in your batch commands on the 5 provided spaces.
    - No remoting is provided with this feature. Any remoting must be done by the commands typed. This has been made easier as the variable “machine” will be automatically set to the IP or name of the currently queried machine. You can access the variable by typing %machine%. An example command that works under these restrictions is "shutdown – s – m %machine%"
    - Permissions required vary per command.
2. For a slightly neater output, you can select @echo off to remove some of the extra output.
