# Corona registration microservices demo
Very tematical demo app were the victims of corona can register and the data can be used for analytics

Technologies:
  - ReactJS for front-end browser access
  - ASP.NET Core 3.1 for back-end 
  - PostgreSQL for database
  - RabbitMQ for messaging queue system
  - SignalR for real-time communication
  - Docker for containerizing
  - Docker compose for container orchestration
  
# The idea of the app
Let's assume that there are thousands of people that register in the app every day. So we need a good architecture to have a place for scaling in the future and also we need to handle somehow the huge daily load on our services. So we want to use a messaging queue system and containerization in order to scale by multiplying instances of our most loaded services.

# How to run corona-registration-microservices-demo app
1. Make sure you have installed on your machine: 
    - Docker for Windows(if you are on Window OS)
    - Gitbash

2. Open Gitbash in the directory where you want to have the project and put the following command in the console to download the project:
    - git clone https://github.com/StoychoMihaylov/corona-registration-microservices-demo.git

3. Go inside the project main directory and open Powershell or CMD. Make sure Docker for Windows is started and running and execute the following commands:
    - docker-compose build
    - docker-compose up
    
4. Go in your favorite browser and hit http://localhost:3001

# Architecture basic scheme

                                                    |--------------------|
                                                    |     ReactJS app    |
                                                    |--------------------|
                                                              |   |-----------------|
                                                              |                     |
                                                    |--------------------|          |
                                                    |   WebGateway API   |          |
                                                    |--------------------|  |--------------|
                                                              |             |    SignalR   |
                                                              |             |--------------|
                                                    |--------------------|          |
                                                    |      RabbitMQ      |          |
                                                    |--------------------|          |
                                                            |   |                   |   
                                               |------------|   |---------|  |------|        
                                               |                          |  |
                                     |--------------------|     |--------------------|
                                     |    Applicant API   |     |  Notification API  |
                                     |--------------------|     |--------------------|
                                               |
                                               |
                                       (----------------)
                                       (----------------)
                                       (   PostgreSQL   )
                                       (----------------)
                                       (----------------)

- ReactJS is the front-end part which consist just a form for registration of new victim
- WebGateway API is used to validate the data that's coming from the client, it also can be used in the future for data aggregation between multiple services.
Currently is used to validate the data and return indication to the user that the data is processing.
- RabbitMQ is the messaing system that transfers the data from WebGateway to the Applicant API and Transfering notification messages from Applicant API
to Notificaton API
- Applicant API is a service that processing data related to corona victims that register in the app and on success it send message to the RabbitMQ with notification
that needs to be processed from Notification API
- Notification API receives notification from RabbitMQ and pushes them to React JS Client through SignalR real-time communication.
