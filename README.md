# Fidelity API Gateway

### :white_check_mark: Technologies used:
- .NET 5
- CQS
- UnitOfWork
- MediatR
- Ocelot
- Consul
- JWT
- Swagger
- Entity framework Core
- MySql
- Docker
- FluentValidation
- Auto Mapper
- XUnit

## :camera: Project images:

<table>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/diagram.png"/></td>
  </tr>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/consul.png"/></td>
  </tr>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/swagger.png"/></td>
  </tr>
</table>

## :computer: How to run the application?

```bash
# Before executing the commands below you will need the docker installed on your machine

$ cd src
$ docker-compose up -d
```

### Each project will be executed in its url:
- Consul(http://localhost:8500)
- Api Gateway(http://localhost:5100/swagger)
- User Service(http://localhost:5101/swagger)
- Product Service(http://localhost:5102/swagger)

## :camera: Postman:

### Getting the JWT token:

You must first open the "postman" folder or the "Fidelity Requests.postman_collection.json" file in your postman.
There are two folders one for open requests and others that need permission, to generate the JWT token 
just call the end point "Authenticate user" with the same parameters as the example in the image below.

<table>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/postman_1.png"/></td>
  </tr>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/postman_2.png"/></td>
  </tr>
</table>

### Modifying the token in the postman variable:

After generating the token, you can modify it by clicking on the "Fidelity Requests" folder and going to
"variables" and in the "current value" define the name of the variable "token" where you will place the token that was generated.

<table>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/postman_3.png"/></td>
  </tr>
  <tr>
    <td valign="top"><img src="https://github.com/reinanbruno/fidelity-microservice/blob/master/images/postman_4.png"/></td>
  </tr>
</table>




