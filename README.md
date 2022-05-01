# mongodb_lab
mongodb exercise 
The exercise will host mongodb in docker container. 

## Install mongodb Setup on windows 11 
1. Download and install docker desktop
2. Dowload and install mongodb following instruction of link (https://hub.docker.com/_/mongo) via docker command
    - `c:\Users\dongz\docker pull mongo`
3. run mongodb in docker as below 
    - Open Docker Desktop, the downloaded mongodb will display in the image list, then click the Run button and enter the setting of the mongodb instance below
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-1a.png)
4. Install Mongodb Compass on WIN 11 (a GUI db management studio tool) 
5. Open Mongodb Compass, click new Connection to connect Mongodb database instance and enter 8088 as a port number of local server as below 
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-2a.png)
6. Create a Mongodb database 'mytestdb' and table 'stores' as below 
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-3a.png)
7. import json data into table 'stores' as below 
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-4a.png)
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-5a.png)
8. Create text index on the two columns 'name' and 'description' as below
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-6a.png)
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-7a.png)
9. perform text search via entering filter expression `{ $text: { $search: "\"coffee\"" } } ` as below
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-8a.png)
    - ![](https://github.com/dongzhao/mongodb_lab/blob/main/Screenshot-9a.png)
