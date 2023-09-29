<a name='assembly'></a>
# PetStore.API.Swagger

## Contents

- [Order](#T-PetStore-API-Swagger-Controllers-Generated-Order 'PetStore.API.Swagger.Controllers.Generated.Order')
  - [Status](#P-PetStore-API-Swagger-Controllers-Generated-Order-Status 'PetStore.API.Swagger.Controllers.Generated.Order.Status')
- [Pet](#T-PetStore-API-Swagger-Controllers-Generated-Pet 'PetStore.API.Swagger.Controllers.Generated.Pet')
  - [Status](#P-PetStore-API-Swagger-Controllers-Generated-Pet-Status 'PetStore.API.Swagger.Controllers.Generated.Pet.Status')
- [PetControllerBase](#T-PetStore-API-Swagger-Controllers-Generated-PetControllerBase 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase')
  - [AddPet(body)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-AddPet-PetStore-API-Swagger-Controllers-Generated-Pet- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.AddPet(PetStore.API.Swagger.Controllers.Generated.Pet)')
  - [DeletePet(petId)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-DeletePet-System-String,System-Int64- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.DeletePet(System.String,System.Int64)')
  - [FindPetsByStatus(status)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-FindPetsByStatus-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-Anonymous}- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.FindPetsByStatus(System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.Anonymous})')
  - [FindPetsByTags(tags)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-FindPetsByTags-System-Collections-Generic-IEnumerable{System-String}- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.FindPetsByTags(System.Collections.Generic.IEnumerable{System.String})')
  - [GetPetById(petId)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-GetPetById-System-Int64- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.GetPetById(System.Int64)')
  - [UpdatePet(body)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UpdatePet-PetStore-API-Swagger-Controllers-Generated-Pet- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.UpdatePet(PetStore.API.Swagger.Controllers.Generated.Pet)')
  - [UpdatePetWithForm(petId,name,status)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UpdatePetWithForm-System-Int64,System-String,System-String- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.UpdatePetWithForm(System.Int64,System.String,System.String)')
  - [UploadFile(petId,additionalMetadata,file)](#M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UploadFile-System-Int64,System-String,PetStore-API-Swagger-Controllers-Generated-FileParameter- 'PetStore.API.Swagger.Controllers.Generated.PetControllerBase.UploadFile(System.Int64,System.String,PetStore.API.Swagger.Controllers.Generated.FileParameter)')
- [StoreControllerBase](#T-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase 'PetStore.API.Swagger.Controllers.Generated.StoreControllerBase')
  - [DeleteOrder(orderId)](#M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-DeleteOrder-System-Int64- 'PetStore.API.Swagger.Controllers.Generated.StoreControllerBase.DeleteOrder(System.Int64)')
  - [GetInventory()](#M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-GetInventory 'PetStore.API.Swagger.Controllers.Generated.StoreControllerBase.GetInventory')
  - [GetOrderById(orderId)](#M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-GetOrderById-System-Int64- 'PetStore.API.Swagger.Controllers.Generated.StoreControllerBase.GetOrderById(System.Int64)')
  - [PlaceOrder(body)](#M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-PlaceOrder-PetStore-API-Swagger-Controllers-Generated-Order- 'PetStore.API.Swagger.Controllers.Generated.StoreControllerBase.PlaceOrder(PetStore.API.Swagger.Controllers.Generated.Order)')
- [User](#T-PetStore-API-Swagger-Controllers-Generated-User 'PetStore.API.Swagger.Controllers.Generated.User')
  - [UserStatus](#P-PetStore-API-Swagger-Controllers-Generated-User-UserStatus 'PetStore.API.Swagger.Controllers.Generated.User.UserStatus')
- [UserControllerBase](#T-PetStore-API-Swagger-Controllers-Generated-UserControllerBase 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase')
  - [CreateUser(body)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUser-PetStore-API-Swagger-Controllers-Generated-User- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.CreateUser(PetStore.API.Swagger.Controllers.Generated.User)')
  - [CreateUsersWithArrayInput(body)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUsersWithArrayInput-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-User}- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.CreateUsersWithArrayInput(System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User})')
  - [CreateUsersWithListInput(body)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUsersWithListInput-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-User}- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.CreateUsersWithListInput(System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User})')
  - [DeleteUser(username)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-DeleteUser-System-String- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.DeleteUser(System.String)')
  - [GetUserByName(username)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-GetUserByName-System-String- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.GetUserByName(System.String)')
  - [LoginUser(username,password)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-LoginUser-System-String,System-String- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.LoginUser(System.String,System.String)')
  - [LogoutUser()](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-LogoutUser 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.LogoutUser')
  - [UpdateUser(username,body)](#M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-UpdateUser-System-String,PetStore-API-Swagger-Controllers-Generated-User- 'PetStore.API.Swagger.Controllers.Generated.UserControllerBase.UpdateUser(System.String,PetStore.API.Swagger.Controllers.Generated.User)')

<a name='T-PetStore-API-Swagger-Controllers-Generated-Order'></a>
## Order `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='P-PetStore-API-Swagger-Controllers-Generated-Order-Status'></a>
### Status `property`

##### Summary

Order Status

<a name='T-PetStore-API-Swagger-Controllers-Generated-Pet'></a>
## Pet `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='P-PetStore-API-Swagger-Controllers-Generated-Pet-Status'></a>
### Status `property`

##### Summary

pet status in the store

<a name='T-PetStore-API-Swagger-Controllers-Generated-PetControllerBase'></a>
## PetControllerBase `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-AddPet-PetStore-API-Swagger-Controllers-Generated-Pet-'></a>
### AddPet(body) `method`

##### Summary

Add a new pet to the store

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [PetStore.API.Swagger.Controllers.Generated.Pet](#T-PetStore-API-Swagger-Controllers-Generated-Pet 'PetStore.API.Swagger.Controllers.Generated.Pet') | Pet object that needs to be added to the store |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-DeletePet-System-String,System-Int64-'></a>
### DeletePet(petId) `method`

##### Summary

Deletes a pet

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| petId | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Pet id to delete |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-FindPetsByStatus-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-Anonymous}-'></a>
### FindPetsByStatus(status) `method`

##### Summary

Finds Pets by status

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| status | [System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.Anonymous}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.Anonymous}') | Status values that need to be considered for filter |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-FindPetsByTags-System-Collections-Generic-IEnumerable{System-String}-'></a>
### FindPetsByTags(tags) `method`

##### Summary

Finds Pets by tags

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| tags | [System.Collections.Generic.IEnumerable{System.String}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{System.String}') | Tags to filter by |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-GetPetById-System-Int64-'></a>
### GetPetById(petId) `method`

##### Summary

Find pet by ID

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| petId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | ID of pet to return |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UpdatePet-PetStore-API-Swagger-Controllers-Generated-Pet-'></a>
### UpdatePet(body) `method`

##### Summary

Update an existing pet

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [PetStore.API.Swagger.Controllers.Generated.Pet](#T-PetStore-API-Swagger-Controllers-Generated-Pet 'PetStore.API.Swagger.Controllers.Generated.Pet') | Pet object that needs to be added to the store |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UpdatePetWithForm-System-Int64,System-String,System-String-'></a>
### UpdatePetWithForm(petId,name,status) `method`

##### Summary

Updates a pet in the store with form data

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| petId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | ID of pet that needs to be updated |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Updated name of the pet |
| status | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Updated status of the pet |

<a name='M-PetStore-API-Swagger-Controllers-Generated-PetControllerBase-UploadFile-System-Int64,System-String,PetStore-API-Swagger-Controllers-Generated-FileParameter-'></a>
### UploadFile(petId,additionalMetadata,file) `method`

##### Summary

uploads an image

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| petId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | ID of pet to update |
| additionalMetadata | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | Additional data to pass to server |
| file | [PetStore.API.Swagger.Controllers.Generated.FileParameter](#T-PetStore-API-Swagger-Controllers-Generated-FileParameter 'PetStore.API.Swagger.Controllers.Generated.FileParameter') | file to upload |

<a name='T-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase'></a>
## StoreControllerBase `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-DeleteOrder-System-Int64-'></a>
### DeleteOrder(orderId) `method`

##### Summary

Delete purchase order by ID

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| orderId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | ID of the order that needs to be deleted |

<a name='M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-GetInventory'></a>
### GetInventory() `method`

##### Summary

Returns pet inventories by status

##### Returns

successful operation

##### Parameters

This method has no parameters.

<a name='M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-GetOrderById-System-Int64-'></a>
### GetOrderById(orderId) `method`

##### Summary

Find purchase order by ID

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| orderId | [System.Int64](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Int64 'System.Int64') | ID of pet that needs to be fetched |

<a name='M-PetStore-API-Swagger-Controllers-Generated-StoreControllerBase-PlaceOrder-PetStore-API-Swagger-Controllers-Generated-Order-'></a>
### PlaceOrder(body) `method`

##### Summary

Place an order for a pet

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [PetStore.API.Swagger.Controllers.Generated.Order](#T-PetStore-API-Swagger-Controllers-Generated-Order 'PetStore.API.Swagger.Controllers.Generated.Order') | order placed for purchasing the pet |

<a name='T-PetStore-API-Swagger-Controllers-Generated-User'></a>
## User `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='P-PetStore-API-Swagger-Controllers-Generated-User-UserStatus'></a>
### UserStatus `property`

##### Summary

User Status

<a name='T-PetStore-API-Swagger-Controllers-Generated-UserControllerBase'></a>
## UserControllerBase `type`

##### Namespace

PetStore.API.Swagger.Controllers.Generated

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUser-PetStore-API-Swagger-Controllers-Generated-User-'></a>
### CreateUser(body) `method`

##### Summary

Create user

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [PetStore.API.Swagger.Controllers.Generated.User](#T-PetStore-API-Swagger-Controllers-Generated-User 'PetStore.API.Swagger.Controllers.Generated.User') | Created user object |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUsersWithArrayInput-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-User}-'></a>
### CreateUsersWithArrayInput(body) `method`

##### Summary

Creates list of users with given input array

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User}') | List of user object |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-CreateUsersWithListInput-System-Collections-Generic-IEnumerable{PetStore-API-Swagger-Controllers-Generated-User}-'></a>
### CreateUsersWithListInput(body) `method`

##### Summary

Creates list of users with given input array

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| body | [System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Collections.Generic.IEnumerable 'System.Collections.Generic.IEnumerable{PetStore.API.Swagger.Controllers.Generated.User}') | List of user object |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-DeleteUser-System-String-'></a>
### DeleteUser(username) `method`

##### Summary

Delete user

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name that needs to be deleted |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-GetUserByName-System-String-'></a>
### GetUserByName(username) `method`

##### Summary

Get user by user name

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name that needs to be fetched. Use user1 for testing. |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-LoginUser-System-String,System-String-'></a>
### LoginUser(username,password) `method`

##### Summary

Logs user into the system

##### Returns

successful operation

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The user name for login |
| password | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The password for login in clear text |

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-LogoutUser'></a>
### LogoutUser() `method`

##### Summary

Logs out current logged in user session

##### Returns

successful operation

##### Parameters

This method has no parameters.

<a name='M-PetStore-API-Swagger-Controllers-Generated-UserControllerBase-UpdateUser-System-String,PetStore-API-Swagger-Controllers-Generated-User-'></a>
### UpdateUser(username,body) `method`

##### Summary

Updated user

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| username | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | name that need to be updated |
| body | [PetStore.API.Swagger.Controllers.Generated.User](#T-PetStore-API-Swagger-Controllers-Generated-User 'PetStore.API.Swagger.Controllers.Generated.User') | Updated user object |
